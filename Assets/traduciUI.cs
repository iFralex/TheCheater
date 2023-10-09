using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class traduciUI : MonoBehaviour
{
    void Awake() => GetComponent<Text>().text = traduzioni.traduci(GetComponent<Text>().text);
}

static public class traduzioni// : MonoBehaviour
{
    public static Dictionary<string, string> traduzione = new Dictionary<string, string>
    {
        { "Clicca qui!", "Click Here!"},
        { "Nome falso:", "Fake name:" },
        { "Inserisci un nome falso", "Enter a fake name" },
        { "Chiudi", "Quick" },
        { "Crea stanza", "Create room" },
        { "Entra in stanza", "Enter in room" },
        { "Max numero players:", "Max players number:" },
        { "Stato stanza:", "Room state:" },
        { "Publica", "Public" },
        { "Privata", "Private" },
        { "Link Discord:", "Discord Link:" },
        { "Nome stanza:", "Room name:" },
        { "esempio: sdfvs...", "example: sdfvs..." },
        { "Crea", "Create" },
        { "Cerca stanza...", "Search room..." },
        { "Entra", "Enter" },
        { "Svliuppo:", "Development:" },
        { "Contatta", "Contact" },
        { "Grafica", "Graphics" },
        { "Hai perso connessione.\nControlla di avere accesso ad internet e clicca sul pulsante.", "You have lost connection.\nCheck that you have access to the internet and click on the button." },
        { "Riprova", "Try again" },
        { "Nome vero", "Real name" },
        { "Inserisci il tuo vero nome...", "Enter your real name..." },
        { "Stanza", "Room" },
        { "Esci", "Exit" },
        { "Inizia", "Start" },
        { "Apri", "Open" },
        { "Classifica", "Ranking" },
        { "Risposta...", "Answer..." },
        { "Invia", "Send" },
        { "Risposte", "Answers" },
        { "Fatto", "Done" },
        { "Players in attesa:", "Players waiting:" },
        { "Risposte indovinate:", "Guessed answer:" },
        { "Player che ti hanno indovinato la risposta", "Players who have guessed your answer" },
        { "Continua", "Continue" },
        { "Punti: ", "Points:" },
        { "Classifica finale!", "Final ranking!" },
        { "Attendi gli altri...", "Wait for the others..." },
        { ": tabellone", ": scoreboard" },
        { "Complimenti, i tuoi amici dovrebbero tenersi alla larga da te, sei stato troppo bravo a imbrogliare e manipolare gli altri. Tu sei THE CHEATER!", "Congratulations, your friends should stay away from you, you have been too good at cheating and manipulating others. You are THE CHEATER!" },
        { "Sei troppo un bravo ragazzo, non puoi essere THE CHEATER!", "You're too good a guy, you can't be THE CHEATER!" }
    };

    public static string traduci(string s)
    {
        if (Application.systemLanguage == SystemLanguage.English)
            return traduzione[s];
        else
            return s;
    }
}