using UnityEngine;
using System.Collections.Generic;

public class Nodo : MonoBehaviour
{
    public string id;
    public List<Camino> conexiones = new List<Camino>();

    public Nodo ObtenerVecino(Vector3 direccion)
    {
        // Busca el nodo vecino más alineado con la dirección deseada
        Nodo mejor = null;
        float mejorPuntaje = 0f;

        foreach (var c in conexiones)
        {
            Vector3 dir = (c.destino.transform.position - transform.position).normalized;
            float puntaje = Vector3.Dot(dir, direccion.normalized);

            if (puntaje > mejorPuntaje && puntaje > 0.7f) // umbral direccional
            {
                mejor = c.destino;
                mejorPuntaje = puntaje;
            }
        }

        return mejor;
    }
}
