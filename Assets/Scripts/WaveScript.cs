using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {
    public float speed;
    public float xPosition;
    public float startX;
    public List<GameObject> individuals;
    public bool isActive = false;
    public int zedCode;
    public GameObject TopZedPrefab;
    public GameObject HMidZedPrefab;
    public GameObject LMidZedPrefab;
    public GameObject BotZedPrefab;

    // Use this for initialization
    void Start () {
        xPosition = startX;
	}


    public void Spawn(int incZedCode)
    {
        GameObject empty = new GameObject();
        individuals.Add(empty);
        individuals.Add(empty);
        individuals.Add(empty);
        individuals.Add(empty);

        zedCode = incZedCode;
        if (zedCode % 2 == 1)
        {//lane 0
            GameObject temp = Instantiate(BotZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(0);
            individuals[0]=temp;
        }
        if (zedCode % 4 > 1)
        {//lane 1
            GameObject temp = Instantiate(LMidZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(1);
            individuals[1] = temp;
        }
        if (zedCode % 8 > 3)
        {//lane 2
            GameObject temp = Instantiate(HMidZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(2);
            individuals[2] = temp;
        }
        if (zedCode % 16 > 7)
        {//lane 3
            GameObject temp = Instantiate(TopZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(3);
            individuals[3] = temp;
        }
    }

   public bool IsColliding(int lane)
    {
        switch(lane)
        {
            case 0:
                if (zedCode % 2 == 1)
                {
                    Destroy(individuals[0]);
                    individuals[0] = new GameObject();
                    zedCode -= 1;
                    return true;
                }
                else
                {
                    return false;
                }
                
             case 1:
                if (zedCode % 4 > 1)
                {
                    Destroy(individuals[1]);
                    individuals[1] = new GameObject();
                    zedCode -= 2;
                    return true;
                }
                else
                {
                    return false;
                }
            case 2:
                if (zedCode % 8 > 3 )
                {
                    Destroy(individuals[2]);
                    individuals[2] = new GameObject();
                    zedCode -= 4;
                    return true;
                }
                else
                {
                    return false;
                }
            case 3:
                if (zedCode % 16 > 7)
                {
                    Destroy(individuals[3]);
                    individuals[3] = new GameObject();
                    zedCode -= 8;
                    return true;
                }
                else
                {
                    return false;
                }
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            //Keep moving the enemy to the left of the screen
            if (gameObject.transform.position.x > -startX)
            {
                xPosition -= speed * Time.deltaTime;
                gameObject.transform.position = new Vector3(xPosition,0,0);
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }

    }

    

    public void Purge() { 
        foreach(GameObject Zed in individuals)
        {
            Object.Destroy(Zed);          
        }
        while(individuals.Count > 0)
        {
            individuals.RemoveAt(0);
        }
    }
}

