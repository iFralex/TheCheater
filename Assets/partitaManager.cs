using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;

public class partitaManager : Photon.PunBehaviour
{
    enum Stato { domanda, discussione, attesa, tabellone, classifica }
    public RectTransform domandaPan, discussionePan, attesaPan, tabellonePan, finalePan, listaNomi, listaRisposte, listaClassifica, liastaClassificaFinale, selezionato;
    public InputField risposta;
    public Text titoloT, domandaT, nomeDomanda, nomeFinale, numDomCompPlayer, SeiStatoIndovinatiT, indovinatiT, tempoDomT, tempoDiscT, puntiT, tempoTabT, testoFinaleT;
    public int round, domandeCompletate, punti;
    System.Collections.Generic.List<int> numeriDomande = new System.Collections.Generic.List<int>(0);
    public Button inviaBt, fattoBt, continuaBt, classificaBt;
    public GameObject nomePlayer, rispostaPlayer, nomePlayerTabellone, elementiClassifica;
    public System.Collections.Generic.Dictionary<string, PhotonPlayer> dizionarioNomi = new System.Collections.Generic.Dictionary<string, PhotonPlayer>();
    public System.Collections.Generic.Dictionary<PhotonPlayer, string> dizionarioRisposte = new System.Collections.Generic.Dictionary<PhotonPlayer, string>();
    public static Color[] colori = new Color[10];
    public InputField rispostaIF;
    public bool modDifficile;
    public Font font;

