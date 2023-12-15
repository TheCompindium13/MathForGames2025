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

        private static Scene _currentScene;
        private static Actor[] _actorstoRemove = new Actor[0]; 

        
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
        
        private void Start()
        {
            Raylib.InitWindow(_screenwidth, _screenheight, "MATH FOR GAMES 2025");
            Raylib.SetTargetFPS(200);
            _stopwatch.Start();
            _currentScene = new TestScene();


            _currentScene.Start();
            
        }
        public static Scene GetCurrentScene()
        {
            return _currentScene;
        }
        /// <param name="icon">The image that is on screen</param>
        /// <param name="position">the location of the thing being rendered</param>
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
        /// Adds the actor to a list of actors to remove that is cleared after update is called
        /// </summary>
        /// <param name="actortoRemove">A reference to the actor to remove it from the scene</param>
        /// <returns></returns>
        public static void RemoveActorfromScene(Actor actortoRemove)
        {
            if (_actorstoRemove == null)
            {
                _actorstoRemove = new Actor[0];
            }
            //Creates a new array with a size one greater than our old array
            Actor[] temp = new Actor[_actorstoRemove.Length + 1];
            //Copy values from the old array to the new array except the actor to delete
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
