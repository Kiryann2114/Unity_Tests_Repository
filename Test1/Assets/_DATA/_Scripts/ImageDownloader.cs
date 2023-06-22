using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ImageDownloader : MonoBehaviour
{
    public string Url;
    private Image img;
    void Start()
    {
        if (Url == "")
        {
            Url = DataHolder.URL;
            StartCoroutine(LoadImage());
        }
        img = GetComponent<Image>();
    }

    void OnBecameVisible()
    {
        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(Url);

        yield return webRequest.SendWebRequest();

        if (!webRequest.isDone)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            img.sprite = Sprite.Create((Texture2D)texture, new Rect(0,0,texture.width,texture.height), Vector2.zero);
        }
    }
}
