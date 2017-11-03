using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
	
	public int _love{ get; private set;}
	public int _hungry{ get; private set;}
	public int _life{ get; private set;}



	public Sprite [] head = new Sprite[3]; //머리 파츠
	public Sprite [] body = new Sprite[3]; //바디 파츠
	public SpriteRenderer headOn; //현재 머리
	public SpriteRenderer bodyOn; //현재 바디


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
	

		SetImage ();




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
		SetImage ();

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
		SetImage ();
	}


	void Statchanges() //스탯 변동시 실행
	{

		DataloadMng.GetInstance.SaveData ();


	}





	void SetImage () //바디 이미지 체인.
	{


	//	headOn.sprite = head [0];
	//	bodyOn.sprite = body [0];


	}





}
