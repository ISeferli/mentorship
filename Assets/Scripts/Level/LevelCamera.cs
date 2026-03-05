using Unity.Cinemachine;
using UnityEngine;

public class LevelCamera : LevelSingleton<LevelCamera>
{
    [SerializeField] private CinemachineCamera cinemachineVirtualCamera;

    /// <summary>
    /// Set the camera to follow the character
    /// </summary>
    public void SetPlayerCameraFollow()
    {
        cinemachineVirtualCamera.Follow = CharacterMovement.Instance.transform;
    }
}
