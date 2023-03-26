using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 start_pos;
    float player_speed;
    float jump_force;
    bool on_ground;

    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        player_speed = 6.0f;
        jump_force = 5.0f;
        on_ground = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * player_speed);

        if (on_ground && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jump_force, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        on_ground = true;

        if (collision.GetContact(0).normal != Vector3.up)
        {
            transform.position = start_pos;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        on_ground = false;
    }
}
