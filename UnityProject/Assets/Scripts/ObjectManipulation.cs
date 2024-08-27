using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    public GameObject rotationCanvas;
    public GameObject scaleCanvas;
    private GameObject _gameObject;
    private Outline _outline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameObject)
        {
            if (_gameObject.CompareTag("Untagged"))
                DeselectObject();
            else
                return;
        }

        _gameObject = GameObject.FindWithTag("SelectedObject");
        if (!_gameObject)
            return;

        StartManipulation();
    }

    public void RotateLeft()
    {
        if (_gameObject)
            _gameObject.transform.Rotate(0, -10, 0);
    }

    public void RotateRight()
    {
        if (_gameObject)
            _gameObject.transform.Rotate(0, 10, 0);
    }

    public void RotateUp()
    {
        if (_gameObject)
            _gameObject.transform.Rotate(10, 0, 0);
    }

    public void RotateDown()
    {
        if (_gameObject)
            _gameObject.transform.Rotate(-10, 0, 0);
    }

    public void IncreaseScale()
    {
        if (_gameObject)
            _gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void DecreaseScale()
    {
        if (_gameObject && _gameObject.transform.localScale.x > 0.1f)
            _gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void StartManipulation()
    {
        GameObject activeUI = GameObject.FindWithTag("ActiveUI");
        if (activeUI)
        {
            activeUI.SetActive(false);
            activeUI.tag = "Untagged";
        }
        rotationCanvas.SetActive(true);
        rotationCanvas.tag = "ActiveUI";

        _outline = _gameObject.GetComponent<Outline>();
        _outline.enabled = true;
    }

    public void DeselectObject()
    {
        _gameObject.tag = "Untagged";
        _gameObject = null;
        _outline.enabled = false;
        _outline = null;
        rotationCanvas.GetComponent<CanvasController>().Hide();
        scaleCanvas.SetActive(false);
    }
}
