﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Face
{
	Normal=0,
	Anger=1,
	Happy=2
}

public enum Pose
{
	Normal=0
}

public enum Stat
{
	Love = 0, 
	Hunger = 1, 
	Life = 2
}
		




public class UI_control : MonoBehaviour {

	public Slider [] bar = new Slider[3];
	public Text [] buttontexts = new Text[3];
	public Text charactertext;
	private float[] value = new float[3];

	/*
	 * SetTalk(텍스트): 질문, 일반 말
	 * SetAnswer(버튼번호, 텍스트): 답(버튼)
	 * ButtonEvent(버튼번호) : 버튼 이벤트;
	 */
	//bar0: love bar1: hunger bar2: life

	Zombie Zombiescript;

	void Start()
	{
		Zombiescript = GameObject.Find ("zombie").GetComponent<Zombie> ();

	}



	void LateUpdate()
	{

		value[0]=Zombiescript._love;
		value[1]=Zombiescript._hungry;
		value[2]=Zombiescript._life;
		TransParameter ();

	}
		
	void TransParameter()
	{

		for (int i = 0; i < 3; i++) {

			if(bar [i].value!=value[i])
			{
				float temp = 50f * Time.deltaTime;
				if (value [i] - bar [i].value > 0 && value [i] - bar [i].value > temp)
					bar [i].value += temp;
				else if (value [i] - bar [i].value < 0 && bar [i].value - value [i] > temp)
					bar [i].value -= temp;
				else
					bar [i].value = value [i];
			}

		}

	}


	public void SetTalk(string texting)
	{

		charactertext.text = texting;


	}	

	public void SetAnswer(string texting){
		for (int i = 0; i < 3; i++) {
			buttontexts [i].text = texting; 
		}
	}


	public void ButtonEvent(int num)
	{







	}





}