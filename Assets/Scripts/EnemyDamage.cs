using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;

    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudio;

    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= 0){
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        myAudio.PlayOneShot(enemyDeathSFX);

        ParticleSystem vFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vFX.Play();

        Destroy(vFX.gameObject,vFX.main.duration);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        myAudio.PlayOneShot(enemyHitSFX);

        hitParticlePrefab.Play();
        hitPoints -= 1;
    }
}
