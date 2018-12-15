using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpanws = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

	void Start () {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(secondsBetweenSpanws);
        }
    }
}
