using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public void StartGame(string character)
    {
        PlayerPrefs.SetString("SelectedCharacter", character);

        SceneManager.LoadScene(2);
    }
}