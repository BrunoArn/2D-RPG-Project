using System.Collections;
using UnityEngine;

public class GrapeProjectile : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 3f;
    [SerializeField] private GameObject grapeProjectileShadow;

    private void Start()
    {
        GameObject grapeShadow = Instantiate(grapeProjectileShadow, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);

        Vector3 playerPos = PlayerController.Instance.transform.position;
        Vector3 grapeShadowStartPosition = grapeShadow.transform.position;

        StartCoroutine(ProjectileCurveRoutine(transform.position, playerPos));
        StartCoroutine(MoveGrapeShadowRoutine(grapeShadow, grapeShadowStartPosition, playerPos));
    }

    private IEnumerator ProjectileCurveRoutine(Vector3 startPosition, Vector3 endPosition) {
        float timePassed = 0f;

        while (timePassed < duration) 
        {
            timePassed += Time.deltaTime;
            float LinearT = timePassed / duration;
            float heightT = animCurve.Evaluate(LinearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPosition, endPosition, LinearT) + new Vector2(0f, height);

            yield return null;
        }

        Destroy(gameObject);
    }

    private IEnumerator MoveGrapeShadowRoutine(GameObject grapeShadow, Vector3 startPosition, Vector3 endPosition) {
        float timePassed = 0f;

        while(timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float LinearT = timePassed / duration;
            // to scale the shadow with the curve.... the /2.0f is to get a more nice visualy shadow
            float heightT = animCurve.Evaluate(LinearT)/2.0f;

            grapeShadow.transform.position = Vector2.Lerp(startPosition, endPosition, LinearT);
            //scaling the shadow, the -1 makes its inverse
            grapeShadow.transform.localScale = new Vector3(1 - heightT, 1 - heightT, 1);
            yield return null;
        }
        Destroy(grapeShadow);
    }
}
