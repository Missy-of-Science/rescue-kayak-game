using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    private float turn_speed = 60f;
    private float side_bound = 18f;
    private float top_bound = 60f;
    public bool isActive = true;
    public TextMeshProUGUI gameEnded;

    void Update()
    {
        if (isActive)
        {
            MovePlayer();
            ConstrainPlayer();
        }
        else
        {
            gameEnded.gameObject.SetActive(true);
        }
    }

    // move player accross the screen
    void MovePlayer()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float forward_input = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forward_input);
        transform.Rotate(Vector3.up, Time.deltaTime * turn_speed * horizontal_input);
    }

    // set left, right and upwards boundaries
    void ConstrainPlayer()
    {
        if (transform.position.x < -side_bound)
        {
            transform.position = new Vector3(
                -side_bound,
                transform.position.y,
                transform.position.z
            );
        }
        else if (transform.position.x > side_bound)
        {
            transform.position = new Vector3(
                side_bound,
                transform.position.y,
                transform.position.z
            );
        }

        if (transform.position.z > top_bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, top_bound);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            isActive = false;
            gameEnded.text = "Oh No, you hit another swimmer";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isActive = false;
        gameEnded.text = "yeah you reached the damsel in distress";
    }
}

// variables:
// private Rigidbody player_rb;
// private Quaternion left_bound;
// private Quaternion right_bound;
// private Vector3 turn_speed = new Vector3(0, 60 , 0);

// in start:
// player_rb = GetComponent<Rigidbody>();
// left_bound = Quaternion.Euler(turn_speed * Time.deltaTime);
// right_bound = Quaternion.Euler(turn_speed * -1 * Time.deltaTime);

// Update is called once per frame
// void Update()
// {
//     float horizontal_input = Input.GetAxis("Horizontal");
//     float forward_input = Input.GetAxis("Vertical");

//     Quaternion input_rot = Quaternion.Euler(turn_speed * horizontal_input * Time.deltaTime);
//     print($"input_rot: {input_rot}; left: {left_bound}; right: {right_bound}");
//     print($"player.position: {player_rb.position} ({transform.position})");
//     // add forward movement
//     player_rb.AddRelativeForce(Vector3.forward * speed * forward_input, ForceMode.Impulse);
//     player_rb.AddRelativeTorque(Vector3.up * horizontal_input, ForceMode.Impulse);
//     // Rotate left or right
//     // player_rb.MoveRotation(player_rb.rotation *  input_rot);

//     if (transform.position.x < -boundary)
//     {
//         player_rb.velocity = Vector3.one;
//         player_rb.MoveRotation(player_rb.rotation * left_bound);
//     }
//     else if (transform.position.x > boundary)
//     {
//         player_rb.velocity = Vector3.one;
//         player_rb.MoveRotation(player_rb.rotation * right_bound);
//     }
// }
