using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int score = 0;
    [SerializeField] private float timeLeft = 60f;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timerText;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        _timerText.text = "Time: " + Mathf.Ceil(timeLeft);

        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        _scoreText.text = "Score: " + score;
    }

    private void EndGame()
    {
        Debug.Log("Игра окончена");

        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }
    
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameArea");
    }
}
