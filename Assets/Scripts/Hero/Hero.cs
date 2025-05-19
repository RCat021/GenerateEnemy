using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroMover))]
public class Hero : Warrior
{
    private HeroMover _mover;

    private void Awake()
    {
        _mover = GetComponent<HeroMover>();
    }

    public void MoveToWaypoints(List<Vector3> waypoints) =>
        _mover.SetWaypoints(waypoints);
}
