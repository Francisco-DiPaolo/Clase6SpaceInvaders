using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static Action addScoreEvent;
    public static Action loseLifeEvent;
    public static Action gameOverEvent;

    public Text scoreText;
    public Text lifeText;

    public GameObject gameOverText;
    public float timeRespawn;

    [SerializeField] int life;
    [SerializeField] int score;
    GameObject playerDestroy;
    GameObject player;
    [SerializeField] Transform spawnPosition;

    void Start()
    {
        player = Resources.Load<GameObject>("Prefabs/Player");
        UpdateUi();
        InstantiatePlayer();
    }

    void UpdateUi()
    {
        scoreText.text = "Score: " + score;
        lifeText.text = "Life: " + life;
    }

    void AddScore()
    {
        score++;
        UpdateUi();
    }

    void LoseLife()
    {
        if (life > 0) 
        {
            StartCoroutine(PlayerLossLife(timeRespawn));
        }
        else GameManager.gameOverEvent?.Invoke();
    }

    void GameOver()
    {
        gameOverText.SetActive(true);
    }

    void InstantiatePlayer()
    {
        playerDestroy = Instantiate(player, spawnPosition.position, Quaternion.identity);
    }

    IEnumerator PlayerLossLife(float time)
    {
        Destroy(playerDestroy);
        playerDestroy.GetComponent<PlayerController>().isDeath = true;
        yield return new WaitForSeconds(time);
        InstantiatePlayer();
        life--;
        UpdateUi();
    }
    
    private void OnEnable()
    {
        addScoreEvent += AddScore;
        loseLifeEvent += LoseLife;
        gameOverEvent += GameOver;
    }

    private void OnDisable()
    {
        addScoreEvent -= AddScore;
        loseLifeEvent -= LoseLife;
        gameOverEvent -= GameOver;
    }
}
