using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGames2025
{
    internal class Enemy : Character
    {
        private Character _target;

        public Enemy(Character target, Icon icon, Vector2 position) : base(icon, position)
        {
            _target = target;
        }

        public override void Update(float deltaTime)
        {

            //vector enemy to target
            Vector2 enemytotarget = _target.Position - Position; 
            //normalise vector
            Vector2 direction = enemytotarget.GetNormalized();
            //set velocity to be vector scaled by speed
            Velocity = direction * 100;

            base.Update(deltaTime);


        }
    }
}
