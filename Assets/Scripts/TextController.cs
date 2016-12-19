using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text textDiscription;

	private enum States {cell, mirror, door_0, sheets_0, cell_mirror, sheets_1, door_1, corridor_0, corridor_1, corridor_2, stairs_0, floor, closet_door, stairs_1, in_closet, stairs_2, corridor_3, courtyard};
	private States playerState;
	// Use this for initialization
	void Start () {
		playerState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (playerState);
		if (playerState == States.cell) {
			stateCell ();
		} else if (playerState == States.mirror) {
			stateMirror ();
		} else if (playerState == States.sheets_0) {
			stateSheets ();
		} else if (playerState == States.door_0) {
			stateDoor ();
		} else if (playerState == States.cell_mirror) {
			stateCellMirror ();
		} else if (playerState == States.door_1) {
			stateDoor_1 ();
		} else if (playerState == States.sheets_1) {
			stateSheets_1 ();
		} else if (playerState == States.corridor_0) {
			stateCorridor ();
		} else if (playerState == States.stairs_0) {
			stateStairs ();
		} else if (playerState == States.floor) {
			stateFloor ();
		} else if (playerState == States.closet_door) {
			stateClosetDoor ();
		} else if (playerState == States.corridor_1){
			stateCorridor_1();
		} else if (playerState == States.stairs_1){
			stateStairs_1();
		} else if (playerState == States.in_closet){
			stateInCloset();
		} else if (playerState == States.corridor_2){
			stateCorridor_2();
		} else if (playerState == States.stairs_2){
			stateStairs_2();
		} else if (playerState == States.corridor_3){
			stateCorridor_3();
		} else if (playerState == States.courtyard){
			stateCourtyard();
		}
	}
	//States
	void stateCell (){
		textDiscription.text =  "You awake in a cell with no memory of why you are there. You notice a mirror on the wall, " +
								"some ragged sheets on a bed, and the locked cell door\n\n" +
								"Press 'M' to look at the mirror\n" +
								"Press 'S' to look at the Sheets\n" +
								"Press 'D' to look at the Door";
		if (Input.GetKeyDown (KeyCode.M)) {
			playerState = States.mirror;
		} else if (Input.GetKeyDown (KeyCode.S)){
			playerState = States.sheets_0;
		} else if (Input.GetKeyDown (KeyCode.D)){
			playerState = States.door_0;
		}
	}
	void stateMirror (){
		textDiscription.text = "Your face is wrinkled, and eyes sunken. Time has not been kind. You now feel slightly more depressed.\n" +
								"The mirror appears to have a jagged piece of the frame sticking out.\n\n" +
								"Press 'T' to take the frame fragment\n" +
								"Press 'R' to return";

		if (Input.GetKeyDown (KeyCode.T)) {
			playerState = States.cell_mirror;
		} else if (Input.GetKeyDown (KeyCode.R)){
			playerState = States.cell;
		}
	}

	void stateSheets (){
		textDiscription.text = "The sheets look stained and ripped. You hope none of it came in contact with your face.\n\n" +
								"Press 'R' to return";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			playerState = States.cell;
		} 
	}
	void stateDoor () {		
		textDiscription.text = "The door looks solid enough.\n\n" +
								"Press 'R' to return";
		if (Input.GetKeyDown (KeyCode.R)) {
			playerState = States.cell;
		} 
	}
	//States after picking up the mirror
	void stateCellMirror () {		
		textDiscription.text =  "You pry of the jagged frame fragment from the mirror.\n" +
								"Some ragged sheets are on the bed, and the cell door remains locked.\n\n" +
								"Press 'S' to look at the Sheets\n" +
								"Press 'D' to look at the Door";
		if (Input.GetKeyDown (KeyCode.S)) {
			playerState = States.sheets_1;
		} else if (Input.GetKeyDown (KeyCode.D)){
			playerState = States.door_1;
		}
		
	}
	void stateSheets_1 (){
		textDiscription.text = "The sheets look stained and ripped. You hope non of it came in contact with your face.\n\n" +
			"Press 'R' to return";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			playerState = States.cell_mirror;
		} 
	}
	void stateDoor_1 () {		
		textDiscription.text =	"The door looks solid enough.\n\n" +
								"Press 'M' to use the Mirror Fragment on the lock\n" +
								"Press 'R' to return";
		if (Input.GetKeyDown (KeyCode.R)) {
			playerState = States.cell_mirror;
		} else if (Input.GetKeyDown (KeyCode.M)){
			playerState = States.corridor_0;
		}
	}
	//escape
	void stateCorridor (){
		textDiscription.text = 	"Freedom! Wait. No. That's not the outdoors. That's the opposite of the outdoors. " +
								"You are standing in a dimly lit corridor. The floor is a pale green. There is a closet door to the left. " +
								"There appear to be stairs at the end of the hallway.\n\n" +
								"Press 'C' to look at the closet\n" +
								"Press 'F' to look at the floor\n" +
								"Press 'S' to go up the stairs";
		if (Input.GetKeyDown (KeyCode.C))		{playerState = States.closet_door;}
		else if (Input.GetKeyDown (KeyCode.F))	{playerState = States.floor;}
		else if (Input.GetKeyDown (KeyCode.S))	{playerState = States.stairs_0;}
	}
	void stateStairs (){
		textDiscription.text = 	"You approach the stairs but hear talking coming from up the stairwell. You doubt someone in " +
								"a prison outfit walking up the stairs will go unnoticed by those at the top. Better not risk it.\n\n" +
								"Press 'R' to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R))		{playerState = States.corridor_0;}
	}
	void stateFloor (){
		textDiscription.text = 	"The pale green of the floor reminds you of a hospital. Upon closer " +
								"Inspection you notice a bobby pin in the corner.\n\n" +
								"Press 'P' to Pickup the bobby pin\n" +
								"Press 'R' to Return to the corridor";
		if (Input.GetKeyDown (KeyCode.R))		{playerState = States.corridor_0;}
		else if (Input.GetKeyDown (KeyCode.P))	{playerState = States.corridor_1;}
	}
	void stateClosetDoor (){
		textDiscription.text = 	"You try the closet door, but despite jiggaling the handle, it remains locked. " +
								"\n\n" +
								"Press 'R' to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R))		{playerState = States.corridor_0;}
	}
	//after bobby pin
	void stateCorridor_1 (){
		textDiscription.text = 	"The bobby pin is now in your pocket.\n " +
								"You are standing in a dimly lit corridor. There is a closet door to the left and " +
								"stairs at the end of the hallway.\n\n" +
								"Press 'P' to try and pick the locked closet door with the bobby pin\n" +
								"Press 'S' to go up the stairs";
		if (Input.GetKeyDown (KeyCode.P))		{playerState = States.in_closet;}
		else if (Input.GetKeyDown (KeyCode.S))	{playerState = States.stairs_1;}
	}
	void stateStairs_1 (){
		textDiscription.text = 	"You approach the stairs but hear talking coming from up the stairwell. Looking at the bobby pin " +
								"in your hand, you contemplate how one would use it to disable the guards... Nothing pleasent comes to mind.\n\n" +
								"Press 'R' to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R))		{playerState = States.corridor_1;}

	}
	void stateInCloset (){
		textDiscription.text = 	"You have succesfully use the bobby pin to pick the lock on the door. Once inside the " +
								"closet you see a set of janitor's coveralls.\n\n" +
								"Press 'C' to put on the Coveralls\n" +
								"Press 'R' to return to the corridor";
		if (Input.GetKeyDown (KeyCode.C))		{playerState = States.corridor_3;}
		else if (Input.GetKeyDown (KeyCode.R))		{playerState = States.corridor_2;}
	}
	void stateCorridor_2 (){
		textDiscription.text = 	"You are standing in a dimly lit corridor. The open closet door is to the left and " +
								"the stairs are at the end of the hallway.\n\n" +
								"Press 'C' to go back into the Closet\n" +
								"Press 'S' to go up the stairs";
		if (Input.GetKeyDown (KeyCode.C))		{playerState = States.in_closet;}
		else if (Input.GetKeyDown (KeyCode.S))	{playerState = States.stairs_2;}
	}
	void stateStairs_2 (){
		textDiscription.text = 	"You approach the stairs but hear talking coming from up the stairwell. You doubt someone in " +
								"a prison outfit walking up the stairs will go unnoticed by those at the top. Better not risk it.\n\n" +
								"Press 'R' to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R))		{playerState = States.corridor_2;}
	}
	void stateCorridor_3 (){
		textDiscription.text = 	"You emerge from the closet dressed in the janitor's coveralls. The open closet door is to the left and " +
								"the stairs are at the end of the hallway.\n\n" +
								"This is silly, Press 'C' to go back into the closet and change\n" +
								"Press 'S' to go up the stairs";
		if (Input.GetKeyDown (KeyCode.C))		{playerState = States.in_closet;}
		else if (Input.GetKeyDown (KeyCode.S))	{playerState = States.courtyard;}
	}
	void stateCourtyard (){
		textDiscription.text = 	"You walk up the stairs, there are two guards at the top. You smile and nod as you walk by dressed in " +
								"your coveralls. They nod back and continue to talk about last night's sports-ball game.\n\n" +
								"Congratulations! You have escaped prison! That was easier than it probably should have been though. " +
								"Perhaps a word with your state official about prison system funding.\n" +
								"Press 'P' to play again";
		if (Input.GetKeyDown (KeyCode.P))		{playerState = States.cell;}
	}
}
