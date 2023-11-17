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
            _applicationShouldClose = true;

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
        public static Actor RemoveActorfromScene(Actor actortoRemove)
        {
            _currentScene.RemoveActor(actortoRemove);
            return actortoRemove;
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

                //Matrix3 sum = testa * testb;
                //Console.WriteLine(sum);
                //Console.WriteLine(            "___________\n");
                //  Console.WriteLine(M00 + "  | " + M01 + "   | " + M02 + "\n" +
                //                              "___________\n" +
                //                    M10 + "  | " + M11 + "   | " + M12 + "\n" +
                //                              "___________\n" +
                //                    M20 + "  | " + M21 + "   | " + M22);
                //Console.WriteLine("_________________________");
                //Console.WriteLine("Dot Product: " + Vector2.DotProduct(test, test3));
                //Console.WriteLine("_________________________");
                //Console.WriteLine("Get Distance: " + Vector2.GetDistance(test, test3));
                //Console.WriteLine("_________________________");
                //test.Normalize();

                //Console.WriteLine("Test 1 Magnitude: " + test.GetMagnitude());
                //Console.WriteLine("_________________________");
                //Console.WriteLine("Test 2 Magnitude: " + magnitude);
                //Console.WriteLine("_________________________");

                //Console.WriteLine("Current Time: " + currentTime);
                //Console.WriteLine("|||||||||||||||||||||||||");

                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                deltaTime = currentTime - lastTime;
                
                Draw();
                Update(deltaTime);
                
                lastTime = currentTime;
                _currentScene.Update(deltaTime);
            }

            End();
        }
    }
}
