using UnityEngine;
using TMPro;

public class CubeMover : MonoBehaviour
{
    public float moveSpeed = 10f;
    public TMP_InputField commandInputField;
    public TextMeshProUGUI statusText;

    public Nodo nodoActual; // El nodo donde está el cubo

    void Start()
    {
        if (nodoActual == null)
        {
            Debug.LogError("Nodo actual no asignado.");
        }
    }

    public void ProcessCommand()
    {
        if (commandInputField == null || nodoActual == null)
        {
            return;
        }

        string command = commandInputField.text.ToLower().Trim();
        Vector3 direction = Vector3.zero;

        switch (command)
        {
            case "adelante":
                direction = Vector3.forward;
                break;
            case "atras":
                direction = Vector3.back;
                break;
            case "izquierda":
                direction = Vector3.left;
                break;
            case "derecha":
                direction = Vector3.right;
                break;
            default:
                statusText.text = $"Comando inválido: {command}";
                commandInputField.text = "";
                return;
        }

        // Buscar nodo destino en esa dirección
        Nodo siguienteNodo = nodoActual.ObtenerVecino(direction);

        if (siguienteNodo == null)
        {
            statusText.text = "¡Movimiento no permitido! No hay camino en esa dirección.";
            commandInputField.text = "";
            return;
        }

        // Mover el cubo al siguiente nodo
        transform.position = siguienteNodo.transform.position;
        nodoActual = siguienteNodo;

        statusText.text = $"Movido a {siguienteNodo.id}. Escribe otro comando.";
        commandInputField.text = "";
    }
}
