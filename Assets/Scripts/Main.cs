using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    [SerializeField] private TextMeshProUGUI textMeshProScreenSize;
    [SerializeField] private TextMeshProUGUI textMeshProRawMousePosition;
    [SerializeField] private TextMeshProUGUI textMeshProScaleFactor;
    [SerializeField] private TextMeshProUGUI textMeshProOffset;
    [SerializeField] private TextMeshProUGUI textMeshProMousePositionOfWindow;
    [SerializeField] private TextMeshProUGUI textMeshProClickedMousePositionOfWindow;
    
    private int _positionX;
    private int _positionY;

    private void Update()
    {
        GetCurrentMousePosition();
        ChangeCameraOrthoGraphicSize();
        GetClickedMousePositionOfWindow();
    }
    
    private void GetCurrentMousePosition()
    {
        var width = Screen.width;
        var height = Screen.height;
        var factor = Mathf.Min(width / 1920.0f, height / 1080f);
        var mousePosition = Input.mousePosition;
        var offsetPositionX = Mathf.Max(0, (width - height * 16 / 9) / 2);
        var offsetPositionY = Mathf.Max(0, (height - width * 9 / 16) / 2);
        var positionX = (int) ((mousePosition.x - offsetPositionX) / factor);
        var positionY = (int) ((mousePosition.y - offsetPositionY) / factor);
        _positionX = positionX;
        _positionY = positionY;

        textMeshProScreenSize.text = "Screen Size：" + width + "x" + height;
        textMeshProScaleFactor.text = "Scale Factor：" + factor.ToString("F3");
        textMeshProRawMousePosition.text = "Raw Mouse Position：x=" + mousePosition.x.ToString("F0") + "、y=" +
                                        mousePosition.y.ToString("F0");
        textMeshProOffset.text = "Offset：x=" + offsetPositionX + "、y=" + offsetPositionY;
        textMeshProMousePositionOfWindow.text = "Mouse Position of Window：x=" + positionX + "、y=" + positionY;
    }
    private void ChangeCameraOrthoGraphicSize()
    {
        if (Screen.width * 9 / Screen.height < 16)
        {
            mainCamera.orthographicSize = Screen.height * 9.6f / Screen.width;
        }
        else
        {
            mainCamera.orthographicSize = 5.4f;
        }
    }

    private void GetClickedMousePositionOfWindow()
    {
        if (Input.GetMouseButton(0))
        {
            textMeshProClickedMousePositionOfWindow.text =
                "Clicked Mouse Position of Window：x=" + _positionX + "、y=" + _positionY;
        }
    }
}
