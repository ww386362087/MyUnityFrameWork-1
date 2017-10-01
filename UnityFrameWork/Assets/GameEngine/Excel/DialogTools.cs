using Excel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
public class DialogTools : MonoSingleton<DialogTools>
{
    private Dictionary<int, DialogItem> DialogItems;
    public override void OnInitialized()
    {
        base.OnInitialized();
        ReadExcelData();
    }
    private void ReadExcelData()
    {
        FileStream stream = File.Open(Application.dataPath + "/GameEngine/Excel/Dialog.xlsx", FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();

        DialogItems = new Dictionary<int, DialogItem>();
        DialogItem item = null;
        for (int i = 1; i < result.Tables[0].Rows.Count; i++)
        {
            item = new DialogItem(result.Tables[0].Rows[i][0], result.Tables[0].Rows[i][1], result.Tables[0].Rows[i][2]);
            DialogItems.Add(result.Tables[0].Rows[i][0].Convert2Int32(), item);
        }
    }
    public DialogItem GetDialogItem(int DialogID)
    {
        return DialogItems.TryGetValue(DialogID);
    }
    public override void OnDestory()
    {
        base.OnDestory();
        DialogItems.Clear();
    }
}
