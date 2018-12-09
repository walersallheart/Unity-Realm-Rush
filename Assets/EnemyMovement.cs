using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float dwellTime = 1f;

    // Use this for initialization
    void Start () {
        Pathfinder pathFinder = FindObjectOfType<Pathfinder>();

        var path = pathFinder.GetPath();

        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
    }
}
