using System.Collections;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    [SerializeField] private float fadeTime = .4f;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator SlowFadeRoutine() {
        float elapsedTime = 0;    
        float startValue = spriteRenderer.color.a;

        while (elapsedTime < fadeTime) {
            elapsedTime += Time.deltaTime;
            float newAplha = Mathf.Lerp(startValue, 0f, elapsedTime/ fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b, newAplha);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
