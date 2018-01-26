using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public List<GameObject> zedList;
	public bool runEnemy, recentlySpawned=false, toDelete=false;
    public float spawnBoundry=8.0f;//point at which to spawn a new zed
    public int maxZeds = 3;
    public GameObject ZedPrefab;

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
            if (zedList.Count < maxZeds && ! recentlySpawned)
            {
                zedList.Add(Instantiate(ZedPrefab));
                ZedScript temp = zedList[zedList.Count - 1].GetComponent<ZedScript>();
                temp.Spawn((int)Random.Range(0, 3));
                recentlySpawned = true;
            }

            recentlySpawned = false;
            foreach (GameObject obby in zedList) {
				//Grab the script from the enemy
				ZedScript zeddy = obby.GetComponent<ZedScript> ();          
                if(zeddy.isActive)
                {
                 if(zeddy.transform.position.x > spawnBoundry)
                    {
                        recentlySpawned = true;
                    }
                }
                else
                {
                    toDelete = true;

                }


                if(toDelete==true)
                {//garbage collection
                    zedList.RemoveAt(0);
                    toDelete = false;
                }
				
				//If there are more than one enemy type take a random enemy obstacle and run it back through the screen
			
			}
		}


		
	}
}
