using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Previous_Scene : MonoBehaviour {

	public void Load()
    {
        if(PlayerPrefs.HasKey("Game_Mode") == true)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Game_Mode"));
        }
        else
        {
            SceneManager.LoadScene("Game_Mode_Screen");
        }
    }
}
