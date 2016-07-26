using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StateManager : MonoBehaviour {

    public SceneState State = SceneState.Setup;
   
    public List<SceneState> list;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}

public enum SceneState {
    Setup,
    Test
}