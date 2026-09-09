using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManger : MonoBehaviour
{
    public LoadSceneManger Instance { get; private set; }
    public string sceneToLoad;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
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
