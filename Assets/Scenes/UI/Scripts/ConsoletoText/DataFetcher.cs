using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataFetcher : MonoBehaviour
{
    private const string url = "http://192.168.185.95:8080/speech";
    //�r�e�{�b�q��(unity Game view)��127.0.0.1�A�e�{�bhololens�W��192.168.0.141(�����) ��:���O0.174��?�ݸ�(���� ���ӬO��cmdserver�e���b���̶])��:.185.95�O�p��
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

            if (www.isNetworkError || www.isHttpError)//ishttpError�Q����ĵ�i���^�O
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
