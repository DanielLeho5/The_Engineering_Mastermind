# Specifications

## The concept

Making a digitally playable version of GhostBlitz / Bílá Pány Dluhova.

It is a reaction card game.

The simplified rules of the game are:
1. In each round a card gets flipped from the deck.
2. According to the picture drawn on the card the players have to select one of the following:
    - Bílá Pány Duhova
    - Zelená Zába
    - Modry Reben
    - Cerveny Koberec
    - Sada Vana
3. The rules for selecting the correct object:
    - the picture either has to contain the exact object i.e. a green frog > zelená zába
    - or if it doesnt contain an exact match, select the item that does not appear at all (not the object or its color)

4. The person who correctly selects the object first, gets the card, earning a point.

5. When the deck runs out, the player with the most cards is the winner.

## Functional specifications

Each player can [open the game in their browser / open the game in a desktop app / open the mobile app the game].

The player that decides, can create a room with a room code.

By sharing the code, other players can join the room and play with eachother in real time.

There can be a maximum number of players.

In each round the card is flipped, the players can choose to tap 1 of 5 options on their screen. The first player to hit the correct answear get the card. A player who hits a  wrong card, gets a downtime penalty (i.e. 3 seconds) in which they can't have another guess.

## Technical specifications

Programming Language: C#

The rules of the game and the logic of the application will be written in plain C#.

For the user interface, a simple graphical library is used: libRay.

For the web-socket, real time online interactions: signalR is used as a simple framework.

For hosting the server: ASP.NET Core