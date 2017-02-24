using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : MonoBehaviour
{

    private SteeringBasics steeringBasics;
    public int maxLookAhead;
    public int maxAvoidForce;
    private Rigidbody rb;
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        steeringBasics = GetComponent<SteeringBasics>();
    }

    public Vector3 collisionAvoid(Vector3 target)
    {
        Vector3 dvelocity = steeringBasics.seek(target);
        Vector3 ahead = rb.position + Vector3.Normalize(dvelocity) * maxLookAhead; // calculate the look ahead vector
        Vector3 steeravoid;
        Ray sweep = new Ray(rb.transform.position, target);

        if (LineIntersects(ahead) == true)
        {
            Physics.Raycast(sweep, out hit, maxLookAhead);
            target += hit.normal * maxAvoidForce;
            steeravoid = target;
            Debug.Log(steeravoid);
            return steeravoid;
        }
        else
        {
            steeravoid = Vector3.zero;
        }

        return steeravoid;
    }


    private bool LineIntersects(Vector3 ahead)
    {

        bool hitfound = false;
        Ray sweep = new Ray(rb.transform.position, ahead);

        if (Physics.Raycast(sweep, out hit, maxLookAhead))
        {
            Vector3 hitpos = hit.point;
            Debug.DrawLine(transform.position, hit.point, Color.white);
            hitfound = true;
            return hitfound;
        }
        else
        {
            hitfound = false;
            return hitfound;
        }

    }

}