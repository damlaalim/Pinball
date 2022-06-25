using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score
    {
        get => score;
        set
        {
            score = value;
            textScore.text = score.ToString();
            uiAnimator.SetTrigger(ScoreIndex);
        }
    }
    public int score;

    [SerializeField] private TextMeshPro textScore;
    
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textStart;
    [SerializeField] private TextMeshProUGUI textRestart;

    [SerializeField] private GameObject ball;
    
    [SerializeField] private Animator uiAnimator;
    
    private static readonly int ScoreIndex = Animator.StringToHash("score");

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ball.SetActive(false);
        AudioManager.Instance.Play(AudioType.Music);
    }

    public void OnGameStart()
    {
        Score = 0;

        button.gameObject.SetActive(false);
        textStart.enabled = false;
        textRestart.enabled = true;
        
        ball.SetActive(true);
    }

    public void OnGameOver()
    {
        ball.SetActive(false);
        
        ball.transform.position = Vector3.zero;
        
        button.gameObject.SetActive(true);
        
        AudioManager.Instance.Play(AudioType.Restart);
    }
}