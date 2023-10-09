using UnityEngine;

public class Domande : MonoBehaviour
{
    public static string[] domande = new string[]
    {
        "Come ti chiami?",
        "Di che cosa hai più paura?",
        "Ultimo desiderio prima di morire?",
        "A chi confideresti un segreto? *",
        "Quali sono i tuoi punti deboli?",
        "Quali sono i tuoi punti di forza?",
        "Chi è il più simpatico/a?*Motiva.",
        "Chi eviteresti per strada?*Motiva.",
        "Chi è più bravo a mentire?*Motiva.",
        "Pazzia per amore?",
        "Cosa odi di più delle persone?",
        "Cos'è l'amore?",
        "Chi è il più pigro?*Motiva.",
        "Frase che funziona sia ad un funerale che a letto?",
        "Saresti amico di te stesso? Motiva.",
        "Ammetteresti un tradimento se sai che il tuo partner non lo scoprirebbe mai?",
        "Se un uomo che sta morendo di fame mangiasse un cane cosa penseresti?",
        "Che musica ascolti?",
        "Preferiresti andare avanti o indietro nel tempo?",
        "La prima cosa da fare con 1 milione di euro?",
        "Chi ti conosce meglio?*Motiva.",
        "Ti senti frustrato perché eiaculi prima di quando vuoi?",
        "É il tuo compleanno cosa fai?",
        "Se avete chiesto in prestito del denaro per giocare d’azzardo o per pagare i debiti di gioco, da chi o da dove avete preso i soldi ?",
        "Cosa sei in grado di fare oggi che non sapevi fare un anno fa?",
        "In una sola frase chi sei tu?",
        "A cosa stai pensando?",
        "A cosa non potrai mai rifiutare?",
        "Con chi passeresti una notte di fuego?*Motiva",
        "Cosa ne pensi dei piedi?",
        "Cos'è che ci nascondono?",
        "Chi preferiresti baciare?*Motiva.",
        "Cosa ti sorprende?",
        "Il pensiero di essere legato ti attrae?",
        "La mise più sexy per un uomo o una donna a letto",
        "Qual è il porno più interessante su cui ti sei masturbato?",
        "Come fare in modo che una donna abbia un orgasmo?",
        "Cosa ti fa ridere?",
        "Chi prenderesti a pugni?* Motiva.",
        "Cosa c'è dopo la morte?",
        "Che animale vorresti essere? Motiva.",
        "In cosa credi?",
        "Fatti una domanda e datti una risposta.",
        "Come stai?",
        "Qual è la tua città del cuore?",
        "Un tuo sogno ricorrente?",
        "Che cosa pensi quando senti dei boomers parlare di politica?",
        "Un metodo per guadagnare molto?",
        "Con quale personaggio famoso faresti volentieri sesso? Motiva.",
        "Di cosa non potresti mai fare a meno?",
        "Di che forma è la terra? Motiva.",
        "Se non esistevano i giganti perchè esistono delle porte così grandi?",
        "Cosa ti rende euforico?",
        "Una cattiva abitudine di uno di voi?*",
        "Non sopporto...quando...*",
        "Amo...quando...*",
        "Mi bagno quando...fa...*",
        "Qual è il senso della vita?",
        "Se...non fosse...sarebbe...*",
        "Film da vedere in bagno?",
        "La colazione perfetta?",
        "Convinci gli altri a diventare vegani",
        "Convinci gli altri a diventare di estrema destra",
        "Convinci gli altri a votare Salvini",
        "Convinci gli altri a non farsi vaccinare",
        "...è completamente incapace a...*",
        "Ma Marco Merrino è almeno realmente daltonico?Motiva",
        "Con chi non lavoreresti mai? Motiva",
        "Convinci gli altri a diventare testimoni di Geova",
        "Con chi faresti un lungo viaggio? Motiva",
        "Ultimo viaggio prima di morire?",
        "Una frase da boomer?",
        "Una frase da normie?",
        "Un lavoro che non faresti mai?",
        "Il vostro meme preferito?",
        "Con chi fareste uno speed date?",
        "A chi non affideresti mai neanche il tuo pesce rosso? Motiva *",
        "Quanto spesso ti masturbi? Motiva",
        "Sei mai stato Rubinato?spiega",
        "Quanto è bello avere una piscina a casa per una streamer?",
        "Quale super potere vorresti?",
        "Una parola bella?",
        "Il 2020 in quattro parole?",
        "Come sarebbe la tua casa ideale?",
        "Tre opere da vedere prima di morire?",
        "Che personaggio anime vorresti essere?",
        "I tuoi anime preferiti?",
        "Canzoni che non ti stanchi mai di ascoltare?",
        "Tre persone che ammazzeresti?",
        "Chi è il più vendicativo?*",
        "Chi è il più permaloso?*",
        "Cos'è la diversità?",
        "Qual è il tuo senso più sviluppato?",
        "Quali sono i tuoi vizi?",
        "Il vizio di...è...",
        "La violenza è sempre sbagliata? Motiva",
        "La violenza è un sistema educativo? Motiva",
        "Chi è il più emotivo? Motiva",
        "Tipologia di videogioco preferito? Motiva",
        "Chi tortureresti nel tempo libero?Motiva*",
        "Con chi tradiresti la tua ragazza? *Motiva",
        "Di chi annuseresti il rutto?Motiva",
        "Cosa ti mette in imbarazzo?",
        "Come terminare l'esistenza di qualcuno",
        "Di chi leccheresti i piedi?",
        "Convinci gli altri che il cannibalismo è una cosa bella",
        "Convinci gli altri che non l'hai ucciso",
        "Spazio Spam",
        "Come manipoleresti una persona?",
        "Convinci gli altri che la terra è piatta",
        "Con chi non staresti da solo in una stanza? Motiva.*",
        "Ti rimane un ora di vita con chi non la passeresti mai? Motiva.*",
        "Per cosa diventerai famoso?",
        "Con...non vorrei mai...*",
        "Chi si masturba di più? Motiva *",
        "Posso fidarmi di te anche siamo lontani? Motiva",
        "Pensi ancora al/alla tuo/tua ex? Motiva",
        "Quanto guadagni? Motiva",
        "Ti sei mai innamorato/a? Motiva",
        "Cosa vedi dalla tua finestra?",
        "Sai qual è il bello del caos? Motiva",
        "Vuoi sapere come mi sono fatto queste cicatrici? Motiva",
        "In questo mondo è UCCIDERE o ESSERE UCCISI!",
        "Ottobre, il mio mese preferito. Amo guardare le foglie cambiare colore e trasformarsi in piccole fiamme.",
        "Sai perché mi piace il fango? Perché è pulito e sporco allo stesso tempo.",
        "La paura è l’oscura prigione della luce. Il coraggio è?",
        "Ragazza ti ucciderebbe mostrare solo un po' più di attenzione?",
        "A cosa pensi prima di addormentarti?",
        "Descrivi la tua espressione facciale ",
        "Descrivi la posizione in cui dormi solitamente",
        "Descrivi la tua giornata tipo",
        "Descrivi la tua giornata ideale",
        "Cosa non faresti mai per amore?",
        "A chi non confideresti mai un tuo segreto?* Motiva",
        "Convinci gli altri che fare beneficenza sia una cosa brutta",
        "Convinci gli altri che Trump ha perso ingiustamente",
        "Convinci gli altri che TikTok è meglio di Twitch",
        "Perchè dovresti vincere tu?",
        "Chi non è proprio capace a mentire?* Motiva",
        "Qual è il senso di questo gioco?",
        "Convinci gli altri che una dittatura è l'unica soluzione",
        "Annusati le ascelle, cosa senti?",
        "Chi ha un odore più sgradevole?*Motiva",
        "La città italiana migliore per vivere? Motiva",
        "Convinci gli altri che la mafia non esiste",
        "Cosa fai appena sei da solo?",
        "Racconta una breve barzelletta",
        "Il primo pensiero appena sveglio?",
        "Hai mai pensato di architettare un omicidio? Motiva",
        "Hai mai rubato qualcosa? Racconta",
        "Il cringe in poche parole",
        "Fai provare cringe alle altre persone",
        "Ma se il mio capo si droga, io sono un tossicodipendente? ",
        "Perché i negozi aperti 24 ore su 24 hanno la serratura? ",
        "Quanto a lungo può vivere una donna che allatta se beve il suo stesso latte? ",
        "Quali sono le qualità dei tuoi genitori che ti piacciono di meno? ",
        "Dimmi qualcosa di vero, su cui nessuno è d’accordo con te ",
        "Se dovessi morire, cosa vorresti venisse scritto sulla tua lapide? ",
        "Qual e' un'altra parola per 'Sinonimo'?",
        "E se Dio avesse creato l'Uomo solo come nutrimento per le zanzare?"
    };

