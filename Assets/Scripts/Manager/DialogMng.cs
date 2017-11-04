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

    private int _questionId;
    private int[] _answerId = new int[3];

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
        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        var ranValue = Random.Range(0, _qData.Count);
        _uiControl.SetTalk(_qData[ranValue]["Question"]);
        

        int buttonNum = 0;
        for (int i = 0; i < _aData.Count; i++)
        {
            if (_aData[i]["Qid"].Equals(ranValue.ToString()))
            {
                _uiControl.SetAnswer(buttonNum, _aData[i]["Answer"]);
                _answerId[buttonNum] = i;
                buttonNum++;
            }
        }
        //sw.Stop();
        //UnityEngine.Debug.Log(sw.ElapsedMilliseconds.ToString() + "ms");
    }
    public void Response(int answerNum)
    {
        int love = int.Parse(_aData[_answerId[answerNum]]["Love"]);
        int hunger = int.Parse(_aData[_answerId[answerNum]]["Hunger"]);
        int life = int.Parse(_aData[_answerId[answerNum]]["Life"]);

        _zombie.TransParameter(Zombie.Stat.Love, love);
        _zombie.TransParameter(Zombie.Stat.Hunger, hunger);
        _zombie.TransParameter(Zombie.Stat.Life, life);
        TimeMng.GetInstance.LevelUp();
        ShowDialog();
    }
}