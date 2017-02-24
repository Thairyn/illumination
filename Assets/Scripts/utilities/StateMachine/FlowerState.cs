using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerState : IMothState {

    private readonly StateMachine moth;
    private ProphecyClick prophecy;

    public FlowerState(StateMachine mothmachine)
    {
        moth = mothmachine;
    }

    public void UpdateState()
    {

    }

    public void OnMouseDown()
    {

    }

    public void ToFlowerState()
    {

    }

    public void ToWanderState()
    {

    }

    public void OnMouseDown (GameObject clicked) { }
}

