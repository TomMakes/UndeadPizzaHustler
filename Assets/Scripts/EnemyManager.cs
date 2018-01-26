using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public List<GameObject> zedList;
	bool runEnemy;

	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject obby in zedList) {
			//Grab the script from the enemy
			ZedScript zedScript = obby.GetComponent<ZedScript> ();

			//If there is an enemy currently running through the game
			if (zedScript.isActive == true) {
				runEnemy = false;
				break;
			} else {
				runEnemy = true;
			}
		}

		if (runEnemy) {
			foreach (GameObject obby in zedList) {
				//Grab the script from the enemy
				ZedScript zedScript = obby.GetComponent<ZedScript> ();


				
				//If there are more than one enemy type take a random enemy obstacle and run it back through the screen
				if (zedList.Count > 1) {
					int random = Random.Range (0, zedList.Count);
					zedList [random].GetComponent<ZedScript> ().Reset ();
					break;
				} else {
					zedList [0].GetComponent<ZedScript> ().Reset ();
					break;
				}
			}
		}


		
	}
}
