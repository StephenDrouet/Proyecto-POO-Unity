using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacle : Enemy
{
    private float speedRotation = 2;
    private Vector3 Rotation;

    private void Start()
    {
        Rotation = new Vector3(Random.Range(-speedRotation, speedRotation),
                               Random.Range(-speedRotation, speedRotation),
                               Random.Range(-speedRotation, speedRotation));
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
        Move();
    }

    void RotateObject()
    {
        transform.Rotate(Rotation);
    }
}
