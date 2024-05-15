using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField inputField; // Use TMP_InputField instead of InputField
    public Button submitButton;

    private void Start()
    {
        // Ensure the button is disabled if the input field is initially empty
        submitButton.interactable = !string.IsNullOrEmpty(inputField.text);

        // Add a listener to call the OnInputFieldChanged method whenever the input field's value changes
        inputField.onValueChanged.AddListener(OnInputFieldChanged);
    }

    private void OnInputFieldChanged(string input)
    {
        // Enable the button if the input field is not empty, disable it otherwise
        submitButton.interactable = !string.IsNullOrEmpty(input);
    }
}
