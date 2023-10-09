using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigazioneMenù : MonoBehaviour
{
    public List<GameObject> percorso = new List<GameObject>(1);
    public GameObject indietroBot;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Indietro()
    {
        percorso[percorso.Count - 1].SetActive(false);
        percorso.RemoveAt(percorso.Count - 1);
        percorso[percorso.Count - 1].SetActive(true);
        if (percorso.Count == 1)
        {
            indietroBot.SetActive(false);
        }
    }

    public void Premi(GameObject pulsante)
    {
        if (percorso.Count == 1)
        {
            indietroBot.SetActive(true);
        }
        percorso[percorso.Count - 1].SetActive(false);
        percorso.Add(pulsante);
        pulsante.SetActive(true);
    }
}