    public static string[] domandeIng = new string[]
    {
        "What is your name?",
        "What scares you the most?",
        "Last dying wish?",
        "To whom would you share a secret?*",
        "What are your weakness?",
        "What are your strenghts?",
        "Who is the funniest?*Elaborate ",
        "Who would you avoid ?*Elaborate",
        "Who is the best liar?*Elaborate",
        "Crazy move for love? ",
        "What do you hate about people?",
        "What is love?",
        "Who is the laziest?*Elaborate",
        "A phrase which could work both to a funeral and during an intercourse.",
        "Would you become your own friend? Elaborate",
        "Would you admin a betrayal if you knew your partner would never find out?",
        "What would you think of a starving man eating a dog?",
        "What music you fancy?",
        "Would you travel back or forward in time?",
        "What would be the 1st thing to do after winning $1.000.000?",
        "Who knows you best?*Elaborate",
        "Do you feel frustrated if you cum earlier than when you would like to? ",
        "It is your birthday, what do you do?",
        "Who would lend you money in order to gamble or to payback debts?",
        "What are you able to do today that you didn’t know how to a year ago?",
        "Describe yourself in a sentence",
        "What are you thinking about?",
        "What is the thing that you will never say no to?",
        "With whom would you spend a spicy night?*Elaborate",
        "Thoughts on feet?",
        "What conspiracy do you believe in?",
        "Whom would you kiss?*Elaborate",
        "What surprise you?",
        "Does “bondage” excites you?",
        "What is the sexiest clothing in bed for a man/woman?",
        "What is the most interesting porn you jizzed on?",
        "How do you give an orgasm to a man/woman?",
        "What makes you laugh?",
        "Who would you fight?*Elaborate",
        "What comes in the afterlife?",
        "Which animal would you like to be?",
        "What do you believe in?",
        "Make yourself a question and answer it.",
        "How are you?",
        "What is your favourite city/town?",
        "Describe a recurrent dream/nightmare.",
        "What is your take on boomers talking politics?",
        "A method to earn a lot of money?",
        "Which famous person would you like to have sex with? Elaborate.",
        "What is the thing that would never bores you?",
        "What is the Earth’s shape? Why?",
        "If giants never existed then how come we have big doors?",
        "What makes you euphoric?",
        "Describe someone’s bad habit*",
        "I can’t stand...when..*",
        "I love...when...*",
        "I wet myself when...do... *",
        "What is the meaning of life?",
        "If...wouldn’t be...he/she would be...*",
        "Movie to watch in the bathroom?",
        "Describe the perfect breakfast.",
        "Persuade others to go vegan.",
        "Persuade others to support the right wing extremists.",
        "Persuade others to vote for Trump.",
        "Persuade others not to get vaccinated.",
        "...is completely incapable of/to...*",
        "But is Marco Merrino at least really color blind? Elaborate",
        "Whom would you never work with? Elaborate.",
        "Persuade others to become a Jehovah’s Witness.",
        "Who would you pick to have a long trip with? Elaborate.",
        "Last trip before dying?",
        "A boomer phrase?",
        "A normie phrase?",
        "Which job you would never consider doing?",
        "Favourite Meme?",
        "Who would you take to a speed date?",
        "To whom you would never entrust your pet?*Elaborate",
        "How often do you masturbate? Elaborate",
        "Sei mai stato Rubinato?spiega",
        "How convenient is to have a house pool for a female streamer?",
        "What is your dream superpower?",
        "A beautiful word?",
        "2020 in 4 words",
        "How do you imagine your ideal home?",
        "3 art pieces to see before dying?",
        "Which anime character would you like to be?",
        "Top 3 favourite anime",
        "Top 3 songs you never get bored of",
        "Top 3 people you would kill",
        "Who is the most vengeful?*",
        "Who is the most touchy?*",
        "Describe “diversity”",
        "Which is your most developed sense?",
        "Yours top 3 vices",
        "(Insert name)’s vice is...",
        "Is violence always wrong? Elaborate",
        "Can violence be educational? Elaborate",
        "Who is the most emotional? Elaborate",
        "Favourite game genre? Elaborate",
        "Who would you torture in your free time? Elaborate*",
        "Who would you cheat on your girlfriend with?*Elaborate",
        "Whose burp would you smell? Elaborate",
        "What makes you akward?",
        "How would you kill someone?",
        "Whose feet would you lick?",
        "Persuade others that cannibalism is a nice thing.",
        "Persuade others that you didn’t kill anyone",
        "Advertise yourself",
        "How would you manipulate someone?",
        "Persuade others that the Earth is flat",
        "Who wouldn’t you be alone in a room with?*Elaborate",
        "Who would you never spend your last hour alive with?",
        "What will make you famous?",
        "I would never...with...*",
        "Who masturbates the most?*Elaborate",
        "Can I trust you over a long distance relationship? Elaborate",
        "Do you still think about your ex/exes? Elaborate",
        "What is your annual income? Elaborate",
        "Have you ever fell in love? Elaborate?",
        "What do you see from your window?",
        "Is chaos beautiful? Elaborate",
        "Do you want to know how did i get these scars? Elaborate",
        "Do you stand by the sentence KILL or BE KILLED?",
        "October, my favourite month. I love to watch leaves changing colour and transform into little flames.",
        "Do you know why I like mud? Because it is both clean and dirty at the same time.",
        "Fear is light’s dark prison. What is courage?",
        "Would showing a bit more emphathy kill you?",
        "What do you think before falling asleep?",
        "Describe your facial expression. ",
        "Describe your usual sleeping position.",
        "Describe your usual day.",
        "Describe your ideal day.",
        "What would you never do for love? ",
        "To whom you would never confess a secret?* Elaborate",
        "Pesuade others that charity is a bad thing.",
        "Persuade others that Trump unrightly lost the latest elections.",
        "Persuade others that TikTok is better than Twitch",
        "Why should you win?",
        "Who is an uncapable liar?* Elaborate",
        "What is this game’s goal?",
        "Persuade others that dictatorship is the only solution",
        "Smell your armpit. Now describe it.",
        "Who smells the most?*Elaborate",
        "Choose the best Italian city to live in. Elaborate",
        "Persuade others that Mafia is a hoax.",
        "What first thing you do when alone?",
        "Tell a short joke.",
        "First thought in the morning?",
        "Have you ever thought about plotting a murder? Elaborate",
        "Have you ever stolen? Elaborate",
        "“Cringe” in few words.",
        "Induce cringe to others.",
        "If my boss is a drug addict, am I a dependent on drugs?",
        "Why 24/7 convenient stores has locks on the doors?",
        "How long can a woman live if she drunks her own milk?",
        "Which parents’ qualities do you dislike the most?",
        "Tell me something which is true to you but no one agrees with you.",
        "What would you like to have engraved on your tombstone?",
        "What is a synonym for “synonym”?",
        "What if God created us purposely for the mosquitoes diet?"
    };
}