using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public List<GameObject> zedList;
	public bool runEnemy, recentlySpawned=false, toDelete=false;
    public float spawnBoundry=8.0f;//point at which to spawn a new zed
    public int maxZeds = 4;
    public GameObject ZedPrefab;
    public GameObject Player;
    PlayerManager playerScript;

	// Use this for initialization
	void Start () {
        playerScript = Player.GetComponent<PlayerManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject obby in zedList) {
			//Grab the script from the enemy
			ZedScript zedScript = obby.GetComponent<ZedScript> ();
			
		}

		if (runEnemy) {
            if (zedList.Count < maxZeds && ! recentlySpawned)
            {
                zedList.Add(Instantiate(ZedPrefab));
                ZedScript temp = zedList[zedList.Count - 1].GetComponent<ZedScript>();
                temp.Spawn((int)Random.Range(0, 4));
                recentlySpawned = true;
            }

            int i = 0;//only need to check the 3 closest zeds for collisions.
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

                 if(i<=4)
                    {
                        if(zeddy.position.x < Player.transform.position.x + 1.25f)//CHANGE THIS TO PLAYER WIDTH VARIBLE LATER
                        {//if the first 3 zeds are close enough to the player to maybe hit, check em
                            if(zeddy.whichLane == playerScript.layer){
                                Debug.Log("HIT!");
                            }
                        }
                        i++;
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
