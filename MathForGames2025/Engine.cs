using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Diagnostics;

namespace MathForGames2025
{
    internal class Engine
    {
        
        private const int _screenwidth = 800;
        private const int _screenheight = 450;
        private static bool _applicationShouldClose;
        private static Icon[,] _buffer;
        private TestScene _testScene;
        private Stopwatch _stopwatch = new Stopwatch();
       
        


        private void Start()
        {
            Raylib.InitWindow(_screenwidth, _screenheight, "MATH FOR GAMES 2025");
            Raylib.SetTargetFPS(200);
            _stopwatch.Start();
            _testScene = new TestScene();
            _buffer = new Icon[10, 10];

            _testScene.Start();
            
        }

        public static void Render(Icon icon, Vector2 position)
        {
            Raylib.DrawText(icon.Symbol, (int)position.X, (int)position.Y, 50, icon.RaylibColor);
        }

        private void Draw()
        {
            
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.MAGENTA);

            _testScene.Draw();

            Raylib.EndDrawing();
        }

        private void Update(float deltaTime)
        {
            _testScene.Update(deltaTime);
            
        }

        private void End()
        {
            _testScene.End();
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

        public void Run()
        {
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
                Console.WriteLine("_________________________");
                Console.WriteLine("Dot Product: " + Vector2.DotProduct(test, test3));
                Console.WriteLine("_________________________");
                Console.WriteLine("Get Distance: " + Vector2.GetDistance(test, test3));
                Console.WriteLine("_________________________");
                test.Normalize();

                Console.WriteLine("Test 1 Magnitude: " + test.GetMagnitude());
                Console.WriteLine("_________________________");
                Console.WriteLine("Test 2 Magnitude: " + magnitude);
                Console.WriteLine("_________________________");

                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                Console.WriteLine("Current Time: " + currentTime);
                Console.WriteLine("|||||||||||||||||||||||||");

                deltaTime = currentTime - lastTime;
                
                Draw();
                Update(deltaTime);

                lastTime = currentTime;
            }

            End();
        }
    }
}
