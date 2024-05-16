using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public Text Name;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    private string playerName;


    // Start is called before the first frame update
    void Start()
    {
        if (NameState.Instance == null)
        {
            SceneManager.LoadScene("menu");
            return;
        }
        TryLoadBestScore();
        playerName = NameState.Instance.PlayerName;
        Name.text = $"Player: {playerName}";
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            Time.timeScale = 1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score: {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        if (TryUpdateBestScore())
        {
            GameOverText.GetComponent<Text>().text = "New best score!";
        }
        GameOverText.SetActive(true);
    }

    private bool TryUpdateBestScore()
    {
        if (PlayerPrefs.GetInt("BestScore", 0) < m_Points)
        {
            PlayerPrefs.SetInt("BestScore", m_Points);
            PlayerPrefs.SetString("BestPlayer", playerName);
            return true;
        }
        return false;
    }

    private void TryLoadBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        string bestPlayer = PlayerPrefs.GetString("BestPlayer", "No one");
        BestScoreText.text = $"Best score: {bestScore} by {bestPlayer}";
    }
}
