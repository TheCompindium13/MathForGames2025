using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
namespace MathForGames2025
{
    internal class Player : Character
    {
        public float _speed = 400;

        public Player(Icon icon, Vector2 position) : base (icon, position) 
        {
            
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            Console.WriteLine("_________________________");
            Console.WriteLine("Position X:" + Position.X);
            Console.WriteLine("_________________________");
            Console.WriteLine("Position Y:" + Position.Y);
            Console.WriteLine("_________________________");
            Console.WriteLine(deltaTime);


            //char direction = Engine.GetInput();

            Vector2 direction = new Vector2();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                direction += new Vector2(0, -1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                direction += new Vector2(0, 1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                direction += new Vector2(-1, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                direction += new Vector2(1, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            {
                _speed = 1000;
            }
            else
            {
                _speed = 400;
            }
            Velocity = direction.GetNormalized() * _speed;

            Position += Velocity * deltaTime;

            //This set of if statements wraps the player icon around to the other side
            //------------------------------------------------------------------------
            if (Position.X >= 800)
            {
                Position = new Vector2(0, Position.Y);
            }
            else if (Position.X <= -360)
            {
                Position = new Vector2(800, Position.Y);
            }
            if (Position.Y >= 450)
            {
                Position = new Vector2(Position.X, 0);
            }
            else if (Position.Y <= -47)
            {
                Position = new Vector2(Position.X, 450);
            }
            //------------------------------------------------------------------------
        }
    }
}
