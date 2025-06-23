using UnityEngine;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    private Image image;

    private Color myColor;
    private void Awake()
    {
        image = GetComponent<Image>();
        myColor = image.color;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            Color color = image.color;
            color.a = 0;
            image.color = color;
        }
        else
        {
            image.color = myColor;
        }
    }
}
