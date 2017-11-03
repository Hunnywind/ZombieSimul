using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
	
	public int _love{ get; private set;}
	public int _hungry{ get; private set;}
	public int _life{ get; private set;}

	public enum Stat
	{
		Love = 0, 
		Hunger = 1, 
		Life = 2
	}

	public void Awake()
	{
		
			_love = DataloadMng.GetInstance.LoveStat;
			_hungry = DataloadMng.GetInstance.HungerStat;
			_life = DataloadMng.GetInstance.LifeStat;
	
	}



	public void TransParameter(Stat bartype, int stat)
	{


		switch ((int)bartype) {
		case 0:
			_love += stat;
			if (_love > 100)
				_love = 100;
			if (_love < 0)
				_love = 0;
				break;

		case 1:
			_hungry += stat;
			if (_hungry > 100)
				_hungry = 100;
			if (_hungry < 0)
				_hungry = 0;
			break;

		case 2:
			_life += stat;
			if (_life > 100)
				_life = 100;
			if (_life < 100)
				_life = 100;
			break;
		}




		Statchanges ();
	
	
	
	}

	public void SetParameter(Stat bartype, int stat)
	{
	
		switch ((int)bartype) {
		case 0:
			_love = stat;
			break;

		case 1:
			_hungry = stat;
			break;

		case 2:
			_life = stat;
			break;
		}

		Statchanges ();
	
	}


	void Statchanges()
	{

		DataloadMng.GetInstance.SaveData ();


	}




}
