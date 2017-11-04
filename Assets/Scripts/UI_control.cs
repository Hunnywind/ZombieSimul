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
	public Transform buttonset;
	Vector3 buttonsetoriginpos;

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
		buttonsetoriginpos = buttonset.position;
		buttonset.position = new Vector3 (0, -10, 0);
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

		StartCoroutine ("settingTalk",texting);

	}	

	bool UIup=false;

	bool firsttime=false;

	IEnumerator settingTalk(string text)
	{
		Debug.Log ("a");
		charactertext.text = "";
		yield return new WaitForSeconds (0.05f);
		for (int i=0; i < text.Length; i++) 
		{
		
			charactertext.text = text.Substring (0, i);
			yield return new WaitForSeconds (0.05f);

		}
		charactertext.text = text;
		UIup = true;

		if(firsttime==false)
		{
			firsttime=true;
			StartCoroutine ("buttonUIup");

		}


		yield break;



	}




	string[] Tempmessage = new string[3];

	public void SetAnswer(int num, string texting){

		 Tempmessage [num] = texting;
	
	}


	public void ButtonEvent(int num)
	{
        DialogMng.GetInstance.Response(num);
	}


	public Animator [] buttons = new Animator[3];

	bool pushing=true;

	public void Buttondown(int num)
	{
	
		if (pushing == false) {
			buttons [num].SetTrigger ("push");
			pushing=true;
			ButtonEvent (num);
			StopCoroutine ("buttonUIdown");
			StartCoroutine ("buttonUIdown");
		}

	}


	IEnumerator buttonUIdown()
	{
		yield return new WaitForSeconds (0.2f);
		float dtime = Time.deltaTime;
		while  (buttonset.position.y - 10*dtime > -10) 
		{
		
			buttonset.Translate (0, -10*dtime, 0);
			yield return null;
			dtime = Time.deltaTime;
		}

		buttonset.position = new Vector3 (0, -10, 0);


	
		while (UIup==false) 
		{
			
			yield return null;

		}
		StopCoroutine ("buttonUIdown");
		StartCoroutine ("buttonUIup");
		UIup = false;
		yield break;

	}

	IEnumerator buttonUIup()
	{

		for(int i=0;i<3;i++)
		{
			buttontexts [i].text = Tempmessage [i];
		}

		float dtime = Time.deltaTime;
		while  (buttonset.position.y + 10*dtime < buttonsetoriginpos.y) 
		{

			buttonset.Translate (0, 10*dtime, 0);
			yield return null;
			dtime = Time.deltaTime;
		}


		buttonset.position = buttonsetoriginpos;
		pushing = false;
		yield break;
	}



}