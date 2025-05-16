using System.Collections;
using TMPro;
using UnityEngine;

public class GestureGameStarter : MonoBehaviour
{
    private string playerGesture; // Gesto del jugador
    private string opponentGesture; // Gesto del rival
    private bool gameStarted = false;
    public TextMeshProUGUI contador, status, resultado, gesto;

    public void StartGame()
    {
        CleanText();
        status.text = "Iniciando juego de piedra, papel o tijera...";
        gameStarted = true;
        StartCoroutine(CountdownAndPlay());
    }

    private IEnumerator CountdownAndPlay()
    {
        // Cuenta atrás
        for (int i = 3; i > 0; i--)
        {
            if (!gameStarted) yield break; // Salir si el juego ha terminado
            contador.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        if (!gameStarted) yield break; // Salir si el juego ha terminado
        contador.text = "¡Ya!";

        // Da un margen de tiempo para que el jugador haga su gesto
        yield return new WaitForSeconds(2);

        if (!gameStarted) yield break; // Salir si el juego ha terminado

        // Simula el gesto del rival
        opponentGesture = GetRandomGesture();
        status.text = $"Gesto del rival: {opponentGesture}";

        // Verifica si el jugador hizo un gesto válido
        if (string.IsNullOrEmpty(playerGesture))
        {
            status.text = "No hiciste un gesto válido a tiempo.";
            yield break;
        }

        // Determina el resultado
        string result = DetermineWinner(playerGesture, opponentGesture);
        resultado.text = $"Resultado: {result}";
    }

    private string GetRandomGesture()
    {
        string[] gestures = { "Piedra", "Papel", "Tijera", "Rock", "Conejo" };
        return gestures[Random.Range(0, gestures.Length)];
    }

    private string DetermineWinner(string player, string opponent)
    {
        if (player == opponent)
            return "Empate";

        if ((player == "Piedra" && (opponent == "Tijera" || opponent == "Rock")) ||
            (player == "Papel" && (opponent == "Piedra" || opponent == "Conejo")) ||
            (player == "Tijera" && (opponent == "Papel" || opponent == "Rock")) ||
            (player == "Rock" && (opponent == "Papel" || opponent == "Conejo")) ||
            (player == "Conejo" && (opponent == "Piedra" || opponent == "Tijera")))
        {
            return "¡Ganaste!";
        }

        return "Perdiste";
    }

    public void SetPlayerGesture(string gesture)
    {
        if (gameStarted)
        {
            playerGesture = gesture;
            gesto.text = $"Tu gesto: {playerGesture}";
        }
    }

    public void FinishGame()
    {
        status.text = "Juego terminado.";
        gameStarted = false;
        ResetGame();
    }
    
    public void CleanText()
    {
        contador.text = "";
        status.text = "";
        resultado.text = "";
        gesto.text = "";
    }

    public void ResetGame()
    {
        playerGesture = "";
        opponentGesture = "";
        gameStarted = false;
        CleanText();
    }
}