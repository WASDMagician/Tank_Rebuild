using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    Vehicle_Control_Holder firing_vehicle;
    Rigidbody shell_rigidbody;
    public float shoot_speed, blast_radius;
    public int damage;
    public GameObject explosion;
    int num_reflections;
    Vector3 old_velocity;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 10f);
        shell_rigidbody = GetComponent<Rigidbody>();
        if(shell_rigidbody != null)
        {
            shell_rigidbody.AddForce(this.transform.forward * shoot_speed, ForceMode.Impulse);
        }
	}

    public void Set_Firing_Vehicle(Vehicle_Control_Holder _vehicle)
    {
        firing_vehicle = _vehicle;
    }

    private void Update()
    {
        old_velocity = shell_rigidbody.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponentInChildren<Health>() == true || num_reflections > 1)
        {
            Explode();
        }
        else
        {
            Ricochet(collision);
            num_reflections++;
        }
    }

    void Explode()
    {
        //do damage
        //spawn explosion
        GameObject explosion_inst = Instantiate(explosion, this.transform.position, this.transform.rotation);
        Collider[] surrounding_objects = Physics.OverlapSphere(this.transform.position, blast_radius);
        for (int i = 0; i < surrounding_objects.Length; i++)
        {
            Health health = surrounding_objects[i].GetComponent<Health>();
            if (health != null)
            {
                health.Take_Health(damage, firing_vehicle);
            }
        }
        Destroy(explosion_inst, 1);
        Destroy(this.gameObject);
    }

    void Ricochet(Collision _collision)
    {
        shell_rigidbody.velocity = Vector3.Reflect(old_velocity, _collision.contacts[0].normal);
    }
}
