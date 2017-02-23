using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersUnit : MonoBehaviour {

    private Flowers flowers;
    private SteeringBasics steeringBasics;

    // Use this for initialization
    void Start () {
        steeringBasics = GetComponent<SteeringBasics>();
        flowers = GetComponent<Flowers>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 target = flowers.SeekFlower();
        Vector3 accel = steeringBasics.arrive(target);
        steeringBasics.steer(accel);
        steeringBasics.lookWhereYoureGoing(target);
    }
}
