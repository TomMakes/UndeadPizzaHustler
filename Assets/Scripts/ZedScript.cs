using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedScript : MonoBehaviour {

	//Speed at which enemy travels from right to left of screen
	public Vector3 speed;
	public Vector3 position;

	//Is this lane a safe or deadly lane? True means it is a safe lane
	public bool lane0, lane1, lane2, lane3;

    //What lane in this Zed in?
    public int whichLane;


	public bool isActive = false;
    public float startX=12.5f, endX =-12.5f;


	// Use this for initialization
	void Start () {
        //Make the enemy begin at the start point
        position.x = startX;
        position.y = -3.875f + (2.25f * whichLane);
        position.z = 1;
        gameObject.transform.position = position;

	}

    public void Spawn(int incLane)
    {
        //Make the enemy begin at the start point
        position.x = startX;
        position.y = -3.875f + (2.25f * incLane);
        position.z = 0;
        gameObject.transform.position = position;
        isActive = true;
        whichLane = incLane;

    }

    // Update is called once per frame
    void Update () {
        if (isActive)
        {
            //Keep moving the enemy to the left of the screen
            if (gameObject.transform.position.x > endX)
            {
                position -= speed * Time.deltaTime;
                gameObject.transform.position = position;
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }

	}

	public void Reset()
	{
        Spawn(whichLane);
	}

	bool IsColliding()
	{
		return false;
	}
}
