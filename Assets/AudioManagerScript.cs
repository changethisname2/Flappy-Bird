using System.Collections;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] private AudioSource startMenu;
    [SerializeField] private AudioSource bodyMenu;
    public AudioSource buttonClick;
    public AudioSource buttonHover;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1); // Set initial volume to saved value or 1
        Time.timeScale = 1;
        double playTime = 0.1d;
        startMenu.PlayDelayed((float)playTime);
        playTime += (double)startMenu.clip.length;
        bodyMenu.PlayDelayed((float)playTime);
    }


    public void playButtonClick()
    {
        buttonClick.time = 0.01f;
        buttonClick.Play();
    }

    public void playButtonHover()
    {
        buttonHover.Play();
    }

    public IEnumerator FadeAudio(float duration, float startVol)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            AudioListener.volume = Mathf.Lerp(startVol, 0f, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        AudioListener.volume = 0f;
    }
    
    
    void Update()
    {
        // Check if the user pressed the Escape key
        if (Input.GetKeyDown(KeyCode.Escape) && optionsMenu.activeSelf)
        {
            mainMenu.SetActive(true);
            buttonClick.Play();
        }
    }
}
