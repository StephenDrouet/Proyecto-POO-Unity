using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.2f);
    }

}
