using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontParallax : MonoBehaviour
{
    public Vector2 driftSpeed = new Vector2(0.2f, 0.2f);
    public Vector2 driftIntensity = new Vector2(0.5f, 0.5f);

    private Vector2 startPos;
    private float timeOffsetX;
    private float timeOffsetY;

    void Start()
    {
        startPos = transform.position;
        timeOffsetX = Random.Range(0f, 100f);
    }

    void Update()
    {
        float driftX = (Mathf.PerlinNoise(Time.time * driftSpeed.x + timeOffsetX, 0) - 0.3f) * driftIntensity.x;

        transform.position = new Vector3(startPos.x + driftX, startPos.y, transform.position.z);
    }
}