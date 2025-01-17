﻿using MathLibrary;
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
        public float _speed = 05;

        public Player(Icon icon, Vector2 position) : base (icon, position) 
        {
            
        }
        public Player(string spritePath, Vector2 position) : base(spritePath, position) 
        { 
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            _speed = 20;
        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            
            Console.WriteLine("_________________________");
            Console.WriteLine("Position X:" + LocalPosition.X);
            Console.WriteLine("_________________________");
            Console.WriteLine("Position Y:" + LocalPosition.Y);
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
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                Rotate(.1f);
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                Rotate(-10f);
            }
            else
            {
                _speed = 400;
            }
            Rotate(100f);
            Velocity = direction.GetNormalized() * _speed * deltaTime;

            Translate(Velocity.X, Velocity.Y);

            Icon newicon = Actoricon;

            newicon.RaylibColor = Color.YELLOW;

            Actoricon = newicon;
        }
    }
}
