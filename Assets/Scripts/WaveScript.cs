using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {
    public float speed;
    public float xPosition;
    public float startX;
    public List<ZedScript> individuals;
    bool isActive = false;
    int zedCode;

	// Use this for initialization
	void Start () {
        xPosition = startX;
	}


    void Spawn(int incZedCode)
    {
        zedCode = incZedCode;
        if (zedCode % 2 == 1)
        {//lane 0

        }
        if (zedCode % 4 > 1)
        {//lane 1

        }
        if (zedCode % 8 > 3)
        {//lane 2

        }
        if (zedCode % 16 > 7)
        {//lane 3

        }
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
}
}
