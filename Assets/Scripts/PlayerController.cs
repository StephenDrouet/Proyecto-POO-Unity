using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float demage = 10;
    [SerializeField] private float health = 20;

    private Rigidbody playerRb;
    private float giro = 2;
    public GameObject shootingObject;
    public float fireRate;
    private float nextFire;
    public ParticleSystem BoomParticle;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        nextFire = 0;
    }

    private void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        MoveControll();
    }

    void MoveControll()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector3(horizontalInput, 0, verticalInput) * speed;

        transform.rotation = Quaternion.Euler(Vector3.forward * playerRb.velocity.x * -giro);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time > nextFire) {

            nextFire = Time.time + fireRate;
            Instantiate(shootingObject, transform.position, shootingObject.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShootingEnem"))
        {
            Instantiate(BoomParticle, transform.position, BoomParticle.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(BoomParticle, transform.position, BoomParticle.transform.rotation);
            Destroy(gameObject);
        }
    }
}

