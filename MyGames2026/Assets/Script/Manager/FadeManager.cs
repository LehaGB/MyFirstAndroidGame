using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;


    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 0.5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        fadeCanvasGroup.alpha = 1;
        float t = 0;

        while(t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = 1 - (t / fadeDuration);
            yield return null;
        }
        fadeCanvasGroup.alpha = 0;
        
    }
    public IEnumerator FadeOut()
    {
        fadeCanvasGroup.alpha = 0;
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = t / fadeDuration;
            yield return null;
        }
        fadeCanvasGroup.alpha = 1;
        
    }
}
