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


        
        public override void Start()
        {
            

            Vector2 startPosition = new Vector2(0, 0);
            Vector2 enemystartPosition = new Vector2(400, 200);    

            Icon playerIcon = new Icon { RaylibColor = Color.YELLOW, Symbol = "H"};
            Icon enemyIcon = new Icon { RaylibColor = Color.RED, Symbol = "R" };


            _testActor = new Player(playerIcon, startPosition);
            _testEnemy = new Enemy(_testActor, enemyIcon, enemystartPosition, .3f, 100f);

            CircleCollider playercollider = new CircleCollider(20, _testActor);
            CircleCollider enemycollider = new CircleCollider(_testEnemy.MaxAngle, _testEnemy);

            _testActor.AttachedCollider = playercollider;
            _testEnemy.AttachedCollider = enemycollider;

            AddActor(_testEnemy);
            AddActor(_testActor);

            base.Start();

        }


    }
}
