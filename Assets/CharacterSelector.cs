using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public void StartGame(string character)
    {
        // Save the selected character name in PlayerPrefs
        PlayerPrefs.SetString("SelectedCharacter", character);
        
        // Load the next scene (index 1)
        SceneManager.LoadScene(1);
    }
}