    void Awake()
    {
        if (!PhotonNetwork.connected)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    void Start()
    {
        colori[0] = Color.green;
        colori[1] = Color.blue;
        colori[2] = Color.red;
        colori[3] = Color.yellow;
        colori[4] = Color.cyan;
        colori[5] = new Color(1, .5f, 0, 1);
        colori[6] = Color.magenta;
        colori[7] = new Color(0, .5f, .5f, 1);
        colori[8] = new Color(1, .5f, 1, 1);
        colori[9] = Color.gray;

        Hashtable m = new Hashtable();
        m.Add("fatto", false);
        m.Add("nome fake", menùManager.nomeFalso);
        m.Add("punti", 0);
        PhotonNetwork.player.SetCustomProperties(m);
        if (PhotonNetwork.player.IsMasterClient)
        {
            NumeriCasuali(Random.Range(0, 160));
            Hashtable h = new Hashtable();
            int[] num = new int[numeriDomande.Count];
            for (int i = 0; i < numeriDomande.Count; i++)
                num[i] = numeriDomande[i];
            h.Add("domande", num);
            PhotonNetwork.room.SetCustomProperties(h);
            for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
                m.Add(PhotonNetwork.playerList[i].NickName, 0);
            PhotonNetwork.room.SetCustomProperties(m);
            CambiaStato(Stato.domanda);
        }
        else
            StartCoroutine(RicavaElenco());
    }

    void NumeriCasuali(int n, int q = 160, int p = 7)
    {
        if (numeriDomande.Count < p)
        {
            if (!numeriDomande.Contains(n))
                numeriDomande.Add(n);
            NumeriCasuali(Random.Range(0, q), q, p);
        }
    }

    void CambiaStato(Stato s, Stato s2 = Stato.discussione)
    {
        if (s == Stato.domanda)
        {
            discussionePan.gameObject.SetActive(false);
            attesaPan.gameObject.SetActive(false);
            tabellonePan.gameObject.SetActive(false);
            ImpostaFatto(false);
            if (round != 6)
            {
                domandaPan.gameObject.SetActive(true);
                finalePan.gameObject.SetActive(false);
                if (Application.systemLanguage == SystemLanguage.Italian)
                    domandaT.text = Domande.domande[numeriDomande[round]];
                else
                    domandaT.text = Domande.domandeIng[numeriDomande[round]];
                titoloT.text = "Round " + (round + 1).ToString();
                nomeDomanda.text = PhotonNetwork.player.NickName;
                StartCoroutine(ScorriTempo(tempoDomT, 1, 20, inviaBt));
            }
            else
            {
                domandaPan.gameObject.SetActive(false);
                finalePan.gameObject.SetActive(true);
                titoloT.text = traduzioni.traduci("Classifica finale!");
                nomeFinale.text = PhotonNetwork.player.NickName;
                classificaBt.gameObject.SetActive(false);
                CreaClassifica(liastaClassificaFinale, 2090, true);
            }
        }
        else if (s == Stato.discussione)
        {
            discussionePan.gameObject.SetActive(true);
            domandaPan.gameObject.SetActive(false);
            attesaPan.gameObject.SetActive(false);
            tabellonePan.gameObject.SetActive(false);
            titoloT.text = "Round " + (round + 1).ToString();
            StartCoroutine(RicavaRisposte());
            StartCoroutine(ScorriTempo(tempoDiscT, 3, 0, fattoBt));
        }
        else if (s == Stato.attesa)
        {
            discussionePan.gameObject.SetActive(false);
            domandaPan.gameObject.SetActive(false);
            attesaPan.gameObject.SetActive(true);
            tabellonePan.gameObject.SetActive(false);
            titoloT.text = traduzioni.traduci("Attendi gli altri...");
            StartCoroutine(NumeroDomandeCompletate(s2));
        }
        else if (s == Stato.tabellone)
        {
            discussionePan.gameObject.SetActive(false);
            domandaPan.gameObject.SetActive(false);
            attesaPan.gameObject.SetActive(false);
            tabellonePan.gameObject.SetActive(true);
            titoloT.text = "Round " + (round + 1);
            StartCoroutine(DatiTabellone());
            StartCoroutine(ScorriTempo(tempoTabT, 1, 0, continuaBt));
        }
    }

    public void AttivaDomanda() => CambiaStato(Stato.domanda);

    public void AttivaAttendi()
    {
        PreparaAttesa();
        CambiaStato(Stato.attesa);
    }

    public void AttivaAttendiSecondo()
    {
        PreparaAttesa(false);
        CambiaStato(Stato.attesa, Stato.tabellone);
    }

    public void AttivaAttendiTerzo()
    {
        PreparaAttesa(false);
        CambiaStato(Stato.attesa, Stato.domanda);
    }

    void PreparaAttesa(bool a = true)
    {
        StopAllCoroutines();
        Hashtable h = new Hashtable();
        if (a)
            h.Add("risposta", risposta.text);
        h.Add("fatto", true);
        PhotonNetwork.player.SetCustomProperties(h);
    }

    public void AttivaTabellone() => CambiaStato(Stato.tabellone);

    public void VerificaDomanda(string s) => inviaBt.interactable = s != "";

    System.Collections.IEnumerator RicavaRisposte()
    {
        System.Collections.Generic.List<int> num = new System.Collections.Generic.List<int>(0);
        for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
            num.Add(i);

        for (int i = 0; i < num.Count; i++)
        {
            int temp = num[i];
            int randomIndex = Random.Range(i, num.Count);
            num[i] = num[randomIndex];
            num[randomIndex] = temp;
        }

        for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
        {
            string risp = (string)PhotonNetwork.playerList[num[i]].CustomProperties["risposta"];
            yield return new WaitUntil(() => risp != "");
            GameObject a = Instantiate(rispostaPlayer, listaRisposte);
            a.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = risp;
            if (!modDifficile)
                a.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = (string)PhotonNetwork.playerList[num[i]].CustomProperties["nome fake"];
            a.GetComponent<Button>().onClick.AddListener(() => Associa(a.GetComponent<RectTransform>()));
            a.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => NascondiAssociazione(a));
            listaRisposte.sizeDelta = new Vector2(listaRisposte.sizeDelta.x, listaRisposte.sizeDelta.y + rispostaPlayer.GetComponent<RectTransform>().sizeDelta.y + 52);
        }

        for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
        {
            string nome = PhotonNetwork.playerList[i].NickName;
            yield return new WaitUntil(() => nome != "");
            GameObject a = Instantiate(nomePlayer, listaNomi);
            a.GetComponentInChildren<Text>().text = nome;
            dizionarioNomi.Add(nome, PhotonNetwork.playerList[i]);
            listaNomi.sizeDelta = new Vector2(listaNomi.sizeDelta.x, listaNomi.sizeDelta.y + nomePlayer.GetComponent<RectTransform>().sizeDelta.y);
        }

        ImpostaFatto(false);
    }

