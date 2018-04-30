using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Prefs_Player_Utility : MonoBehaviour {

    public static void Initialise_Prefs()
    {
        PlayerPrefs.SetInt("Player_1", -1);
        PlayerPrefs.SetInt("Player_2", -1);
        PlayerPrefs.SetInt("Player_3", -1);
        PlayerPrefs.SetInt("Player_4", -1);
        PlayerPrefs.SetInt("Player_1_Rounds", 0);
        PlayerPrefs.SetInt("Player_2_Rounds", 0);
        PlayerPrefs.SetInt("Player_3_Rounds", 0);
        PlayerPrefs.SetInt("Player_4_Rounds", 0);
    }

    public static bool Is_Player_Connected(int _id)
    {
        if(PlayerPrefs.GetInt("Player_1") == _id)
        {
            return true;
        }
        if(PlayerPrefs.GetInt("Player_2") == _id)
        {
            return true;
        }
        if(PlayerPrefs.GetInt("Player_3") == _id)
        {
            return true;
        }
        if(PlayerPrefs.GetInt("Player_4") == _id)
        {
            return true;
        }
        return false;
    }

    public static int Get_First_Available_Slot()
    {
        if (PlayerPrefs.GetInt("Player_1") == -1)
        {
            return 1;
        }
        if (PlayerPrefs.GetInt("Player_2") == -1)
        {
            return 2;
        }
        if (PlayerPrefs.GetInt("Player_3") == -1)
        {
            return 3;
        }
        if (PlayerPrefs.GetInt("Player_4") == -1)
        {
            return 4;
        }
        return -1;
    }

    public static void Add_Player(int _id)
    {
        int slot = Get_First_Available_Slot();
        if (slot != -1)
        {
            PlayerPrefs.SetInt("Player_" + slot, _id);
        }
    }

    public static void Remove_Player(int _id)
    {
        if(PlayerPrefs.GetInt("Player_1") == _id)
        {
            PlayerPrefs.SetInt("Player_1", -1);
        }
        if (PlayerPrefs.GetInt("Player_2") == _id)
        {
            PlayerPrefs.SetInt("Player_2", -1);
        }
        if (PlayerPrefs.GetInt("Player_3") == _id)
        {
            PlayerPrefs.SetInt("Player_3", -1);
        }
        if (PlayerPrefs.GetInt("Player_4") == _id)
        {
            PlayerPrefs.SetInt("Player_4", -1);
        }
    }

    public static int Get_Player_Number(int _id)
    {
        if (PlayerPrefs.GetInt("Player_1") == _id)
        {
            return 1;
        }
        if (PlayerPrefs.GetInt("Player_2") == _id)
        {
            return 2;
        }
        if (PlayerPrefs.GetInt("Player_3") == _id)
        {
            return 3;
        }
        if (PlayerPrefs.GetInt("Player_4") == _id)
        {
            return 4;
        }
        return -1;
    }

    public static int Get_Highest_Round_Win_ID()
    {
        int max_won = 0;
        int player_id = -1;
        if(PlayerPrefs.GetInt("Player_1_Rounds") > max_won)
        {
            max_won = PlayerPrefs.GetInt("Player_1_Rounds");
            player_id = 1;
        }
        if(PlayerPrefs.GetInt("Player_2_Rounds") > max_won)
        {
            max_won = PlayerPrefs.GetInt("Player_2_Rounds");
            player_id = 2;
        }
        if(PlayerPrefs.GetInt("Player_3_Rounds") > max_won)
        {
            max_won = PlayerPrefs.GetInt("Player_3_Rounds");
            player_id = 3;
        }
        if(PlayerPrefs.GetInt("Player_4_Rounds") > max_won)
        {
            max_won = PlayerPrefs.GetInt("Player_4_Rounds");
            player_id = 4;
        }
        return player_id;
    }

    public static void Reset_Rounds()
    {
        PlayerPrefs.SetInt("Player_1_Rounds", 0);
        PlayerPrefs.SetInt("Player_2_Rounds", 0);
        PlayerPrefs.SetInt("Player_3_Rounds", 0);
        PlayerPrefs.SetInt("Player_4_Rounds", 0);
    }

    public static void Add_Round_Win(int _player_number)
    {
        PlayerPrefs.SetInt("Player_" + _player_number.ToString() + "_Rounds", PlayerPrefs.GetInt("Player_" + _player_number.ToString() + "_Rounds" + 1));
    }

    public static int Get_Player_Id(int _player_number)
    {
        return PlayerPrefs.GetInt("Player_" + _player_number.ToString());
    }
}
