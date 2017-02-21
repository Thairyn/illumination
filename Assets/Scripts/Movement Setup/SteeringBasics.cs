using UnityEngine;
using System.Collections;

/* A helper class for steering a game object in 2D */
using System.Collections.Generic;


[RequireComponent(typeof(Rigidbody))]
public class SteeringBasics : MonoBehaviour
{

    public float maxVelocity = 3.5f;

    /* The maximum acceleration */
    public float maxAcceleration = 10f;

    /* The radius from the target that means we are close enough and have arrived */
    public float targetRadius = 0.005f;

    /* The radius from the target where we start to slow down  */
    public float slowRadius = 1f;

    /* The time in which we want to achieve the targetSpeed */
    public float timeToTarget = 0.1f;


    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 /* STEER behaviour. Steers agent towards target using the given linear acceleration */
    public void steer(Vector3 linearAcceleration)
    {
        rb.velocity += linearAcceleration * Time.deltaTime;

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }


/* SEEK behavior. Returns steering for the current game object to seek a given target */
    public Vector3 seek(Vector3 targetPosition, float maxSeekAccel)
    {
        //Get the direction
        Vector3 dvelocity = targetPosition - transform.position;

        //normalise desired travel vector
        dvelocity.Normalize();

        //Accelerate to the target
        dvelocity *= maxSeekAccel;

        return dvelocity;
    }

    /* Call for Agent to seek a target's position given max acceleration */
    public Vector3 seek(Vector3 targetPosition)
    {
        return seek(targetPosition, maxAcceleration);
    }


    /* Makes the current game object look where it is going */
    public void lookWhereYoureGoing(Vector3 targetPosition)
    {
        Vector3 relativepos = seek(targetPosition, maxAcceleration);
        Quaternion rotation = Quaternion.LookRotation(relativepos);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);

    }

    /* ARRIVE behaviour. Seeks target until entering landing zone, the slows over time to a stop at target */

    public Vector3 arrive(Vector3 targetPosition)
    {
        /* Get the right direction for the linear acceleration */
        Vector3 targetVelocity = targetPosition - transform.position;


        /* Get the distance to the target */
        float dist = targetVelocity.magnitude;

        /* If we are within the stopping radius then stop */
        if (dist < targetRadius)
        {
            rb.velocity = Vector3.zero;
            return Vector3.zero;
        }

        /* Calculate the target speed, full speed at slowRadius distance and 0 speed at 0 distance */
        float targetSpeed;
        if (dist > slowRadius)
        {
            targetSpeed = maxVelocity;
        }
        else
        {
            targetSpeed = maxVelocity * (dist / slowRadius);
        }

        /* Give targetVelocity the correct speed */
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        /* Calculate the linear acceleration we want */
        Vector3 acceleration = targetVelocity - new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        /*
		 Rather than accelerate the character to the correct speed in 1 second, 
		 accelerate so we reach the desired speed in timeToTarget seconds 
		 (if we were to actually accelerate for the full timeToTarget seconds).
		*/
        acceleration *= 1 / timeToTarget;

        /* Make sure we are accelerating at max acceleration */
        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration.Normalize();
            acceleration *= maxAcceleration;
        }

        return acceleration;
    }

    public Vector3 interpose(Rigidbody target1, Rigidbody target2)
    {
        Vector3 midPoint = (target1.position + target2.position) / 2;

        float timeToReachMidPoint = Vector3.Distance(midPoint, transform.position) / maxVelocity;

        Vector3 futureTarget1Pos = target1.position + target1.velocity * timeToReachMidPoint;
        Vector3 futureTarget2Pos = target2.position + target2.velocity * timeToReachMidPoint;

        midPoint = (futureTarget1Pos + futureTarget2Pos) / 2;

        return arrive(midPoint);
    }

}