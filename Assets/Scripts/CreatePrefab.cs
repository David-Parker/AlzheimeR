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
       GameObject obj = (GameObject)Instantiate(prefab, this.transform.position - new Vector3(0.0f,this.transform.position.y*1.25f,0.0f), Quaternion.identity);
       obj.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Assets.Scripts.ReferenceStore.Instance.color;
    }
}
