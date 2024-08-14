using UnityEngine;

public class EditSelectedObject : MonoBehaviour
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
            {
                _gameObject = null;
                buttonCanvas.SetActive(false);
            }
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

    public void ToggleShow()
    {
        if (_canvas)
            _canvas.gameObject.SetActive(!_canvas.isActiveAndEnabled);
    }
}
