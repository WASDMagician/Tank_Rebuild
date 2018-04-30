using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Vehicle_Movement : MonoBehaviour {

    Rigidbody vehicle_rigidbody;
    public float rotate_speed, move_speed, maximum_velocity, deccelerate_speed, rotation_fix_speed, rot_z_limit;
    public Transform turn_point;
    bool can_move = false;

    Vehicle_Control_Holder vehicle_control_holder;

    

	// Use this for initialization
	void Start () {
        vehicle_rigidbody = GetComponent<Rigidbody>();
        vehicle_control_holder = GetComponent<Vehicle_Control_Holder>();
	}

    // Update is called once per frame
    void Update()
    {
        if(vehicle_control_holder == null)
        {
            vehicle_control_holder = GetComponent<Vehicle_Control_Holder>();
        }
        else
        {
            if (Game_State.game_state_inst != null && Game_State.game_state_inst.Get_State() == Game_State.Game_States.in_play)
            {
                float hor = vehicle_control_holder.state.ThumbSticks.Left.X;
                float ver = vehicle_control_holder.state.ThumbSticks.Left.Y;
                if (hor != 0 || ver != 0)
                {
                    //Rotate(hor, ver);
                    Move(hor, ver);
                    Rotate(hor, ver);
                }
                else
                {
                    Decelerate();
                }
            }
        }
    }
    void Rotate(float _hor, float _ver)
    {
        Vector3 input_direction = new Vector3(_hor, 0, _ver); //get the input direction, this is the direction we want the vehicle to face
        Vector3 current_rotation = this.transform.rotation.eulerAngles;
        Vector3 new_rotation = (Quaternion.FromToRotation(this.transform.forward, input_direction) * this.transform.rotation).eulerAngles; //convert input direction to rotation
        float angle = new_rotation.y - current_rotation.y;
        //this.transform.RotateAround(turn_point.position, turn_point.up, angle); //removed due weird lepring, behavior reproduced with parent child relationship
        Quaternion initial = this.transform.rotation; //take initial rotation
        this.transform.Rotate(0, angle, 0); //rotate by difference between previous angles
        Quaternion final = this.transform.rotation; //take final rotation
        this.transform.rotation = Quaternion.Lerp(initial, final, rotate_speed * Time.deltaTime); //lerp between initial and final rotation
    }

    void Move(float _hor, float _ver)
    {
        Vector3 input_direction = new Vector3(_hor, 0, _ver);
        vehicle_rigidbody.AddForce(input_direction * move_speed, ForceMode.Acceleration);
        vehicle_rigidbody.velocity = Vector3.ClampMagnitude(vehicle_rigidbody.velocity, maximum_velocity);
    }

    void Decelerate()
    {
        vehicle_rigidbody.velocity = Vector3.Lerp(vehicle_rigidbody.velocity, Vector3.zero, deccelerate_speed * Time.deltaTime);
        vehicle_rigidbody.angularVelocity = Vector3.Lerp(vehicle_rigidbody.angularVelocity, Vector3.zero, deccelerate_speed * Time.deltaTime);
    }
}
