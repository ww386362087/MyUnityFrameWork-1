using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameEngine;
using UnityEngine.Networking;
using System.Text;
using System.Net;
using System;
using System.IO;

public delegate void TestDelegate();

public class test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventHandler.Instance.GameEvent.AddEvent("t", test1);
            EventHandler.Instance.GameEvent.AddEvent("t", test2);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StopAllCoroutines();
            StartCoroutine(WebRequestPost("http://localhost:8080/"));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            getWeatherByCity("上海");
        }
    }

    private void test1(object obj)
    {
        Debug.Log("test1 test1 test1");
    }

    private void test2(object obj)
    {
        Debug.Log("test2 test2 test2");
    }

    private void postWeatherByCity(string city)
    {
        Dictionary<string, string> citys = new Dictionary<string, string>()
        {
            { "theCityName",city}
        };
        //StartCoroutine(Post("http://localhost:8080/", citys));
        StartCoroutine(WebRequestPost("http://localhost:8080/", citys));
    }

    private void getWeatherByCity(string city)
    {
        StartCoroutine(GET("http://localhost:8080/"));
    }

    public float mjingdu = 0f;
    private WWWForm form = null;

    private IEnumerator Post(string url, Dictionary<string, string> post = null)
    {
        form = new WWWForm();
        foreach (KeyValuePair<string, string> item in post)
        {
            form.AddField(item.Key, item.Value);
        }
        WWW www = new WWW(url, form);
        yield return www;
        mjingdu = www.progress;
        if (www.error != null)
        {
            Debug.Log("www.error->" + www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
        www.Dispose();
    }

    private IEnumerator GET(string url, Dictionary<string, string> dictionary = null)
    {
        string info = string.Empty;
        if (dictionary.IsNonNull())
        {
            info = "?";
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                info += item.Key + "=" + item.Value;
                info += "&";
            }
        }
        WWW www = new WWW(url + info);
        yield return www;
        mjingdu = www.progress;
        if (www.error.IsNonNull())
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
        www.Dispose();
    }

    private IEnumerator WebRequestPost(string url, Dictionary<string, string> dictionary = null)
    {
        byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes("test001=中文&test002=英文");
        HttpWebRequest request = new HttpWebRequest(new Uri(url));
        request.Method = "POST";
        request.ContentLength = bytes.Length;
        request.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
        }
        yield return request.GetResponse();
        WebResponse res = request.GetResponse();
        Stream responstream = res.GetResponseStream();
        StreamReader reader2 = new StreamReader(responstream, Encoding.GetEncoding("gb2312"));
        string str = reader2.ReadToEnd();
        reader2.Close();
        responstream.Close();
        res.Close();
        Debug.Log(str);
    }
}