using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames2025
{
    internal class Scene
    {
        private Actor[] _actors;


        public void AddActor(Actor actor)
        {
            if (_actors == null)
            {
                _actors = new Actor[0];
            }
            Actor[] temp = new Actor[_actors.Length + 1];
            
            for (int i = 0; i < _actors.Length; i++)
            {
                temp[i] = _actors[i];
            }
            temp[_actors.Length] = actor;

            _actors = temp;
        }

        public bool RemoveActor(Actor actorToRemove)
        {
            if (actorToRemove == null)
            {
                return false;
            }

            if (_actors == null || _actors.Length == 0)
            {
                return false;
            }
            Actor[] temp = new Actor[_actors.Length - 1];

            bool actorRemoved = false;

            int j = 0;
            for (int i = 0; i < _actors.Length; i++)
            {
                
                if (_actors[i] == actorToRemove)
                {
                    actorRemoved = true;
                    continue;
                }

                temp[j] = _actors[i];
                j++;
            }

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
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                {
                    _actors[i].Start();
                }
                _actors[i].Update(deltaTime);

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
