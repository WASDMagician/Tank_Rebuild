using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour {

    public GameObject turret_object;
    Vehicle_Control_Holder vehicle_control_holder;
    public float rotate_speed;
    Turret_Object current_turret;

    // Use this for initialization
    void Start () {
        vehicle_control_holder = GetComponent<Vehicle_Control_Holder>();
        current_turret = GetComponentInChildren<Turret_Object>();
	}
	
	// Update is called once per frame
	void Update () {
		if(vehicle_control_holder == null)
        {
            vehicle_control_holder = GetComponent<Vehicle_Control_Holder>();
        }
        else
        {
            if (Game_State.game_state_inst != null && Game_State.game_state_inst.Get_State() == Game_State.Game_States.in_play)
            {
                float hor = vehicle_control_holder.state.ThumbSticks.Right.X;
                float ver = vehicle_control_holder.state.ThumbSticks.Right.Y;

                Vector3 input_direction = new Vector3(hor, 0, ver); //get the input direction, this is the direction we want the vehicle to face
                Vector3 current_rotation = turret_object.transform.rotation.eulerAngles;
                Vector3 new_rotation = (Quaternion.FromToRotation(turret_object.transform.forward, input_direction) * turret_object.transform.rotation).eulerAngles; //convert input direction to rotation
                float angle = new_rotation.y - current_rotation.y;
                //this.transform.RotateAround(turn_point.position, turn_point.up, angle); //removed due weird lepring, behavior reproduced with parent child relationship
                Quaternion initial = turret_object.transform.rotation; //take initial rotation
                turret_object.transform.Rotate(0, angle, 0); //rotate by difference between previous angles
                Quaternion final = turret_object.transform.rotation; //take final rotation
                turret_object.transform.rotation = Quaternion.Lerp(initial, final, rotate_speed * Time.deltaTime); //lerp between initial and final rotation

                if (vehicle_control_holder.state.Triggers.Right > 0.5f)
                {
                    current_turret.Fire(vehicle_control_holder);
                }
                else
                {
                    current_turret.Un_Fire();
                }
            }
        }
	}
}
