using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
    }


    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
