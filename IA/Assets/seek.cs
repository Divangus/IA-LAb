using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float maxVelocity;
    public float slowDistance;
    public float stopDistance;

    float turnSpeed = 3;
    float turnAcceleration = 1;
    float maxTurnSpeed = 5;
    float movSpeed = 1;
    public float acceleration = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Seek
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;    // (x, z): position in the floor

        Vector3 movement = direction.normalized * maxVelocity;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);

        if (Vector3.Distance(target.transform.position, transform.position) > slowDistance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                                     Time.deltaTime * turnSpeed);
            transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;
            movSpeed += acceleration * Time.deltaTime;

        }

        if (Vector3.Distance(target.transform.position, transform.position) <
         slowDistance)
        {
            if(Vector3.Distance(target.transform.position, transform.position) >
            stopDistance)
            {
                Seek();   // calls to this function should be reduced
                turnSpeed += turnAcceleration * Time.deltaTime;
                turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
                movSpeed += acceleration * Time.deltaTime;
                movSpeed = Mathf.Min(movSpeed, maxVelocity);
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      rotation, Time.deltaTime * turnSpeed);
                transform.position += transform.forward.normalized * movSpeed *
                                      Time.deltaTime;
            }
            
        }
        
    }

    void Seek()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        Vector3 movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
