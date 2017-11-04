using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadScene : MonoBehaviour {

	public CanvasGroup fade;
	public CanvasGroup Yes;
	public CanvasGroup No;

	// Use this for initialization
	void Start () {
	

		StartCoroutine ("fadein");

	}


	IEnumerator fadein()
	{

		while (fade.alpha > 0) 
		{
		
			fade.alpha -= Time.deltaTime;
			yield return null;

		}
		Yes.interactable = true;
		No.interactable = true;
		yield break;

	}


	public void buttonclick(int i)
	{

		Yes.interactable = false;
		No.interactable = false;
		StartCoroutine ("fadeout" + i.ToString ());
	
	}


	IEnumerator fadeout0()
	{

		while (fade.alpha < 1) 
		{
			
			No.alpha -= 2*Time.deltaTime;
			fade.alpha += Time.deltaTime;
			yield return null;

		}
		DataloadMng.GetInstance.ResetData ();
		Destroy (GameObject.Find ("GameManger"));
		SceneManager.LoadScene ("intro");
		yield break;

	}


	IEnumerator fadeout1()
	{

		while (fade.alpha < 1) 
		{
			Yes.alpha -= 2*Time.deltaTime;
			fade.alpha += Time.deltaTime;
			yield return null;
		}
		Application.Quit ();
		yield break;

	}


}
