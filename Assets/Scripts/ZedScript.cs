using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedScript : MonoBehaviour {

	//Speed at which enemy travels from right to left of screen
	public Vector3 speed;

	//Is this lane a safe or deadly lane? True means it is a safe lane
	public bool lane0, lane1, lane2, lane3;


	//Where to spawn/place the enemy and where to remove it from the game.
	public GameObject startPoint;
	public GameObject endPoint;

	public bool isActive = false;


	// Use this for initialization
	void Start () {
		//Make the enemy begin at the start point
		gameObject.transform.position = startPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//Keep moving the enemy to the left of the screen
		while (gameObject.transform.position.x > endPoint.transform.position.x) {
			gameObject.transform.position -= speed;
			isActive = true;
		}
		isActive = false;

	}

	public void Reset()
	{
		gameObject.transform.position = startPoint.transform.position;
	}

	bool IsColliding()
	{
		
	}
}
