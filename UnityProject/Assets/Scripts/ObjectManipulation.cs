using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    public GameObject buttonCanvas;
    private GameObject _gameObject;
    private Canvas _canvas;

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

        _canvas = _gameObject.GetComponentInChildren<Canvas>();
        buttonCanvas.SetActive(true);
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

    public void ToggleShow()
    {
        if (_canvas)
            _canvas.gameObject.SetActive(!_canvas.isActiveAndEnabled);
    }

    public void DeselectObject()
    {
        _gameObject.tag = "Untagged";
        _gameObject = null;
        buttonCanvas.GetComponent<CanvasController>().Hide();
    }
}
