using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {
	public int _love{ get; private set;}
	public int _hungry{ get; private set;}
	public int _life{ get; private set;}

	public Sprite [] head = new Sprite[15]; //머리 파츠
	public Sprite [] body = new Sprite[5]; //바디 파츠
	public Image headOn; //현재 머리
	public Image bodyOn; //현재 바디


	public enum Stat
	{
		Love = 0, 
		Hunger = 1, 
		Life = 2
	}

	public enum Face
	{
		Normal=0,
		Happy=1,
		Sadness=2,
		Anger=3,
		Surprise=4
	}

	public enum Pose
	{
		Normal=0
	}

	public void Awake()
	{
		
			_love = DataloadMng.GetInstance.LoveStat;
			_hungry = DataloadMng.GetInstance.HungerStat;
			_life = DataloadMng.GetInstance.LifeStat;
	
	}


	public void TransParameter(Stat bartype, int stat)	//스탯 변화
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

	public void SetParameter(Stat bartype, int stat) 	//스탯 고정
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








	void Statchanges() //스탯 변동시 실행
	{

		DataloadMng.GetInstance.SaveData ();


	}


	public void CalculatingEnding ()
	{

		int endingnumber;
		int temp = _love - _hungry;

		if (temp > 0) {
			if (temp > 33) 
			{
				if (temp > 67) 
					endingnumber = 5;
				else
					endingnumber = 4;
			}
			else
				endingnumber = 3;	


		}
		else 
		{

			if (temp < -33) 
			{
				if (temp < -66) 
					endingnumber = 8;
				else
					endingnumber = 7;
			}
			else
				endingnumber = 6;	
			

		}


		GameMng.GetInstance.Ending(endingnumber);



	}


	public void TransCharacter(Face face) //바디 이미지 체인.
	{

		int temp=(int)face;
		int temp2;
		if (_love > 50 && _hungry > 50) {

			if (_love > _hungry)
				temp2 = 1;
			else
				temp2 = 0;

		} else
			temp2 = 2;

		bodyOn.sprite = body [temp];
		headOn.sprite = head [5*temp2+temp];


	}
}
