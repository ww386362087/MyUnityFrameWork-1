using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMgr : MonoSingleton<ModelMgr>
{
    private Dictionary<string, BaseModel> models = null;

    public override void OnInitialized()
    {
        base.OnInitialized();
        models = new Dictionary<string, BaseModel>();
    }

    public T GetModel<T>() where T : BaseModel
    {
        string name = typeof(T).Name;
        if (!models.ContainsKey(name))
        {
            models.Add(name, new BaseModel());
        }
        return models[name] as T;
    }
}