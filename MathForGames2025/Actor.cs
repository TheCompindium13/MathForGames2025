
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
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private bool _started;
        private Collider _collider;
        private Sprite _sprite;
        public Vector2 Position
        {
            get { return new Vector2(_translation.M02, _translation.M12); }
            set
            {
                _translation.M02 = value.X;
                _translation.M12 = value.Y;
            }
        }
        public Actor(string spritePath, Vector2 position )
        {
            _sprite = new Sprite(spritePath);
            Position = position;
        }
        public Vector2 Facing
        {
            get { return new Vector2(_rotation.M00, _rotation.M01).GetNormalized(); }

        }
        public Vector2 Size
        {
            get
            {
                return new Vector2(_scale.M00, _scale.M11);
            }
            set
            {

                _scale.M00 = value.X;
                _scale.M11 = value.Y;

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
            UpdateTransforms();
        }

        public virtual void Draw()
        {
            //Engine.Render(_icon, Position);



            //Draw the sprite if this actor has one
            if (_sprite != null)
            {
                _sprite.Draw(_transform);
            }
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
        /// <summary>
        /// move the actor by the given amount from its current position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Translate(float x, float y)
        {
            _translation *= Matrix3.CreateTranslation(x, y);
        }
        /// <summary>
        /// Sets the actors position to be the given value.
        /// </summary>
        /// <param name="x">The new x axis position</param>
        /// <param name="y">The new y axis position</param>
        public void SetTranslation(float x, float y)
        {
            _translation = Matrix3.CreateTranslation(x,y);
        }
        public void Scale(float x, float y)
        {
            _scale *= Matrix3.CreateScale(x, y);


        }
        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);

        }
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);

        }
        public void SetRotate(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);

        }
        /// <summary>
        /// Concatenates all of the transformations matrices and stores the result into the actor transform
        /// </summary>
        private void UpdateTransforms()
        {
            _transform = _translation * _rotation * _scale;
        }
    }

}
