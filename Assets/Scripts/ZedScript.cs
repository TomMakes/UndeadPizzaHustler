using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedScript : MonoBehaviour {

	//Speed at which enemy travels from right to left of screen
	public Vector3 speed;
	public Vector3 position;
    public float scoreMod = 1.0f;

    //What lane in this Zed in?
    public int whichLane;

    public GameObject ply = null;

	public bool isActive = false;
    public float startX=12.5f, endX =-12.5f;


	// Use this for initialization
	void Start () {
        //Make the enemy begin at the start point
        position.x = startX;
        position.y = -3.75f + (2.5f * whichLane);
        position.z = 1;
        gameObject.transform.position = position;
        scoreMod = PlayerManager.speed;
    }

    public void Spawn(int incLane, float sMod, GameObject player)
    {
        //Make the enemy begin at the start point
        position.x = startX;
        position.y = -3.75f + (2.5f * incLane);
        position.z = 0;
        gameObject.transform.position = position;
        isActive = true;
        whichLane = incLane;
        //scoreMod = sMod;
        //scoreMod = PlayerManager.speed;
        ply = player;
    }

    // Update is called once per frame
    void Update () {
        if (isActive)
        {
            //Keep moving the enemy to the left of the screen
            if (gameObject.transform.position.x > endX)
            {
                position -= speed * PlayerManager.speed * Time.deltaTime;
                gameObject.transform.position = position;
                isActive = true;
               // CollisionCheck(ply);
            }
            else
            {
                isActive = false;
            }
        }

	}

	public void Reset()
	{
        Spawn(whichLane, scoreMod, ply);
	}

	bool IsColliding()
	{
		return false;
	}

    bool CollisionCheck(GameObject Player)
    {/* THIS CODE IS 
        DEPRECATED.
        if (isActive == true)
        {
            if (this.position.x < Player.transform.position.x + 1.8f && this.position.x > Player.transform.position.x - 1.8f)//CHANGE THIS TO PLAYER WIDTH VARIBLE LATER
            {//if the first 3 zeds are close enough to the player to maybe hit, check em
                if (whichLane == Player.layer)
                {
                    Debug.Log("HIT!");
                    Player.GetComponent<PlayerManager>().OnHit(1, 200);
                    //this.position.y = -1000.0f;
                    isActive = false;
                    return true;
                }
            }
        }*/
        return false;
    }

    public void SetMod(float sMod)
    {
        this.scoreMod = sMod;
    }
    /*
    public void SetPlayer(PlayerManager player)
    {
        ply = player;
    }*/
}
