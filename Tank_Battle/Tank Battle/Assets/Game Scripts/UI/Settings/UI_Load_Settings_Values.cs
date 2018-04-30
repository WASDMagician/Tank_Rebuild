using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Load_Settings_Values : MonoBehaviour {

    public Slider master_volume, music_volume, sfx_volume;

	// Use this for initialization
	void Start () {
        //check player prefs... move this into a public static function?
        if(PlayerPrefs.HasKey("Master_Volume") == false)
        {
            PlayerPrefs.SetInt("Master_Volume", 5);
        }
        if(PlayerPrefs.HasKey("Music_Volume") == false)
        {
            PlayerPrefs.SetInt("Music_Volume", 5);
        }
        if(PlayerPrefs.HasKey("SFX_Volume") == false)
        {
            PlayerPrefs.SetInt("SFX_Volume", 5);
        }

        if (master_volume != null && music_volume != null && sfx_volume != null)
        {
            master_volume.value = PlayerPrefs.GetInt("Master_Volume");
            music_volume.value = PlayerPrefs.GetInt("Music_Volume");
            sfx_volume.value = PlayerPrefs.GetInt("SFX_Volume");
        }
	}
}
