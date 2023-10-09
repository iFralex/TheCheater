# The Cheater
This game was commissioned to me on Fiverr in 2021 by a Twitch streamer who wanted something to entertain and engage his community.

From his ideas, I developed The Cheater: a game where you have to guess the identity of other users without getting caught.
Users have to answer honestly to one question per game, and various friends, by reading the answers of others without knowing who wrote each answer, have to associate each response with the names of other users.

The game was supposed to be distributed on PC and Android, but in the end, the streamer decided to abandon the project.

# Technical Information
To develop it, I used the Unity development engine.
The multiplayer part was developed using the "PUN 2 (Photon Unity Networking 2)" plugin, with which I created the following features:
• Matchmaking system to create game rooms, connect players, and establish room rules (e.g., maximum number of players, game time, room visibility or privacy);
• Synchronize player and room states (e.g., score, in-game ranking, question number, real and fake names);

# C# Files
A Unity project has many files in addition to scripts that are usually not managed by the developer. If **you are only interested in seeing my work**, namely the C# scripts I wrote, go directly to the [assets folder](https://github.com/iFralex/TheCheater/tree/main/Assets) and open the C# files.

Unfortunately, the project was not developed with the intention of publication, so the file names, variables, and functions are in Italian, and no scripts are commented or written to facilitate reading by others.

Keep in mind that I programmed this video game when I was 15 years old, so you can imagine that the code is not perfect or optimized to the best, but it still works perfectly, and you can study it to understand how Unity and PUN 2 work.
