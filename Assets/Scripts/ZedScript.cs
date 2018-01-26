using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedScript : MonoBehaviour {

	//Speed at which enemy travels from right to left of screen
	public Vector3 speed;

	public Vector3 position;

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
		position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//Keep moving the enemy to the left of the screen
		if (gameObject.transform.position.x > endPoint.transform.position.x) {
			position -= speed;
			gameObject.transform.position = position;
			isActive = true;
		} else {
			isActive = false;
			Reset ();
		}

	}

	public void Reset()
	{
		gameObject.transform.position = startPoint.transform.position;
		position = gameObject.transform.position;
	}

	bool IsColliding()
	{
		return false;
	}
}
