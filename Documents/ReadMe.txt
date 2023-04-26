To use this project:

•	The project in its entirety is relatively easy to use. To begin a user must download/clone the project onto their computer.
•	Once Downloaded the project should be ran ideally through Unity Hub.
•	Once the Unity project loads the user should navigate through the project window: Assets > Scenes. From here the user can choose to go into the “Template” scene or the “DialogueEditor” scene.

Note*: It is recommended that the user has some prior experience with the Unity Engine prior to this
Note**: If a Virtual Headset(eg. Oculus Quest 2) is not connected to the computer when running the project, the editor will display an error. However, the project is still fully functional regardless of if a headset is connected
or not!

If the user wishes to write/edit/delete dialogue:
•	The user should double click the “DialogueEditor” scene and press the play button at the top of the Unity Editor
•	The user is then shown the Dialogue Editor view. There are 4 buttons which the user can choose from at the top of the screen. Load Dialogue File, Edit Character, Create Character, Save Current Dialogue.
•	If the user chooses “Load Dialogue File” new options will show up on-screen allowing the user to choose which dialogue file, they wish to load or they can cancel the operation.
•	If the user chooses “Edit Character” the user will see all the characters that have dialogue in the current loaded dialogue file, appear in the Dialogue Editor window. 
	The user can choose which character they wish to work on by clicking the character name. Once a character name is clicked the Editor will display the character dialogue tree.
	o	The character tree on display will consist of several Dialogue Nodes and Reply Nodes depending on how much dialogue is currently written for the character. 
		All the nodes are connected via lines to showcase the possible branching pathways in a dialogue.
	o	There are two buttons under each dialogue node and beside each Reply Node. 
		The red X button deletes the given node whereas the green + button creates a new node which will stem from the node on which the button was pressed.
	o	The user can re-organise the tree however they wish. As dialogue trees get bigger, they tend to get more and more confusing. 
		Hence the user is able to move the nodes how they wish to make it more useable for themselves.
	o	To temporarily save this character dialogue the user can press save at the top of the dialogue tree.
	o	To cancel all changes to the dialogue tree the user can just press cancel.
	o	Once the user is happy with all changes made to characters, to save the new dialogues to file the user simply needs to press “Save Current File” and choose which file they want to save to.
•	If the user chooses “Create Character” the user is prompted to type in a character name. The user can then click “Add Character” or “Cancel”.
	o	If the user clicks “Add Character” the character is added to the dialogue list and will now show up in the list of characters when the user clicks “Edit Character”. 
		The new character dialogue can now be written.
	o	If the user clicks “Cancel” the character is not created.
•	If the user chooses “Save Current Dialogue” the user will be shown the options to save to and a cancel button. If the user clicks one of the save buttons the dialogue will be saved to disk in the corresponding XML dialogue file.
If the user wants to test the template or previously written dialogue with the use of the built in Dialogue System:
•	The user can Use Virtual Reality to play through the scene or simply move the player in Scene View while watching the game view to see the current dialogue displayed by a character. The dialogue displays if the player is close enough to the character.
•	To use the Dialogue System for their own unique character, the user must do a few simple steps.
	o	Firstly, the user must create a new gameObject in the scene which will be used as the new character.
	o	Next the user must drag the CurrentCharacterStage script to the character in the inspector.
	o	Lastly the user must make a child trigger on the new character and add a tag which corresponds with the character name. 
		For example, if the character’s name is “Bob Man” the tag on the trigger must be “Bob Man”.
•	That is all that the user needs to do. Once these actions are complete the user can load their custom dialogue and the Dialogue System will assign all dialogues to the correct characters if they exist in the scene.
