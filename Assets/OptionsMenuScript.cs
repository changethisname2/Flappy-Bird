using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionsMenuScript : MonoBehaviour
{
    Resolution[] resolutions;
    List<Resolution> resList = new List<Resolution>();
    int currResIdx;
    bool isFullscreen;
    public Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1); // Set the initial volume to saved value or 1

        isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1; // Get the current fullscreen setting from PlayerPrefs
        fullscreenToggle = GameObject.Find("IsFullscreen").GetComponent<Toggle>();
        fullscreenToggle.isOn = isFullscreen;

        // Get all available resolutions
        resolutions = Screen.resolutions;
        currResIdx = PlayerPrefs.GetInt("Res", resolutions.Length - 1); // Get the current resolution index from PlayerPrefs
        
        // Set the resolution dropdown options
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (!options.Contains(option))
            {
                options.Add(option);
                resList.Add(resolutions[i]);
            }
            
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResIdx;
        resolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        // Update the volume and fullscreen settings based on user input
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
    public void SetVolume(float volume)
    {
        // Set the volume of the game
        AudioListener.volume = volume;
        // Save the volume setting
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void SetFullscreen()
    {
        // Set the fullscreen mode of the game
        isFullscreen = fullscreenToggle.isOn;
        Screen.SetResolution(Screen.width, Screen.height, isFullscreen);
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        //Debug.Log("Fullscreen: " + PlayerPrefs.GetInt("Fullscreen"));
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        // Set the resolution of the game
        Resolution resolution = resList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullscreen);
        currResIdx = resolutionIndex;
        PlayerPrefs.SetInt("Res", currResIdx);
        PlayerPrefs.Save();
    }
}
