﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGames2025
{
    internal class TestScene : Scene
    {
        private Actor _testActor;

        public override void Start()
        {
            base.Start();
            Vector2 startPosition = new Vector2(9, 3);
            _testActor = new Actor('@', startPosition);

            _testActor.Start();
        }

        public override void Draw()
        {
            base.Draw();
            _testActor.Draw();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}