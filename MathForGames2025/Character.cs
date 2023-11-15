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
            other.SetScale(10, 10);
            Actoricon = newicon;
            if (!CheckCollision(other))
            {
                return;
            }

            newicon.RaylibColor = Color.WHITE;

            Actoricon = newicon;
        }
        private float _health;

        public override void Draw()
        {
            Vector2 endposition = LocalPosition + Facing * 100;
            Raylib.DrawLine((int)LocalPosition.X, (int)LocalPosition.Y, (int)endposition.X, (int)endposition.Y, Actoricon.RaylibColor);
            base.Draw();
        }
        public Character(Icon icon, Vector2 position) : base(icon, position)
        {
        }
        public Character(string spritePath, Vector2 position, float health) : base(spritePath, position)
        {

        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            LocalPosition += Velocity * deltaTime;
            
            //(Done) The enemy's facing should always be in the last direction they were moving in.
            
            //Facing = Velocity.GetNormalized();

            //This set of if statements wraps the player icon around to the other side
            //------------------------------------------------------------------------
            if (LocalPosition.X >= 800)
            {
                LocalPosition = new Vector2(0, LocalPosition.Y);
            }
            else if (LocalPosition.X <= -360)
            {
                LocalPosition = new Vector2(800, LocalPosition.Y);
            }
            if (LocalPosition.Y >= 450)
            {
                LocalPosition = new Vector2(LocalPosition.X, 0);
            }
            else if (LocalPosition.Y <= -47)
            {
                LocalPosition = new Vector2(LocalPosition.X, 450);
            }
            //------------------------------------------------------------------------
        }
    }
}
