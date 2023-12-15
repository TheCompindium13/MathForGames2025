using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
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


        /// <param name="target">The opposeing force of the enemy</param>
        /// <param name="spritePath">the filepath of the image that is releted to the enemy</param>
        /// <param name="position">the location of the enemy in the game scene</param>
        /// <param name="maxangle">the max angle of the enemies cone of vison</param>
        /// <param name="seedistance">how far the enemy can see ahead of itself</param>
        public Enemy(Character target, string spritePath, Vector2 position, float maxangle, float seedistance) : base(spritePath, position)
        {
            _target = target;
            _maxangle = maxangle;
            _seedistance = seedistance;
            
        }
        /// <summary>
        /// the max angle of the enemies cone of vison
        /// </summary>
        public float MaxAngle
        {
            get { return _maxangle; }
            set { _maxangle = value; }
        }
        /// <summary>
        /// how far the enemy can see ahead of itself
        /// </summary>
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



            //vector subtracts the targets current position from the enemies current position
            Vector2 enemytotarget = _target.WorldPosition - WorldPosition; 
            //normalise vector
            Vector2 direction = enemytotarget.GetNormalized();

            float dotproduct = Vector2.DotProduct(direction, Facing);



            Icon newicon = Actoricon;

            newicon.RaylibColor = Color.YELLOW;

            Actoricon = newicon;

            if (dotproduct <= _maxangle)
            {
                return;
            }

            if (Vector2.GetDistance(_target.WorldPosition, WorldPosition) >= _seedistance)
            {

                return;

            }
            newicon.RaylibColor = Color.RED;
            SetScale(100,100);
            Actoricon = newicon;

            Velocity = direction * 100;

            base.Update(deltaTime);


        }
    }
}
