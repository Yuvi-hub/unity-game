# unity-game
unity game for assignment 2

Mini Map Adventure – Unity Assignment 2

About the Game

A 3D Unity game featuring a player, colorful obstacles, and a mini-map camera.

Features

* Player movement
* Mini-map in the upper-right corner
* Orthographic mini-map camera
* Colorful 3D environment
* Playable directly in a web browser

How to Play

Move the player using the keyboard and explore the environment while watching the mini-map.

Technologies

* Unity 6
* C#
* Unity Input System
* WebGL

Play Online

Play Mini Map Adventure here -  https://yvvvvvv.itch.io/mini-map-adventure

 
Question 2(a) – Screen Rotation Explanation

When rotating the phone from landscape to portrait orientation, the screen’s aspect ratio  changes.

In an orthographic camera, the orthographicSize property determines half the height of the visible area in the game world.

When this value remains constant and the screen changes to portrait orientation, the camera displays a narrower area horizontally. As a result, objects appear larger relative to the screen’s width.

To solve this problem, we can adjust the camera’s orthographicSize based on the screen’s aspect ratio, ensuring that objects maintain a consistent relative size in both orientations.
Developer

Yuval Frankel 
