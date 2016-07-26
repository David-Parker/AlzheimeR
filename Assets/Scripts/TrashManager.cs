﻿using UnityEngine;
using System.Collections;

public class TrashManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Colliding!");

        if (col.gameObject.tag == "HoloObject")
        {
            Debug.Log("Deleting!");
            Destroy(col.gameObject);
        }
    }
}
