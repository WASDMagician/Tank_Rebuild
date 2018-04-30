using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_State : MonoBehaviour {

    public enum Game_States { pre_game, in_play, post_game, paused};
    public Game_States game_state;

    public static Game_State game_state_inst;

	// Use this for initialization
	void Start () {
        if (game_state_inst != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            game_state_inst = this;
        }
	}
	
    public void Set_State(Game_States _state)
    {
        game_state = _state;
    }

    public Game_States Get_State()
    {
        return game_state;
    }
}
