using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeControl : MonoBehaviour {

	// Use this for initialization

	public CanvasGroup fade;
	bool fading=true;
		void Start () {

			Time.timeScale = 0;
			StartCoroutine ("fadein");

		}


		IEnumerator fadein()
		{

			while (fade.alpha > 0) 
			{

				fade.alpha -= Time.unscaledDeltaTime;
				yield return null;

			}

		Time.timeScale = 1;
		fading = false;
		yield break;

		}


	public void fadeout(int num)
		{
		if (fading == false) {
			StartCoroutine ("fadeouting", num);
			fading = true;
		}
		}


	IEnumerator fadeouting(int num)
		{


			while (fade.alpha < 1) 
			{
			fade.alpha += Time.unscaledDeltaTime;
				yield return null;

			}
		if (num < 10) {
			PlayerPrefs.SetInt ("ending", num);
			SceneManager.LoadScene ("EndingScene");
			yield break;
		}
		else
			SceneManager.LoadScene ("Start");
		

		}
}
