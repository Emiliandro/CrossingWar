using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    private int _score;
    private int HighScore;
    // Use this for initialization
    void Start () {
        int HighScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update () {
	
	}

    void SaveScore()
    {
        if (_score > HighScore) PlayerPrefs.SetInt("highscore", _score);
    }
}
