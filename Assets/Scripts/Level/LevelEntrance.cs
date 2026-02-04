using UnityEngine;

public class LevelEntrance : MonoBehaviour
{
    void Awake()
    {
        LevelCamera.Instance.SetPlayerCameraFollow();
        CharacterMovement.Instance.GetCharacterInPosition(transform);
    }
}
