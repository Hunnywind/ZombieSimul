using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMng : Singleton<DialogMng> {
    [SerializeField]
    private UI_control _uiControl;
    [SerializeField]
    private Zombie _zombie;

    void Init()
    {
    }
    public void ShowDialog()
    {
        var Qdata = GameData.GetInstance.GetData("Question");
        var Adata = GameData.GetInstance.GetData("Answer");
        var ranValue = Random.Range(0, Qdata.Count);
        while (true)
        {
            ranValue = Random.Range(0, Qdata.Count);
            var d = int.Parse(Qdata[ranValue]["L_Condition"]);
            if (_zombie._love >= d)
            {
                _uiControl.SetTalk(Qdata[ranValue]["Question"]);
                break;
            }
        }
        int buttonNum = 0;
        for (int i = 0; i < Adata.Count; i++)
        {
            if (Adata[i]["Qid"].Equals(ranValue.ToString()))
            {
                _uiControl.SetAnswer(buttonNum, Adata[i]["Answer"]);
                buttonNum++;
            }
        }
    }

}