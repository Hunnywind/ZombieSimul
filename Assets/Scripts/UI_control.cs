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
		Zombiescript = GameObject.Find ("Zombie").GetComponent<Zombie> ();
		value[0]=Zombiescript._love;
		value[1]=Zombiescript._hungry;
		value[2]=Zombiescript._life;
		SetParameter ();
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
				float temp;
				if(i<2)
				temp = 100f * Time.deltaTime;
				else
				temp = 10f * Time.deltaTime;



				if (value [i] - bar [i].value > 0 && value [i] - bar [i].value > temp)
					bar [i].value += temp;
				else if (value [i] - bar [i].value < 0 && bar [i].value - value [i] > temp)
					bar [i].value -= temp;
				else
					bar [i].value = value [i];
			}

		}

	}

	void SetParameter()
	{

		for (int i = 0; i < 3; i++) {

			if(bar [i].value!=value[i])

				bar [i].value =value[i];

		}

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
        DialogMng.GetInstance.Response(num);
	}


	public Animator [] buttons = new Animator[3];

	bool poping=false;
	bool pushing=false;
	public void Buttondown(int num)
	{
	
		if (poping == false&&pushing==false) {
			pushing = true;
			buttons [num].SetTrigger ("push");
		}
	}
	public void Buttonup(int num)
	{
		if (poping == false) {
			buttons [num].SetTrigger ("up");
			pushing = false;

		}
	}
	public void Buttonpoping(int num)
	{
		if (poping == false) {
			buttons [num].SetTrigger ("poping");
			poping = true;
			pushing = false;
			ButtonEvent(num);
		}
	}



	void update()
	{



	}



}