# zako-game-programming-final
Zak and Ako's final project for Game Programming class <3

## Packages

- ProGrids (https://docs.unity3d.com/Packages/com.unity.progrids@3.0/manual/index.html)

## Objects

- Player
- Environment
- PlayerCamera

## Scripts

- PlayerMovement
- EnvironmentMovement

### Notes
On Animations and Character: 
- Source of character and animations: https://www.mixamo.com/#/
- When uploading a character to Unity Import the T-pose of the character twice with following settings: first is .fbx for Unity, second is .dae
- Drag the .fbx of the texteures folder from .dae format file into Unity Assets folder first, then import the .fbx file of the character. 
- Choose "fix now" for mapping request.
- You have to do this because the .fbx for Unity files don't have the textures with them, and the .dae animation doesn't work on Unity, only the textures files from it. 
- When downloading the animations for that character choose .fbx for Unity, without skin, 30 frames per second, no rendering.

## Week#1 goals

- [x] Create the scene where the player runs infinitely
- [x] Enable the player controller - swipes up, down, left, right
 - Animations for the character: 
- - [x] Running 
- - [x] Waving 
- - [x] Jumping Up 
- - [x] Sliding 
- - [x] Spinning 
- [x] Attach the virtual camera to the player

## Week#2 goals

- [x] Obstacles: Import assets, make prefabs, implement obstacle spawning logic.
- [x] Add meter count on top
- [x] Add audio: 
- - [x] Background music 
- - [x] Losing/spinning SFX 

## Week#3 goals

- [x] Add health count and losing logic.
- [x] Activate health bar
- [x] Show restart menu when health is zero
- [x] Collectibles: Import assets, spawn collectibles
- [x] Add collectible count logic
- [x] Coin collecting audio
- [x] Add more environment to road backround
- [x] Display Score
- [x] Add SFXs
- [x] Fix bugs
