using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour {

    private SteeringBasics steeringBasics;

    private float sphereRadius;

	// Use this for initialization
	void Start () {
        steeringBasics = GetComponent<SteeringBasics>();
    }


    public Transform FindFlower() {
    //check for collision only on flower layer
        int layerMask = 1 << 9;
        bool foundFlower = false;
        sphereRadius = 10;
        GameObject nearestflower = new GameObject();
        Transform nearest = nearestflower.transform;

        while (foundFlower == false)
        {
            // Is there a collision with objects on flower layer
            if (Physics.CheckSphere(transform.position, sphereRadius, layerMask))
            {
                Collider[] hitFlowers = Physics.OverlapSphere(transform.position, sphereRadius, layerMask);
                nearestflower = hitFlowers[0].gameObject;
                nearest = nearestflower.transform;
                Debug.Log("Found flower");
                foundFlower = true;
            }
            else
            {
                sphereRadius += 10;
                Debug.Log("Did not Hit");
            }
        }
        return nearest;
    }

    public Vector3 SeekFlower() {
        Transform flower = FindFlower();
        Vector3 flowerposition = flower.position;
        return flowerposition;
    }
}
