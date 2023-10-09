using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragAndDrop : Photon.MonoBehaviour
{
    public PhotonPlayer player;
    string nome;
    Transform padre;

    void Start()
    {
        padre = transform.parent;
    }

    public void Seleziona(RectTransform elemento)
    {
        if (elemento.GetComponent<Image>().color != Color.green)
        {
            for (int i = 0; i < elemento.parent.childCount; i++)
            {
                if (elemento.parent.GetChild(i).GetComponent<Image>().color == Color.green)
                {
                    elemento.parent.GetChild(i).GetComponent<Image>().color = Color.black;
                }
            }
            elemento.GetComponent<Image>().color = Color.green;
            FindObjectOfType<partitaManager>().selezionato = elemento;
        }
        else
        {
            elemento.GetComponent<Image>().color = Color.black;
            FindObjectOfType<partitaManager>().selezionato = null;
        }
    }
}