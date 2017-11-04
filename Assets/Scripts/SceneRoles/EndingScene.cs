using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndingScene : MonoBehaviour {


	public Transform TextTransform;
	public CanvasGroup fade;
	public Image endingImage;
	public Sprite[] endingImages = new Sprite[9];
	public string[] endingText = {"","","","","","","","",""};


	// Use this for initialization
	void Start () {
		int temp = PlayerPrefs.GetInt ("ending",0);
		endingImage.sprite = endingImages [temp];
		TextTransform.GetComponent<Text> ().text = endingText [temp];
		StartCoroutine ("scrolling");

	}


	IEnumerator scrolling()
	{
		
		while (TextTransform.position.y < 4) 
		{

			fade.alpha -= Time.deltaTime;
			TextTransform.Translate (0, Time.deltaTime, 0);
			if (Input.GetMouseButton (0))
				Time.timeScale = 3;
			else
				Time.timeScale = 1;

			yield return null;
		}

		while (fade.alpha < 1) 
		{
			fade.alpha += Time.deltaTime;
			if (Input.GetMouseButton (0))
				Time.timeScale = 4;
			else
				Time.timeScale = 1;
			yield return null;
		}
		Time.timeScale = 1;
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("ReloadScene");

	}







}
