using MathLibrary;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames2025
{
    internal class Character : Actor
    {
        private Vector2 _velocity;

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
        public override void OnCollision(Actor other)
        {
            Icon newicon = Actoricon;
            newicon.RaylibColor = Color.YELLOW;

            Actoricon = newicon;
            if (!CheckCollision(other))
            {
                return;
            }

            newicon.RaylibColor = Color.WHITE;

            Actoricon = newicon;
        }
        public override void Draw()
        {
            Vector2 endposition = Position + Facing * 100;
            Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)endposition.X, (int)endposition.Y, Actoricon.RaylibColor);
            base.Draw();
        }
        public Character(Icon icon, Vector2 position) : base(icon, position)
        {
        }
        public Character(string spritePath, Vector2 position) : base(spritePath, position)
        {

        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            Position += Velocity * deltaTime;
            
            //(Done) The enemy's facing should always be in the last direction they were moving in.
            
            //Facing = Velocity.GetNormalized();

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
