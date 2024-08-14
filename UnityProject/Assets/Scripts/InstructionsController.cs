using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject instructionCanvas;
    public GameObject mainCanvas;

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
        instructionCanvas.SetActive(true);
    }

    public void Hide()
    {
        Debug.Log("Hiding");
        instructionCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
