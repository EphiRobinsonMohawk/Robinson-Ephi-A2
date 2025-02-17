// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        bool rDown = false;
        bool gDown = false;
        bool bDown = false;
        bool moveDone = false;
        bool moveDoneU = false;
        int r = (Random.Integer(1, 256));
        int g = (Random.Integer(1, 256));
        int b = (Random.Integer(1, 256));
        int[] duckSpotsX = [Random.Integer(50, 350), Random.Integer(100, 300), Random.Integer(150, 250)];
        int[] duckSpotsY = [Random.Integer(50, 350), Random.Integer(100, 300), Random.Integer(150, 250)];
        float mousePosX = 160;
        float mousePosY = 160;
        int move = 0;
        int moveU = 0;
        int[] randomsX = [Random.Integer(1, 20), Random.Integer(10, 30), Random.Integer(20, 40)];
        int[] randomsY = [Random.Integer(1, 20), Random.Integer(10, 30), Random.Integer(20, 40)];
        Color yellow = new Color(249, 252, 33);
        Color orange = new Color(227, 130, 27);
        //
        ///     Setup runs once before the game loop begins.
        public void Setup()
        {
            Window.SetSize(400, 400);
            
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Color color1 = new(r, g, b);
            Window.ClearBackground(color1);

            // if statement to find the mouse when you hit spacebar
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                mousePosX = Input.GetMouseX() - 38;
                mousePosY = Input.GetMouseY() - 38;
            }

            // loop to spawn a school of fishes
            for (int i = 0; i < 3; i++)
            {
                drawFish(move + randomsX[i], move + randomsY[i]);
            }

            // code to spawn the duck where the mouse is when the player hits space
            spawnDuck(mousePosX, mousePosY);
      
            //loop to make 3 ducks spawn in increasingly towards the center //Anything higher than i < 3 causes crashed
            for (int i = 0; i < 3; i++)
            {
                spawnDuck(duckSpotsX[i], duckSpotsY[i]);
            }

            // Code to make the position the fish's spawn position move across the screen
            if (moveDone == false)
            {
                move++;
            }
            if (moveDone == true)
            {
                move = 0;
            }
            if (move == 0)
            {
                moveDone = false;
            }
            if (move == 400)
            {
                moveDone = true;
            }
            // Code to make the position the fish spawns at go up and down //Not working as intended. 🤷‍
            if (moveDoneU == false)
            {
                moveU++;
            }
            if (moveDoneU == true)
            {
                moveU--;
            }
            if (moveU == 1)
            {
                moveDoneU = false;
            }
            if (move == 20)
            {
                moveDoneU = true;
            }

            //if statements to slowly increase the r g b values to make a colour shifting effect
            if (rDown == false)
            {
                r++;
            }
            if (rDown == true)
            {
                r--;
            }
            if (r == 1)
            {
                rDown = false;
            }
            if (r == 256)
            {
                rDown = true;
            }
            if (gDown == false)
            {
                g++;
            }
            if (gDown == true)
            {
                g--;
            }
            if (g == 1)
            {
                gDown = false;
            }
            if (g == 256)
            {
                gDown = true;
            }
            if (bDown == false)
            {
                b++;
            }
            if (bDown == true)
            {
                b--;
            }
            if (b == 1)
            {
                bDown = false;
            }
            if (b == 256)
            {
                bDown = true;
            }

        }

        //function to draw fish
        void drawFish(float x, float y)
        {
            // Body
            Draw.FillColor = Color.Blue;
            Draw.Ellipse(x + 20, y + 20, 20, 14);
            
            // Eye
            Draw.FillColor = Color.Black;
            Draw.Circle(x + 25, y + 15, 3);

            // Fin
            Draw.FillColor = Color.Blue;
            Draw.Triangle(x + 15, y + 20, x, y + 30, x, y + 10);

        }
        //function to draw duck
        void spawnDuck(float x, float y)
        {
            //Neck
            Draw.FillColor = yellow;
            Draw.Rectangle(33 + x, 26 + y, 12, 18);

            //behind head (eye)
            Draw.FillColor = Color.Black;
            Draw.Circle(50 + x, 8 + y, 3);

            //Head
            Draw.FillColor = yellow;
            Draw.Circle(40 + x, 20 + y, 15);

            //infront of head (eye)
            Draw.FillColor = Color.Black;
            Draw.Circle(40 + x, 20 + y, 3);

            //Beak
            Draw.FillColor = orange;
            Draw.Triangle(53 + x, 18 + y, 65 + x, 30 + y, 50 + x, 25 + y);

            //Claw?
            Draw.FillColor = orange;
            Draw.Triangle(45 + x, 67 + y, 50 + x, 75 + y, 55 + x, 70 + y);

            //Claw Left
            Draw.FillColor = orange;
            Draw.Triangle(34 + x, 67 + y, 32 + x, 75 + y, 38 + x, 77 + y);

            //Body
            Draw.FillColor = yellow;
            Draw.Ellipse(40 + x, 55 + y, 42, 30);

            //Wing
            Draw.FillColor = yellow;
            Draw.Triangle(25 + x, 54 + y, 43 + x, 48 + y, 45 + x, 64 + y);
        }
    }

}
