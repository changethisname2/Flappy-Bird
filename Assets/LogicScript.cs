using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public TMP_Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject fadePanel;
    public GameObject pauseMenu;
    public AudioSource scoreSound;
    public AudioSource bgMusic;
    public AudioSource buttonClick;
    public AudioSource buttonHover;
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1); // Set initial volume to saved value or 1
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    [ContextMenu("Add Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScoreText.text = "High Score: " + playerScore.ToString();
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
        scoreSound.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator FadeAudio(float duration)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            bgMusic.volume = Mathf.Lerp(1f, 0f, currentTime / duration);
            currentTime += Time.fixedDeltaTime;
            yield return null;
        }
        bgMusic.volume = 0f;
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        StartCoroutine(FadeAudio(5f));
    }

    public void playButtonClick()
    {
        buttonClick.Play();
    }
    public void playButtonHover()
    {
        buttonHover.Play();
    }

    public void pauseGame()
    {
        Time.timeScale = 0; // Pause the game
        pauseMenu.SetActive(true); // Show the pause menu
    }

    public void resumeGame()
    {
        Time.timeScale = 1; // Resume the game
        pauseMenu.SetActive(false); // Hide the pause menu
    }

    public void backToMenu()
    {
        FadeTransitionScript fadeTransition = fadePanel.GetComponent<FadeTransitionScript>();
        fadeTransition.FadeToLevel(0); // Load the main menu scene (index 0)
        if (bgMusic.volume == 1f)
        {
            StartCoroutine(FadeAudio(4f));
        }
        
    }
}
