using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectObjectController : MonoBehaviour
{
    public List<Object> prefabList;
    public List<float> prefabscaleList;
    public TapManager tapManager;
    private int _currentSelection;
    private Object _preview;

    // Start is called before the first frame update
    void Start()
    {
        _currentSelection = 0;
        UpdatePreview();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNext()
    {
        _currentSelection++;
        if (_currentSelection == prefabList.Count)
            _currentSelection = 0;

        UpdatePreview();
    }

    public void SelectPrevious()
    {
        _currentSelection--;
        if (_currentSelection < 0)
            _currentSelection = prefabList.Count - 1;

        UpdatePreview();
    }

    private void UpdatePreview()
    {
        if (_preview)
            Destroy(_preview);

        _preview = Instantiate(prefabList[_currentSelection]);
        _preview.GameObject().transform.position = new Vector3(0, 0, 0);
        _preview.GameObject().transform.localScale = new Vector3(prefabscaleList[_currentSelection],
            prefabscaleList[_currentSelection],
            prefabscaleList[_currentSelection]);
        _preview.GameObject().layer = LayerMask.NameToLayer("Preview");
        var children = _preview.GetComponentsInChildren<Transform>();
        foreach (var child in children)
            child.GameObject().layer = LayerMask.NameToLayer("Preview");
    }

    public void OnPlaceButtonPressed()
    {
        tapManager.prefab = prefabList[_currentSelection];
    }
}
