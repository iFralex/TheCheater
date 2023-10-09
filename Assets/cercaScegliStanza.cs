using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cercaScegliStanza : Photon.PunBehaviour
{
    public InputField cercaStanza;
    public Transform _content;
    public listaRoom _roomListing;
    public List<listaRoom> _listings = new List<listaRoom>();

    public void JoinRoomDaCampoDiRicerca()
    {
        GetComponent<menùManager>().ImpostaNomeVeroEFalso();
        PhotonNetwork.JoinRoom(cercaStanza.text);
    }

    public override void OnReceivedRoomListUpdate()
    {
        _content.GetComponent<RectTransform>().sizeDelta = new Vector2(_content.GetComponent<RectTransform>().sizeDelta.x, 0);
        RoomInfo[] roomList = PhotonNetwork.GetRoomList();
        for (int i = 0; i < 15 && i < roomList.Length; i++)
        {
            RoomInfo info = roomList[i];
            if (info.removedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else
            {
                for (int o = 0; o < _listings.Count; o++)
                    if (_listings[o].nomeStanza.text == info.Name)
                    {
                        Destroy(_listings[o].gameObject);
                        _listings.RemoveAt(o);
                    }
                _content.GetComponent<RectTransform>().sizeDelta = new Vector2(_content.GetComponent<RectTransform>().sizeDelta.x, _content.GetComponent<RectTransform>().sizeDelta.y + 150);
                listaRoom listing = Instantiate(_roomListing, _content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    _listings.Add(listing);
                }
            }
        }
    }

    public override void OnPhotonJoinRoomFailed(object[] message)
    {
        GetComponent<menùManager>().Errore("Impossibile entrare nella stanza selezionata.");
    }
}