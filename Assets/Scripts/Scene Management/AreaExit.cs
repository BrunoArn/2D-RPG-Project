using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;


    private float waitLoadTime = 1f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerController>()) {
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);

            UIFade.Instance.FadetoBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }

    private IEnumerator LoadSceneRoutine() {
        yield return new WaitForSeconds(waitLoadTime);
        SceneManager.LoadScene(sceneToLoad);
    }
    
}
