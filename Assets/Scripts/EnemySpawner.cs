using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 10f)]
    [SerializeField] float secondsBetweenSpanws = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;

    int score = 0;

    void Start () {
        spawnedEnemies.text = score.ToString();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemyParentTransform);

            score++;
            spawnedEnemies.text = score.ToString();


            yield return new WaitForSeconds(secondsBetweenSpanws);
        }
    }
}
