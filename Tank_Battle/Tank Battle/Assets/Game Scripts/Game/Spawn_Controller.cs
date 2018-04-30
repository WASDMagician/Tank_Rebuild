using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour {

    public static Spawn_Controller spawn_controller_inst;
    Spawn_Point[] spawn_points;
    Vehicle_Control_Holder[] all_players;

	// Use this for initialization
	void Start () {
        if (spawn_controller_inst != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            spawn_controller_inst = this;
        }
        spawn_points = FindObjectsOfType<Spawn_Point>();
        all_players = FindObjectsOfType<Vehicle_Control_Holder>();
        Spawn_All_Players();
	}

    public void Spawn_All_Players()
    {
        for(int i = 0; i < all_players.Length; i++)
        {
            all_players[i].transform.position = spawn_points[i].transform.position;
            all_players[i].transform.rotation = spawn_points[i].transform.rotation;
        }
    }

    public void Spawn_Player(GameObject _player)
    {
        int rand = Random.Range(0, 4);
        _player.transform.position = spawn_points[rand].transform.position;
        _player.transform.rotation = spawn_points[rand].transform.rotation;
    }
}
