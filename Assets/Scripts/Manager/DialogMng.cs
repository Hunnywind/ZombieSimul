using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DialogMng : Singleton<DialogMng> {
    [SerializeField]
    private UI_control _uiControl;
    [SerializeField]
    private Zombie _zombie;

    private Dictionary<int, Dictionary<string, string>> _qData = new Dictionary<int, Dictionary<string, string>>();
    private Dictionary<int, Dictionary<string, string>> _aData = new Dictionary<int, Dictionary<string, string>>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        _qData = GameData.GetInstance.GetData("Question");
        _aData = GameData.GetInstance.GetData("Answer");
        ShowDialog();
    }
    public void ShowDialog()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var ranValue = Random.Range(0, _qData.Count);
        while (true)
        {
            ranValue = Random.Range(0, _qData.Count);
            var d = int.Parse(_qData[ranValue]["L_Condition"]);
            if (_zombie._love >= d)
            {
                _uiControl.SetTalk(_qData[ranValue]["Question"]);
                break;
            }
        }
        int buttonNum = 0;
        for (int i = 0; i < _aData.Count; i++)
        {
            if (_aData[i]["Qid"].Equals(ranValue.ToString()))
            {
                _uiControl.SetAnswer(buttonNum, _aData[i]["Answer"]);
                buttonNum++;
            }
        }
        sw.Stop();
        UnityEngine.Debug.Log(sw.ElapsedMilliseconds.ToString() + "ms");
    }

}