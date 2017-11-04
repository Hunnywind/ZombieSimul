using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMng : Singleton<GameMng> {


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SceneManager.LoadScene("main_scene");
    }


	public void Ending(int num)
	{


		PlayerPrefs.SetInt ("ending", num);
		SceneManager.LoadScene("EndingScene");



	}


}
