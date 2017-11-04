using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData : Singleton<GameData> {

    Dictionary<string, Dictionary<int, Dictionary<string, string>>> gameDataDictionary
        = new Dictionary<string, Dictionary<int, Dictionary<string, string>>>();

    private void Awake()
    {
        LoadData("Question");
        LoadData("Answer");
        LoadData("NormalEndings");
    }
    private void LoadData(string directory)
    {
        string[] line = null;
        string[] keys = null;
        string[] values = null;

        TextAsset loadText = Resources.Load<TextAsset>("Data\\" + directory);

        line = loadText.text.Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            line[i] = line[i].Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
        }
        keys = line[0].Split(',');

        var data = new Dictionary<int, Dictionary<string, string>>();

        for (int i = 1; i < line.Length; i++)
        {
            values = line[i].Split(',');
            var valueD = new Dictionary<string, string>();
            for (int j = 0; j < values.Length; j++)
            {
                valueD.Add(keys[j], values[j]);
            }
            data.Add(i - 1, valueD);
        }
        gameDataDictionary.Add(directory, data);
    }
    public Dictionary<int, Dictionary<string, string>> GetData(string dataName)
    {
        return gameDataDictionary[dataName];
    }
}
