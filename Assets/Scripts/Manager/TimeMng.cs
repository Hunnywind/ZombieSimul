using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMng : Singleton<TimeMng> {
    public int _day { get; private set; }
    public int _time { get; private set; }
    public int _level { get; private set; }



    [SerializeField]
    private Text _dayText;
    [SerializeField]
    private Text _timeText;

public Zombie _zombie;

    void Start()
    {
        Init();
    }
    void Init()
    {
        _day = 1;
        _time = 0;
        _level = 0;
        TextApply();
    }
    public void LevelUp()
    {
        _level++;
        if(_level > 2)
        {
            _time++;
            _level = 0;
            if(_time > 2)
            {
                _day++;
                _time = 0;
                if(_day > 3)
                {
					_day--;
					_zombie.CalculatingEnding ();
		
                    // go ending
                }
            }
        }
        TextApply();
    }
    void TextApply()
    {
        _dayText.text = "Day " + _day;
        switch (_time)
        {
            case 0:
                _timeText.text = "오전";
                break;
            case 1:
                _timeText.text = "오후";
                break;
            case 2:
                _timeText.text = "저녁";
                break;
            default:
                break;
        }
    }
}
