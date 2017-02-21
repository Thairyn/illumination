using UnityEngine;
using System.Collections;

public class ArriveUnit : MonoBehaviour {

    private SteeringBasics steeringBasics;

    public Transform target;

    // Use this for initialization
    void Start()
    {
        steeringBasics = GetComponent<SteeringBasics>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 accel = steeringBasics.arrive(target.position);

        steeringBasics.steer(accel);
        steeringBasics.lookWhereYoureGoing(target.position);
    }
}
