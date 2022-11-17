---------------------------------------------------------------------------------------------------------------------------------------------
Toy Robot Coding Challenge
Instructions
	a. You are required to simulate a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
	b. There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction.
	c. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
	d. All commands should be discarded until a valid place command has been executed.
	e. The solution must be written in C#.
	f. The UI can be provided via CLI, however you are free to expand on this.
	g. We want to see what you can do, please put your best foot forward when architecting a solution.
	h. Give some consideration to testing.
	i. Include a README file with instructions on how to build/compile your solution and how to run it. Additionally, please mention any assumptions you've made.
	j. Share your code via a public GitHub repository, git bundle or zip file.
		We like to see how you work, not just the end result.

Commands
All commands should provide output indicating whether or not they succeeded.	
	a. PLACE X,Y,DIRECTION
		X and Y are integers that indicate a location on the tabletop.
		DIRECTION is a string indicating which direction the robot should face. It it one of the four cardinal directions: NORTH, EAST, SOUTH or WEST.
	b. MOVE
		Instructs the robot to move 1 square in the direction it is facing.
	c. LEFT
		Instructs the robot to rotate 90° anticlockwise/counterclockwise.
	d. RIGHT
		Instructs the robot to rotate 90° clockwise.
	e. REPORT
		Outputs the robot's current location on the tabletop and the direction it is facing.
---------------------------------------------------------------------------------------------------------------------------------------------

Clone this repo:

	git clone git@github.com:paulmarvinlumen/ToyRobotChallenge.git

Setup:

	Load your repo solution to Visual Studio and build it. Application was developed using Visual Studio 2019.


To Use:
	
	1. Create Commands.txt file inside the folder path C:\ToyRobot\Settings\ .
	2. Inside the Commands.txt file will be the commands for the Toy Robot.
		Example:
			PLACE 1,1,WEST
			MOVE
			RIGHT
			MOVE
			LEFT
			MOVE
			MOVE
			REPORT
	3. Run the application.
	4. Maximize the CLI for better display out.

Assumption:
	1. Start x,y position will be (0,0) coordinates.
	2. All Commands will be save in Commands.txt file. And it will be uploaded to Toy Robot Simulator.
	3. Assume all machine using this simulator has a C:\ drive where the Commands.txt will be save.