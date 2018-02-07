using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DefeatSceneManager : MonoBehaviour {

    public Text gameScore;
    public Text highScore;
    // Use this for initialization
    void Start()
    {
        gameScore.text = "Game Score: "+PlayerPrefs.GetInt("GameScore").ToString();
        highScore.text = "High Score: "+PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {
        SceneManager.LoadScene("Testing_Koh");
    }
    public void EndGame()
    {
        
    }
}
