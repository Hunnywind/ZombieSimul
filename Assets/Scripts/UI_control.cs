using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




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

	/*
	 * TransParameter(바타입, 수치): 수치 변환
	 * SetParameter(바타입, 수치): 수치 지정
	 * SetTalk(텍스트): 질문, 일반 말
	 * SetAnswer(버튼번호, 텍스트): 답(버튼)
	 */
	//bar0: love bar1: hunger bar2: life

	public void TransParameter(Stat bartype, int stat)
	{
		bar[(int)bartype].value +=stat;
		if (bar [(int)bartype].value < 0)
			bar [(int)bartype].value = 0;
	}

	public void SetParameter(Stat bartype, int stat)
	{
		bar[(int)bartype].value = stat;
	}

	public void SetTalk(string texting)
	{

		charactertext.text = texting;


	}	


	public void SetAnswer(int num, string texting){

		buttontexts [num].text = texting; 

	}


	public void ButtonEvent(int num)
	{



	}





}