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

        public override void Start()
        {
            base.Start();
            Vector2 startPosition = new Vector2(0, 0);

            Icon playerIcon = new Icon { RaylibColor = Color.YELLOW, Symbol = "H" + "a" + "i" + "d" + "o" + "n" + " " + "C" + "o" + "s" + "s" + "e" + "'"};

            _testActor = new Player(playerIcon, startPosition);

            _testActor.Start();
        }

        public override void Draw()
        {
            base.Draw();
            _testActor.Draw();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            _testActor.Update(deltaTime);
        }
    }
}
