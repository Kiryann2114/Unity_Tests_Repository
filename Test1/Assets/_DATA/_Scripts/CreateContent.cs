using UnityEngine;
using UnityEngine.UI;

public class CreateContent : MonoBehaviour
{
    public GameObject content;
    void Start()
    {
        for (int i = 1; i <= 66; i++)
        {
            Instantiate(content, GetComponent<Transform>()).GetComponent<ImageDownloader>().Url = "http://data.ikppbb.com/test-task-unity-data/pics/" + i + ".jpg";
        }
    }
}
