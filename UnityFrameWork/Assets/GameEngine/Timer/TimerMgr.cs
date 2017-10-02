using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class TimerMgr : MonoSingleton<TimerMgr>
{
    private Dictionary<int, Timer> timers;
    private List<int> removeList;
    private int timerId = 0;
    public override void OnInitialized()
    {
        base.OnInitialized();
        timers = new Dictionary<int, Timer>();
        removeList = new List<int>();
    }
    public Timer Sucribe(float duringTime, TimerCallBack onStartCallBack = null)
    {
        timerId++;
        Timer t = new Timer(Instance, timerId, duringTime, onStartCallBack);
        timers.Add(timerId, t);
        return timers[timerId];
    }
    public void Update()
    {
        if (!timers.IsNullOrEmpty())
        {
            foreach (var item in timers.Values)
            {
                item.OnUpdate();
            }
        }
    }
    public void LateUpdate()
    {
        if (removeList.IsNonNullOrEmpty())
        {
            for (int i = 0; i < removeList.Count; i++)
            {
                timers[removeList[i]] = null;
                timers.Remove(removeList[i]);
            }
            removeList.Clear();
        }
    }
    public void DestoryObject(int id)
    {
        removeList.Add(id);
    }
    public override void OnDestory()
    {
        base.OnDestory();
        timers = null;
        removeList = null;
        timerId = 0;
    }
    public class Timer
    {
        private float duringTime = 0f;
        private TimerCallBack onStartCallBack;
        private Action<Timer> onUpdateCallBack;
        private TimerCallBack onCompleteCallBack;
        private float tempTime = 0;
        /// <summary>
        /// 倒计时
        /// </summary>
        public int EscapleTime { get { return (int)tempTime; } }
        /// <summary>
        /// 顺计时
        /// </summary>
        public int EntranceTime { get { return (int)(duringTime - tempTime); } }
        private bool autoToKill = true;
        private TimerMgr handler;
        private int timerId;
        private bool IsPause = false;
        public Timer() { }
        public Timer(TimerMgr handler, int timerId, float duringTime, TimerCallBack onStartCallBack = null)
        {
            this.handler = handler;
            this.timerId = timerId;
            this.duringTime = duringTime;
            this.onStartCallBack = onStartCallBack;
            if (this.onStartCallBack.IsNonNull()) { this.onStartCallBack(); }
        }
        public Timer OnUpdate(Action<Timer> updataCallBack = null)
        {
            if (!IsPause)
            {
                if (onUpdateCallBack == null)
                {
                    onUpdateCallBack = updataCallBack;
                }
                if (tempTime >= duringTime)
                {
                    if (onCompleteCallBack.IsNonNull()) { onCompleteCallBack(); }
                    if (!autoToKill)
                    {
                        tempTime = 0;
                    }
                    DestoryObject();
                }
                else
                {
                    if (onUpdateCallBack.IsNonNull()) { onUpdateCallBack(this); }
                    tempTime += Time.deltaTime;
                }
            }
            return this;
        }
        public void Pause()
        {
            IsPause = true;
        }
        public Timer SetAutoToKill(bool autoToKill)
        {
            this.autoToKill = autoToKill;
            return this;
        }
        public void DestoryObject()
        {
            handler.DestoryObject(timerId);
        }
        public void OnComplete(TimerCallBack onCompleteCallBack)
        {
            this.onCompleteCallBack = onCompleteCallBack;
        }
    }
    public delegate void TimerCallBack();
}
