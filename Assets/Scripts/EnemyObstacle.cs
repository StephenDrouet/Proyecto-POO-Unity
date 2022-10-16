using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacle : Enemy
{
    private GameObject visualObject;

    private float speedRotation = 5;
    private Vector3 Rotation;
    private int indexObject;

    private void Start()
    {
        loadGameUI();

        indexObject = Random.Range(0, transform.childCount - 1);
        visualObject = transform.GetChild(indexObject).gameObject;
        visualObject.SetActive(true);

        Rotation = new Vector3(Random.Range(-speedRotation, speedRotation),
                               Random.Range(-speedRotation, speedRotation),
                               Random.Range(-speedRotation, speedRotation));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameUI.isLife)
        {
            RotateObject();
            Move();
        }
    }

    void RotateObject()
    {
        transform.Rotate(Rotation);
    }
}
