using UnityEngine;

public class TapToPlace : MonoBehaviour
{
    public bool Placing;

    void Start()
    {
        Placing = false;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        Placing = !Placing;

        // If the user is in placing mode, display the spatial mapping mesh.
        if (Placing)
        {
            SpatialMapping.Instance.DrawVisualMeshes = true;
            this.GetComponent<MeshRenderer>().material.color = Assets.Scripts.ReferenceStore.Instance.color;
            Assets.Scripts.ReferenceStore.Instance.ActiveSelection = this.gameObject;
        }
        // If the user is not in placing mode, hide the spatial mapping mesh.
        else
        {
            SpatialMapping.Instance.DrawVisualMeshes = false;
            Assets.Scripts.ReferenceStore.Instance.ActiveSelection = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (Placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f))
            {
                // Move this object's parent object to
                // where the raycast hit the Spatial Mapping mesh.
                this.transform.position = hitInfo.point;

                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.rotation = toQuat;
            }
        }
    }
}