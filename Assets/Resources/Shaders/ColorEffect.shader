Shader "Custom/ColorEffect"
{
    Properties
    {
        // Unity uses _BlitTexture for the screen color in Full Screen Passes
        [HideInInspector] _BlitTexture("Screen Texture", 2D) = "white" {}
        _SourcePos ("Source Position", Vector) = (0,0,0,0)
        _Radius ("Radius", Float) = 5.0
        _Softness ("Softness", Float) = 2.0
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

            TEXTURE2D_X(_BlitTexture);
            SAMPLER(sampler_BlitTexture);

            Varyings vert(Attributes input) {
                Varyings output;
                // Built-in URP function to generate a full-screen quad
                output.positionCS = GetFullScreenTriangleVertexPosition(input.vertexID);
                output.uv = GetFullScreenTriangleTexCoord(input.vertexID);
                return output;
            }

            float4 frag(Varyings input) : SV_Target {
                // 1. Get the original color
                float3 col = SAMPLE_TEXTURE2D(_BlitTexture, sampler_BlitTexture, input.uv).rgb;

                // 2. Reconstruct World Position from Depth
                float depth = SampleSceneDepth(input.uv);
                float3 worldPos = ComputeWorldSpacePosition(input.uv, depth, UNITY_MATRIX_I_VP);

                // 3. Grayscale Logic
                float gray = dot(col, float3(0.2126, 0.7152, 0.0722));
                float3 grayscaleCol = float3(gray, gray, gray);

                // 4. Distance Mask (comparing pixel world pos to player world pos)
                float dist = distance(worldPos, _SourcePos);
                
                // If depth is at the skybox (infinity), we usually want it grayscale too
                if (depth <= 0.00001) dist = 1000.0; 

                float mask = smoothstep(_Radius, _Radius + _Softness, dist);

                // mask = 0 (near player) -> original color
                // mask = 1 (far away) -> grayscale
                return float4(lerp(col, grayscaleCol, mask), 1.0);
            }
            ENDHLSL
        }
    }
}