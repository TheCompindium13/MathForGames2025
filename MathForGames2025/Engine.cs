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
        string M00 = Matrix4.Identity.M00.ToString(); string M01 = Matrix4.Identity.M01.ToString(); string M02 = Matrix4.Identity.M02.ToString(); string M03 = Matrix4.Identity.M03.ToString();
        string M10 = Matrix4.Identity.M10.ToString(); string M11 = Matrix4.Identity.M11.ToString(); string M12 = Matrix4.Identity.M12.ToString(); string M13 = Matrix4.Identity.M13.ToString();
        string M20 = Matrix4.Identity.M20.ToString(); string M21 = Matrix4.Identity.M21.ToString(); string M22 = Matrix4.Identity.M22.ToString(); string M23 = Matrix4.Identity.M23.ToString();
        string M30 = Matrix4.Identity.M30.ToString(); string M31 = Matrix4.Identity.M21.ToString(); string M32 = Matrix4.Identity.M32.ToString(); string M33 = Matrix4.Identity.M33.ToString();

        string M300 = Matrix3.Identity.M00.ToString(); string M301 = Matrix3.Identity.M01.ToString(); string M302 = Matrix3.Identity.M02.ToString();
        string M310 = Matrix3.Identity.M10.ToString(); string M311 = Matrix3.Identity.M11.ToString(); string M312 = Matrix3.Identity.M12.ToString();
        string M320 = Matrix3.Identity.M20.ToString(); string M321 = Matrix3.Identity.M21.ToString(); string M322 = Matrix3.Identity.M22.ToString();

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
        public void Run()
        {
            Matrix3 testa = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3 testb = new Matrix3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix4 testc = new Matrix4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4 testd = new Matrix4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);


            Vector2 test = new Vector2(10, 10);

            Vector2 test3 = new Vector2(10, 10);
            Vector3 test4 = new Vector3(10, 10, 10);

            Vector3 test5 = new Vector3(10, 10, 10);

            Vector2 test2 = test.GetNormalized();

            float magnitude = test2.GetMagnitude();
            
            Start();
            float currentTime = 0f;
            float lastTime = 0f;
            float deltaTime = 0f;
            
            
            while (!_applicationShouldClose && !Raylib.WindowShouldClose())
            {

                Vector3 sum = Vector3.CrossProduct(test4, test5);
                Vector3 sum2 = testa * test5;
                //Console.WriteLine("Cross Product: " + sum.X);
                //Console.WriteLine("Cross Product: " + sum.Y);
                //Console.WriteLine("Cross Product: " + sum.Z);

                //Console.WriteLine(sum2.X);
                //Console.WriteLine(sum2.Y);
                //Console.WriteLine(sum2.Z);

                //Console.WriteLine(            "___________\n");
                //  Console.WriteLine(M00 + "  | " + M01 + "   | " + M02 + "   | " + M03 + "\n" +
                //                              "___________\n" +
                //                    M10 + "  | " + M11 + "   | " + M12 + "   | " + M13 + "\n" +
                //                              "___________\n" +
                //                    M20 + "  | " + M21 + "   | " + M22 + "   | " + M23 + "\n" +
                //                              "___________\n" +
                //                    M30 + "  | " + M31 + "   | " + M32 + "   | " + M33 + "\n" );
                //Console.WriteLine("_________________________");
                //Console.WriteLine("Dot Product: " + Vector2.DotProduct(test, test3));
                //Console.WriteLine("_________________________");
                //Console.WriteLine("Get Distance: " + Vector2.GetDistance(test, test3));
                //Console.WriteLine("_________________________");
                test.Normalize();

                //Console.WriteLine("Test 1 Magnitude: " + test.GetMagnitude());
                //Console.WriteLine("_________________________");
                //Console.WriteLine("Test 2 Magnitude: " + magnitude);
                //Console.WriteLine("_________________________");

                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Console.WriteLine("Current Time: " + currentTime);
                //Console.WriteLine("|||||||||||||||||||||||||");

                deltaTime = currentTime - lastTime;
                
                Draw();
                Update(deltaTime);

                lastTime = currentTime;
            }

            End();
        }
    }
}
