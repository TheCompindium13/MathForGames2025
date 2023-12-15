using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames2025
{
    internal class ProjectileSpawner : Actor
    {
        private Actor _owner;
        private float _projectilespeed;
        private string _projectilespritePath;

        /// <param name="position">The position of this spawner in relation to its parent</param>
        /// <param name="owner">The owner for this spawner and for each projectile</param>
        /// <param name="projectilespeed">The speed of projectiles emitted from this spawner</param>
        /// <param name="projectilespritePath">The path to use when loading projectile sprite images</param>

        public ProjectileSpawner(Vector2 position, Actor owner, float projectilespeed, string projectilespritePath) : base("", position)
        {
            _owner = owner;
            Parent = _owner;
            _projectilespeed = projectilespeed;
            _projectilespritePath = projectilespritePath;
            Engine.AddActortoScene(this);
        }
        /// <summary>
        /// Creates a new instance of the projectile and adds it to the scene
        /// </summary>
        public void SpawnProjectile()
        {

            _projectilespeed = 200;
            Bullet bullet = new Bullet(_projectilespritePath, WorldPosition, _owner, Parent.Facing * _projectilespeed);
            bullet.Size = new Vector2(100f, 100f);
            Engine.AddActortoScene(bullet);


        }
    }
}
