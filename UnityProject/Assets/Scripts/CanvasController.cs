using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CanvasController : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject otherCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        mainCanvas.SetActive(false);
        otherCanvas.SetActive(true);
    }

    public void Hide()
    {
        otherCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
