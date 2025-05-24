using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject optionsMenu;
    public AudioManagerScript audioManagerScript;
    public void PlayGame()
    {
        FadeTransitionScript fadeTransition = fadePanel.GetComponent<FadeTransitionScript>();
        fadeTransition.FadeToLevel(1); // Load the game scene (index 1)
        StartCoroutine(audioManagerScript.FadeAudio(1f, AudioListener.volume));
    }


    public void Quit()
    {
        Application.Quit();
    }


}
