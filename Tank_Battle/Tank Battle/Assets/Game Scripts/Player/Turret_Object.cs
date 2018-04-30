using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Object : MonoBehaviour {

    public GameObject shell;
    public Transform fire_point;
    bool trigger_down;
    float next_fire_time;

	public void Fire(Vehicle_Control_Holder _firing_vehicle)
    {
        if (trigger_down == false && Time.fixedTime >= next_fire_time)
        {
            GameObject shell_inst = Instantiate(shell, fire_point.transform.position, fire_point.transform.rotation) as GameObject;
            Shell shell_script = shell_inst.GetComponent<Shell>();
            shell_script.Set_Firing_Vehicle(_firing_vehicle);
            trigger_down = true;
            next_fire_time = Time.fixedTime + 1.5f;
        }
    }

    public void Un_Fire()
    {
        trigger_down = false;
    }
}
