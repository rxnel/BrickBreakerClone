using UnityEngine;

public class ApplyColor : MonoBehaviour
{
    public ColorSettings colorSettings; // Reference to your ScriptableObject

    void Start()
    {
        // Apply the saved color to the GameObject's material
        GetComponent<Renderer>().material.color = colorSettings.selectedColor;
    }
}
