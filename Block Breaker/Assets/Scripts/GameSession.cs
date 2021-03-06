﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameSession : MonoBehaviour {

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
        
    //staet variables
    [SerializeField] int currentScore = 0;

    // this uses the Singleton Pattern
    private void Awake()
    {
        int gamestatusCount = FindObjectsOfType<GameSession>().Length;
        if (gamestatusCount > 1)
        {
            // dont forget the SetActive False, whitout it it can lead to nullpointer errors in certain circumstances.
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        
        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