    System.Collections.IEnumerator RicavaElenco()
    {
        yield return new WaitWhile(() => (int[])PhotonNetwork.room.CustomProperties["domande"] != null);
        int[] num = (int[])PhotonNetwork.room.CustomProperties["domande"];
        numeriDomande.Clear();
        numeriDomande.AddRange(num);
        CambiaStato(Stato.domanda);
    }

    System.Collections.IEnumerator NumeroDomandeCompletate(Stato s = Stato.discussione)
    {
        System.Collections.Generic.List<PhotonPlayer> players = new System.Collections.Generic.List<PhotonPlayer>(0);
        players.AddRange(PhotonNetwork.playerList);
        domandeCompletate = 0;
        while (PhotonNetwork.room.PlayerCount > domandeCompletate)
            for (int i = players.Count - 1; i >= 0; i--)
            {
                bool a = (bool)players[i].CustomProperties["fatto"];
                yield return new WaitForSeconds(.2f);
                if (a)
                {
                    domandeCompletate++;
                    players.RemoveAt(i);
                    numDomCompPlayer.text = domandeCompletate + "/" + PhotonNetwork.room.PlayerCount;
                }
            }
        CambiaStato(s);
    }

    System.Collections.IEnumerator DatiTabellone()
    {
        continuaBt.interactable = false;
        if (dizionarioRisposte.Count < PhotonNetwork.room.PlayerCount)
        {
            dizionarioRisposte.Clear();
            for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
                dizionarioRisposte.Add(PhotonNetwork.playerList[i], "cccccccceessaaqqwertfc22Ade4.@");
        }

        static int OrdinaPerID(PhotonPlayer p1, PhotonPlayer p2)
        {
            return p1.ID.CompareTo(p2.ID);
        }

        System.Collections.Generic.List<PhotonPlayer> players = new System.Collections.Generic.List<PhotonPlayer>(0);
        foreach (PhotonPlayer player in PhotonNetwork.playerList)
            players.Add(player);
        players.Sort(OrdinaPerID);

        SeiStatoIndovinatiT.gameObject.SetActive(false);
        yield return new WaitForSeconds((players.IndexOf(PhotonNetwork.player) + 1) * .4f);
        int n = 0;
        for (int i = 0; i < players.Count; i++)
        {
            string nome = PhotonNetwork.playerList[i].NickName;
            if ((string)players[i].CustomProperties["risposta"] == dizionarioRisposte[players[i]])
            {
                n++;
                players[i].AddScore(1);
            }
        }
        indovinatiT.text = n + "/" + PhotonNetwork.room.PlayerCount;
        if (n >= PhotonNetwork.room.PlayerCount)
        {
            modDifficile = true;
            indovinatiT.color = Color.green;
        }
        AggiungiPunti(n * 40);
        yield return new WaitForSeconds((players.Count + 1) * .4f);
        SeiStatoIndovinatiT.gameObject.SetActive(true);
        int nu = PhotonNetwork.player.GetScore();
        SeiStatoIndovinatiT.text = nu + "/" + PhotonNetwork.room.PlayerCount;
        AggiungiPunti((PhotonNetwork.room.PlayerCount - nu) * 50);
        ImpostaFatto(false);
        yield return new WaitForSeconds(.5f);
        PhotonNetwork.player.SetScore(0);
        CreaClassifica(listaClassifica, 0, false);
        continuaBt.interactable = true;
    }

