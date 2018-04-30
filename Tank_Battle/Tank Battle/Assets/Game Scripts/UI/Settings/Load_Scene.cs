using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour {

    public string scene_name;

	public void Load()
    {
        if(scene_name != string.Empty)
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}
