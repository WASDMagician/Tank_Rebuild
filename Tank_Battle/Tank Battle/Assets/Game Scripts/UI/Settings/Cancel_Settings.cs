using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cancel_Settings : MonoBehaviour {

	public void Cancel()
    {
        SceneManager.LoadScene("Menu_Screen");
    }
}
