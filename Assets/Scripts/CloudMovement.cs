using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    int direction = 1;
    float speed = 0.4f;

    void FixedUpdate()
    {
        if (transform.position.x > 15) direction = 1;
        if (transform.position.x < -15) direction = -1;

        transform.Translate(Vector3.left * Time.deltaTime * direction * speed);
    }
}
