using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public ColorSettings colorSettings; // Reference to your ScriptableObject
    public Button startButton;
    public FlexibleColorPicker colorPicker;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartNew()
    {
        colorSettings.selectedColor = colorPicker.color;
        SceneManager.LoadScene("main");
    }

    // Update is called once per frame
    void Update()
    {

        Color normalColor = colorPicker.color;
        Color highlightedColor = AdjustBrightness(normalColor, 1.2f);
        Color pressedColor = AdjustBrightness(normalColor, 0.8f);
        Color selectedColor = AdjustTransparency(normalColor, 0.75f);
        Color disabledColor = AdjustBrightness(normalColor, 0.5f);

        startButton.colors = new ColorBlock
        {
            normalColor = normalColor,
            highlightedColor = highlightedColor,
            pressedColor = pressedColor,
            selectedColor = selectedColor,
            disabledColor = disabledColor,
            colorMultiplier = 1,
            fadeDuration = 0.1f
        };
    }


    private static Color AdjustBrightness(Color color, float factor)
    {
        return new Color(
            Mathf.Clamp01(color.r * factor),
            Mathf.Clamp01(color.g * factor),
            Mathf.Clamp01(color.b * factor),
            color.a);
    }

    private static Color AdjustTransparency(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, Mathf.Clamp01(alpha));
    }
}
