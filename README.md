# Unity-Train-Simulator
 ![Main Menu](https://i.ibb.co/F0jj5Kh/Screenshot-83.png)

To run the simulation as intended, please run the Menu scene first.

# Game Order: 
In the options menu, you can choose the amount of characters that'll start on each platform. 
Pressing the Play button from the main menu will start the game world scene.
The train starts in Idle state, and will pick up passengers from the platform it's waiting at if there are any. Once all passengers have boarded, the train moves to the other platform, in which it'll drop its passengers and pick new ones.
A passenger would like to get on the train if he waited for ~2 seconds after reaching his target platform. Once he spots the train, the NPC will move towards the nearest door. Upon reaching the door, he'll be teleported to another terrain, and move with the train. Once the train reaches the other station, the NPC gets off the train, and moves to a random location on the platform.
 ![Options Menu](https://i.ibb.co/qBZtm0D/Screenshot-84.png)


# Scripts:
UI SCIPTS
* mainMenu: In this script we handle moving between the other screens(game, options, exit)
* Options: This script handles the amount of NPC's that'll appear on each platform using sliders and PlayerPrefs
* PeopleIndicator: Shows on the game window text boxes telling how many people are currently on each platform or on the train.
* Platform: Simple script that updates the number of people currently on the platform.
* ToggleCamera: Using a toggleGroup, allows switching between a side camera and a train front camera.
* DayNightCycle: Spins the directional light around an axis in order to imitate a day/night cycle.
* LightsControl: Turns on lamps on various objects at night, and off at day.

GAME SCRIPTS:
* TrainMovement: Informs the train when it can change it's states(Idle A, A to B, Idle B, B to A) based on encountering people on platforms A/B, as well as keeping track of the amount of people currently on the train.
* SpawnCharacters: Using Instantiate, creates N/M NPC's on each platform based on values chosen from the options menu.
* Randomizer: A script that handles invisible targets for the NPC's to move to once they get off the train.
* NPCMovement: A script to handle the characters in the game. Using trigger functions, it notifies the NPC on what he should do next.
 ![Twilight approaches](https://i.ibb.co/fpfczjj/4o5t7k.gif)


# Storyboards
If I'm an NPCFromA and on Upper PlatformA and the train arrives, I enter the train and move to the lower terrain.
When the train reaches Platform B, I move up, and out of the train. Then, I move to a random location on platform B.
Upon reaching my destination, I'll wait for ~2 seconds and change my tag.
Now I'm NPCFromB and on Upper platform B.

 ![Train front view](https://i.ibb.co/VMbQr9Z/Screenshot-91.png)

