using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMove : MonoBehaviour
{
    private GameUI gameUI;
    public float speed = 4;

    private void Start()
    {
        gameUI = GameObject.Find("Canvas").GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameUI.isLife)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
