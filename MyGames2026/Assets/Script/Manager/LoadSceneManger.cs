using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManger : MonoBehaviour
{
    public static LoadSceneManger Instance;
    public string sceneToLoad;


    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SceneToLoad()
    {
        StartCoroutine(LoadSceneWithFade(sceneToLoad));
    }

    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        yield return FadeManager.Instance.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
