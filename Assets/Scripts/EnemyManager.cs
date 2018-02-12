using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour {
    public List<GameObject> waveList;
	public bool runEnemy, recentlySpawned=false, toDelete=false;
    public float spawnBoundry=8.0f;//point at which to spawn a new zed
    public int maxZeds = 1;
    public GameObject WavePrefab;
    public GameObject Player;
    PlayerManager playerScript;
    public int testVar;

    float scoreMod;
    float time;

    // Use this for initialization
    void Start()
    {
        playerScript = Player.GetComponent<PlayerManager>();
        scoreMod = PlayerManager.speed;
        time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject obby in waveList) {
			//Grab the script from the enemy
			WaveScript wScript = obby.GetComponent<WaveScript> ();
            wScript.ply = Player;
		}

		if (runEnemy) {
            time += Time.deltaTime;
            scoreMod = PlayerManager.speed;
            //if (scoreMod < 1.0f) { scoreMod = 1.0f; }

            if (waveList.Count < maxZeds && !recentlySpawned)
            {
                waveList.Add(Instantiate(WavePrefab));
                WaveScript temp = waveList[waveList.Count - 1].GetComponent<WaveScript>();
                temp.SetModifiers(scoreMod, time);
                int q = Random.Range(0, 15);
                //int q = testVar;
                Debug.Log(q);
                temp.Spawn(q, Player);                
            }

            recentlySpawned = false;
      
            foreach (GameObject obby in waveList) {
				//Grab the script from the enemy
				WaveScript zeddy = obby.GetComponent<WaveScript> ();          
                if(zeddy.isActive)
                {


                    //zeddy.SetModifiers(scoreMod, time);

                    if (zeddy.xPosition > spawnBoundry)
                    {
                        recentlySpawned = true;
                    }               
                 
                    if(zeddy.xPosition < Player.transform.position.x + 1.8f && zeddy.xPosition > Player.transform.position.x - 1.8f)//CHANGE THIS TO PLAYER WIDTH VARIBLE LATER

                        {//if the first 3 zeds are close enough to the player to maybe hit, check em
                            if(zeddy.IsColliding(playerScript.layer)){
                                Debug.Log("HIT!");
                                playerScript.OnHit(1,200);
                            }

                        }          
                                     

                }
                else
                {
                    toDelete = true;

                }
            }
        }

        if (toDelete == true)
        {//garbage collection
            WaveScript wavey = waveList[0].GetComponent<WaveScript>();
            wavey.Purge();
            Destroy(waveList[0]);
            waveList.RemoveAt(0);            
            toDelete = false;
        }

    }
}
