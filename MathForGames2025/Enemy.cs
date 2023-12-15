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

        public Enemy(Character target, Icon icon, Vector2 position, float maxangle, float seedistance) : base(icon, position)
        {
            _target = target;
            _maxangle = maxangle;
            _seedistance = seedistance;

        }
        public Enemy(Character target, string spritePath, Vector2 position, float maxangle, float seedistance) : base(spritePath, position)
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
