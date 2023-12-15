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
        private float _despawnTime = 1.0f;
        private float _currentTime;
        /// <param name="spritePath">the filepath of the image that is releted to the bullet</param>
        /// <param name="position">the location of the bullet in the game scene</param>
        /// <param name="owner">the class that this object is connected to</param>
        /// <param name="velocity">the direction that the bullet moves</param>

        public Bullet(string spritePath, Vector2 position, Actor owner, Vector2 velocity) : base(spritePath, position)
        {
            _owner = owner;
            _velocity = velocity;

            _bulletcollider = new CircleCollider(20, this);
            AttachedCollider = _bulletcollider;
        }
        public override void OnCollision(Actor other)
        {
            Console.WriteLine(other);

            if (other == _owner)
            {
                return;
            }
                
            if (other != _owner)
            {
                other.WorldPosition = new Vector2(450,800);

            }
            base.OnCollision(other);
        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            
            LocalPosition += _velocity * deltaTime;

            _currentTime += deltaTime;

            if (_currentTime >= _despawnTime)
            {
                Engine.RemoveActorfromScene(this);
            }
        }
    }
}
