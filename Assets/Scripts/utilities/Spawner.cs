using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject moth;
    public GameObject spawn;
    public GameObject[] moths;
    private int mothstospawn = 30;
    public float spawnTime = 0.3f;
    public int mothcount = 0;

    // Use this for initialization
    void Awake() {
        moths = new GameObject[mothstospawn];
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn() {
        if (mothcount < mothstospawn)
        {
            Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), 0, Random.Range(0, 360));
            GameObject newmoth = (GameObject)Instantiate(moth, spawn.transform.position, randomRotation);
            moths[mothcount] = newmoth;
            mothcount += 1;
        }

    }
	
}
