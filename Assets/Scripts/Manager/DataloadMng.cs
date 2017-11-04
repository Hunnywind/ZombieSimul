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
	
		LoveStat = PlayerPrefs.GetInt ("LoveStat", 50);
		HungerStat = PlayerPrefs.GetInt ("HungerStat", 50);
		LifeStat = PlayerPrefs.GetInt ("LifeStat", 10);
		TextLine = PlayerPrefs.GetInt ("TextLine", 0);
		DontDestroyOnLoad (gameObject);
		
	}


	public void SaveData()
	{
		PlayerPrefs.SetInt ("LoveStat", LoveStat);
		PlayerPrefs.SetInt ("HungerStat", HungerStat);
		PlayerPrefs.SetInt ("LifeStat", LifeStat);
		PlayerPrefs.SetInt ("TextLine", TextLine);
	}



}
