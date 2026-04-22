Shader "Custom/ColorEffect"
{
    Properties
    {
        // Unity uses _BlitTexture for the screen color in Full Screen Passes
        [HideInInspector] _BlitTexture("Screen Texture", 2D) = "white" {}
        _SourcePos ("Source Position", Vector) = (0,0,0,0)
        _Radius ("Radius", Float) = 5.0
        _Softness ("Softness", Float) = 2.0

        [Header(Outline Settings)]
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Float) = 0.2
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _NoiseSpeed ("Noise Speed", Float) = 1.0
        _NoiseStrength ("Noise Strength", Float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline"}
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"

            struct Attributes { uint vertexID : SV_VertexID; };
            struct Varyings { float4 positionCS : SV_POSITION; float2 uv : TEXCOORD0; };

            float3 _SourcePos;
            float _Radius;
            float _Softness;
            float4 _OutlineColor;
            float _OutlineWidth, _NoiseSpeed, _NoiseStrength;

            TEXTURE2D_X(_BlitTexture);
            SAMPLER(sampler_BlitTexture);
            TEXTURE2D(_NoiseTex);
            SAMPLER(sampler_NoiseTex);

            Varyings vert(Attributes input) {
                Varyings output;
                // Built-in URP function to generate a full-screen quad
                output.positionCS = GetFullScreenTriangleVertexPosition(input.vertexID);
                output.uv = GetFullScreenTriangleTexCoord(input.vertexID);
                return output;
            }

            float4 frag(Varyings input) : SV_Target {
                float3 col = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_BlitTexture, input.uv).rgb;

                // 1. Reconstruct World Position
                float depth = SampleSceneDepth(input.uv);
                float3 worldPos = ComputeWorldSpacePosition(input.uv, depth, UNITY_MATRIX_I_VP);

                // 2. Sampling Noise
                // We use world-space or UVs for noise. World-space makes it "stick" to the ground.
                float2 noiseUV = worldPos.xz * 0.1 + _Time.y * _NoiseSpeed;
                float noise = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, noiseUV).r * 2.0 - 1.0;
                
                // 3. Distance Mask with Noise Distortion
                float dist = distance(worldPos, _SourcePos);
                float distortedDist = dist + (noise * _NoiseStrength);

                // Handle Skybox
                if (depth <= 0.00001) dist = 1000.0; 

                // 4. Color Transition Mask
                float mask = smoothstep(_Radius, _Radius + _Softness, distortedDist);
                float gray = dot(col, float3(0.2126, 0.7152, 0.0722));
                float3 finalCol = lerp(col, float3(gray, gray, gray), mask);

                // 5. Outline Logic
                // The transition runs from _Radius to _Radius+_Softness, midpoint is at +_Softness*0.5
                float2 outlineNoiseUV = worldPos.xz * 0.15 + _Time.y * _NoiseSpeed * 0.7 + float2(3.7, 1.3);
                float outlineNoise = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, outlineNoiseUV).r * 2.0 - 1.0;
                // Apply outline noise directly to the distance used for the edge test
                // This makes the outline itself warp and move independently
                float outlineDist = dist + (outlineNoise * _NoiseStrength * 1.5);
                float transitionMid = _Radius + _Softness * 0.5;
                float edge = abs(distortedDist - transitionMid);
                // Noise widens/narrows the outline width dynamically
                float noisyWidth = _OutlineWidth * (1.0 + outlineNoise * 0.6);
                float outlineMask = 1.0 - smoothstep(0.0, max(noisyWidth, 0.001), edge);
                // Dim the outline with noise so it flickers and feels organic
                float brightness = saturate(0.4 + outlineNoise * 0.3);
                
                // Prevent outline from showing on the skybox if not desired
                if (depth <= 0.00001) outlineMask = 0;

                finalCol = lerp(finalCol, _OutlineColor.rgb * brightness, outlineMask * _OutlineColor.a);

                return float4(finalCol, 1.0);
            }
            ENDHLSL
        }
    }
}