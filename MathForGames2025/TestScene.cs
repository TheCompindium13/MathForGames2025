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
        private Enemy _testenemy;


        
        public override void Start()
        {
            
            base.Start();
            Vector2 startPosition = new Vector2(0, 0);
            Vector2 enemystartPosition = new Vector2(400, 200);    

            Icon playerIcon = new Icon { RaylibColor = Color.YELLOW, Symbol = "H"};
            Icon enemyIcon = new Icon { RaylibColor = Color.RED, Symbol = "R" };


            _testActor = new Player(playerIcon, startPosition);
            _testenemy = new Enemy(_testActor, enemyIcon, enemystartPosition, .3f, 100f);

            _testActor.Start();
            _testenemy.Start();
        }

        public override void Draw()
        {
            base.Draw();
            _testActor.Draw();
            _testenemy.Draw();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            _testActor.Update(deltaTime);
            _testenemy.Update(deltaTime);
        }
    }
}
