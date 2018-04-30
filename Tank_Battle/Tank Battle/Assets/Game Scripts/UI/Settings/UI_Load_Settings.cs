using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Load_Settings : MonoBehaviour {

	public void Load_Settings()
    {
        SceneManager.LoadScene("Value_Settings_Scene");
    }
}
