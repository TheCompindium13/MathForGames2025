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
        private Actor _testSun;
        private Actor _testEarth;
        private Actor _testMars;
        private Actor _testJup;
        private Actor _testPluto;
        private Actor _testMoon;
        private Actor _testSaturn;
        private Actor _testVenus;
        private Actor _testGali;
        private Actor _testJim;

        public override void Start()
        {
            Matrix3 testa = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 testb = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 sum = testa * testb;

            Vector2 startPosition = new Vector2(0, 0);
            Vector2 enemystartPosition = new Vector2(400, 200);
            Vector2 nicstartPosition = new Vector2(200, 400);
            //Vector2 sunstartPosition = new Vector2(1, 0);
            //Vector2 earthstartPosition = new Vector2(2, 1);
            //Vector2 jupstartPosition = new Vector2(2, 0);
            //Vector2 marsstartPosition = new Vector2(1, 2);
            //Vector2 plutostartPosition = new Vector2(2, 1);
            //Vector2 moonstartPosition = new Vector2(-1, 0);
            //Vector2 saturnstartPosition = new Vector2(-2, -1);
            //Vector2 venusstartPosition = new Vector2(0, -2);
            //Vector2 galistartPosition = new Vector2(0, -1);
            //Vector2 jimstartPosition = new Vector2(0, 1);
            Icon playerIcon = new Icon{ RaylibColor = Color.YELLOW, Symbol = "H"};
            Icon enemyIcon = new Icon{ RaylibColor = Color.RED, Symbol = "R" };
            Icon nicIcon = new Icon{ RaylibColor = Color.BEIGE, Symbol = "NIC" };

            _testActor = new Player("Images/Nic.png", startPosition);
            _testEnemy = new Enemy(_testActor, "Images/nicbullet.png", enemystartPosition, .3f, 100f);
            _testNic = new Enemy(_testActor, "Images/nic2.0.png", nicstartPosition, .3f, 100f);
            //_testSun = new Actor("Images/planet00.png", sunstartPosition);
            //_testEarth = new Actor("Images/planet01.png", earthstartPosition);
            //_testMars = new Actor("Images/planet02.png", marsstartPosition);
            //_testJup = new Actor("Images/planet03.png", jupstartPosition);
            //_testPluto = new Actor("Images/planet04.png", plutostartPosition);
            //_testMoon = new Actor("Images/planet05.png", moonstartPosition);
            //_testSaturn = new Actor("Images/planet06.png", saturnstartPosition);
            //_testVenus = new Actor("Images/planet07.png", venusstartPosition);
            //_testGali = new Actor("Images/planet08.png", galistartPosition);
            //_testJim = new Actor("Images/planet09.png", jimstartPosition);

            _testActor.Size = new Vector2(100, 100);
            _testEnemy.Size = new Vector2(100, 100);
            _testNic.Size = new Vector2(100, 100);
            //_testSun.Size = new Vector2(1, 1);
            //_testEarth.Size = new Vector2(1, 1);
            //_testMars.Size = new Vector2(1, 1);
            //_testJup.Size = new Vector2(1, 1);
            //_testPluto.Size = new Vector2(1, 1);
            //_testMoon.Size = new Vector2(1, 1);
            //_testSaturn.Size = new Vector2(1, 1);
            //_testVenus.Size = new Vector2(1, 1);
            //_testGali.Size = new Vector2(1, 1);
            //_testJim.Size = new Vector2(1, 1);
            CircleCollider playercollider = new CircleCollider(20, _testActor);
            CircleCollider enemycollider = new CircleCollider(_testEnemy.MaxAngle, _testEnemy);
            CircleCollider niccollider = new CircleCollider(_testNic.MaxAngle, _testNic);

            _testSun.Parent = _testActor;
            _testEarth.Parent = _testActor;
            _testMars.Parent = _testActor;
            _testJup.Parent = _testActor;
            _testPluto.Parent = _testActor;
            _testMoon.Parent = _testActor;
            _testSaturn.Parent = _testActor;
            _testVenus.Parent = _testActor;
            _testGali.Parent = _testActor;
            _testJim.Parent = _testActor;



            _testActor.AttachedCollider = playercollider;
            _testEnemy.AttachedCollider = enemycollider;
            _testNic.AttachedCollider = niccollider;

            AddActor(_testActor);
            AddActor(_testEnemy);
            AddActor(_testNic);
            //AddActor(_testSun);
            //AddActor(_testEarth);
            //AddActor(_testMars);
            //AddActor(_testJup);
            //AddActor(_testPluto);
            //AddActor(_testMoon);
            //AddActor(_testSaturn);
            //AddActor(_testVenus);
            //AddActor(_testGali);
            //AddActor(_testJim);




            base.Start();

        }


    }
}
