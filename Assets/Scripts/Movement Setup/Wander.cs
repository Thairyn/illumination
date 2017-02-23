using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteeringBasics))]
public class Wander : MonoBehaviour {

    public float wanderRadius = 1.2f;

    public float wanderDistance = 2f;

    //maximum amount of random displacement a second
    public float wanderJitter = 40f;

    private Vector3 wanderTarget = Vector3.zero;
    private Vector3 targetPosition = Vector3.zero;

    private SteeringBasics steeringBasics;


    void Awake()
    {
        steeringBasics = GetComponent<SteeringBasics>();
        //stuff for the wander behavior
        float theta = Random.value * 2 * Mathf.PI;

        //create a vector to a target position on the wander sphere

        wanderTarget = new Vector3(wanderRadius * Mathf.Cos(theta), wanderRadius * Mathf.Sin(theta), wanderRadius * Mathf.Tan(theta));

        //wanderTarget = Random.insideUnitSphere;
    }

    public Vector3 getTarget()
    {
        //get the jitter for this time frame
        float jitter = wanderJitter * Time.deltaTime;

        //add a small random vector to the target's position
        wanderTarget += new Vector3(Random.Range(-1f, 1f) * jitter, Random.Range(-1f, 1f) * jitter, Random.Range(-1f, 1f) * jitter);
        wanderTarget += wanderTarget * jitter;

        //make the wanderTarget fit on the wander circle again
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        //move the target in front of the character
        targetPosition += transform.right * wanderDistance + wanderTarget;

        return targetPosition;
    }

    public Vector3 getSteering(Vector3 targetPosition)
    { 
        return steeringBasics.seek(targetPosition);

    }


}