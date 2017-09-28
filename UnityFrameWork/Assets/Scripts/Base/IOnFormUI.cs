using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnFormUI : IOnInitUI
{
    void OnRefresh();
    void OnExit();
}
