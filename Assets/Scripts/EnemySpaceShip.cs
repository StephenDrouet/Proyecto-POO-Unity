using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip : Enemy
{
    public GameObject shootingEnemy;
    public float fireRate = 0.7f;
    private bool isFirst = true;
    private float xBound;
    private float maxXBound = 15;
    private Rigidbody enemyRb;
    private int maxSpeedH = 7;
    private int speedH;

    void Shoot()
    {
        Instantiate(shootingEnemy, transform.position, shootingEnemy.transform.rotation);
    }

    public override void Move()
    {
        base.Move();

        if (Mathf.Abs(xBound) > 2)
        {
            if ((transform.position.x > xBound || transform.position.x < -xBound) && !isFirst)
            {
                speedH = -speedH;
            }
            else
            {
                if (Mathf.Abs(transform.position.x) < 2)
                {
                    isFirst = false;
                }
            }

            enemyRb.velocity = Vector3.right * speedH;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        speedH = Random.Range(0, maxSpeedH);
        xBound = Random.Range(0, maxXBound);
        InvokeRepeating("Shoot", 0.5f, fireRate);
        if (transform.position.x > 0)
        {
            speedH = -speedH;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
}
