using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public ColorSettings colorSettings; // Reference to your ScriptableObject
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

    }
}
