using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    //Parameters of Tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWaypoint;

    //State of Tower
    Transform targetEnemy;

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Update is called once per frame
    void Update () {
        SetTargetEnemy();

        if (targetEnemy){
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        if (sceneEnemies.Length == 0) {
            targetEnemy = null;
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distToA = Vector3.Distance(transformA.position, gameObject.transform.position);
        float distToB = Vector3.Distance(transformB.position, gameObject.transform.position);

        if (distToA < distToB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FireAtEnemy(){
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

        if (distanceToEnemy <= attackRange){
            Shoot(true);
        } else{
            Shoot(false);
        }
    }

    private void Shoot(bool isActive){
        var emissionModule = projectileParticle.emission;

        emissionModule.enabled = isActive;
    }
}
