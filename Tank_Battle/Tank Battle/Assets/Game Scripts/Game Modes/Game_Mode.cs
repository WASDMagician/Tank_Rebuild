using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Mode : MonoBehaviour {

    //start pre-game countdown
    //start game countdown
    //switch game state

    public Game_Timer game_timer;
    public In_Game_Record player_records;
    public List<Player_Information> players, winners;

    public int kill_limit, time_limit, hold_limit, round_limit;

    public static Game_Mode game_mode_inst;
    bool game_started = false;

    public void Start_Game()
    {
        game_mode_inst = this;

        kill_limit = PlayerPrefs.GetInt("Kill_Limit");
        time_limit = PlayerPrefs.GetInt("Time_Limit");
        hold_limit = PlayerPrefs.GetInt("Oddball_Hold_Limit"); //@NOTE not yet set
        round_limit = PlayerPrefs.GetInt("Round_Limit");

        player_records = FindObjectOfType<In_Game_Record>();
        players = player_records.Get_All_Players();

        game_timer = FindObjectOfType<Game_Timer>();
        StartCoroutine(Pre_Game_Countdown());
    }

    IEnumerator Pre_Game_Countdown()
    {
        int i = 10;
        while(i > 0)
        {
            i--;
            yield return new WaitForSeconds(1);
            game_timer.Set_Time(i);
        }
        game_started = true;
        Game_State.game_state_inst.Set_State(Game_State.Game_States.in_play);
    }

    private void Update()
    {
        if (game_started == true)
        {
            if (Game_State.game_state_inst == null)
            {
                print("NO GAME STATE");
            }
            if (Game_State.game_state_inst != null)
            {
                if (Game_State.game_state_inst.Get_State() == Game_State.Game_States.in_play)
                {
                    Gameplay_Loop();
                }
            }
        }
    }

    public virtual void Gameplay_Loop()
    {
        //do gameplay things here
    }

    public virtual void Add_Kill(int _player_index)
    {

    }

    public virtual void Add_Hold_Time(int _player_index, float _time)
    {

    }

    public virtual List<Player_Information> Get_Round_Winners()
    {
        return null;
    }
    
    public virtual List<Player_Information> Get_Game_Winners()
    {
        return null;
    }

    public virtual void End_Game()
    {
        Game_State.game_state_inst.Set_State(Game_State.Game_States.post_game);
        this.StopAllCoroutines();
    }
}
