using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : Singleton<GameMng> {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
