using UnityEngine;

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
        mainCanvas.tag = "Untagged";
        otherCanvas.SetActive(true);
        otherCanvas.tag = "ActiveUI";
    }

    public void Hide()
    {
        otherCanvas.SetActive(false);
        otherCanvas.tag = "Untagged";
        mainCanvas.SetActive(true);
        mainCanvas.tag = "ActiveUI";
    }
}
