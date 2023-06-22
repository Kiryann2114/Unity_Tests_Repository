using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int LoadSceneID;
    public int SceneID;
    void Start()
    {
        if (gameObject.GetComponent<ImageDownloader>())
        {
            DataHolder.URL = GetComponent<ImageDownloader>().Url;
        }
        DataHolder.ID_Scene = SceneID;
        SceneManager.LoadSceneAsync(LoadSceneID);
    }
}
