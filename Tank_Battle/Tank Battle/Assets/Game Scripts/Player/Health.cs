using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 100;

    //refactor so it doesn't require passing vehicle

    public void Take_Health(int _amount, Vehicle_Control_Holder _firing_vehicle)
    {
        health -= _amount;
        if(health <= 0)
        {
            Game_Mode.game_mode_inst.Add_Kill(_firing_vehicle.Get_Player_Index());
            print(In_Game_Record.in_game_record_inst.Get_Highest_Kills()[0].kills);
            Die();
        }
    }

    public void Die()
    {
        health = 100;
        Spawn_Controller.spawn_controller_inst.Spawn_Player(this.gameObject);
    }
}
