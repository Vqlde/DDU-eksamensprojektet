using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Load : MonoBehaviour
{
    void Start()
    {
        // Get the selected character from PlayerPrefs
        string character = PlayerPrefs.GetString("SelectedCharacter", "brute");

        // Load the prefab from the Resources/Characters folder
        GameObject loadedPrefab = Resources.Load<GameObject>("Characters/" + character);

        if (loadedPrefab != null)
        {
            // Instantiate the character at position (0, 0, 0)
            Instantiate(loadedPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log($"Character '{character}' spawned successfully.");
        }
        else
        {
            Debug.LogError($"Character '{character}' not found in Resources/Characters folder!");
        }
    }
}
