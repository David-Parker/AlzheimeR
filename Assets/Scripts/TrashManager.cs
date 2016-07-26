using UnityEngine;
using System.Collections;

public class TrashManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "HoloObject")
        {
            var holoObj = this.gameObject;
            Destroy(holoObj);
        }
    }
}
