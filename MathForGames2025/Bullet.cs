using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames2025
{
    internal class Bullet : Actor
    {
        private Actor _owner;
        private Vector2 _velocity;
        private float _damage;
        private CircleCollider _bulletcollider;
        public Bullet(string spritePath, Vector2 position, Actor owner, Vector2 velocity, float damage) : base(spritePath, position)
        {
            _owner = owner;
            _velocity = velocity;
            _damage = damage;
            _bulletcollider = new CircleCollider(100, this);
            AttachedCollider = _bulletcollider;
        }
        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);
            if (other != _owner)
            {
                other.WorldPosition = new Vector2(100,100);
            }
        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            
            LocalPosition += _velocity * deltaTime;
        }
    }
}
