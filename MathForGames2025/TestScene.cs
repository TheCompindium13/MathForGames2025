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
        private Actor _testBody;
        Vector2 enemyendPosition = new Vector2(450, 800);


        public override void Start()
        {
            //this is the initial place in the scene where actors start at 
            //-----------------------------------------------------------------------------------------------------------\\
            Vector2 startPosition = new Vector2(0, 0);
            Vector2 enemystartPosition = new Vector2(400, 200);
            Vector2 nicstartPosition = new Vector2(200, 400);
            //-----------------------------------------------------------------------------------------------------------\\
            //where the base values for each actor get initialized
            //-----------------------------------------------------------------------------------------------------------\\
            _testActor = new Player("Images/Nic.png", startPosition);
            _testEnemy = new Enemy(_testActor, "Images/Blackheart.png", enemystartPosition, .3f, 100f);
            _testBody = new Actor(_testActor, "Images/RR.png", new Vector2(-0.15f,.48f));
            _testNic = new Enemy(_testActor, "Images/nic2.0.png", nicstartPosition, .3f, 100f);
            //-----------------------------------------------------------------------------------------------------------\\
            //Sets the size of each actor so they can be visable
            //-----------------------------------------------------------------------------------------------------------\\
            _testActor.Size = new Vector2(100, 100);
            _testEnemy.Size = new Vector2(100, 100);
            _testNic.Size = new Vector2(100, 100);
            _testBody.Size = new Vector2(1, 1);
            //-----------------------------------------------------------------------------------------------------------\\
            //Createing the colliders that are to be used by each actor
            //-----------------------------------------------------------------------------------------------------------\\
            CircleCollider playercollider = new CircleCollider(20, _testActor);
            CircleCollider enemycollider = new CircleCollider(_testEnemy.MaxAngle, _testEnemy);
            CircleCollider niccollider = new CircleCollider(_testNic.MaxAngle, _testNic);
            //-----------------------------------------------------------------------------------------------------------\\
            //Childs the new colliders to their respective actors
            //-----------------------------------------------------------------------------------------------------------\\
            _testActor.AttachedCollider = playercollider;
            _testEnemy.AttachedCollider = enemycollider;
            _testNic.AttachedCollider = niccollider;
            //-----------------------------------------------------------------------------------------------------------\\
            //This is where the actors are added to the scene array
            //-----------------------------------------------------------------------------------------------------------\\
            AddActor(_testBody);
            AddActor(_testActor);
            AddActor(_testEnemy);
            AddActor(_testNic);
            //-----------------------------------------------------------------------------------------------------------\\
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
