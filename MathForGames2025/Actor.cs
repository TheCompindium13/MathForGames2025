
using System;
using System.Buffers;
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
        private Matrix3 _transform = Matrix3.Identity;
        private bool _started;
        private Collider _collider;
        private Sprite _sprite;
        public Vector2 Position
        {
            get { return new Vector2(_transform.M02, _transform.M12); }
            set
            {
                _transform.M02 = value.X;
                _transform.M12 = value.Y;
            }
        }
        public Actor(string spritePath, Vector2 position )
        {
            _sprite = new Sprite(spritePath);
            Position = position;
        }
        public Vector2 Facing
        {
            get { return new Vector2(_transform.M00, _transform.M01).GetNormalized(); }

        }
        public Vector2 Scale
        {
            get
            {
                float Xscale = new Vector2 (_transform.M00, _transform.M01).GetMagnitude();
                float Yscale = new Vector2(_transform.M01, _transform.M11).GetMagnitude();

                return new Vector2(Xscale, Yscale);
            }
            set
            {
                Vector2 xAxis = new Vector2 (_transform.M00, _transform.M01).GetNormalized() * value.X;
                Vector2 yAxis = new Vector2(_transform.M01, _transform.M11).GetNormalized() * value.Y;

                _transform.M00 = xAxis.X;
                _transform.M10 = xAxis.Y;

                _transform.M01 = yAxis.X;
                _transform.M11 = yAxis.Y;

            }
        }
        public Collider AttachedCollider
        {
            get { return _collider; }
            set { _collider = value; }
        }
        public Actor(Icon icon, Vector2 position) 
        {
            _icon = icon;
            Position = position;
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
            //Engine.Render(_icon, Position);



            //Draw the sprite if this actor has one
            if (_sprite != null)
                _sprite.Draw(_transform);
        }

    

    public virtual void End()
        {

        }
        public virtual void OnCollision(Actor other)
        {
            
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
