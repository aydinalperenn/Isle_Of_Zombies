using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject zombie;

    private float timer;                // zaman sayac�
    private float createdTime = 10f;      // olu�um s�reci (zombi ka� snde bir olu�acak)

    public TextMeshProUGUI scoreText;
    private int score;

    void Start()
    {
        timer = createdTime;
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Vector3 pos = new Vector3 (Random.Range(160,304), 25f, Random.Range(200,310));
            Instantiate(zombie, pos, Quaternion.identity);
            createdTime = Random.Range(5, 15);
            timer = createdTime;
        }
    }

    public void addScore(int s)
    {
        score += s;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("GameOver");
    }
}
