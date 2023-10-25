using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGames2025
{
    internal class Enemy : Character
    {
        private Character _target;
        private float _maxangle;
        private float _seedistance;

        public Enemy(Character target, Icon icon, Vector2 position, float maxangle, float seedistance) : base(icon, position)
        {
            _target = target;
            _maxangle = maxangle;
            _seedistance = seedistance;

        }
        public float MaxAngle
        {
            get { return _maxangle; }
            set { _maxangle = value; }
        }
        public float SeeDistance
        {
            get { return _seedistance; }
            set { _seedistance = value; }
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update(float deltaTime)
        {



            //vector = enemy to target
            Vector2 enemytotarget = _target.Position - Position; 
            //normalise vector
            Vector2 direction = enemytotarget.GetNormalized();

            float dotproduct = Vector2.DotProduct(direction, Facing);

            Console.WriteLine("Dot Product: " + dotproduct);

            
            Icon newicon = Actoricon;

            newicon.RaylibColor = Color.YELLOW;

            Actoricon = newicon;
            
            if (dotproduct <= _maxangle)
            {
                return;
            }
            if (Vector2.GetDistance(_target.Position, Position) >= _seedistance)
            {
                return;
            }
            newicon.RaylibColor = Color.RED;

            Actoricon = newicon;


            //set velocity to be vector scaled by speed
            Velocity = direction * 100;


            //(Done) The enemy should only be able to see the player if they are within a certain angle relative to the enemy's forward facing vector. 

            //(Done) The ability to change the viewing angle for the enemy in radians in the constructor.

            //(Done) The enemy should only be able to view the player if they are within some given distance. 

            //(Done) The ability to set the max Seeing distance in the constructor.

            base.Update(deltaTime);


        }
    }
}
