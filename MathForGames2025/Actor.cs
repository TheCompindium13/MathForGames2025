
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGames2025
{
    struct Icon
    {
        private string _symbol;
        private Color _color;
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }    
        }

        public Color RaylibColor
        {
            get { return _color; }
            set { _color = value; }
        }
    }

    internal class Actor
    {
        private Icon _icon;
        private Vector2 _position;
        private Vector2 _facing = new Vector2(1,0);
        private bool _started;
        private Collider _collider;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Facing
        {
            get { return _facing; }
            set { _facing = value; }
        }
        public Collider AttachedCollider
        {
            get { return _collider; }
            set { _collider = value; }
        }
        public Actor(Icon icon, Vector2 position)
        {
            _icon = icon;
            _position = position;
        }
        public bool Started
        {
            get { return _started; }
        }
        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void Draw()
        {
            Engine.Render(_icon, _position);
        }

        public virtual void End()
        {

        }
        public virtual void OnCollision(Actor other)
        {
            if (other <= )
        }
        public bool CheckCollision(Actor other)
        {
            if (AttachedCollider == null || other.AttachedCollider == null)
            {
                return false;
            }
            return AttachedCollider.CheckCollision(other.AttachedCollider);
        }
        public Icon Actoricon
        {
            get { return _icon; }
            set { _icon = value; }
        }
    }
}
