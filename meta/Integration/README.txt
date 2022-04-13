Starship is controlled by the FlightComputer.cs module. Which is integrated into the navLight1 part. 
The part is completely arbitrary. I just used one which I could easily add and did not use otherwise.

	MODULE
	{
		name = FlightComputer
	}

navLight1.cfg can be found here: ...\Kerbal Space Program\GameData\Squad\Parts\Utility\Lights

Starship's flight path is defined in an .xml file. It must be located here:
...\Kerbal Space Program\GameData\FlightComputer\Configs\flight_segment_configs.xml 
Versions of it can be found in the \Progress folder starting from \7_Control_The_Aerodynamic_Descent_With_Xml