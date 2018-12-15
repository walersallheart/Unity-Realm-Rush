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

    AudioSource myAudioSource;

    // Use this for initialization
    void Start () {
        myAudioSource = GetComponent<AudioSource>();

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
        ParticleSystem vFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vFX.Play();

        Destroy(vFX.gameObject,vFX.main.duration);

        AudioSource.PlayClipAtPoint(enemyDeathSFX, FindObjectOfType<Camera>().transform.position);

        Destroy(gameObject);
    }

    void ProcessHit()
    {
        myAudioSource.PlayOneShot(enemyHitSFX);

        hitParticlePrefab.Play();
        hitPoints -= 1;
    }
}
