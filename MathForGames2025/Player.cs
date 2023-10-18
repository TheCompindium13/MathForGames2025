using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
namespace MathForGames2025
{
    internal class Player : Actor
    {
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

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                Position += new Vector2(0, -400) * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                Position += new Vector2(0, 400) * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                Position += new Vector2(-400, 0) * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                Position += new Vector2(400, 0) * deltaTime;
            }

            if (Position.X >= 800)
            {
                Position = new Vector2(0, Position.Y);
            }
            else if (Position.X <= -800)
            {
                Position = new Vector2(800, Position.Y);
            }
            if (Position.Y >= 450)
            {
                Position = new Vector2(Position.X, 0);
            }
            else if (Position.Y <= -450)
            {
                Position = new Vector2(Position.X, 450);
            }
        }
    }
}
