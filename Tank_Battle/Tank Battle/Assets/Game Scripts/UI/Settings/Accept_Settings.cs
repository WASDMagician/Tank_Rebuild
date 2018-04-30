using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Accept_Settings : MonoBehaviour {

    public Slider master_volume, music_volume, sfx_volume;

	public void Accept()
    {
        PlayerPrefs.SetInt("Master_Volume", (int)master_volume.value);
        PlayerPrefs.SetInt("Music_Volume", (int)music_volume.value);
        PlayerPrefs.SetInt("SFX_Volume", (int)sfx_volume.value);
        SceneManager.LoadScene("Menu_Screen");
    }
}
