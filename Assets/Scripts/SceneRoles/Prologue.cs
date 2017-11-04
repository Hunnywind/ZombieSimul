using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("scrolling");
	}

	IEnumerator scrolling()
	{
		
		while (transform.position.y < 6) {

			transform.Translate (0, Time.deltaTime, 0);
			if (Input.GetMouseButton (0))
				Time.timeScale = 3;
			else
				Time.timeScale = 1;

			yield return null;

		}
		Time.timeScale = 1;
		yield return new WaitForSeconds(1f);

		SceneManager.LoadScene ("intro");

	}


}
