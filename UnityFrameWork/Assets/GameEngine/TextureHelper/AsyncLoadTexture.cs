using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AsyncLoadTexture : MonoSingleton<AsyncLoadTexture>
{
    public override void OnInitialized()
    {
        base.OnInitialized();
        Initialized();
    }

    private void Initialized()
    {
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }
        mCurretTextures = new List<Texture2D>();
        AllTexturesIndex = new Dictionary<int, int>();
        TextureCount = 0;
    }

    public void SetAsyncTexture(string url, UITexture uITexture)
    {
        int code = url.GetHashCode();
        if (AllTexturesIndex.ContainsKey(code))
        {
            uITexture.mainTexture = mCurretTextures[AllTexturesIndex[code]];
        }
        else
        {
            if (mCurretTextures.Count >= 54) { return; }
            StartCoroutine(AsyncLoadNetTexture(url, uITexture, code));
        }
    }

    private IEnumerator AsyncLoadNetTexture(string url, UITexture uITexture, int code)
    {
        mTempUrl = new WWW(url);
        yield return mTempUrl;
        mTempTexture = mTempUrl.texture;
        uITexture.mainTexture = mTempTexture;
        AllTexturesIndex[code] = AsyncLoadTexture.Instance.TextureCount;
        mCurretTextures.Add(mTempTexture);
        AsyncLoadTexture.Instance.TextureCount++;
        mTempUrl.Dispose();
    }

    private IEnumerator AsyncLoadCacheTexture(string url, UITexture texture)
    {
        mTempUrl = new WWW("file:///" + url + url.GetHashCode());
        yield return mTempUrl;
        texture.mainTexture = mTempUrl.texture;
        mTempUrl.Dispose();
    }

    private WWW mTempUrl;
    private Texture2D mTempTexture;
    private List<Texture2D> mCurretTextures;
    private Dictionary<int, int> AllTexturesIndex;
    public int TextureCount = 0;
    public string Path { get { return Application.persistentDataPath + "/TextureCache"; } }
}