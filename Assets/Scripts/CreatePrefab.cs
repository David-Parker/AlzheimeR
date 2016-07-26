using UnityEngine;
using System.Collections;

public class CreatePrefab : MonoBehaviour
{

    public GameObject prefab;

    // Use this for initialization
    void Start()
    {
        prefab = this.transform.GetChild(0).gameObject;
        MeshFilter childMesh = prefab.GetComponent<MeshFilter>();
        this.gameObject.GetComponent<MeshFilter>().mesh = childMesh.mesh;
        
        this.gameObject.GetComponent<Renderer>().material = prefab.GetComponent<Renderer>().material;

        prefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect()
    {
        var activeSelection = Assets.Scripts.ReferenceStore.Instance.ActiveSelection;
        if(activeSelection != null)
        {
            return;
        }

        GameObject obj = (GameObject)Instantiate(prefab, this.transform.position, Quaternion.identity);
        obj.SetActive(true);
        obj.tag = "HoloObject";
        obj.SendMessage("onSelect");
    }
}
