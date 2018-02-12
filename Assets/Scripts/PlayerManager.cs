using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public int layer=0;
    Vector3 newPosition;
    public int lives;
    public int highscore;
    public int score = 0;
    int oldScore;
    float time=0;
    bool ifExist;
    public Text scoreText;
    public Image lifebar;
    public Sprite health2;
    public Sprite health1;

    public static float speed;

    // Use this for initialization
    void Start ()
    {

        newPosition = gameObject.transform.position;
        PlayerPrefs.SetInt("GameScore", score);
        speed = 1.0f;
        ifExist = true;
        
	}
	
	// Update is called once per frame
	void Update () {
        newPosition = gameObject.transform.position;
        newPosition.y = -3.75f + (2.5f * layer);

        if (Input.GetKeyDown("w"))
        {
            layer++;
            if(layer > 3)
            {
                layer = 3;
            }

        }

        if (Input.GetKeyDown("s"))
        {
            layer--;
            if (layer < 0)
            {
                layer = 0;
            }

        }

		if (Input.GetKey("a"))
		{
			newPosition.x -= 5 * speed * Time.deltaTime;
            if(newPosition.x < -12.5f)
            {
                newPosition.x = -12.5f;
            }
            
		}

		if (Input.GetKey("d"))
		{
			newPosition.x += 2.5f* speed * Time.deltaTime;
            if (newPosition.x > 12.5f)
            {
                newPosition.x = 12.5f;
            }

        }
        time += Time.deltaTime;
        score = (int)time * 100;
        speed = 1 + (time / 10.0f);
        if (speed < 1.0f) { speed = 1.0f; }
        //if (speed > 1.0f && speed < 1.25f ) { speed = 1.25f; }
        //if (speed > 1.25f && speed < 1.5f) { speed = 1.5f; }
        //if (speed > 1.5f && speed < 1.75f) { speed = 1.25f; }
        else if (speed > 2.5f) { speed = 2.5f; }
        Debug.Log(speed);
        scoreText.text = "Score: " + score;
        gameObject.transform.position = newPosition;

        if (lives == 2)
        {
            lifebar.sprite = health2;
        }
        if (lives == 1)
        {
            lifebar.sprite = health1;
        }
        if (lives <= 0)
        {
           
            PlayerPrefs.SetInt("GameScore", score);
            AddScore(score);
            SceneManager.LoadScene("GameOverScene");
        }
       
    }
    void AddScore(int curscore)
    {
        int gameScore = curscore;
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HighScore"))
            {
                if (PlayerPrefs.GetInt(i + "HighScore") < gameScore)
                {
                    oldScore = PlayerPrefs.GetInt(i + "HighScore");
                    PlayerPrefs.SetInt(i + "HighScore", gameScore);
                    gameScore = oldScore;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + "HighScore", gameScore);
                

            }
        }
    }
    public void OnHit(int hit,int penalty)
    {
        lives -= hit;
        score -= penalty;
    }
}
