using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Load : MonoBehaviour
{
    void Start()
    {
        string character = PlayerPrefs.GetString("SelectedCharacter", "brute");

        GameObject loadedPrefab = Resources.Load<GameObject>("Characters/" + character);

        if (loadedPrefab != null)
        {
            Instantiate(loadedPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log($"Character '{character}' blev fundet.");
        }
        else
        {
            Debug.LogError($"Character '{character}' blev ikke fundet!");
        }
    }
}
