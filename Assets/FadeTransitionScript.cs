using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransitionScript : MonoBehaviour
{
    private int levelToLoad;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnFadeComplete()
    {
        SceneManager.LoadSceneAsync(levelToLoad); // Replace with your game scene name
    }

    public void SetInactive()
    {
        gameObject.SetActive(false); // Deactivate the GameObject
    }

    public void FadeToLevel(int levelIndex)
    {
        gameObject.SetActive(true); // Activate the GameObject
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut"); // Trigger the fade-out animation
    }
}
