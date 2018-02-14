using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DefeatSceneManager : MonoBehaviour {

    public Text gameScore;
    public Text highScore;
    public Text secondPlaceScore;
    public Text thirdPlaceScore;
    // Use this for initialization
    void Start()
    {
        gameScore.text = "Game Score: "+PlayerPrefs.GetInt("GameScore").ToString();
        highScore.text = "1. "+PlayerPrefs.GetInt("0HighScore").ToString();
        secondPlaceScore.text = "2. " + PlayerPrefs.GetInt("1HighScore").ToString();
        thirdPlaceScore.text = "3. " + PlayerPrefs.GetInt("2HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {
        SceneManager.LoadScene("Petritsch_Testing");
    }
    public void EndGame()
    {
        
    }
}
