using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class listaRoom : Photon.PunBehaviour
{
    public Text numeroPlayers, nomeStanza;
    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        numeroPlayers.text = roomInfo.PlayerCount.ToString() + "/" + roomInfo.MaxPlayers;
        nomeStanza.text = roomInfo.Name;
    }

    public void EntraInStanzaSelezionata()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
