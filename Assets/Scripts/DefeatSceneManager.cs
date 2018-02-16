using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DefeatSceneManager : MonoBehaviour {

    //Textbox
    public Text gameScore;
    public Text highScore;
    public Text secondPlaceScore;
    public Text thirdPlaceScore;
    //Ints and strings to hold scores and to hold names
    int lostGameScore;
    int firstPlace;
    int secondPlace;
    int thirdPlace;
    string oldName;
    string oldNameTwo;
    string oldNameThree;
    //Name for highscore input
    string name;
    //Popup Window
    public GameObject recordkeep;

    // Use this for initialization
    void Start()
    {
        //Getting Previous score holders
        oldName = PlayerPrefs.GetString("0Names");
        oldNameTwo = PlayerPrefs.GetString("1Names");
        oldNameThree = PlayerPrefs.GetString("2Names");
        //Getting previous scores
        lostGameScore = PlayerPrefs.GetInt("GameScore");
        firstPlace = PlayerPrefs.GetInt("0HighScore");
        secondPlace = PlayerPrefs.GetInt("1HighScore");
        thirdPlace = PlayerPrefs.GetInt("2HighScore");
        //Setting text
        gameScore.text = "Game Score: " + lostGameScore;
        highScore.text = "1. "+oldName+".........." + firstPlace;
        secondPlaceScore.text = "2. " + oldNameTwo + ".........."+ secondPlace;
        thirdPlaceScore.text = "3. "+oldNameThree + ".........."+ thirdPlace;
        //Setting canvas active only if broken within top three
        if(lostGameScore>thirdPlace)
        {
            recordkeep.SetActive(true);
        }

        else
        {
            recordkeep.SetActive(false);
        }
      
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
        SceneManager.LoadScene("MainMenu");
    }
    
        public void ExitWindow()
    {
        recordkeep.SetActive(false);
    }
    public void GetName(string userInput)
    {
       
        name = userInput;
        if (lostGameScore > firstPlace)
        {
            PlayerPrefs.SetString("2Names", oldNameTwo);
            PlayerPrefs.SetString("1Names", oldName);
            PlayerPrefs.SetString("0Names", name);

        }
        if (lostGameScore > secondPlace && lostGameScore < firstPlace)
        {
            PlayerPrefs.SetString("2Names", oldNameTwo);
            PlayerPrefs.SetString("1Names", name);
        }
        if (lostGameScore > thirdPlace && lostGameScore < secondPlace)
        {
            PlayerPrefs.SetString("2Names", name);
        }

    }
}
