using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {
    public float speed;
    public float xPosition;
	public float yPosition;
    public float startX;
    public List<GameObject> individuals;
    public bool isActive = false;
    int zedCode;
    public GameObject ZedPrefab;

	// Use this for initialization
	void Start () {
        xPosition = startX;
	}


    public void Spawn(int incZedCode)
    {
        zedCode = incZedCode;
        if (zedCode % 2 == 1)
        {//lane 0
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(0);
            individuals.Add(temp);
        }
        if (zedCode % 4 > 1)
        {//lane 1
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(1);
            individuals.Add(temp);
        }
        if (zedCode % 8 > 3)
        {//lane 2
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(2);
            individuals.Add(temp);
        }
        if (zedCode % 16 > 7)
        {//lane 3
            GameObject temp = GameObject.Instantiate(ZedPrefab);
            ZedScript tempscript = temp.GetComponent<ZedScript>();
            tempscript.Spawn(3);
            individuals.Add(temp);
        }
    }

   public bool IsColliding(int lane)
    {
        switch(lane)
        {
            case 0:
                if (zedCode % 2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
             case 1:
                if (zedCode % 4 > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 2:
                if (zedCode % 8 > 3 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 3:
                if (zedCode % 16 > 7)
                {
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
				yPosition = gameObject.transform.position.y;
                gameObject.transform.position = new Vector3(xPosition,0,0);
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }

    }
}

