using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform target;

    public Rigidbody rb;

    public float moveSpeed = 2000f;

    public string AIstate;

    Vector3 direction;

    Vector3 moveDirection;

    Vector3 waypoint;

    int counter = 0;

    void Update()
    {
        //makeshift case statement
        if (AIstate == "Seek")
        {
            Seek();
        }
        if (AIstate == "Flee")
        {
            Flee();
        }
        if (AIstate == "Wander")
        {
            //WanderWaypoint();
            moveSpeed = 2;
            transform.position += transform.TransformDirection(Vector3.forward) * moveSpeed * Time.deltaTime;

            if (counter == 60)
            {
                WanderWaypoint();
                counter = 0;
            }
            else
            {
                counter = counter + 1;
            }
        }
        if (AIstate == "Arrive")
        {
            Arrival();
        }
    }

    void Seek() //seek function that will have the AI move towards the player
    {
        direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        moveDirection = direction.normalized * moveSpeed * Time.deltaTime;
        transform.LookAt(moveDirection);
        rb.AddForce(moveDirection);
    }

    void Flee() //flee function that will have the AI move away from the player
    {
        direction = transform.position - target.position;
        transform.rotation = Quaternion.LookRotation(direction);
        moveDirection = direction.normalized * moveSpeed * Time.deltaTime;
        transform.LookAt(moveDirection);
        rb.AddForce(moveDirection);
    }

    void Arrival() //arrival function that will have the AI move towards the player and stop at a certain point
    {
        direction = target.position - transform.position;
        //float distance = direction.magnitude;
        transform.rotation = Quaternion.LookRotation(direction);
        moveDirection = direction.normalized * moveSpeed * Time.deltaTime;
        //transform.position = transform.position + moveDirection;
        rb.AddForce(moveDirection);

        if (direction.magnitude < 10)
        {
            moveSpeed = moveSpeed / 10;
        }

        if (direction.magnitude < 5)
        {
            moveSpeed = moveSpeed / 5;
        }
        if(direction.magnitude > 10)
        {
            moveSpeed = 2000;
        }
    }

    void WanderWaypoint() //sets a waypoint for wander
    {
        waypoint = Random.insideUnitSphere * 47;
        waypoint.y = 1;
        transform.LookAt(waypoint);
        //rb.AddForce(waypoint);
       
    }
}
