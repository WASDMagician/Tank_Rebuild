using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Game_Mode_Settings : MonoBehaviour {

    public string game_mode;
    public Slider kill_limit, time_limit, round_limit;

	public void Store_Settings()
    {
        if(kill_limit != null)
        {
            Store_Int("Kill_Limit", (int)kill_limit.value);
        }
        if(time_limit != null)
        {
            Store_Int("Time_Limit", (int)time_limit.value * 60);
        }
        if(round_limit != null)
        {
            Store_Int("Round_Limit", (int)round_limit.value);
        }
    }

    public void Store_GameMode()
    {
        if(PlayerPrefs.HasKey("Game_Mode") == false)
        {
            PlayerPrefs.SetString("Game_Mode", game_mode);
        }
        else
        {
            PlayerPrefs.SetString("Game_Mode", game_mode);
        }
    }

    public void Store_Int(string _key, int _value)
    {
        if(PlayerPrefs.HasKey(_key) == false)
        {
            PlayerPrefs.SetInt(_key, _value);
        }
        else
        {
            PlayerPrefs.SetInt(_key, _value);
        }
    }
}
