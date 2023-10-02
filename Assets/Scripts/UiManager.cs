using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject zigzagPanel, gameOverPanel;
    public Text startText;
    public Text score, highScore, bestScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startText.enabled = false;
        zigzagPanel.GetComponent<Animator>().Play("Up Panel");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        bestScore.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Game");
    }
}
