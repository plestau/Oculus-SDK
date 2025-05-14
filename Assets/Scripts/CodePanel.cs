using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public TextMeshProUGUI codeDisplay;
    public string correctCode = "4271";
    private string currentInput = "";

    public void PressButton(string number)
    {
        Debug.Log($"Botón presionado: {number}");
        if (currentInput.Length >= correctCode.Length) return;

        currentInput += number;
        codeDisplay.text = currentInput;

        if (currentInput.Length == correctCode.Length)
        {
            if (currentInput == correctCode)
                Debug.Log("✅ Código correcto");
            else
                Debug.Log("❌ Código incorrecto");

            Invoke(nameof(ResetCode), 2f);
        }
    }

    private void ResetCode()
    {
        currentInput = "";
        codeDisplay.text = "";
    }
}
