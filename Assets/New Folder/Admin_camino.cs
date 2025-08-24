using UnityEngine;
using System.Collections.Generic;

public class Admin_camino : MonoBehaviour
{
    public List<Nodo> nodos;

    void Awake()
    {
        nodos = new List<Nodo>(FindObjectsOfType<Nodo>());
    }
}

