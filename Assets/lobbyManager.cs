using UnityEngine;
using UnityEngine.UI;

public class lobbyManager : Photon.PunBehaviour
{
    public InputField nomeStanza, linkDisc;
    public Text numPlayers;
    public Toggle publica, privata;
    public Button startBot;
    
    void Start()
    {
        if (!PhotonNetwork.connected && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        if (!PhotonNetwork.player.IsMasterClient)
            startBot.gameObject.SetActive(false);
        VerificaDatiStanza();
    }

    void VerificaDatiStanza()
    {
        nomeStanza.text = PhotonNetwork.room.Name;
        numPlayers.text = PhotonNetwork.room.PlayerCount + "/" + PhotonNetwork.room.MaxPlayers;
        if (PhotonNetwork.room.IsVisible)
        {
            publica.isOn = true;
            privata.isOn = false;
        }
        else
        {
            privata.isOn = true;
            publica.isOn = false;
        }
        linkDisc.text = (string)PhotonNetwork.room.CustomProperties["link Discord"];
    }

    public void ApriLink() => Application.OpenURL(linkDisc.text);

    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        numPlayers.text = PhotonNetwork.room.PlayerCount + "/" + PhotonNetwork.room.MaxPlayers;
        VerificaIniziaBottone();
    }

    public override void OnMasterClientSwitched(PhotonPlayer newMasterClient) => startBot.gameObject.SetActive(newMasterClient == PhotonNetwork.player);

    public override void OnPhotonPlayerConnected(PhotonPlayer otherPlayer)
    {
        numPlayers.text = PhotonNetwork.room.PlayerCount + "/" + PhotonNetwork.room.MaxPlayers;
        VerificaIniziaBottone();
    }

    void VerificaIniziaBottone() => startBot.interactable = PhotonNetwork.room.PlayerCount >= 2;

    public override void OnLeftRoom() => UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    public void Esci() => PhotonNetwork.LeaveRoom();

    public void IniziaPartita() => PhotonNetwork.LoadLevel(2);
}