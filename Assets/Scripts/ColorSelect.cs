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
        //reset the other color selections
        foreach(Transform child in this.transform.parent.transform)
        {
            child.transform.localScale = new Vector3(.15f,.015f,.15f);
        }

        //make this color bigger
        this.transform.localScale = new Vector3(.2f, .02f, .2f);

        Assets.Scripts.ReferenceStore.Instance.color = color;
    }
}
