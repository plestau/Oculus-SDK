using UnityEngine;
using TMPro;
using Oculus.Voice;

public class VoiceButton : MonoBehaviour
{
    public AppVoiceExperience voice; // Reference to AppVoiceExperience
    public TMP_Text buttonText;

    private bool isListening = false;

    public void PressButton()
    {
        if (!isListening)
        {
            if (voice != null)
            {
                // Start voice recognition
                voice.Activate();
                buttonText.text = "Escuchando...";
                isListening = true;
            }
            else
            {
                Debug.LogError("AppVoiceExperience is not assigned!");
            }
        }
        else
        {
            if (voice != null)
            {
                // Stop voice recognition
                voice.Deactivate();
                buttonText.text = "Hablar";
                isListening = false;
            }
        }
    }

    void Update()
    {
        // Reset text when recognition ends
        if (isListening && voice != null && !voice.Active)
        {
            buttonText.text = "Hablar";
            isListening = false;
        }
    }
}