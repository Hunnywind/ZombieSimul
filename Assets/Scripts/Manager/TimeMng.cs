﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMng : Singleton<TimeMng> {
    public int _day { get; private set; }
    public int _time { get; private set; }
    public int _level { get; private set; }



    [SerializeField]
    private Text _dayText;
    public GameObject [] time= new GameObject[3];




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
					GameMng.GetInstance._isPlaying = false;
					_time--;
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
        _dayText.text = "" + _day;
        switch (_time)
        {
		case 0:
			time [0].SetActive (true);
			time [1].SetActive (false);
			time [2].SetActive (false);
		break;
            case 1:
			time [1].SetActive (true);
			time [0].SetActive (false);
			time [2].SetActive (false);
		break;
            case 2:

			time [2].SetActive (true);
			time [1].SetActive (false);
			time [0].SetActive (false);
                break;
            default:
                break;
        }
    }
}
