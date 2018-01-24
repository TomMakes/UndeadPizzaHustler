using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public List<GameObject> zedList;


	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach(GameObject obby in zedList)
        {
            ZedScript currentScript = obby.GetComponent<ZedScript>();
            //Check if its the farthest out

        //check if its far enough to be colliding

        //check if its in the right lane

        //handle collisions

        }

        //Spawn conditional Check
        {
            //Check the previous safe lanes
            //randomize new dangerous lanes
            //ensure that the new safe lanes are within 1 lane of the old safe lanes?
            //bitwise math
            // 0  1  2  3  4  5  6  7  8  9
            // Z O O O  Z  Z  Z  O  O  O
            // O Z O O  Z  O  O  Z  Z  O
            // O O Z O  O  Z  O  Z  O  Z
            // O O O Z  O  O  Z  O  Z  Z

        }
		
	}
}
