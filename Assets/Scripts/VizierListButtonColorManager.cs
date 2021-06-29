using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VizierListButtonColorManager : MonoBehaviour
{
    public Color selectedColor;
    public Color normalColor;
    public Image[] images;

    public void ChangeColor(Button button)
    {
        Image currentImage = button.GetComponent<Image>();
        if (currentImage.color == normalColor)
        {
            currentImage.color = selectedColor;

            foreach (var item in images)
            {
                if(item != currentImage)
                {
                    item.color = normalColor;
                }
            }
        }
    }
}
