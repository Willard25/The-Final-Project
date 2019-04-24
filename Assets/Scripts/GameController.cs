using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public AudioClip winsoundClip;
    public AudioSource winsoundSource;
    public AudioClip losesoundClip;
    public AudioSource losesoundSource;

    public Text ScoreText;
    public Text winText;
    public Text createdByText;
    public Text restartText;
    public Text gameOverText;
    public Text hardText;

    private bool gameOver;
    private bool restart;
    private int score;

    public BGScroller other;
    public IncreasePS please;
    public increaseDistantPS thank;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        createdByText.text = "";
        hardText.text = "Press Q for Hard";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        winsoundSource.clip = winsoundClip;
        losesoundSource.clip = losesoundClip;
    }

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.F))
        {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'F' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if(score >=100)
        {
            winText.text = "You win!";
            createdByText.text = "Created by Willard Marley";
            winsoundSource.Play();
            other.ChangeSpeed();
            please.fastPar();
            thank.DistantPar();
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        createdByText.text = "Created by Willard Marley";
        losesoundSource.Play();
        gameOver = true;
    }
}