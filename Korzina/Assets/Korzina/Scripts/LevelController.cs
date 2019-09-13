using Dialogs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : Singleton<LevelController>
{
    public Text Health;
    public Text Score;
    public Text MaxScore;
    public SpawnerController spawnerController;
    public ColliderHandler colliderHandler;
    public PlayerController playerController;

    public static event Action CatchObjectEvent;

    public int health = 5;
    public int score = 0;

    public const string KEY = "MAX_SCORE_KEY";

    private void Start()
    {
        Health.text = health.ToString();
        Score.text = score.ToString();
        if (PlayerPrefs.HasKey(KEY))
        {
            MaxScore.text = PlayerPrefs.GetInt(KEY).ToString();
        }
        else
        {
            MaxScore.text = "0";
        }
        colliderHandler.CollisionEvent += ColliderHandler_CollisionEvent;
        playerController.CatchEvent += PlayerController_CatchEvent;
        StartCoroutine("spawnCoroutine");
    }

    private void PlayerController_CatchEvent(bool Obj)
    {
        if (Obj)
        {
            health++;
            score++;
            if (PlayerPrefs.HasKey(KEY))
            {
                if (score > PlayerPrefs.GetInt(KEY))
                {
                    PlayerPrefs.SetInt(KEY, score);
                }
            }
            else
            {
                PlayerPrefs.SetInt(KEY, score);
            }
        }
        else
        {
            health--;
            if (health <= 0)
            {
                StopCoroutine("spawnCoroutine");
                DialogController.Instance.ShowDialog("Lose");
            }
        }
        UpdateUI();
    }

    private void ColliderHandler_CollisionEvent(bool Obj)
    {
        if(!Obj)
        {
            health--;
            if (health <= 0)
            {
                StopCoroutine("spawnCoroutine");
                DialogController.Instance.ShowDialog("Lose");
            }
        }
        UpdateUI();
    }

    private IEnumerator spawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(2f);
            spawnerController.Spawn();
        }
    }

    private void UpdateUI()
    {
        Health.text = health.ToString();
        Score.text = score.ToString();
        if (PlayerPrefs.HasKey(KEY))
        {
            MaxScore.text = PlayerPrefs.GetInt(KEY).ToString();
        }
        else
        {
            MaxScore.text = "0";
        }
    }

    public void ExitMainScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void Restart()
    {
        health = 5;
        score = 0;
        UpdateUI();
        StartCoroutine("spawnCoroutine");
    }

    private void OnDestroy()
    {
        colliderHandler.CollisionEvent -= ColliderHandler_CollisionEvent;
        playerController.CatchEvent -= PlayerController_CatchEvent;
        StopCoroutine("spawnCoroutine");
    }
}