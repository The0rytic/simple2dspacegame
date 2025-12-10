using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;     // <--- TAMBAHAN DI SINI
    public float flashSpeed = 0.3f;   // kecepatan kedip
    public float delayBeforeReturn = 3f;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        StartCoroutine(FlashText());         // mulai kedip
        StartCoroutine(ReturnToMainMenu());  // mulai timer balik menu
    }

    IEnumerator FlashText()
    {
        while (true) // terus kedip sampai scene pindah
        {
            gameOverText.color = Color.red;
            yield return new WaitForSecondsRealtime(flashSpeed);

            gameOverText.color = Color.white;
            yield return new WaitForSecondsRealtime(flashSpeed);
        }
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSecondsRealtime(delayBeforeReturn);

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
