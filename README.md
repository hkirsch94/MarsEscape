# MarsEscape_Unity

- Alina Griesel, agriesel@uni-osnabrueck.de
- Fabian Kirsch, fkirsch@uni-osnabrueck.de
- Carmen Moßner, cmossner@uni-osnabrueck.de
- Course: Introduction to Unity, SoSe 2022


## Welcome to Planet Mars!



This is a collaborative project of Fabian Kirsch, Alina Griesel and Carmen Moßner. The following roughly describes how we approached, structured and implemented the game.

Our initial idea was to implement a horror game where the player is being chased by a creepy creature. We quickly agreed on a space station on mars as the location where the game should take place. It would leaves us with a wide variety of opportunities to get creative in object designs and story-line.
Before we started to decide on the story and the make-up of the space station, we made sure to implement a proper control of the player as this would be a necessary requirement for the functioning of our game. We then met up to draw a rough sketch of how the space station should be set up. This involved different capsule-like glass division, each with a different theme. According to the themes, we were then able to come up with mini-games and tasks which the player could solve in order to collect points. We thought it would be an interesting idea if the ending of the game depends on the points collected in each task, thus multiple endings can be reached by the player. The glass capsules were divided into personal living space, where the player finds himself at the start of the game, followed by a market area where food would have to be collected for the journey that lies ahead of the player. The next capsule comprises a garden where extraordinarily beautiful animals can be observed in their natural habitat. To the disadvantage of the player, a bush blocks the passage that leads to the next capsule. The player must therefore find an axe which is hidden somewhere in the garden, in order to destroy the bush. Subsequent to the garden, the player can enter a laboratory in which aliens have been preserved in large tubules for research purposes. In order to get a cure against a virus that has spread across the colony, the player must find two hidden hints within the laboratory, which together reveal the code that needs to be typed in. In the final capsule, the player needs to look for and collect up to 10 suitcases which contain equipment such as suits which are needed to flee from the space station together with the fellow men.

Even though we had a rough sketch from the beginning, the storyline in all it’s detail only developed as we worked on the project. We used ProBuilder and Blender to create our own assets such as the glass capsules, the buildings as well as the aliens and some smaller assets such as the axe, the doors and the ladders. The whole scenery thus evolved over time as we worked on more and more assets.
During the gameplay, the player is shown a text field with all possible tasks. Depending on how many points have been achieved in each task (or in the case of the bush, whether it was destroyed), the respective text turns red, yellow or green. The mini-game at the food market is largely build after the Jumpignon game with a few changes. Most importantly, there are not only enemies falling from the sky which kill the player after 3 collisions, there is also food raining down on the player. The collected food is counted as points with 20 as the highest amount the player can achieve. The Game Over screen is coloured red for points below 10, yellow for everything else up to 19 and only the full 20 points turn the text in the mini-game as well as the text in the main game green. The most obvious difference is probably the design of the game. We used a different picture to set the theme for a mars scenery with assets of stones as the platforms on which the player can jump. Once the game is played, the player is teleported back into the main game.
The main struggles we had during the implementation of the game were rather small but crucial things such as an input text or an inventory that memorises the objects that were picked up. As usual when trying to code something, we were often stuck at small problems which we resolved after a while of trying all kinds of things and looking for solutions online.

# Blender Creations:
- Dome.fbx
  - First Blender creation for the project. Used as Rooms for the Game which we want to fill. We wanted to create a Mars Colony
- Alien.fbx
  - Used for decoration and would not be scary as a horrorgame monster. 
- TubeDoor.fbx
  - Door between the Domes including Animation
- Path.fbx
  - Path around the Dome as decoration
- Door.fbx
  - Normal doors for buildings including animations
- Button.fbx
  - Button which we want to press including animations
- ExperimentalTube.fbx
  - Decoration for the laboratory
- Axe.fbx
  - An Axe which we want to collect to destroy the Bush

# Ideas/Struggles/Solutions Scripts:
## CourseScripts/Minigame

- Bulle_Behaviour.cs
  - no changes, bullet speed initialised and bullets disappear above y=20  
- CameraMovement2D.cs
  - no changesm camera movement follows movement of player
- UI_Manager.cs
  - we included a point count for each collected item
  - function gameOver() and win() with specified colour changes
  - we had to use a mesh renderer responsible for the background picture which only gets activated / enabled if gameOver or win is used. It serves a higher readability for the gameOver/win text
