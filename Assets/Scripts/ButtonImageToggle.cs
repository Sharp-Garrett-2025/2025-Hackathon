using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageToggle : MonoBehaviour
{
    public Image ImageDisplayGameObject;
    public Sprite ImageToActive;
    public void ShowImage()
    {
        ImageDisplayGameObject.sprite = ImageToActive;
    }
}
