using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Record kills, deaths and oddball hold times of all players
/// this will be used to determine the winners of each game
/// </summary>
public class Player_Records : MonoBehaviour {

    public class Player_Stats
    {
        public int player_id; //records controller id as that remains constant
        public int kills;
        public int deaths;
        public int oddball_hold_time;
        public float time_of_death;
    }

    public static Player_Records player_records_inst;

    List<Player_Stats> all_player_stats = new List<Player_Stats>();

    private void Start()
    {
        player_records_inst = this;
    }

    //add player with default values
    public Player_Stats Add_Player(int _player_id)
    {
        for(int i = 0;i < all_player_stats.Count; i++)
        {
            if(all_player_stats[i].player_id == _player_id)
            {
                return all_player_stats[i];
            }
        }
        Player_Stats player_record = new Player_Stats();
        player_record.player_id = _player_id;
        player_record.kills = 0;
        player_record.deaths = 0;
        player_record.time_of_death = 0f;
        all_player_stats.Add(player_record);
        return player_record; //is this returning a copy or a reference?
    }

    //get playre by id or add player if it does not exist
    Player_Stats Get_Player(int _player_id)
    {
        for(int i = 0; i < all_player_stats.Count; i++)
        {
            if(all_player_stats[i].player_id == _player_id)
            {
                return all_player_stats[i];
            }
        }
        //if player does not create it and return
        return Add_Player(_player_id);
        
    }

    public void Add_Kill(int _player_id)
    {
        Get_Player(_player_id).kills++;
        Display_Kills();
    }

    public void Add_Death(int _player_id)
    {
        Get_Player(_player_id).deaths++;
    }

    public void Set_Time_Of_Death(int _player_id, float _time)
    {
        Get_Player(_player_id).time_of_death = _time;
    }

    public void Add_Hold_Time(int _player_id, int _amount)
    {
        Get_Player(_player_id).oddball_hold_time += _amount;
    }

    public List<Player_Stats> Get_Player_Records()
    {
        return all_player_stats;
    }

    public int Get_Highest_Kill()
    {
        int highest_kill = 0;
        for(int i = 0; i < all_player_stats.Count; i++)
        {
            if(all_player_stats[i].kills > highest_kill)
            {
                highest_kill = all_player_stats[i].kills;
            }
        }
        return highest_kill;
    }

    public int Get_Highest_Kill_ID()
    {
        int highest_kill_id = 0;
        int highest_kill = 0;
        for (int i = 0; i < all_player_stats.Count; i++)
        {
            if (all_player_stats[i].kills > highest_kill)
            {
                highest_kill = all_player_stats[i].kills;
                highest_kill_id = all_player_stats[i].player_id;
            }
        }
        return highest_kill_id;
    }

    public int Get_Highest_Hold_Time()
    {
        int highest_hold_time = 0;
        for (int i = 0; i < all_player_stats.Count; i++)
        {
            if (all_player_stats[i].oddball_hold_time > highest_hold_time)
            {
                highest_hold_time = all_player_stats[i].oddball_hold_time;
            }
        }
        return highest_hold_time;
    }

    public void Display_Kills()
    {
        for(int i = 0; i < all_player_stats.Count; i++)
        {
            print(all_player_stats[i].player_id + " " + all_player_stats[i].kills);
        }
    }
}
