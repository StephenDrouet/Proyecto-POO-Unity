using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public ParticleSystem BoomParticle;

    public virtual void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shooting"))
        {
            Instantiate(BoomParticle, transform.position, BoomParticle.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
