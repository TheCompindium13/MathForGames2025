using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGames2025
{
    internal class TestScene : Scene
    {
        private Player _testActor;
        private Enemy _testEnemy;
        private Enemy _testNic;
        Vector2 enemyendPosition = new Vector2(450, 800);


        public override void Start()
        {
            Matrix3 testa = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 testb = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 sum = testa * testb;

            Vector2 startPosition = new Vector2(0, 0);
            Vector2 enemystartPosition = new Vector2(400, 200);
            Vector2 nicstartPosition = new Vector2(200, 400);
            
            Icon playerIcon = new Icon{ RaylibColor = Color.YELLOW, Symbol = "H"};
            Icon enemyIcon = new Icon{ RaylibColor = Color.RED, Symbol = "R" };
            Icon nicIcon = new Icon{ RaylibColor = Color.BEIGE, Symbol = "NIC" };

            _testActor = new Player("Images/Nic.png", startPosition, 100);
            _testEnemy = new Enemy(_testActor, "Images/Blackheart.png", enemystartPosition, 100, .3f, 100f);
            if (enemystartPosition.X == _testEnemy.LocalPosition.X && enemystartPosition.Y == _testEnemy.LocalPosition.Y)
            {
                enemystartPosition = new Vector2(enemystartPosition.X, _testEnemy.LocalPosition.Y); ;
            }
            else if (enemystartPosition.X != _testEnemy.LocalPosition.X && enemystartPosition.Y != _testEnemy.LocalPosition.Y)
            {
                enemystartPosition = new Vector2(_testEnemy.LocalPosition.X, _testEnemy.LocalPosition.Y);
            }
            _testNic = new Enemy(_testActor, "Images/nic2.0.png", nicstartPosition, 100, .3f, 100f);

            _testActor.Size = new Vector2(100, 100);
            _testEnemy.Size = new Vector2(100, 100);
            _testNic.Size = new Vector2(100, 100);

            
            CircleCollider playercollider = new CircleCollider(20, _testActor);
            CircleCollider enemycollider = new CircleCollider(_testEnemy.MaxAngle, _testEnemy);
            CircleCollider niccollider = new CircleCollider(_testNic.MaxAngle, _testNic);


            _testActor.AttachedCollider = playercollider;
            _testEnemy.AttachedCollider = enemycollider;
            _testNic.AttachedCollider = niccollider;
            
            AddActor(_testActor);
            AddActor(_testEnemy);
            AddActor(_testNic);

            




            base.Start();

        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if (enemyendPosition.X == _testEnemy.WorldPosition.X && enemyendPosition.Y == _testEnemy.WorldPosition.Y && enemyendPosition.X == _testNic.WorldPosition.X && enemyendPosition.Y == _testNic.WorldPosition.Y)
            {
                Engine.EndApplication();
            }
        }

    }
}
