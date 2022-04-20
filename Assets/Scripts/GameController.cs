using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;

    private int score;
    private int hiscore;
    private int asteroidsRemaining;
    private int lives;
    private int wave;
    private int increaseEachWave;

    public Text scoreText;
    public Text livesText;
    public Text waveText;
    public Text hiscoreText;
    // Start is called before the first frame update
    void Start()
    {
        hiscore = PlayerPrefs.GetInt ("hiscore", 0);
        BeginGame ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("Escape"))
        {
            Application.Quit();
        }
    }
    void BeginGame()
    {
        score = 0;
        lives = 3;
        wave = 1;

        //HUD
        scoreText.text = "SCORE: " + score;
        hiscoreText.text = "HISCORE: " + hiscore;
        livesText.text = "LIVES: " + lives;
        waveText.text = "WAVE: " + wave;

        SpawnAsteroids();
    }
    void SpawnAsteroids()
    {
        DestroyExistingAsteroids();

        //Destrou old game asteroids
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-9.0f, 9.0f),
                Random.Range(-6.0f, 6.0f), 0),
                Quaternion.Euler(0,0,Random.Range(-0.0f, 359.0f)));
        }
        waveText.text = "WAVE: " + wave;
    }
    public void IncrementScore()
    {
        score++;

        scoreText.text = "SCORE: " + score;

        if(score > hiscore)
        {
            hiscore = score;
            hiscoreText.text = "HISCORE: " + hiscore;

            //Saves hiscore
            PlayerPrefs.SetInt ("hiscore", hiscore);
        }
        //Checks has the player destroyed all asteroids
        if(asteroidsRemaining < 1)
        {
            //New wave
            wave++;
            SpawnAsteroids();
        } 
    }
    public void DecrementLives()
    {
        lives--;
        livesText.text = "LIVES: " + lives;

        //Checks is there live at player 
        if (lives < 1)
        {
            //Restarts games
            BeginGame();
        }
    }
    public void DecrementAsteroids()
    {
        asteroidsRemaining--;
    }
    public void SplitAsteroids()
    {
        asteroidsRemaining+=2;
    }

    void DestroyExistingAsteroids()
    {
        GameObject[] asteroids =
            GameObject.FindGameObjectsWithTag("Large Asteroids");

            foreach(GameObject current in asteroids)
            {
                GameObject.Destroy (current);
            }
        GameObject[] asteroids2 =
            GameObject.FindGameObjectsWithTag("Small Asteroids");

            foreach(GameObject current in asteroids2)
            {
                GameObject.Destroy (current);
            }
    }
}
