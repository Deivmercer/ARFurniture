using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Object = UnityEngine.Object;

public class TapManager : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public ARPlaneManager arPlaneManager;
    public Object prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        // Ignoring touch when the user is holding the finger on the screen
        if (touch.phase != TouchPhase.Began)
            return;

        if (!arPlaneManager.isActiveAndEnabled)
            return;

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        bool result = arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon);

        if (!result)
            return;

        GameObject selectedObject = GameObject.FindWithTag("SelectedObject");
        if (selectedObject)
            selectedObject.tag = "Untagged";

        if (!prefab)
            return;

        Object newGameObject = Instantiate(prefab, hits[0].pose.position, hits[0].pose.rotation);
        newGameObject.GameObject().tag = "SelectedObject";
    }

    private void OnEnable()
    {
        TogglePlaneManager();
    }

    private void OnDisable()
    {
        TogglePlaneManager();
    }

    public void TogglePlaneManager()
    {
        arPlaneManager.enabled = !arPlaneManager.isActiveAndEnabled;
        arPlaneManager.SetTrackablesActive(arPlaneManager.enabled);
    }
}
