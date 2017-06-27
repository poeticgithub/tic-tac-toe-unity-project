# tic-tac-toe-unity-project
unity engine game tic tac toe

This single player-vs-computer tic tac toe game was created using Unity Game Engine. Works on windows,  iOS, android,  etc. depending on how you build it inside the Unity Game Engine.

I created a rudimentary Artificial Intelligence from a short lookup-table that makes the computer prioritize moves that would lead to a winning game state or would impede the player

Still a work in progress.

I want to improve the AI to make it prioritize moves that would block a subsequent winning move from the player. I will accomplish this by making the computer a maximizing player, creating an evaluation function that would assign the most points to moves that block the player, and storing a dictionary of game states where the player would win on his subsequent move.

Requires an installation of Unity Game Engine version 5.3.4 or newer.

Inside the Unity Game Engine Editor

1. Open this Project.

2. Open Scene : firstLevel

3. Click Play button to test inside the Editor or click on File -> Build Settings to create an executable on your desired platform: Windows, Mac, Linux, Android etc.

![tictactoeprojectpic](https://cloud.githubusercontent.com/assets/18449651/25506004/6ccb41fa-2b72-11e7-806a-459761a9e7e6.jpg)

