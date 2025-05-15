using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public TextMeshProUGUI codeDisplay, resultado;
    public string correctCode;
    private string currentInput = "";

    public void PressButton(string number)
    {
        Debug.Log($"Botón presionado: {number}");
        if (currentInput.Length >= correctCode.Length) return;

        currentInput += number;
        codeDisplay.text = currentInput;
    }

    public void PressDelete()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            codeDisplay.text = currentInput;
        }
    }

    public void PressEnter()
    {
        if (currentInput.Length == correctCode.Length)
        {
            if (currentInput == correctCode)
            {
                codeDisplay.text = "";
                resultado.text = "Codigo correcto";
            }
            else
            {
                codeDisplay.text = "";
                resultado.text = "Codigo incorrecto";
            }
        }
        else
        {
            codeDisplay.text = "";
            resultado.text = "Codigo incompleto";
        }
        Invoke(nameof(ResetCode), 2f);
    }

    private void ResetCode()
    {
        currentInput = "";
        codeDisplay.text = "";
        resultado.text = "";
    }
}