using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManager : MonoBehaviour {
    public int layer=0;
    Vector3 newPosition;


	// Use this for initialization
	void Start () {

        newPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        newPosition = gameObject.transform.position;
        newPosition.y = -3.875f + (2.25f * layer);

        if (Input.GetKeyDown("w"))
        {
            layer++;
            if(layer > 3)
            {
                layer = 3;
            }

        }

        if (Input.GetKeyDown("s"))
        {
            layer--;
            if (layer < 0)
            {
                layer = 0;
            }

        }

        gameObject.transform.position = newPosition;
    }
}
