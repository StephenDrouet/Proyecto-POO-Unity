using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject shootingObject;
    public ParticleSystem BoomParticle;
    public ParticleSystem BoomParticle2;
    public ParticleSystem PowerUpParticle;
    public AudioClip shootAudio;
    public AudioClip powerUpAudio;
    public AudioClip[] boomAudio;
    private AudioSource audioSource;
    public GameUI gameUI;

    [SerializeField] private float speed = 1;

    private float giro = 2;
    public float fireRate;
    private float nextFire;

    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        nextFire = 0;
    }

    private void Update()
    {
        if (gameUI.isLife)
        {
            Shoot();
        }
        else
        {
            playerRb.velocity = Vector3.zero;
            RotatePlayer();
        }

    }

    void FixedUpdate()
    {
        if (gameUI.isLife)
        {
            MoveControll();
        }
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
            audioSource.PlayOneShot(shootAudio, 0.7f);
            nextFire = Time.time + fireRate;
            Instantiate(shootingObject, transform.position, shootingObject.transform.rotation);
        }
    }

    void RotatePlayer()
    {
        float speedRotation = 4;
        Vector3 Rotation = new Vector3(Random.Range(-speedRotation, speedRotation),
                               Random.Range(-speedRotation, speedRotation),
                               Random.Range(-speedRotation, speedRotation));

        transform.Rotate(Rotation);
    }

    IEnumerator DestroyPlayer()
    {      
        Instantiate(BoomParticle, transform.position, BoomParticle.transform.rotation);
        audioSource.PlayOneShot(boomAudio[0], 0.8f);
        yield return new WaitForSeconds(1.6f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShootingEnem"))
        {
            audioSource.PlayOneShot(boomAudio[1], 0.5f);
            Instantiate(BoomParticle2, other.transform.position, BoomParticle2.transform.rotation);
            Destroy(other.gameObject);
            gameUI.UpdateHealth();
            if (!gameUI.isLife)
            {
                StartCoroutine(DestroyPlayer());
            }
        }

        if (other.gameObject.CompareTag("PowerUp")) {
            audioSource.PlayOneShot(powerUpAudio , 1);
            gameUI.addTime();
            Instantiate(PowerUpParticle, other.transform.position, PowerUpParticle.transform.rotation);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyShip") || collision.gameObject.CompareTag("EnemyObs"))
        {            
            gameUI.UpdateHealth();
            if (!gameUI.isLife)
            {
                StartCoroutine(DestroyPlayer());
            }
        }
    }
}

