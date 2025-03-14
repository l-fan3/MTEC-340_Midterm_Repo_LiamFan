using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MBS_GameBehaviour : MonoBehaviour
{
    public static MBS_GameBehaviour Instance;

    // Timer settings
    private float _timeRemaining = 5f; // Countdown timer starts at 60 seconds
    private bool _isGameActive = true;

    // UI Elements
    [SerializeField] public TextMeshProUGUI _messages;
    [SerializeField] public TextMeshProUGUI _timerTextUI;

    // Game state management
    public Utilities.GameplayState State = Utilities.GameplayState.Play;
    public KeyCode pause;

    void Awake()
    {
        // Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _messages.enabled = false;
        UpdateTimerUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            SwitchState();
        }

        if (State == Utilities.GameplayState.Play && _isGameActive)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            _timeRemaining = 0;
            _isGameActive = false;
            Victory();
        }
    }

    private void UpdateTimerUI()
    {
        if (_timerTextUI != null)
        {
            int minutes = Mathf.FloorToInt(_timeRemaining / 60);
            int seconds = Mathf.FloorToInt(_timeRemaining % 60);
            _timerTextUI.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    private void Victory()
    {
        State = Utilities.GameplayState.Victory;
        SceneManager.LoadScene("Victory");
    }


    

    // Unified method for switching between states
    private void SwitchState()
    {
        if (State == Utilities.GameplayState.Play)
        {
            State = Utilities.GameplayState.Pause;
            Time.timeScale = 0; // Freezes the game
            _messages.text = "The Onslaught Awaits...";
            _messages.enabled = true;
        }
        else if (State == Utilities.GameplayState.Pause)
        {
            State = Utilities.GameplayState.Play;
            Time.timeScale = 1; // Resumes the game
            _messages.enabled = false;
        }
    }

    public static class Utilities
    {
        public enum GameplayState
        {
            Play,
            Pause,
            Lose,
            Victory
        }
    }
}

