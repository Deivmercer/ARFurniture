using KTintercativeProp;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LightEstimation : MonoBehaviour
{
    private ARCameraManager arCameraManager;
    private LightProp lightProp;

    // Start is called before the first frame update
    void Start()
    {
        arCameraManager = GameObject.FindWithTag("MainCamera").GetComponent<ARCameraManager>();
        lightProp = GetComponent<LightProp>();
        arCameraManager.frameReceived += FrameChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnEnable()
    {
        // if (arCameraManager != null)
        // {
        //     arCameraManager.frameReceived += FrameChanged;
        //     debugText.text = "Added callback";
        // }
    }

    void OnDisable()
    {
        if (arCameraManager != null)
            arCameraManager.frameReceived -= FrameChanged;
    }
    
    void FrameChanged(ARCameraFrameEventArgs args)
    {
        if (!args.lightEstimation.averageBrightness.HasValue)
            return;

        lightProp.ToggleLight(args.lightEstimation.averageBrightness.Value > 0.4f);
    }
}
