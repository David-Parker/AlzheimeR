using UnityEngine;
using System.Collections;

public class ColorSelect : MonoBehaviour {

    public Color color;

	// Use this for initialization
	void Start () {
        Material mat = this.GetComponent<MeshRenderer>().material;

        mat.color = color;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnSelect()
    {
        Assets.Scripts.ReferenceStore.Instance.color = color;
    }
}
