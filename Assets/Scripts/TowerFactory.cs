using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        Tower oldTower = towers.Dequeue();

        oldTower.transform.position = baseWaypoint.transform.position;
        oldTower.baseWaypoint.isPlaceable = true;

        oldTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towers.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towerParentTransform);
        towers.Enqueue(newTower);

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
    }
}
