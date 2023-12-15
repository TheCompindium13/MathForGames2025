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
        private float _speed = 05;
        private ProjectileSpawner _spawner;

        public Player(Icon icon, Vector2 position) : base (icon, position) 
        {
            
        }
        /// <param name="spritePath">the filepath of the image that is releted to the player</param>
        /// <param name="position">the location of the player in the game scene</param>
        public Player(string spritePath, Vector2 position) : base(spritePath, position) 
        {
            _spawner = new ProjectileSpawner(new Vector2(1, 0), this, 50, "Images/bullet.png");

        }
        public override void Draw()
        {

            base.Draw();

        }
        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            _speed = 20;
        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            Vector2 direction = new Vector2();
            //------------------------------------------------------------------------------------\\
            //Adds the new vector of to direction you want to go when you press the corrasponding key.
            //------------------------------------------------------------------------------------\\
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
            //------------------------------------------------------------------------------------\\
            //Sets the current speed when the Key is pressed down
            //------------------------------------------------------------------------------------\\
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            {
                _speed = 1000;
            }
            //------------------------------------------------------------------------------------\\
            //Pressing the corresponding key(s) will either rotate the player left or right but they cannot be held down
            //------------------------------------------------------------------------------------\\
            if (!Raylib.IsKeyUp(KeyboardKey.KEY_Q))
            {
                Rotate(.1f);
            }
            else if (!Raylib.IsKeyUp(KeyboardKey.KEY_E))
            {
                Rotate(-0.1f);
            }
            //------------------------------------------------------------------------------------\\
            //Checks the size of the player and if it is within the set paramaters increases/decreases he size of the player
            //------------------------------------------------------------------------------------\\
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) )
            {
                if (Size.X >= 500 && Size.Y >= 500)
                {
                    return;
                }
                Scale(2, 2);

            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO))
            {
                if (Size.X < 100 && Size.Y < 100)
                {
                    return;
                }
                Scale((float).2, (float).2);

            }
            //------------------------------------------------------------------------------------\\
            //Spawn a new bullet each time button is pressed.
            //------------------------------------------------------------------------------------\\
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                _spawner.SpawnProjectile();
                
            }
            //------------------------------------------------------------------------------------\\
            else
            {
                _speed = 400;
            }
            //------------------------------------------------------------------------------------\\
            Velocity = direction.GetNormalized() * _speed * deltaTime;

            Translate(Velocity.X, Velocity.Y);

            Icon newicon = Actoricon;

            newicon.RaylibColor = Color.YELLOW;

            Actoricon = newicon;
        }
    }
}
