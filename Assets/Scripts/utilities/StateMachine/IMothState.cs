using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMothState {

    void UpdateState();

    void OnMouseDown(GameObject clicked);

    void ToFlowerState();

    void ToWanderState();

}
