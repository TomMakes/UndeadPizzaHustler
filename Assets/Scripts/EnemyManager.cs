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
			//Grab the script from the enemy
			ZedScript zedScript = obby.GetComponent<ZedScript> ();

			//If there is an enemy currently running through the game
			if (zedScript.isActive == true) {
				break;
			}
				
			//If there are more than one enemy type take a random enemy obstacle and run it back through the screen
			if (zedList.Count > 1) {
				zedList [Random.Range (0, zedList.Count-1)].GetComponent<ZedScript> ().Reset ();
			}
			else{
				zedList[0].GetComponent<ZedScript> ().Reset ();
        }


		
	}
}
