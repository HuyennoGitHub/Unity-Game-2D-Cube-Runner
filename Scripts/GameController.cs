using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;

    public float spawnTime;

    int m_score;

    float m_spawnTime;

    bool m_isGameover;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;

        if (m_spawnTime < 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnObstacle()
    {
        float randYpos = Random.Range(-1f, 0.5f);
        Vector2 spawnPos = new Vector2(11, randYpos);

        if (obstacle)
        {
            Instantiate(obstacle,spawnPos,Quaternion.identity);
        }
    }

    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }

    public void IncreaseScore()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }

    public bool IsGameover()
    {
        return m_isGameover;
    }

    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
