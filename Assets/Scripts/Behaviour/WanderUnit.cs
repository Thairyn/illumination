using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderUnit : MonoBehaviour {

    private SteeringBasics steeringBasics;
    private Wander wander;

    // Use this for initialization
    void Start()
    {
        steeringBasics = GetComponent<SteeringBasics>();
        wander = GetComponent<Wander>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 accel = wander.getTarget();
        steeringBasics.steer(accel);
        steeringBasics.lookWhereYoureGoing(accel);
    }
}