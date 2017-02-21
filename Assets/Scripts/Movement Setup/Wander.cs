using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteeringBasics))]
    public class Wander : MonoBehaviour {

    /* Offset of the wander zone ahead of agent */
    public float wanderOffset = 1.5f;

    /* The radius of the wander zone */
    public float wanderRadius = 4;

    /* The rate at which the wander orientation can change */
    public float wanderRate = 0.4f;

    private float wanderOrientation = 0;

    private SteeringBasics steeringBasics;

    void Start () {
        steeringBasics = GetComponent<SteeringBasics>();
    }
	
    

}
