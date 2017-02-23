using System;
using System.Collections;
using UnityEngine;

    public class StateMachine : MonoBehaviour
    {

        [HideInInspector]
        public IMothState currentstate;
        [HideInInspector]
        public WanderState wanderstate;
        [HideInInspector]
        public FlowerState flowerstate;
        [HideInInspector]
        public HoverState hoverstate;

    private void Awake()
    {
        wanderstate = new WanderState(this);
        flowerstate = new FlowerState(this);
        hoverstate = new HoverState(this);

    }

    void Start()
    {
        currentstate = wanderstate;
    }

    void Update()
    {
        currentstate.UpdateState();
    }

    void OnMouseDown(GameObject clicked)
    {
        currentstate.UpdateState();
    }

    }