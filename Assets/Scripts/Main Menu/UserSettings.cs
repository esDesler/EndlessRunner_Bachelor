using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UserSettings : MonoBehaviour
{
    public AudioMixer gameMixer;
    public AudioMixer menuMixer;

    // Volume sliders
    public Slider masterSlider;
    public Slider menuSlider;
    public Slider gameSlider;
    public Slider jumpLoopSlider;
    public Slider slideLoopSlider;
    public Slider actionSoundSlider;

    // Game mode toggles
    public Toggle audioToggle;
    public Toggle hapticToggle;
    public Toggle visualToggle;

    public GameObject blackScreen;

    // Current volumes
    private float master;
    private float menuMusic;
    private float gameMusic;
    private float jumpLoop;
    private float slideLoop;
    private float actionSound;

    // Current game mode
    private bool audioMode;
    private bool hapticMode;
    private bool visualMode;

    private void Start()
    {
        LoadSettings();
    }

    public void SetMasterVolume (float volume)
    {
        gameMixer.SetFloat("Game master volume", volume);
        menuMixer.SetFloat("Menu master volume", volume);
        master = volume;
    } 
    
    public void SetMenuVolume (float volume)
    {
        menuMixer.SetFloat("Menu music volume", volume);
        menuMusic = volume;
    }
    
    public void SetGameVolume (float volume)
    {
        gameMixer.SetFloat("Game music volume", volume);
        gameMusic = volume;
    } 
    
    public void SetJumpLoopVolume (float volume)
    {
        gameMixer.SetFloat("Jump loop volume", volume);
        jumpLoop = volume;
    }

    public void SetSlideLoopVolume(float volume)
    {
        gameMixer.SetFloat("Slide loop volume", volume);
        slideLoop = volume;
    }

    public void SetActionSoundVolume(float volume)
    {
        gameMixer.SetFloat("Action sound volume", volume);
        actionSound = volume;
    }

    public void SetAudioMode(bool audioMode)
    {
        this.audioMode = audioMode;

        if (audioMode)
        {
            // Turn on UAP screen reader
            UAP_AccessibilityManager.EnableAccessibility(true);

            // Turn off menu navigation sounds as UAP system will be used instead
            menuMixer.SetFloat("Navigation volume", -80);

            // Turn on blackscreen
            blackScreen.SetActive(true);
        }        
    }

    public void SetHapticMode(bool hapticMode)
    {
        this.hapticMode = hapticMode;

        if (hapticMode)
        {
            // Turn on UAP screen reader
            UAP_AccessibilityManager.EnableAccessibility(true);

            // Turn off menu navigation sounds as UAP system will be used instead
            menuMixer.SetFloat("Navigation volume", -80);

            // Turn on blackscreen
            blackScreen.SetActive(true);
        }
    }

    public void SetVisualMode(bool visualMode)
    {
        this.visualMode = visualMode;

        if (visualMode)
        {
            // Turn back on menu sounds
            menuMixer.SetFloat("Navigation volume", 0);

            // Turn off blackscreen
            blackScreen.SetActive(false);
        }
    }

    public void SaveSettings()
    {
        // Save audio settings
        PlayerPrefs.SetFloat("master volume", master);
        PlayerPrefs.SetFloat("menu music volume", menuMusic);
        PlayerPrefs.SetFloat("game music volume", gameMusic);
        PlayerPrefs.SetFloat("jump loop volume", jumpLoop);
        PlayerPrefs.SetFloat("slide loop volume", slideLoop);
        PlayerPrefs.SetFloat("action sound volume", actionSound);

        // Save game mode selection
        PlayerPrefs.SetInt("audio mode", Convert.ToInt32(audioMode));
        PlayerPrefs.SetInt("haptic mode", Convert.ToInt32(hapticMode));
        PlayerPrefs.SetInt("visual mode", Convert.ToInt32(visualMode));

        if (visualMode)
        {
            // Turn off UAP screen reader
            UAP_AccessibilityManager.EnableAccessibility(false);
        }
    }

    public void LoadSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat("master volume", 0);
        menuSlider.value = PlayerPrefs.GetFloat("menu music volume", 0);
        gameSlider.value = PlayerPrefs.GetFloat("game music volume", -8);
        jumpLoopSlider.value = PlayerPrefs.GetFloat("jump loop volume", -4);
        slideLoopSlider.value = PlayerPrefs.GetFloat("slide loop volume", 0);
        actionSoundSlider.value = PlayerPrefs.GetFloat("action sound volume", -3);

        audioToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("audio mode", 1));
        hapticToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("haptic mode", 0));
        visualToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("visual mode", 0));

        if (visualMode)
        {
            // Turn off UAP screen reader
            UAP_AccessibilityManager.EnableAccessibility(false);
        }
    }

    public void RevertChanges()
    {
        LoadSettings();
    }
}
