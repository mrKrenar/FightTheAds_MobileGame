using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.SceneManagement;


public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text levelCoinsText;
    public Text levelScoreText;
    public Text coinsText;
    public Text scoreText;
    public Text gameOverText;

    public Canvas welcomeToThisLevel;
    public Button iAmReady;
    public string congratsForNewLevel;
    public string youLoseText;
    public GameObject restartButton;
    public GameObject extraScore;

    private bool gameOver;
    private bool restart;

    private int levelCoins;
    private int levelScore;
    private int score;
    private int coins;
    public int scoreForNextLevel;
    public int nextLevelNumber;
    public int lastPlayedLevel;

    void Start()
    {
        lastPlayedLevel = 1;
        UpdateLastPlayedLevel();
        coinsText.enabled = false;
        scoreText.enabled = false;
        welcomeToThisLevel = welcomeToThisLevel.GetComponent<Canvas>();
        welcomeToThisLevel.enabled = true;
        Time.timeScale = 0.0f;
        iAmReady.enabled = true;
        gameOver = false;
        restart = false;
        restartButton.SetActive(false);
        extraScore.SetActive(false);
        gameOverText.text = "";
        levelScore = 0;
        UpdateLevelScore();
        levelCoins = 0;
        UpdateLevelCoins();
        score = PlayerPrefs.GetInt("score:", score);
        coins = PlayerPrefs.GetInt("coins:", coins);
        UpdateCoins();
        StartCoroutine(SpawnWaves());
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

            if (levelScore >= scoreForNextLevel)
            {
                GameOver();
                yield return new WaitForSeconds(3);
            }

            if (gameOver)
            {
                if (levelScore >= scoreForNextLevel)
                {
                    lastPlayedLevel += 1;
                    PlayerPrefs.SetInt("last played level:", lastPlayedLevel);
                    restartButton.SetActive(false);
                    SceneManager.LoadScene(nextLevelNumber);
                    PlayerPrefs.Save();
                }

                if (levelScore < scoreForNextLevel)
                {
                    PlayerPrefs.Save();
                    restart = true;
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (levelScore > score)
        {
            score = levelScore;
            PlayerPrefs.SetInt("score:", score);
            scoreText.text = "New High Score: " + score;
        }
        if (levelScore <= score)
        {
            scoreText.text = "High Score: " + score;
        }
    }


    public void AddLevelScore(int newLevelScoreValue)
    {
        levelScore += newLevelScoreValue;
        UpdateLevelScore();
    }

    public void AddLevelCoins(int newLevelCoinsValue)
    {
        levelCoins += newLevelCoinsValue;
        UpdateLevelCoins();
    }

    public void AddCoins(int newCoinsValue)
    {
        coins += newCoinsValue;
        UpdateCoins();
        PlayerPrefs.SetInt("coins:", coins);
    }

    void UpdateLevelScore()
    {
        levelScoreText.text = "Scores: " + levelScore + "/" + scoreForNextLevel;
    }

    void UpdateLastPlayedLevel()
    {
        lastPlayedLevel= PlayerPrefs.GetInt("last played level:", lastPlayedLevel);
    }

    void UpdateCoins()
    {
        coinsText.text = "Total Coins: " + PlayerPrefs.GetInt("coins:", coins);
    }

    void UpdateLevelCoins()
    {
        levelCoinsText.text = "Coins: " + levelCoins;
    }

    public void IAmReady()
    {
        welcomeToThisLevel.enabled = false;
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        if (levelScore < scoreForNextLevel)
        {
            coinsText.enabled = true;
            scoreText.enabled = true;
            extraScore.SetActive(true);
            restartButton.SetActive(true);
            gameOverText.text = youLoseText;
            gameOver = true;
        }
        if (levelScore >= scoreForNextLevel)
        {
            gameOverText.text = congratsForNewLevel;
            gameOver = true;
        }
    }


    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //rewarded video for 250 scores

    public void ShowRewardedAdScore()
    {
        //if (Advertisement.IsReady("rewardedVideo"))
        //{
        //    var options = new ShowOptions { resultCallback = HandleShowResult };
        //    Advertisement.Show("rewardedVideo", options);
        //}
    }

    //private void HandleShowResult(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Finished:
    //            Debug.Log("The rewarded ad was successfully shown.");
    //            if(levelScore<score)
    //            {
    //                levelScore += 250;
    //                UpdateLevelScore();
    //                if (levelScore > score)
    //                {
    //                    lastPlayedLevel += 1;
    //                    PlayerPrefs.SetInt("last played level:", lastPlayedLevel);
    //                    score = levelScore;
    //                    PlayerPrefs.SetInt("score:", score);
    //                    PlayerPrefs.Save();
    //                }
    //            }

    //            if(score>=scoreForNextLevel)
    //            {
    //                gameOverText.text = congratsForNewLevel;
    //                lastPlayedLevel += 1;
    //                PlayerPrefs.SetInt("last played level: ", lastPlayedLevel);
    //                PlayerPrefs.Save();
    //                SceneManager.LoadScene(nextLevelNumber);
    //            }
    //            break;
    //        case ShowResult.Skipped:
    //            Debug.Log("The ad was skipped before reaching the end.");
    //            break;
    //        case ShowResult.Failed:
    //            Debug.LogError("The ad failed to be shown.");
    //            break;
    //    }
    //}
}