using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace MathForGames2025
{
    internal class Engine
    {
        
        private const int _screenwidth = 800;
        private const int _screenheight = 450;
        private static bool _applicationShouldClose;
        private static Icon[,] _buffer;
        private static Scene _currentScene;
        private static Actor[] _actorstoRemove = new Actor[0]; 
        string M00 = Matrix3.Identity.M00.ToString(); string M01 = Matrix3.Identity.M01.ToString(); string M02 = Matrix3.Identity.M02.ToString();
        string M10 = Matrix3.Identity.M10.ToString(); string M11 = Matrix3.Identity.M11.ToString(); string M12 = Matrix3.Identity.M12.ToString();
        string M20 = Matrix3.Identity.M20.ToString(); string M21 = Matrix3.Identity.M21.ToString(); string M22 = Matrix3.Identity.M22.ToString();
        
        public static int ScreenWidth
        {
            get
                { return _screenwidth; }

        }
        public static int ScreenHeight
        {
            get
            { return _screenheight; }
        }


        private Stopwatch _stopwatch = new Stopwatch();
        
        private int[] _original = new int[] { 1, 2, 3 };
        private void Start()
        {
            Raylib.InitWindow(_screenwidth, _screenheight, "MATH FOR GAMES 2025");
            Raylib.SetTargetFPS(200);
            _stopwatch.Start();
            _currentScene = new TestScene();
            _buffer = new Icon[10, 10];

            _currentScene.Start();
            
        }
        public static Scene GetCurrentScene()
        {
            return _currentScene;
        }
        public static void Render(Icon icon, Vector2 position)
        {
            Raylib.DrawText(icon.Symbol, (int)position.X, (int)position.Y, 50, icon.RaylibColor);
            Raylib.DrawCircle((int)position.X, (int)position.Y, 20, Color.GREEN);
        }

        private void Draw()
        {
            
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.MAGENTA);

            _currentScene.Draw();
            
            
            
            Raylib.EndDrawing();
        }

        private void Update(float deltaTime)
        {
            _currentScene.Update(deltaTime);
            RemoveActors();
            
        }

        private void End()
        {
            _currentScene.End();
            Raylib.CloseWindow();
        }

        public static char GetInput()
        {
            return Console.ReadKey(true).KeyChar;
        }

        public static void EndApplication()
        {
            Raylib.DrawText("You Win Press escape to close game",200, 225, 20, Color.GREEN);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                _applicationShouldClose = true;

            }

        }
        /// <summary>
        /// Adds the given actor to the current scene array
        /// </summary>
        /// <param name="actortoSpawn">A reference to the actor to copy and add to the scene</param>
        /// <returns></returns>
        public static Actor AddActortoScene(Actor actortoSpawn)
        {
            _currentScene.AddActor(actortoSpawn);
            return actortoSpawn;

        }
        /// <summary>
        /// Removes the given actor from the current scene array
        /// </summary>
        /// <param name="actortoRemove">A reference to the actor to remove it from the scene</param>
        /// <returns></returns>
        public static void RemoveActorfromScene(Actor actortoRemove)
        {
            if (_actorstoRemove == null)
            {
                _actorstoRemove = new Actor[0];
            }
            Actor[] temp = new Actor[_actorstoRemove.Length + 1];

            for (int i = 0; i < _actorstoRemove.Length; i++)
            {
                temp[i] = _actorstoRemove[i];
            }
            temp[_actorstoRemove.Length] = actortoRemove;

            _actorstoRemove = temp;
        }
        private void RemoveActors()
        {
            for (int i = 0; i < _actorstoRemove.Length; i++)
            {
                _currentScene.RemoveActor(_actorstoRemove[i]);
            }
            _actorstoRemove = new Actor[0];
        }
        public void Run()
        {
            Matrix3 testa = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 testb = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);


            Vector2 test = new Vector2(10, 10);

            Vector2 test3 = new Vector2(10, 10);

            Vector2 test2 = test.GetNormalized();

            float magnitude = test2.GetMagnitude();
            
            Start();
            float currentTime = 0f;
            float lastTime = 0f;
            float deltaTime = 0f;
            
            
            while (!_applicationShouldClose && !Raylib.WindowShouldClose())
            {

                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                deltaTime = currentTime - lastTime;
                
                Draw();
                Update(deltaTime);
                
                lastTime = currentTime;
            }

            End();
        }
    }
}
