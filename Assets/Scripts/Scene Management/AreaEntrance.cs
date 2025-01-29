using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField] private string TransitionName;

    private void Start() {
        if (TransitionName == SceneManagement.Instance.SceneTransitionName) {
            PlayerController.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();

            UIFade.Instance.FadeToClear();
        }
    }
}
