using UnityEngine;
using System.Collections;

public class CreatePrefab : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnSelect()
    {
        Instantiate(prefab, new Vector3(3, 0, 3), Quaternion.identity);
    }
}
