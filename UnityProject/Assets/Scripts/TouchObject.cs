using KTintercativeProp;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchObject : MonoBehaviour, IPointerClickHandler
{
    private AnimProp animProp;

    // Start is called before the first frame update
    void Start()
    {
        animProp = GetComponent<AnimProp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CompareTag("SelectedObject"))
            RunAnimation();
        else
            SelectObject();
    }

    private void SelectObject()
    {
        GameObject currentSelectedObject = GameObject.FindWithTag("SelectedObject");
        if (currentSelectedObject)
            currentSelectedObject.tag = "Untagged";

        tag = "SelectedObject";
    }

    private void RunAnimation()
    {
        animProp.Animate();
    }
}
