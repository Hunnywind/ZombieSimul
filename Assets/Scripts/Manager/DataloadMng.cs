using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataloadMng : Singleton<DataloadMng> {


	public int LoveStat;
	public int HungerStat;
	public int LifeStat;
	public int TextLine;


	// Use this for initialization
	void Awake () {
	
		LoveStat = PlayerPrefs.GetInt ("LoveStat", 0);
		HungerStat = PlayerPrefs.GetInt ("HungerStat", 0);
		LifeStat = PlayerPrefs.GetInt ("LifeStat", 0);
		TextLine = PlayerPrefs.GetInt ("TextLine", 0);

		DontDestroyOnLoad (gameObject);
		
	}
	

}
