using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

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
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        bool result = arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon);

        if (!result)
            return;

        Instantiate(prefab, hits[0].pose.position, hits[0].pose.rotation);
    }

    public void TogglePlaneManager()
    {
        arPlaneManager.enabled = !arPlaneManager.isActiveAndEnabled;
        arPlaneManager.SetTrackablesActive(arPlaneManager.enabled);
    }
}
