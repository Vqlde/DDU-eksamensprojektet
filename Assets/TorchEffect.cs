using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchEffect : MonoBehaviour
{
    private Light2D torchLight;
    public float Min = 1.0f;
    public float Max = 3.0f;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        torchLight = GetComponent<Light2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        torchLight.pointLightOuterRadius = Mathf.Lerp(Min, Max, Mathf.PingPong(Time.time * speed, 1));
    }
}
