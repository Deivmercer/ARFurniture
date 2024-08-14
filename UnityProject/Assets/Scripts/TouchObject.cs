using UnityEngine;
using UnityEngine.EventSystems;

public class TouchObject : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject currentSelectedObject = GameObject.FindWithTag("SelectedObject");
        if (currentSelectedObject)
            currentSelectedObject.tag = "Untagged";

        tag = "SelectedObject";
    }
}
