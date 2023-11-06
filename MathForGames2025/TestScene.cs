using System;
using System.Collections.Generic;
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

        
        public override void Start()
        {
            

            Vector2 startPosition = new Vector2(0, 0);
            Vector2 enemystartPosition = new Vector2(400, 200);
            Vector2 nicstartPosition = new Vector2(200, 400);
            
            Icon playerIcon = new Icon{ RaylibColor = Color.YELLOW, Symbol = "H"};
            Icon enemyIcon = new Icon{ RaylibColor = Color.RED, Symbol = "R" };
            Icon nicIcon = new Icon{ RaylibColor = Color.BEIGE, Symbol = "NIC" };

            _testActor = new Player("Images/Nic.png", startPosition);
            _testEnemy = new Enemy(_testActor, "Images/nicbullet.png", enemystartPosition, .3f, 100f);
            _testNic = new Enemy(_testActor, "Images/nic2.0.png", nicstartPosition, .3f, 100f);

            _testActor.Size = new Vector2(100, 100);
            _testEnemy.Size = new Vector2(50, 50);
            _testNic.Size = new Vector2(50, 50);

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


    }
}
