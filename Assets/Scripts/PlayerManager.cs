using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public int layer=0;
    Vector3 newPosition;
    public int lives;
    public int score = 0;
    float time=0;
    bool ifExist;
    public Text scoreText;
    public Image lifebar;
    public Sprite health2;
    public Sprite health1;

    // Use this for initialization
    void Start ()
    {

        newPosition = gameObject.transform.position;
        PlayerPrefs.SetInt("GameScore", score);
        
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

		if (Input.GetKeyDown("a"))
		{
			newPosition.x -= 0.1f;
		}

		if (Input.GetKeyDown("d"))
		{
			newPosition.x += 0.1f;
			print ("Moving Forward!");
		}
        time += Time.deltaTime;
        score = (int)time * 100;
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
            SceneManager.LoadScene("GameOverScene");

        }
    }
    public void OnHit(int hit,int penalty)
    {
        lives -= hit;
        score -= penalty;
    }
}
