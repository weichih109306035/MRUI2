using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataFetcher : MonoBehaviour
{
    private const string url = "http://192.168.0.141:8080/speech";
    //字呈現在電腦(unity Game view)用127.0.0.1，呈現在hololens上用192.168.0.141
    private WaitForSeconds fetchInterval = new WaitForSeconds(1f);

    private IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(FetchData());
            yield return fetchInterval;
        }
    }

    private IEnumerator FetchData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)//ishttpError被黃色警告說淘汰
            {
                Debug.LogError("XXXX~: " + www.error);
            }
            else
            {
                string data = www.downloadHandler.text;
                data = System.Text.RegularExpressions.Regex.Unescape(data);
                Debug.Log(data);
            }
        }
    }
}
