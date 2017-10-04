using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.GameEngine
{
    public delegate void ObjectParamDelegate(object obj);
    public class BaseEvent
    {
        public void OnInitialiaze()
        {
            delegates = new Dictionary<string, ObjectParamDelegate>();
        }
        public void OnDestory()
        {
            delegates.Clear();
            delegates = null;
        }
        public void AddEvent(string key, ObjectParamDelegate method)
        {
            if (!delegates.ContainsKey(key))
            {
                delegates.Add(key, method);
            }
            else
            {
                delegates[key] += method;
            }
        }
        public void RemoveEvent(string key)
        {
            if (delegates.ContainsKey(key))
            {
                delegates.Remove(key);
            }
        }
        public void DispatchEvent(string key, object obj = null)
        {
            if (delegates.ContainsKey(key))
            {
                delegates[key](obj);
            }
        }
        public Dictionary<string, ObjectParamDelegate> delegates;
    }

}