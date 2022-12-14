using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameUI gameUI;
    public float speed;
    public ParticleSystem BoomParticle;
    public AudioClip BoomSound;
    public AudioSource audioSource;

    public void loadGameUI()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        gameUI = GameObject.Find("Canvas").GetComponent<GameUI>();
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shooting"))
        {
            audioSource.PlayOneShot(BoomSound, 0.7f);
            if (gameObject.CompareTag("EnemyShip"))
            {
                gameUI.UpdateScore(15);
                Instantiate(BoomParticle, transform.position, BoomParticle.transform.rotation);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }

            if (gameObject.CompareTag("EnemyObs"))
            {
                gameUI.UpdateScore(5);
                Instantiate(BoomParticle, transform.position, BoomParticle.transform.rotation);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(BoomSound, 0.7f);
            Instantiate(BoomParticle, transform.position, BoomParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

}
