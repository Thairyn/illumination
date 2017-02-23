using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteeringBasics))]
public class Flowers : MonoBehaviour
{

    private float sphereRadius;

    void Start() { }


    public Transform FindFlower()
    {
        //check for collision only on flower layer
        int layerMask = 1 << 8;
        bool foundFlower = false;
        sphereRadius = 10;
        GameObject nearestflower = null;
        Transform nearest = null;

        while (foundFlower == false)
        {
            // Is there a collision with objects on flower layer
            if (Physics.CheckSphere(transform.position, sphereRadius, layerMask))
            {
                Collider[] hitFlowers = Physics.OverlapSphere(transform.position, sphereRadius, layerMask);
                //int getFlower = Random.Range(0, (hitFlowers.Length - 1));
                nearestflower = hitFlowers[0].gameObject;
                nearest = nearestflower.transform;
                foundFlower = true;
            }
            else
            {
                sphereRadius += 50;
            }
        }
        return nearest;
    }


    public Vector3 SeekFlower()
    {
        Transform flower = FindFlower();
        Vector3 flowerposition = flower.position;
        return flowerposition;
    }
}