using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform target;

    public Rigidbody rb;

    public float moveSpeed = 2000f;

    public bool AIstate = true;

    Vector3 direction;

    Vector3 moveDirection;

    void Update()
    {
        if(AIstate == true)
        {
            Seek();
        }
        if(AIstate == false)
        {
            Flee();
        }
    }

    void Seek()
    {
        direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        moveDirection = direction.normalized * moveSpeed * Time.deltaTime;
        transform.LookAt(moveDirection);
        rb.AddForce(moveDirection);
    }

    void Flee()
    {
        direction = transform.position - target.position;
        transform.rotation = Quaternion.LookRotation(direction);
        moveDirection = direction.normalized * moveSpeed * Time.deltaTime;
        transform.LookAt(moveDirection);
        rb.AddForce(moveDirection);
    }
}