    public void VerificaSelezioneRisposte()
    {
        bool a = true;
        dizionarioRisposte.Clear();
        for (int i = 0; i < listaRisposte.transform.childCount; i++)
            if (listaRisposte.transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text == "")
                a = false;
            else
                dizionarioRisposte.Add(dizionarioNomi[listaRisposte.transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text], listaRisposte.transform.GetChild(i).GetChild(0).GetComponentInChildren<Text>().text);
        fattoBt.interactable = a;
    }

    void Associa(RectTransform risp)
    {
        string t = selezionato.GetComponentInChildren<Text>().text;
        for (int i = 0; i < risp.transform.parent.childCount; i++)
        {
            if (risp.transform.parent.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text == t && risp.transform.parent.GetChild(i).gameObject != risp.gameObject)
            {
                risp.transform.parent.GetChild(i).GetChild(2).gameObject.SetActive(false);
                risp.transform.parent.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = "";
                break;
            }
        }
        selezionato.GetComponent<Image>().color = Color.black;
        risp.transform.GetChild(2).GetComponentInChildren<Text>().text = t;
        risp.transform.GetChild(2).gameObject.SetActive(true);
        selezionato.GetComponent<Outline>().enabled = true;
        selezionato = null;
        VerificaSelezioneRisposte();
    }

    void NascondiAssociazione(GameObject risp)
    {
        if (selezionato == null)
        {
            for (int i = 0; i < listaNomi.childCount; i++)
                if (listaNomi.GetChild(i).GetComponentInChildren<Outline>().enabled && listaNomi.GetChild(i).GetComponentInChildren<Text>().text == risp.transform.GetChild(2).GetComponentInChildren<Text>().text)
                {
                    listaNomi.GetChild(i).GetComponentInChildren<Outline>().enabled = false;
                    break;
                }
            risp.transform.GetChild(2).gameObject.SetActive(false);
            risp.transform.GetChild(2).GetComponentInChildren<Text>().text = "";
        }
        else
        {
            for (int i = 0; i < listaNomi.childCount; i++)
                if (listaNomi.GetChild(i).GetComponentInChildren<Outline>().enabled && listaNomi.GetChild(i).GetComponentInChildren<Text>().text == risp.transform.GetChild(2).GetComponentInChildren<Text>().text)
                {
                    listaNomi.GetChild(i).GetComponentInChildren<Outline>().enabled = false;
                    break;
                }
            Associa(risp.GetComponent<RectTransform>());
        }
    }

