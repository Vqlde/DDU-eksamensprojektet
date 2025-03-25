using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerScript : MonoBehaviour
{
    public float moveDistance = 5.0f;
    public float moveSpeed = 2.0f;

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - moveDistance)
            {
                movingUp = true;
            }
        }
    }
}