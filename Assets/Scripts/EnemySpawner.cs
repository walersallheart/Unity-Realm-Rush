﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 10f)]
    [SerializeField] float secondsBetweenSpanws = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

	void Start () {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(secondsBetweenSpanws);
        }
    }
}