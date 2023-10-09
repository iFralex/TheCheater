using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creaStanza : Photon.PunBehaviour
{
    public UnityEngine.UI.InputField nomeStanza;
    public int maxPlayers;
    public static string linkDisc, playerNickName;

    private void Start()
    {
        PhotonNetwork.automaticallySyncScene = true;

        if (!PlayerPrefs.HasKey("nome stanza"))
            PlayerPrefs.SetString("nome stanza", "");
        if (!PlayerPrefs.HasKey("numero players"))
            PlayerPrefs.SetInt("numero players", 0);
        if (!PlayerPrefs.HasKey("link discord"))
            PlayerPrefs.SetString("link discord", "");
        if (!PlayerPrefs.HasKey("publica"))
            PlayerPrefs.SetInt("publica", 0);

        nomeStanza.text = PlayerPrefs.GetString("nome stanza");
        maxPlayers = PlayerPrefs.GetInt("numero players");
        if (maxPlayers > 0)
            GetComponent<menùManager>().numPlayMax.text = maxPlayers.ToString();
        linkDisc = GetComponent<menùManager>().linkDisc.text = PlayerPrefs.GetString("link discord");
        GetComponent<menùManager>().publica.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("publica"));
    }

    public void setPlayers(string p)
    {
        int n = System.Convert.ToInt32(p);
        if (n < 2)
            n = 2;
        else if (n > 10)
            n = 10;
        maxPlayers = n;
    }

    public void ImpostaLinkDiscord(string link)
    {
        linkDisc = link;
    }

    public void CreaStanza()
    {
        if (!PhotonNetwork.connected)
            return;
        
        PlayerPrefs.DeleteKey("nome stanza");
        PlayerPrefs.SetString("nome stanza", nomeStanza.text);

        PlayerPrefs.DeleteKey("numero players");
        PlayerPrefs.SetInt("numero players", maxPlayers);

        PlayerPrefs.DeleteKey("link discord");
        PlayerPrefs.SetString("link discord", linkDisc);

        PlayerPrefs.DeleteKey("publica");
        PlayerPrefs.SetInt("publica", System.Convert.ToInt32(GetComponent<menùManager>().publica.isOn));

        RoomOptions options = new RoomOptions();
        options.IsVisible = GetComponent<menùManager>().publica.isOn;
        options.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.JoinOrCreateRoom(nomeStanza.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        GetComponent<menùManager>().ImpostaNomeVeroEFalso();
        ExitGames.Client.Photon.Hashtable h = new ExitGames.Client.Photon.Hashtable();
        h.Add("link Discord", linkDisc);
        PhotonNetwork.room.SetCustomProperties(h);
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnPhotonCreateRoomFailed(object[] message)
    {
        GetComponent<menùManager>().Errore("Impossibile creare la stanza.");
    }
}
