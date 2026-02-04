using Unity.Cinemachine;
using UnityEngine;

public class LevelCamera : LevelSingleton<LevelCamera>
{
    [SerializeField] private CinemachineCamera cinemachineVirtualCamera;

    public void SetPlayerCameraFollow()
    {
        cinemachineVirtualCamera.Follow = CharacterMovement.Instance.transform;
    }

}
