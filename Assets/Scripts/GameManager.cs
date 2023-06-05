using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool isGameStarted;
    public static int gameScore;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject tapPanel;
    [SerializeField] GameObject score;
    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        gameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
    }

    public void GM_GameOver()
    {
        gameOver = true;
        gameScore = score.GetComponent<Score>().GetScore();
        gameOverPanel.SetActive(true);
        score.SetActive(false);
    }

    public void GM_RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameHasStarted()
    {
        isGameStarted=true;
        tapPanel.SetActive(false);
    }
}
