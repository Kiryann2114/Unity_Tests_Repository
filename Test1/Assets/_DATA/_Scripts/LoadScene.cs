using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image LoadBar;
    public Text TxtBar;

    void Start()
    {
        StartCoroutine(LoadSceneCor());
    }

    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(DataHolder.ID_Scene);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            LoadBar.fillAmount = progress;
            TxtBar.text = "«¿√–”« ¿ " + string.Format("{0:0}%", progress * 100f);
            yield return 0;
        }
    }
}
