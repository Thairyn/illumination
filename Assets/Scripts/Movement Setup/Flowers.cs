using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour {

    private float sphereRadius;

	// Use this for initialization
	void Start () {

    }


    public Vector3 FindFlower() {
    //check for collision only on flower layer
        int layerMask = 1 << 9;
        bool foundFlower = false;
        sphereRadius = 10;
        Transform nearest;
        Vector3 flowerpos = new Vector3();

        while (foundFlower == false)
        {
            // Is there a collision with objects on flower layer
            if (Physics.CheckSphere(transform.position, sphereRadius, layerMask))
            {
                Collider[] hitFlowers = Physics.OverlapSphere(transform.position, sphereRadius, layerMask);
                nearest = hitFlowers[0].gameObject.transform;
                flowerpos = nearest.position;
                foundFlower = true;
            }
            else
            {
                //increase search area
                sphereRadius += 10;
            }
        }
        return flowerpos;
    }

}
