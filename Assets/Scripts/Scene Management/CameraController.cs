using UnityEngine;
using Unity.Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineCamera cinemachineVitrualCamera;

    void Start()
    {
        SetPlayerCameraFollow();
    }

    public void SetPlayerCameraFollow() {
        cinemachineVitrualCamera = FindAnyObjectByType<CinemachineCamera>();
        cinemachineVitrualCamera.Follow = PlayerController.Instance.transform;
    }
}
