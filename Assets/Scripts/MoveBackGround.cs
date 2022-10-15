using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    private float speed = 15;
    private float resetPos = -50;

    // Update is called once per frame
    void LateUpdate()
    {
        TranslateBackground();
    }

    void TranslateBackground()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < resetPos)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
