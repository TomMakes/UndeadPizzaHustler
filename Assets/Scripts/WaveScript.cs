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
    public GameObject ZedPrefab;
    public float scoreMod;
    public float time;
    public GameObject ply = null;

	// Use this for initialization
	void Start () {
        xPosition = startX;
        scoreMod = 1.0f;
        time = 0.0f;
	}


    public void Spawn(int incZedCode, GameObject player)
    {
        ply = player;
        GameObject empty = new GameObject();
        individuals.Add(empty);
        individuals.Add(empty);
        individuals.Add(empty);
        individuals.Add(empty);

        zedCode = incZedCode;
        if (zedCode % 2 == 1)
        {//lane 0
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            //tempscript.scoreMod = this.scoreMod;
            //tempscript.ply = this.ply;
            tempscript.Spawn(0, this.scoreMod, ply);
            individuals[0]=temp;
        }
        if (zedCode % 4 > 1)
        {//lane 1
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            //tempscript.scoreMod = this.scoreMod;
            //tempscript.ply = this.ply;
            tempscript.Spawn(1, this.scoreMod, ply);
            individuals[1] = temp;
        }
        if (zedCode % 8 > 3)
        {//lane 2
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            //tempscript.scoreMod = this.scoreMod;
            //tempscript.ply = this.ply;
            tempscript.Spawn(2, this.scoreMod, ply);
            individuals[2] = temp;
        }
        if (zedCode % 16 > 7)
        {//lane 3
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            //tempscript.scoreMod = this.scoreMod;
            //tempscript.ply = this.ply;
            tempscript.Spawn(3, this.scoreMod, ply);
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
                xPosition -= speed * scoreMod * Time.deltaTime;
                for (int i = 0; i < individuals.Count; i++)
                /*{
                    //ZedScript z = individuals[i].GetComponent<ZedScript>();
                    //zomb.GetComponent<ZedScript>().SetMod(this.scoreMod);
                    //z.SetMod(this.scoreMod);
                    //individuals[i].GetComponent<ZedScript>().SetMod(this.scoreMod);
                    
                }*/
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

    public void SetModifiers(float sMod, float t){
        this.scoreMod = sMod;
        this.time = t;
    }
}

