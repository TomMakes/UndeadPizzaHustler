using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Play()
    {
        SceneManager.LoadScene("Petritsch_Testing");
    }
    public void LoadHighScore()
    {
        SceneManager.LoadScene("HighscoreScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
