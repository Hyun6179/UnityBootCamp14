using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SortManager : MonoBehaviour
{

    [SerializeField] private SliderController _sliderController;
    [SerializeField] private Button _createArrayButton;
    [SerializeField] private TMP_Text _arrayCountText;
    [SerializeField] private Array _array;

    [Header("Buttons")]
    [SerializeField] private Button _selectionSort;
    [SerializeField] private Button _bubbleSort;

    private Camera _mainCamera;

    public void Start()
    {
        _sliderController.SlideValueChange += SetSlideValue;
        _createArrayButton.onClick.AddListener(CreateArray);

        _selectionSort.onClick.AddListener(() => { StartCoroutine(_array.SelectionSort()); });
        _bubbleSort.onClick.AddListener(() => { StartCoroutine(_array.BubbleSort()); });

        _mainCamera = Camera.main;
    }

    private void CameraSetting()
    {
        _mainCamera.transform.position = new Vector3(_array.Size / 2, 1, -_array.Size / 2);
        _mainCamera.clearFlags = CameraClearFlags.SolidColor;
        _mainCamera.backgroundColor = Color.black;
    }

    private void SetSlideValue(float val)
    {
        _arrayCountText.text = val.ToString();
        _array.Size = (int)val;
    }

    public void CreateArray()
    {
        CameraSetting();

        _array.Initialize();
        _array.Spawn();
    }
}


