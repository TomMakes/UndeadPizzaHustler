using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DefeatSceneManager : MonoBehaviour {

    public Text gameScore;
    // Use this for initialization
    void Start()
    {
        gameScore.text = PlayerPrefs.GetInt("GameScore").ToString();
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
