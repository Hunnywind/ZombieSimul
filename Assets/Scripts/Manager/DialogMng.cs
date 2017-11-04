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
    private List<int> _usedQuestion = new List<int>();

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
        _usedQuestion.Clear();
    }
    public void ShowDialog()
    {
        var ranValue = Random.Range(0, _qData.Count);
        bool checkDupli = true;
        while (checkDupli)
        {
            checkDupli = false;
            foreach (var item in _usedQuestion)
            {
                if (ranValue == item)
                {
                    checkDupli = true;
                }
            }
            ranValue = Random.Range(0, _qData.Count);
        }
        
        _uiControl.SetTalk(_qData[ranValue]["Question"]);
        _usedQuestion.Add(ranValue);
        switch (_qData[ranValue]["Face"])
        {
            case "0":
                _zombie.TransCharacter(Zombie.Face.Normal);
                break;
            case "1":
                _zombie.TransCharacter(Zombie.Face.Happy);
                break;
            case "2":
                _zombie.TransCharacter(Zombie.Face.Sadness);
                break;
            case "3":
                _zombie.TransCharacter(Zombie.Face.Anger);
                break;
            case "4":
                _zombie.TransCharacter(Zombie.Face.Surprise);
                break;
            default:
                break;
        }

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