In this step I tried to control starship after flipping it horizontally.
The goal was to have a somewhat stable descent, to see if the flaps can control it.

The tricky part was to obtain correct sensor readings concerning the attitude of 
starship in horizontal position. The previous iteration of the responsible sensor 
was wrong and needed to be updated to use the angular velocity vector of the ship.

Controlling the flaps required understanding the control pattern of starship.
Meaning which flap positions lead to the desired change in attitude.