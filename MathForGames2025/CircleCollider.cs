using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGames2025
{
    internal class CircleCollider : Collider
    {
        private float _radius;

        public CircleCollider(float radius, Actor owner) : base(0, owner)
        {
            _radius = radius;
        }
        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        //make an overrided function for checking collision with a circle
        
        public override bool CheckCollisionCircle(CircleCollider collider)
        {
            float distance = Vector2.GetDistance(Owner.LocalPosition, collider.Owner.LocalPosition);
            float RemainingRadius = Radius + collider.Radius;
            if (distance <= RemainingRadius)
            {
                return true;
            }
            return base.CheckCollisionCircle(collider);

        }
    }
}