- Enemy_Script.cs
  - no changes, speed and position of enemies initialised and destroy if collision with player or bullet
- Food_Script.cs
  - the same as enemy script, just for food items. Speed higher than enemies, also destroy if collision with player or bullet
- Player.cs
  - implementation of Points() function which counts up points when called and checks whether 20 points are reached and call win
  - implementation of Damage() basically the same, calls gameOver instead of win
- SpawnManager.cs
  - if-condition in IEnumerator uses counter to only make 1 food item appear for each 2 emenies that appear, to make it harder for the player
- SceneChange.cs
  - Used in Main to change scene for the endings 

## Scripts Main
### PlayerMovement
- PlayerMovement.cs and CameraMovement.cs
  - the first script we have implemented. We wanted to implement a first person character.
  - The CameraMovement script transforms the mouse input to the camera. We had to do some changes on the hierarchy because first it also transformed the charackter itself
  - The PlayerMovement was build over time. First we watched a tutorial which used the groundCheck for enabling a jumping function. After implementing it we also wanted to be able to climb ladders, be able to crouch and sprint. 
  - Sprinting was realtively easy to implement per Button press. We just changed the speed, which was not good enough, because we wanted to be slower while crouching. This was resolved by adding the modificators in the movement calculation.
  - Ladders were also easy to impelemt, after doing the ground check, because we thought we can use this it in the same way. After some try and error we just had to combine both checks to be able to let go of the ladder.
  - On the other side we created the function for crouching...the worst of them all. We watched a few tutorial which we were not able to use on our script. So we had the idea to just scale the player down at the y-axis. This needed some adjustments because it created some problems with the groundcheck first. After doing that we tried the function on a tunnel. At this Point, if we let go of the ctrl button inside the Tunnel we clipped through the Ground and just were falling into infinity. After that we were first introduced to raycasting. There is a function which checks if there is enough space in a specified direction and after some adjustments our player was finished.

### Raycasting Layers
- RaycastPlayer.cs
  - First Raycast Script for testing. We created a additional canvas Point for every script. We could have used one script for one canvas point whiich would be accessed from the other Raycasting scripts but we didn't want to destroy something while doing so. 
- DoorAnim.cs
  - The Script itself was wasy to implement but we had problems with the animation. We created the animation in unity first. The problem was additional doors were transformed to the location of the first door, so we created the animation in Blender. After activating the root transform in the animator it worked perfectly fine. We are using a bool in the animator which activates the animation which we had to reset directly after the animation starts. Oterwise the dor would be closing directly after opening.
- ActivateAnim.cs
  - The script which we wanted to use to activate everything. But activating a door by pressing a button was more complicated than we thought. After adding doors to a specific button the script was accessing all doors which were assigned to a button. We were able to solve this by accessing the doors different so we just were just accessing a specific door animation.
- DestroyObjectsWithItems.cs
  - We wanted to destroy a bush by using a item, after implementing the other raycasting scripts it was relatively easy. We assigned both items and activated a bool after collecting the item we want to use.
- Collectable.cs
  - Similar to the Script before. In this case we just destroy an object and increase an integer which represents the amount
- ChangeSceneButton.cs
  - A differnet Button Script which we used for a scene change to start our Minigame. We also are saving our reached points inside of it.   
- EnterPassword
  - This Script was a big workaround. We wanted to use the inputField first, but had problems to access it from our player. Our solution was to activate the InputField, add the number keys to a list and ad the numbers to the text in the field according to our input. The string inside is compared with some if-statements.

### Other
- InitializePlayer.cs
  - There are two reasons why we were initializing the players in the start screen and set it dontSestroy OnLoad. First, we wanted to save the progress of the player, which would have a reset if we just change the scene back to the MainGame which had the side effect oft not duplicating the player if initialized in the Main. Second, accessing the different cameras of the Player did not work well if one player was deleted. Somehow just deactivate and activating the GameObjects worked perfectly fine but it took a while finding a solution.
  - We use key input to start the Game. This was a workaround because we were not able to access a canvas button that easy
- TaskValues.cs
  - A extra script to summarize the values of our tasks. Gave a better Overview of our ending by using the bool first and then the int values in the if-statements
- InitializeEnd.cs
  - Just the script were we are accessing all ending we have created as a texts using the values of the TaskValues.cs.
- QuitStart.cs
  - Just a Script for the Player to close the game at each point of the game. Does not work right know. We think it should work after building the Game 


