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
        private Enemy _testJim;

        
        public override void Start()
        {
            

            Vector2 startPosition = new Vector2(0, 0);
            Vector2 enemystartPosition = new Vector2(400, 200);
            Vector2 jimstartPosition = new Vector2(200, 400);
            Icon playerIcon = new Icon { RaylibColor = Color.YELLOW, Symbol = "H"};
            Icon enemyIcon = new Icon { RaylibColor = Color.RED, Symbol = "R" };
            Icon jimIcon = new Icon { RaylibColor = Color.BEIGE, Symbol = "JIM" };

            _testActor = new Player("Images/Nic.png", startPosition);
            _testActor.Scale = new Vector2(50, 50);
            _testEnemy = new Enemy(_testActor, "Images/nicbullet.png", enemystartPosition, .3f, 100f);
            _testEnemy.Scale = new Vector2(50, 50);

            _testJim = new Enemy(_testActor, jimIcon, jimstartPosition, .3f, 100f);


            CircleCollider playercollider = new CircleCollider(20, _testActor);
            CircleCollider enemycollider = new CircleCollider(_testEnemy.MaxAngle, _testEnemy);
            CircleCollider jimcollider = new CircleCollider(_testJim.MaxAngle, _testJim);


            _testActor.AttachedCollider = playercollider;
            _testEnemy.AttachedCollider = enemycollider;
            _testJim.AttachedCollider = jimcollider;

            AddActor(_testJim);
            AddActor(_testEnemy);
            AddActor(_testActor);

            base.Start();

        }


    }
}
