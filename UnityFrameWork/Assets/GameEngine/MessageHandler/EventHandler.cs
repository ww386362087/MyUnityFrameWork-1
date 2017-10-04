using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameEngine;
public class EventHandler : MonoSingleton<EventHandler>
{
    public override void OnInitialized()
    {
        base.OnInitialized();
        GameEvent = new BaseEvent();
        GameEvent.OnInitialiaze();
    }
    public BaseEvent GameEvent { get; set; }
}
