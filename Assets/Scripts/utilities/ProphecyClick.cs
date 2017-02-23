using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProphecyClick : MonoBehaviour {

    public bool HasProphecy = false;
    private string currentproph; 

	void Start () {
        currentproph = "cloud";
    }

    void OnMouseDown()
    {
        string prophecy = GetProphecy();
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("moth");
        foreach (GameObject moth in taggedObjects)
        {
            if (prophecy != null && prophecy == "flower") {
                moth.GetComponent<FlowersUnit>().enabled = true;
                moth.GetComponent<WanderUnit>().enabled = false;
            }
            else if (prophecy != null && prophecy == "cloud")
            {
                moth.GetComponent<WanderUnit>().enabled = true;
                moth.GetComponent<FlowersUnit>().enabled = false;
            }
        }
    }

    public string GetProphecy()
    {
        if (currentproph == "flower")
            currentproph = "cloud";
        else if (currentproph == "cloud")
            currentproph = "flower";
        Debug.Log(currentproph);
        return currentproph;
    }
}

