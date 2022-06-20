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
- Alien.fbx
- TubeDoor.fbx
- Path.fbx
- Door.fbx
- Button.fbx
- ExperimentalTube.fbx
- Axe.fbx

# Ideas/Struggles/Solutions Scripts:
- ActivateAnim.cs
- Bulle_Behaviour.cs
- CameraMovement.cs
- CameraMovement2D.cs
- ChangeSceneButton.cs
- Collectable.cs
- DestroyObjectsWithItems.cs
- DoorAnim.cs
- Enemy_Script.cs
- InitializePlayer.cs
- InitializeEnd.cs
- Player.cs
- PlayerMovement.cs
- QuitStart
- RaycastPlayer.cs
- SceneChange.cs
- SpawnManager.cs
- TaskValues.cs
- UI_Manager.cs
