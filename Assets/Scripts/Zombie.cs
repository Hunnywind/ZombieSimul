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

	public FadeControl fadecontrol;

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


	public void Awake()
	{
		
			_love = DataloadMng.GetInstance.LoveStat;
			_hungry = DataloadMng.GetInstance.HungerStat;
			_life = DataloadMng.GetInstance.LifeStat;
	
	}




	int[] Deltaparameter = new int[3];
	int[] Deltaparaabs = new int[3];

	public void TransParameter(Stat bartype, int stat)	//스탯 변화
	{


		switch ((int)bartype) {
		case 0:
			_love += stat;
			Deltaparameter [0] = stat;
			Deltaparaabs [0] = Mathf.Abs (stat);
			if (_love > 100)
				_love = 100;
			if (_love < 0)
				_love = 0;
				break;

		case 1:
			_hungry += stat;
			Deltaparameter[1] = stat;
			Deltaparaabs [1] = Mathf.Abs (stat);
			if (_hungry > 100)
				_hungry = 100;
			if (_hungry < 0)
				_hungry = 0;
			break;

		case 2:
			_life += stat;
			Deltaparameter[2] = stat;
			Deltaparaabs [2] = Mathf.Abs (stat);
			if (_life > 100)
				_life = 100;
			if (_life < 100)
				_life = 100;
			break;
		}

		if (_life <= 0)
			fadecontrol.fadeout (0);
		else if (_hungry <= 0)
			fadecontrol.fadeout (1);
	StartCoroutine ("TransCharacterSupporter");
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
        var endingValue = GameData.GetInstance.GetData("NormalEndings");

		int endingnumber;
		int temp = _love - _hungry;

		if (temp > 0) {
			if (temp > int.Parse(endingValue[0]["value"])) 
			{
				if (temp > int.Parse(endingValue[1]["value"])) 
					endingnumber = 4;
				else
					endingnumber = 3;
			}
			else
				endingnumber = 2;	


		}
		else 
		{

			if (temp < int.Parse(endingValue[3]["value"])) 
			{
				if (temp < int.Parse(endingValue[4]["value"])) 
					endingnumber = 7;
				else
					endingnumber = 6;
			}
			else
				endingnumber = 5;	
			

		}


		fadecontrol.fadeout(endingnumber);



	}


	Face Tempface;
	public void TransCharacter(Face face) //바디 이미지 체인.
	{
		Tempface = face;
	}


	IEnumerator TransCharacterSupporter()
	{

		int facetype;
		if (Deltaparaabs [0] > Deltaparaabs [1] && Deltaparaabs [0] > (Deltaparaabs [2]*10)) {

			if(Deltaparameter[0]>0)
				facetype = 4;
			else
				facetype = 2;


		} else if (Deltaparaabs [1] > (Deltaparaabs [2]*10)) {
			if(Deltaparameter[1]>0)
				facetype = 3;
			else
				facetype = 1;

		
		} else {
			if (Deltaparameter [2] < 0)
				facetype = 3;	
			else
				facetype = 0;	

		}

		int temp=facetype;
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

		yield return new WaitForSeconds(1f);


		temp=(int)Tempface;

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
