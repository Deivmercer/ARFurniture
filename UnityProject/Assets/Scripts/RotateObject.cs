using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private GameObject _gameObject;
    private Canvas _canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameObject)
        {
            _gameObject = GameObject.FindWithTag("RotateObject");
            if (_gameObject)
                _canvas = _gameObject.GetComponentInChildren<Canvas>();
        }
        
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
    
    // TODO: spostando il cubo sotto un oggetto vuoto riesco a ruotarlo correttamente,
    //       però il tracking sembra essere peggiorato (o magari è colpa di risparmio
    //       energetico?)
}
