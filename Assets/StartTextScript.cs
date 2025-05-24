using UnityEngine;

public class StartTextScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0; // Pause the game at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1; // Resume the game when space or mouse button is pressed
            gameObject.SetActive(false); // Deactivate the GameObject
        }
    }
}
