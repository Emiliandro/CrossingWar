﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CoinManager : MonoBehaviour {
    public static CoinManager instance;
    private int _score;
    private int HighScore;
    private float nextTime;
    private float interval = 1.0f;
    public Text texto;
    // Use this for initialization
    void Start () {
        if(instance == null)instance = this;
        int HighScore = PlayerPrefs.GetInt("highscore");
        nextTime = 0;
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (Time.time >= nextTime)
        {
            _score ++;
            nextTime += interval;
            texto.text = (Mathf.RoundToInt(_score)).ToString();
        }
    }
    public void RestartScore()
    {
        _score = 0;
    }
    public void BoostMoney()
    {
        _score += 5;
    }
    void SaveScore()
    {
        if (_score > HighScore) PlayerPrefs.SetInt("highscore", _score);
    }
}
