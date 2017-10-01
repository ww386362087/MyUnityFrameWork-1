using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogItem
{
    public int ID { get; set; }
    public int Type { get; set; }
    public string Info { get; set; }
    public DialogItem() { }
    public DialogItem(object ID, object Type, object Info)
    {
        this.ID = ID.Convert2Int32();
        this.Type = Type.Convert2Int32();
        this.Info = Info.ToString();
    }
}
