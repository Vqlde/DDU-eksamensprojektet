using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winscreen;

    void Start() {
        winscreen = GameObject.Find("WinCanvas");
        winscreen.SetActive(false);
    }



    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            winscreen.SetActive(true);
        }

    }
    
        
}
