using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;     }


    public void GameOver()
    {

        // Freeze seluruh game
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
