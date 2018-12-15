using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;

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
            yield return new WaitForSeconds(movementPeriod);
        }

        SelfDestruct();
    }

    private void SelfDestruct()
    {
        ParticleSystem vFX = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vFX.Play();

        Destroy(vFX.gameObject, vFX.main.duration);
        Destroy(gameObject);
    }
}
