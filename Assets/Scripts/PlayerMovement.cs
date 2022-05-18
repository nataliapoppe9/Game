using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        input = input.normalized;

        rig.velocity = ((Vector3.right * input.x) + (Vector3.forward * input.y) * speed * Time.deltaTime);
    }   
}
