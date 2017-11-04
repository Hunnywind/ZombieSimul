using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

	public CanvasGroup fade;
	bool clicked=false;

	void Start()
	{
        SoundMng.GetInstance.PlayBGM(0);

        StartCoroutine ("fadein");
	}


	IEnumerator fadein()
	{
		while (fade.alpha > 0) 
		{
			fade.alpha -= Time.deltaTime;
			yield return null;
		}



	}


	IEnumerator fadeout(int num)
	{
		while (fade.alpha < 1) 
		{
			fade.alpha += Time.deltaTime;
			yield return null;
		}
		if (num == 0)
			SceneManager.LoadScene ("prologue");
		else if (num == 1)
			SceneManager.LoadScene ("credit");

	}

	public void Click(int num)
	{
		if (clicked == false) {
			clicked = true;
			StartCoroutine ("fadeout",num);
		}
	}

}
