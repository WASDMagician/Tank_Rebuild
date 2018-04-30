using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Vehicle_Control_Holder : MonoBehaviour {

    //controller stuff //this will be separately when adding players I think
    PlayerIndex player_index;
    bool player_index_set = false;
    public GamePadState state;
    public GamePadState prev_state;
    

    public void Set_Player_Index(int _player_index)
    {
        player_index = (PlayerIndex)_player_index;
        GamePadState test_state = GamePad.GetState(player_index);
        player_index_set = test_state.IsConnected;

    }

    public int Get_Player_Index()
    {
        return (int)player_index;
    }

    // Update is called once per frame
    void Update () {
        if(player_index_set == true)
        {
            prev_state = state;
            state = GamePad.GetState(player_index);
        }
	}
}
