using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChamarCanvaPlay : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public void ToggleCanvas2()
    {
        canvas2.SetActive(!canvas2.activeSelf);
        canvas1.SetActive(!canvas1.activeSelf);
    }
}
