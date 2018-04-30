using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Instantiator : MonoBehaviour
{
    //load in game state
    //get game mode
    //load game mode
    //load players
    //assign controllers
    //load spawn controller
        //spawn players
    //pass control to game mode

    public GameObject tank_prefab;
    In_Game_Record game_record;
    Game_Mode game_mode;

    private void Start()
    {
        Load_Game_State();
        Load_Game_Mode();
        Load_Players();
        Load_Spawn_Controller();
        if(game_mode != null)
        {
            game_mode.Start_Game();
        }
    }

    void Load_Game_State()
    {
        if (Game_State.game_state_inst == null)
        {
            this.gameObject.AddComponent<Game_State>();
        }
        if (Game_State.game_state_inst != null)
        {
            print("GAME STATE ADDED SUCCESSFULLY");
            Game_State.game_state_inst.Set_State(Game_State.Game_States.pre_game);
        }
    }

    void Load_Game_Mode()
    {
        string pref_game_mode = PlayerPrefs.GetString("Game_Mode");
        switch (pref_game_mode)
        {
            case "Deathmatch":
                game_mode = this.gameObject.AddComponent<Deathmatch_Mode>();
                break;
            case "Elimination":
                game_mode = this.gameObject.AddComponent<Elimination_Mode>();
                break;
            case "Oddball":
                game_mode = this.gameObject.AddComponent<Oddball_Mode>();
                break;
            default:
                print("NOT GAME MODE ADDED");
                break;
        }
    }

    void Load_Players()
    {
        //game record holds all player info
        game_record = FindObjectOfType<In_Game_Record>();
        if(game_record != null && tank_prefab != null)
        {
            List<Player_Information> all_players = game_record.Get_All_Players();
            print(all_players.Count);
            for(int i = 0; i < all_players.Count; i++)
            {
                //load player
                GameObject player = Instantiate(tank_prefab, Vector3.zero, Quaternion.identity) as GameObject;
                //assign controller
                Vehicle_Control_Holder control_holder = player.GetComponentInChildren<Vehicle_Control_Holder>();
                if(control_holder != null)
                {
                    control_holder.Set_Player_Index(all_players[i].player_index);
                    //set colours here
                }
                if(control_holder == null)
                {
                    print("NO CONTROL HOLDER");
                }
            }
        }
        else
        {
            print("ERROR");
        }
    }

    void Load_Spawn_Controller()
    {
        if(FindObjectOfType<Spawn_Controller>() == null)
        {
            this.gameObject.AddComponent<Spawn_Controller>();
        }
        if(FindObjectOfType<Spawn_Controller>() == null)
        {
            print("NO SPAWN CONTROLLER");
        }
    }
}
