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

    [SerializeField]
    private Image[] _answerIcons;
    [SerializeField]
    private Sprite[] _answerIconSprites;
    private int[] _iconTemps = new int[3];

	/*
	 * SetTalk(텍스트): 질문, 일반 말
	 * SetAnswer(버튼번호, 텍스트): 답(버튼)
	 * ButtonEvent(버튼번호) : 버튼 이벤트;
	 */
	//bar0: love bar1: hunger bar2: life

	Zombie Zombiescript;

	public CanvasGroup bubble;

	void Start()
	{
		
		Zombiescript = GameObject.Find ("Zombie").GetComponent<Zombie> ();
		value[0]=Zombiescript._love;
		value[1]=Zombiescript._hungry;
		value[2]=Zombiescript._life;
		buttonsetoriginpos = buttonset.position;
		buttonset.position = new Vector3 (0, -10, 0);
		SetParameter ();
		StartCoroutine ("buttonUIup");
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

	string TempSetTalk;

	public void SetTalk(string texting)
	{

		TempSetTalk = texting;

	}	




	string[] Tempmessage = new string[3];

	public void SetAnswer(int num, string texting, string love, string hunger, string life){
        int lov = int.Parse(love);
        int hun = int.Parse(hunger);
        int lif = int.Parse(life);

        if (hun >= lov && hun > 0)
        {
            _iconTemps[num] = 2;
            //_answerIcons[num].gameObject.SetActive(true);
            //_answerIcons[num].sprite = _answerIconSprites[0];
        }
        else if (lov > hun && lov > 0)
        {
            _iconTemps[num] = 2;
            //_answerIcons[num].gameObject.SetActive(true);
            //_answerIcons[num].sprite = _answerIconSprites[1];
        }
        else
        {
            _iconTemps[num] = 2;
            //_answerIcons[num].gameObject.SetActive(false);
        }
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
        SoundMng.GetInstance.Play(2);
		if (pushing == false) {
			buttons [num].SetTrigger ("push");
			pushing=true;
			ButtonEvent (num);
			StopCoroutine ("buttonUIdown");
			StartCoroutine ("buttonUIdown");
		}

	}


	public bool daychange=true;




	IEnumerator buttonUIdown()
	{
        foreach (var item in _answerIcons)
        {
            item.gameObject.SetActive(false);
        }
		yield return new WaitForSeconds (0.2f);
		float dtime = Time.deltaTime;
		while  (buttonset.position.y - 10*dtime > -10) 
		{
		
			bubble.alpha -= 3 * dtime;
			buttonset.Translate (0, -10*dtime, 0);
			yield return null;
			dtime = Time.deltaTime;
		}
		bubble.alpha = 0;
		buttonset.position = new Vector3 (0, -10, 0);

		StopCoroutine ("buttonUIdown");
		StartCoroutine ("buttonUIup");

		yield break;

	}


	int imsi=0;

	public Transform [] line= new Transform[3];




	IEnumerator buttonUIup()
	{
		float dtime;
		if (daychange == true) {
			Time.timeScale = 0;
			dtime = Time.unscaledDeltaTime;
			while (line [imsi].position.x + dtime * 20 < 0) {
				line [imsi].Translate (dtime * 20, 0, 0);
				yield return null;
				dtime = Time.unscaledDeltaTime;
			}
			line [imsi].position = new Vector3 (0, 0, 0);
			yield return new WaitForSecondsRealtime (2f);
			while (line [imsi].position.x < 10) {
				line [imsi].Translate (Time.unscaledDeltaTime * 30, 0, 0);
				yield return null;
			}
			line [imsi].gameObject.SetActive (false);
			Time.timeScale = 1;
			imsi++;
			daychange = false;
		}



		charactertext.text = "";
		while (bubble.alpha < 1) {
			bubble.alpha += Time.deltaTime * 3;
			yield return null; 
		}



		yield return new WaitForSeconds (0.05f);
		for (int i=0; i < TempSetTalk.Length; i++) 
		{

			charactertext.text = TempSetTalk.Substring (0, i);
			yield return new WaitForSeconds (0.05f);

		}
		charactertext.text = TempSetTalk;



		for(int i=0;i<3;i++)
		{
			buttontexts [i].text = Tempmessage [i];
            switch (_iconTemps[i])
            {
                case 0:
                    _answerIcons[i].gameObject.SetActive(true);
                    _answerIcons[i].sprite = _answerIconSprites[0];
                    break;
                case 1:
                    _answerIcons[i].gameObject.SetActive(true);
                    _answerIcons[i].sprite = _answerIconSprites[1];
                    break;
                default:
                    _answerIcons[i].gameObject.SetActive(false);
                    break;
            }
        }

		dtime = Time.deltaTime;
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