    System.Collections.IEnumerator ScorriTempo(Text testo, int minuti, int secondi, Button bot)
    {
        testo.text = minuti.ToString() + ":" + secondi.ToString();
        for (; ; )
        {
            yield return new WaitForSeconds(1);
            secondi--;
            if (secondi < 0)
            {
                minuti--;
                secondi = 59;
            }
            if (minuti < 0)
                break;
            string s = ":";
            if (secondi < 10)
                s = ":0";
            testo.text = minuti.ToString() + s + secondi.ToString();
        }

        bot.onClick.Invoke();
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        if (!finalePan.gameObject.activeInHierarchy && PhotonNetwork.room.PlayerCount < 2)
            PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() => UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    public void Esci() => PhotonNetwork.LeaveRoom();

    void AggiungiPunti(int n)
    {
        punti += n;
        puntiT.text = traduzioni.traduci("Punti: ") + punti.ToString();
        Hashtable m = new Hashtable();
        m.Add("punti", punti);
        PhotonNetwork.player.SetCustomProperties(m);
    }

    public void RoundSuccessivo()
    {
        AttivaAttendiTerzo();
        round++;
        dizionarioRisposte.Clear();
        dizionarioNomi.Clear();
        selezionato = null;
        for (int i = 0; i < listaRisposte.childCount; i++)
            Destroy(listaRisposte.GetChild(i).gameObject);
        for (int i = 0; i < listaNomi.childCount; i++)
            Destroy(listaNomi.GetChild(i).gameObject);
        listaRisposte.sizeDelta = new Vector2(listaRisposte.sizeDelta.x, 0);
        listaNomi.sizeDelta = new Vector2(listaNomi.sizeDelta.x, 0);
        rispostaIF.text = "";
        inviaBt.interactable = fattoBt.interactable = false;
        for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
        {
            Hashtable m = new Hashtable();
            m.Add(PhotonNetwork.playerList[i].NickName, 0);
            PhotonNetwork.room.SetCustomProperties(m);
        }
    }

    void ImpostaFatto(bool b)
    {
        Hashtable h = new Hashtable();
        h.Add("fatto", b);
        PhotonNetwork.player.SetCustomProperties(h);
    }

    public void CreaClassifica(RectTransform posSpown, int larg, bool evidenziaIlPrimo)
    {
        bool vinto = false;
        classificaBt.interactable = true;
        System.Collections.Generic.SortedDictionary<int, string> dizPunti = new System.Collections.Generic.SortedDictionary<int, string>();

        for (int i = 0; i < listaClassifica.childCount; i++)
            Destroy(listaClassifica.GetChild(i).gameObject);

        static int OrdinaPerID(PhotonPlayer p1, PhotonPlayer p2)
        {
            return p1.ID.CompareTo(p2.ID);
        }

        System.Collections.Generic.List<PhotonPlayer> players = new System.Collections.Generic.List<PhotonPlayer>(0);
        foreach (PhotonPlayer player in PhotonNetwork.playerList)
            players.Add(player);
        players.Sort(OrdinaPerID);

        for (int i = 0; i < players.Count; i++)
        {
            void Aggiungi(int l, string st)
            {
                if (!dizPunti.ContainsKey(l))
                    dizPunti.Add(l, st);
                else
                    Aggiungi(l + 1, st);
            }
            Aggiungi((int)players[i].CustomProperties["punti"], players[i].NickName);
        }

        System.Collections.Generic.List<int> keyPunti = new System.Collections.Generic.List<int>(0);
        foreach (int s in dizPunti.Keys)
            keyPunti.Add(s);
        
        for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
        {
            Transform a = Instantiate(elementiClassifica, posSpown).transform;
            posSpown.sizeDelta = new Vector2(posSpown.sizeDelta.x, posSpown.sizeDelta.y + 125);
            if (larg != 0)
                a.GetComponent<RectTransform>().sizeDelta = new Vector2(larg, 100);
            if (evidenziaIlPrimo && i == 0)
                a.GetComponent<Image>().color = Color.yellow;
            if (evidenziaIlPrimo && dizPunti[keyPunti[PhotonNetwork.room.PlayerCount - 1 - i]] == PhotonNetwork.player.NickName && i == 0)
                vinto = true;
            a.GetChild(0).GetComponent<Text>().text = (i + 1).ToString() + ")";
            a.GetChild(1).GetComponent<Text>().text = dizPunti[keyPunti[PhotonNetwork.room.PlayerCount - 1 - i]];
            a.GetChild(2).GetComponent<Text>().text = keyPunti[PhotonNetwork.room.PlayerCount - 1 - i].ToString();
        }

        if (evidenziaIlPrimo && vinto)
        {
            nomeFinale.transform.parent.GetComponent<Image>().color = new Color(.85f, .65f, .12f, 1);
            testoFinaleT.text = traduzioni.traduci("Complimenti, i tuoi amici dovrebbero tenersi alla larga da te, sei stato troppo bravo a imbrogliare e manipolare gli altri. Tu sei THE CHEATER!");
        }
    }
}