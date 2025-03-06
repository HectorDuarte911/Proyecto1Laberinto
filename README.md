This project is made is made whith the idea of creating a game of a maze. This may not be the last version of the project because there are much more to change. 
The project was made in a console application in Windows.

📋**Requisites**
+ Have installed .Net 8.0.
+ Add the package Spectre.Console 
+ Add the package NAudio.Wave

🚂**How running the project?**

To open the game, you may open the program directly for the terminal of the PC, but you can open the terminal inside the project whith the much-extended window than you can and open the project whith dotnet run to a little much visibility of things.

 🔧**How is the project inside?**
 
The project has different folders and inside different classes whith functions to complements the Program class. The functions of these folders are:
+ **audio:** *Archive all the audios of the game.*
+ **Board:** *Save the positions of the Enums pieces in one board, save the different types of Enums cells in the other one, and manage the functions of the generation of the maze. (These boards are square matrix)*
+ **Direction:** *Administer the different directions than the pieces can move.*
+ **Events:** *Administer the events and all their stats and messages.*
+ **Game State:** *Center of the project, administer all the current state of the project and all the information go somehow to this class.*
+ **Move:** *Administer the valid moves of the pieces.*
+ **Objects:** *Administer the selection, discard, stats and the equip process of the objects I the game.*
+ **Pieces:** *Administer all the functions of the pieces in an abstract class PieceBasic and create others class of the abstract class than represents the pieces in the game.*
+ **Player:** *Manage the players in the game and their state. All the pieces have one unique player and in the other side to.*
+ **Position:** *Manage the positions in the board than require a row and a column to know the positions in the matrix.*
+ **Tramps:** *Manage the effects of the tramps in different classes.*

 🎾**How to play?**
 
 The players have turns in the order than they choices, you can do it whith the maze since and the names of the players in the configuration of the game in the principal menu. If you don’t do it then the configuration still in the predetermined configuration (two players, maze 33x33, and the names of the player the same number of they). When you are ready you may start playing selecting the option "Cargar Partida" and the game begins. Each player may choose their piece in the order than they want to play and when all the player choice their pieces the first player can start. You notice than the music change, this is because each of the piece have its own music and when the turn starts the music change to the current piece type. You have a list of actions in your turn, you can do one of them at once, the actions may activate.(See Annex ). The turn only finishes when you select the action “*Terminar Turno*” or when you surrender. You can’t move to a cell with an event, obstacle , wall , or other piece.In the fight you compare the force of the attacker piece with the armor of the defends piece and the highest win (the defend piece wins the draws) ,the piece loser may state two turns in rest state and can’t play in two turns but be careful nether you and your opponent can’t see the others stats. In the games there are objects, all the objects have weight, and you have an inventory weight than can’t be higher than 
 200 sow mange well your object. You can obtain objects in chest or wining a battle with an event in a map. The “Final” event is the end of the maze you may find a way to it and have a goods stat because you 
 can’t go out free. 

🖼️**Annex** 

<table>
 <tr>
  <th>Action Name</th>
  <th>Activate Time</th>
  <th>Number Activation</th>
  <th>Funcionality</th>
 </tr>
  <tr>
  <th>Caminar</th>
  <th>Any time, except when you are in a sub option menu like the fight menu, the equip menu or the info menu	</th>
  <th> If you have moves lefts, you can activate it</th>
  <th>Whith this action you can walk in the maze</th>
 </tr>
  <tr>
  <th>Activar Habilidad
</th>
  <th>Any time except in menus like equip menu or info menu</th>
  <th>When you activate this the first time you can’t activate this action in the number of cold turn than your ability has	</th>
  <th>Whith this action you can activate the ability of your piece</th>
 </tr>
  <tr>
  <th>Derribar Obstaculos</th>
  <th>When you have full movement, and you are adjacent to an obstacle</th>
  <th>If you can regenerate your movement then you can activate this twice in a turn, but I dude it</th>
  <th>Whith this action you can remove one adjacent obstacle, but this consumes all your movement</th>
 </tr>
  <tr>
  <th>Activar Portal</th>
  <th>When you have full movement, and you are in a cell with a portal	</th>
  <th>If you can regenerate your movement then you can activate this twice in a turn, but I dude it </th>
  <th>Whith this action you can teleport to other portal if all of them are not occupied but this consumes all your movement</th>
 </tr>
   <tr>
  <th>Romper Muro</th>
  <th>This is an action exclusive to the piece “Artillero” or “Intelectual”. You can do it when you are adjacent to a wall than are not in the corner of the maze</th>
  <th>	Once per turn </th>
  <th>	With this action you can
remove one adjacent wall than can not be a corner wall</th>
 </tr>
   <tr>
  <th>Rendirse</th>
  <th>At any time except in menus like equip menu or info menu</th>
  <th>Once per turn</th>
  <th>Whith this action you can surrender and lose the game</th>
 </tr>
   <tr>
  <th>Obcion Equipo</th>
  <th>At any time except in info menu</th>
  <th>At many times, you want</th>
  <th>Whith this action you can adjust your piece’s inventory</th>
 </tr>
   <tr>
  <th>Terminar Turno</th>
  <th>At any time, except when you are in a sub option menu like the fight menu, the equip menu or the info menu</th>
  <th> Once per turn </th>
  <th>Whith this action you end your turn</th>
 </tr>
   <tr>
  <th>Luchar</th>
  <th>Only when you are next another piece or an event</th>
  <th>Once per turn</th>
  <th>Whith this action you can fight whith other piece to slow it or fight whith an event to take a reward but consume all your movement</th>
 </tr>
   <tr>
  <th>Info Juego</th>
  <th>At any time, except when you are in a sub option menu like the fight menu or the equip menu</th>
  <th>At many times, you want</th>
  <th>Whith this action you can see many characteristics of the game like the lore,
the color and abilities of the pieces and more</th>
 </tr>
   <tr>
  <th>Player Piece View</th>
  <th>At any time, except when you are in a sub option menu like the fight menu, the equip menu or the info menu</th>
  <th>At many times, you want	</th>
  <th>Whith this action you can see your piece actual stats</th>
 </tr>
 

















