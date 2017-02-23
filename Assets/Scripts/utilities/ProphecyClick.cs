using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProphecyClick : MonoBehaviour {

    public bool HasProphecy = false;
    public int[] prophecies; 

	void Start () {
		
	}

    void OnMouseDown()
    {
        GetProphecy();
        HasProphecy = true;
    }

    public int GetProphecy()
    {
        int prophecy = 0;
        return prophecy;
    }
}

