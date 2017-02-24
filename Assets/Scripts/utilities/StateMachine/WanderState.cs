using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : IMothState {

    private readonly StateMachine moth;
    private ProphecyClick prophecy;

    public WanderState (StateMachine mothmachine)
    {
        moth = mothmachine;
    }

    public void UpdateState()
    {
        Listen();
        Wander();
    }

    public void OnMouseDown(GameObject clicked)
    {

    }

    public void ToFlowerState()
    {
        moth.currentstate = moth.flowerstate;
    }

    public void ToWanderState()
    {
        Debug.Log("Can't transition");   
    }

    public void ToHoverState()
    {
        moth.currentstate = moth.hoverstate;
    }

    private void Listen()
    {
    }

    void Wander()
    {

    }
}
