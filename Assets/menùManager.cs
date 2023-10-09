using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class menùManager : Photon.PunBehaviour
{
    public InputField numPlayMax, linkDisc, nomeStanza, InserisciNomeStanza, nomeFalsoIF;
    public Toggle publica, privata;
    public Button startBt, creaStanzaBot, EntraInStanzaBot, veroNomeBot;
    public ExitGames.Demos.DemoAnimator.LoaderAnime loadAnim;
    public Text erroreT;
    public GameObject disconPannel;
    public static string veroNome, nomeFalso;

    void Start()
    {
        nomeFalso = "";
        /*char[] stringa = new char[20];
        for (int i = 0; i < stringa.Length; i++)
        {
            if (Random.Range(0, 2) == 0)
                stringa[i] = (char)Random.Range(65, 91);
            else
                stringa[i] = (char)Random.Range(97, 123);
            nomeFalso += stringa[i];
        }
        nomeFalsoIF.text = nomeFalso;
        */if (!string.IsNullOrEmpty(veroNome))
            veroNomeBot.transform.parent.gameObject.SetActive(false);
        Connettiti();
        transform.GetChild(0).gameObject.SetActive(false);
        loadAnim.StartLoaderAnimation();
        Invoke("VerificaCampiCompilati", .2f);
    }

    public void Connettiti() => PhotonNetwork.ConnectUsingSettings("1");

    public void VerificaNumero(string s)
    {
        int n = System.Convert.ToInt32(s);
        if (n < 2)
            numPlayMax.text = "2";
        else if (n > 10)
            numPlayMax.text = "10";
    }

    public void VerificaToggle(int n)
    {
        if (n == 0)
            publica.isOn = !privata.isOn;
        else
            privata.isOn = !publica.isOn;
    }

    public void VerificaCampiCompilati() => creaStanzaBot.interactable = nomeStanza.text != "" && linkDisc.text != "" && numPlayMax.text != "";

    public void VerificaCampiCompilatiCerca() => EntraInStanzaBot.interactable = InserisciNomeStanza.text != "";

    public void ApriLink(string s) => Application.OpenURL(s);

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        loadAnim.StopLoaderAnimation();
        transform.GetChild(0).gameObject.SetActive(true);
        disconPannel.SetActive(false);
        if (PhotonNetwork.player.NickName != veroNome)
            PhotonNetwork.player.NickName = veroNome;
    }

    public void Errore(string messaggio)
    {
        erroreT.text = messaggio;
        StartCoroutine(AttEDis(erroreT.gameObject));
    }

    System.Collections.IEnumerator AttEDis(GameObject ob)
    {
        ob.SetActive(true);
        yield return new WaitForSeconds(2);
        ob.SetActive(false);
    }

    public override void OnDisconnectedFromPhoton() => disconPannel.SetActive(true);

    public void VerificaVeroNome(string s)
    {
        veroNomeBot.interactable = s != "";
        veroNome = s;
    }

    public void RegistraNickName()
    {
        if (PhotonNetwork.connected)
            PhotonNetwork.player.NickName = veroNome;
    }

    public void SalvaNomeFalso(string s)
    {
        if (s != "")
            nomeFalso = s;
        //else
          //  nomeFalsoIF.text = nomeFalso;
        startBt.interactable = s != "";
    }

    public void ImpostaNomeVeroEFalso()
    {
        //PhotonNetwork.player.NickName = veroNome;
        ExitGames.Client.Photon.Hashtable h = new ExitGames.Client.Photon.Hashtable();
        h.Add("nome falso", nomeFalso);
        print(nomeFalso);
        PhotonNetwork.player.SetCustomProperties(h);
    }

    public void EsciGioco() => Application.Quit();
}