using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames2025
{
    internal class Scene
    {
        private Actor[] _actors;

        /// <summary>
        /// adds a(n) actor to an actor array
        /// </summary>
        /// <param name="actor">the actor to be added</param>
        public void AddActor(Actor actor)
        {
            if (_actors == null)
            {
                _actors = new Actor[0];
            }
            //a new array with a size one greater than our old array
            Actor[] temp = new Actor[_actors.Length + 1];
            //the values from the old array to be added to the new array
            for (int i = 0; i < _actors.Length; i++)
            {
                temp[i] = _actors[i];
            }
            //Sets the last value in the new array to be the actor we want to add
            temp[_actors.Length] = actor;
            //Set old array to hold the values of the new array
            _actors = temp;
        }
        /// <summary>
        /// removes a(n) actor from an actor array
        /// </summary>
        /// <param name="actorToRemove">the actor to be removed</param>
        /// <returns></returns>
        public bool RemoveActor(Actor actorToRemove)
        {
            //a check to make sure the actorToRemove is not null
            if (actorToRemove == null)
            {
                return false;
            }
            //if actor is null or the actor length is 0 return
            if (_actors == null || _actors.Length == 0)
            {
                return false;
            }
            //this is a new array with a size one greater than our old array
            Actor[] temp = new Actor[_actors.Length - 1];
            
            //variable created to store if the actor was removed
            bool actorRemoved = false;
            
            //variable created to access the temporary array index
            int j = 0;
            //Copy values from the old array to the new array except the actor to be removed
            for (int i = 0; i < _actors.Length; i++)
            {
                //If the actor to remove was skipped, set the actor removed variable to true.
                if (_actors[i] == actorToRemove)
                {
                    actorRemoved = true;
                    continue;
                }

                temp[j] = _actors[i];
                j++;
            }
            //Sets the old array to the new array
            _actors = temp;

            return actorRemoved;
        }
        public virtual void Start()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }
        
        public virtual void Update(float deltaTime)
        {
            // runs through each actor in a(n) actor array to check if they exist
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                {
                    _actors[i].Start();
                }
                _actors[i].Update(deltaTime);
                //checks to see if each actor in a(n) actor array has a collider or not
                if (_actors[i].AttachedCollider == null)
                {
                    continue;
                }
                
                for (int j = 0; j < _actors.Length; j++)
                {
                     if (_actors[i] == _actors[j])
                    {
                        continue;
                    }

                    if (_actors[i].CheckCollision(_actors[j]))
                    {
                        _actors[i].OnCollision(_actors[j]);
                    }
                }
            }
            
        }

        public virtual void Draw()
        {
            //Adds the visuals of the actors to the scene
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();

            }

        }

        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();

            }
        }
    }
}
