using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathmatch_Mode : Game_Mode
{

    float current_time;

    //called when game is in play
    public override void Gameplay_Loop()
    {
        base.Gameplay_Loop();
        current_time += Time.deltaTime;
        if (current_time > time_limit)
        {
            End_Game();
        }
    }

    public override void Add_Kill(int _player_index)
    {
        base.Add_Kill(_player_index);
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].player_index == _player_index)
            {
                players[i].kills += 1;
                if (players[i].kills >= kill_limit)
                {
                    End_Game();
                }
            }
        }
    }

    public override List<Player_Information> Get_Game_Winners()
    {
        List<Player_Information> winners = Get_Round_Winners();
        for(int i=  0;i < winners.Count; i++)
        {
            winners[i].rounds_won++;
        }
        return In_Game_Record.in_game_record_inst.Get_Highest_Rounds_Won();
    }

    public override List<Player_Information> Get_Round_Winners()
    {
        print("GET ROUND WINNERS");
        return In_Game_Record.in_game_record_inst.Get_Highest_Kills();
    }

    public override void End_Game()
    {
        base.End_Game();
        if (PlayerPrefs.GetInt("Current_Round") >= round_limit)
        {
            List<Player_Information> game_winners = Get_Game_Winners();
            Display_Game_Winners(game_winners);
            In_Game_Record.in_game_record_inst.Reset_All();
            StartCoroutine(Load_Scene("Menu_Screen", 5));
        }
        else
        {
            PlayerPrefs.SetInt("Current_Round", PlayerPrefs.GetInt("Current_Round") + 1);
            List<Player_Information> round_winners = Get_Round_Winners();
            if (round_winners != null)
            {
                for (int i = 0; i < round_winners.Count; i++)
                {
                    round_winners[i].rounds_won++;
                }
                Display_Round_Winners(round_winners);
                In_Game_Record.in_game_record_inst.Reset_Kills();
                In_Game_Record.in_game_record_inst.Reset_Deaths();
                StartCoroutine(Load_Scene("Desert_Base", 5));
            }
            else
            {
                print("NO ROUND WINNERS");
            }

        }
    }

    void Display_Round_Winners(List<Player_Information> _round_winners)
    {
        //display stuff
        for(int i = 0;i < _round_winners.Count; i++)
        {
            print(_round_winners[i].player_index);
        }
    }

    void Display_Game_Winners(List<Player_Information> _game_winners)
    {
        //display stuff
        for (int i = 0; i < _game_winners.Count; i++)
        {
            print(_game_winners[i].player_index);
        }
    }

    IEnumerator Load_Scene(string _scene_name, float _after_time)
    {
        print("LOAD NEXT SCENE");
        yield return new WaitForSeconds(_after_time);
        SceneManager.LoadScene(_scene_name);
    }

    IEnumerator Load_Random_Scene(float _after_time)
    {
        yield return new WaitForSeconds(_after_time);
    }


}
