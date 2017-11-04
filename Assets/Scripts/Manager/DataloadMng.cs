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
	
		LoveStat = 50;
		HungerStat = 50;
		LifeStat = 7;
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


	public void ResetData()
	{
		PlayerPrefs.SetInt ("LoveStat", 50);
		PlayerPrefs.SetInt ("HungerStat", 50);
		PlayerPrefs.SetInt ("LifeStat", 10);
		PlayerPrefs.SetInt ("TextLine", 0);
	}





}
