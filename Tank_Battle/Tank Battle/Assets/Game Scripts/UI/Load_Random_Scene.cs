using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Random_Scene : MonoBehaviour {

    string[] scenes = new string[] { "Tundra_Base", "Ruins", "Sci_Fi", "Meadow_Campsite", "Desert_Base" };

	public void Load()
    {
        SceneManager.LoadScene(scenes[Random.Range(0, scenes.Length)]);
    }
}
