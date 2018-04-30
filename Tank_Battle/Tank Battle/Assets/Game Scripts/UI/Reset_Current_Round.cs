using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Current_Round : MonoBehaviour {

	public void On_Click()
    {
        PlayerPrefs.SetInt("Current_Round", 0);
    }
}
