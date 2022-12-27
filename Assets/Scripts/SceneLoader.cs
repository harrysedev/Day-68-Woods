using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string name)
    {
        if (name != null)
        {
            if (name == "game")
            {
                if (GameData.GetIntValue("reset") == 1)
                {
                    PlayerPrefs.DeleteAll();
                }
            }
            SceneManager.LoadScene(name);
        }
    }

    public void ResetGameData()
    {
        GameData.doReset();
    }
}
