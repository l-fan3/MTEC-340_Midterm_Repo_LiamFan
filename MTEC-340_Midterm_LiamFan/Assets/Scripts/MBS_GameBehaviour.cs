using UnityEngine;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

public class MSB_GameBehaviour : MonoBehaviour
{
    public static MSB_GameBehaviour Instance;

    //scoring get set
    private int _score = 0;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            UpdateScoreUI();
        }
    }

    //Scoring UI elements
    [SerializeField] private TextMeshProUGUI _messages;
    [SerializeField] private TextMeshProUGUI _scoreTextUI;
    //pause 
    public Utilities.GameplayState State = Utilities.GameplayState.Play;
    public KeyCode pause;
    void Awake()
    {
        // Singleton Pattern

        //when creating an instance, check if one already exists,
        //and if the existing is the one that is trying to be created
        if (Instance != null && Instance != this)
        {
            //if a different instance already exists,
            //please destroy the instance that is currently being created
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _messages.enabled = false;
    }
    
  private void UpdateScoreUI()
  {
      if (_scoreTextUI != null)
      {
          _scoreTextUI.text = "Score: " + _score.ToString();
      }
  }
  

  public static class Utilities
  {
      public enum GameplayState
      {
          Play,
          Pause
      }
  }
  private void SwitchState()
  {
      if (State == Utilities.GameplayState.Play)
      {
          State = Utilities.GameplayState.Pause;
          Time.timeScale = 0; // Freezes the game
          _messages.text = "Paused";
          _messages.enabled = true;
      }
      else
      {
          State = Utilities.GameplayState.Play;
          Time.timeScale = 1; // Resumes the game
          _messages.enabled = false;
      }
  }

    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            SwitchState();
        }
    }
}


