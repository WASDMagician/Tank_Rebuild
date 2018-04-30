using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;

public class Temp_Player : MonoBehaviour
{
    public int controller_id;
    public GamePadState state, prev_state;


    public Temp_Player(int _controller_id)
    {
        controller_id = _controller_id;
    }

    private void Update()
    {
        prev_state = state;
        state = GamePad.GetState((PlayerIndex)controller_id);
    }
}

public class Player_Join : MonoBehaviour {
    //create temp players
        //controller id
        //prev controller state
        //controller state
    //watch for key presses
        //on key add to player record
    //when two players join start countdown // 10 seconds
        //load next scene
        //load players from player record

    public List<Temp_Player> temp_players = new List<Temp_Player>();
    public List<int> joined_players = new List<int>();
    bool countdown_started;
    public Text countdown_timer_text;
    public Text[] player_join_text;

    private void Start()
    {
        Create_Temp_Players();
    }

    //create 4 temporary players
    void Create_Temp_Players()
    {
        for(int i = 0; i < 4; i++)
        {
            temp_players.Add(this.gameObject.AddComponent<Temp_Player>());
            temp_players[i].controller_id = i;
        }
    }

    private void Update()
    {
        Monitor_Key_Press();
    }

    void Monitor_Key_Press()
    {
        for(int i = 0; i < temp_players.Count; i++)
        {
            //if A pressed this frame
            if(temp_players[i].prev_state.Buttons.A == ButtonState.Released && temp_players[i].state.Buttons.A == ButtonState.Pressed)
            {
                if(joined_players.Contains(temp_players[i].controller_id) == false && In_Game_Record.in_game_record_inst != null)
                {
                    In_Game_Record.in_game_record_inst.Add_Player(temp_players[i].controller_id, joined_players.Count);
                    joined_players.Add(temp_players[i].controller_id);
                    player_join_text[joined_players.Count - 1].text = "Player " + joined_players.Count.ToString() + " Joined";
                }
            }
        }
        if(countdown_started == false && joined_players.Count >= 2)
        {
            StartCoroutine(Join_Countdown());
            countdown_started = true;
        }
    }

    IEnumerator Join_Countdown()
    {
        int time = 5;
        while(time >= 0)
        {
            yield return new WaitForSeconds(1);
            countdown_timer_text.text = time.ToString();
            time--;
        }
        //load scene
        SceneManager.LoadScene("Level_Selection");
    }
}
