using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Information
{
    //player id is controller index and player number is the order in which the player joined
    public int player_index, player_number, kills, deaths, rounds_won;
    public float oddball_hold_time, time_of_death;
    public Player_Information(int _player_index, int _player_number)
    {
        player_number = _player_number;
        player_index = _player_index;
        kills = deaths = rounds_won = 0;
        oddball_hold_time = time_of_death = 0;
    }
}

public struct Game_Information
{
    public enum Game_Types { deathmatch, elimination, oddball};
    public Game_Types game_type;

    public int round_limit, current_round, kill_limit, time_limit;
}


public class In_Game_Record : MonoBehaviour {

    public static In_Game_Record in_game_record_inst;

    Game_Information current_game;
    List<Player_Information> all_players = new List<Player_Information>();

	// Use this for initialization
	void Start () {
        if(in_game_record_inst == null)
        {
            in_game_record_inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
	}

    public Player_Information Get_Player_By_Index(int _player_index)
    {
        for(int i = 0; i < all_players.Count; i++)
        {
            if (all_players[i].player_index == _player_index)
            {
                return all_players[i];
            }
        }
        return null;
    }
    
    public Player_Information Get_Player_By_Player_Number(int _player_number)
    {
        for(int i = 0;i < all_players.Count; i++)
        {
            if(all_players[i].player_number == _player_number)
            {
                return all_players[i];
            }
        }
        return null;
    }

    public void Add_Player(int _player_index, int _player_number)
    {
        for(int i = 0; i < all_players.Count; i++)
        {
            if(all_players[i].player_index == _player_index || all_players[i].player_number == _player_number)
            {
                return;
            }
        }
        Player_Information new_player = new Player_Information(_player_index, _player_number);
        all_players.Add(new_player);
    }

    public void Remove_Player(int _player_index)
    {
        for(int i = 0;i < all_players.Count; i++)
        {
            if(all_players[i].player_index == _player_index)
            {
                all_players.Remove(all_players[i]);
                return;
            }
        }
    }

    public void Reset_All()
    {
        Reset_Kills();
        Reset_Deaths();
        Reset_Hold_Time();
        Reset_Rounds();
    }

    public void Reset_Kills()
    {
        for(int i=  0;i < all_players.Count; i++)
        {
            all_players[i].kills = 0;
        }
    }

    public void Reset_Deaths()
    {
        for(int i = 0; i < all_players.Count; i++)
        {
            all_players[i].deaths = 0;
        }
    }

    public void Reset_Hold_Time()
    {
        for(int i = 0; i < all_players.Count; i++)
        {
            all_players[i].oddball_hold_time = 0;
        }
    }

    public void Reset_Rounds()
    {
        for(int i=  0; i < all_players.Count;i++)
        {
            all_players[i].rounds_won = 0;
        }
    }

    public List<Player_Information> Get_Highest_Kills()
    {
        int highest_kill = 0;
        List<Player_Information> highest_killers = new List<Player_Information>();
        for(int i = 0; i < all_players.Count; i++)
        {
            if (all_players[i].kills == highest_kill) //if player has joint highest kills add to list
            {
                highest_killers.Add(all_players[i]);
            }
            if (all_players[i].kills > highest_kill) //if player has more kills clear list and add current player
            {
                highest_kill = all_players[i].kills;
                highest_killers.Clear();
                highest_killers.Add(all_players[i]);
            }
        }
        return highest_killers;
    }

    public List<Player_Information> Get_Highest_Rounds_Won()
    {
        int highest_rounds_won = 0;
        List<Player_Information> highest_round_winners = new List<Player_Information>();
        for(int i = 0; i < all_players.Count; i++)
        {
            if(all_players[i].rounds_won == highest_rounds_won)
            {
                highest_round_winners.Add(all_players[i]);
            }
            if(all_players[i].rounds_won > highest_rounds_won)
            {
                highest_rounds_won = all_players[i].rounds_won;
                highest_round_winners.Clear();
                highest_round_winners.Add(all_players[i]);
            }
        }
        return highest_round_winners;
    }

    public List<Player_Information> Get_All_Players()
    {
        return all_players;
    }
}
