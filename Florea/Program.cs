using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace Florea
{
    class ProgramSimplu : GameWindow
    {

        float vitezaRotatie = 100.0f;
        float unghi;
        bool arataCub = true;

        public ProgramSimplu() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();

            if (keyboard[OpenTK.Input.Key.A])
            {
                arataCub = true;
            }

            if (keyboard[OpenTK.Input.Key.S])
            {
                arataCub = false;
            }

            if (keyboard[OpenTK.Input.Key.Space])
            {
                vitezaRotatie = 250.0f;
            }

            if (mouse[OpenTK.Input.MouseButton.Left])
            {
                if (arataCub == true)
                {
                    arataCub = false;
                }
                else
                {
                    arataCub = true;
                }
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            unghi += vitezaRotatie * (float)e.Time;
            GL.Rotate(unghi, 0.0f, 1.0f, 0.0f);
            GL.Rotate(unghi, 1.0f, 0.0f, 0.0f);
            GL.Rotate(unghi, 0.0f, 0.0f, 1.0f);
            if (arataCub == true)
            {
                PicteazaCub();
            }
            SwapBuffers();
        }

        private void PicteazaCub()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Red);
            GL.Vertex3(-5.0f, -5.0f, -5.0f);
            GL.Vertex3(-5.0f, 5.0f, -5.0f);
            GL.Vertex3(5.0f, 5.0f, -5.0f);
            GL.Vertex3(5.0f, -5.0f, -5.0f);

            GL.Color3(Color.Green);
            GL.Vertex3(-5.0f, -5.0f, -5.0f);
            GL.Vertex3(5.0f, -5.0f, -5.0f);
            GL.Vertex3(5.0f, -5.0f, 5.0f);
            GL.Vertex3(-5.0f, -5.0f, 5.0f);

            GL.Color3(Color.White);

            GL.Vertex3(-5.0f, -5.0f, -5.0f);
            GL.Vertex3(-5.0f, -5.0f, 5.0f);
            GL.Vertex3(-5.0f, 5.0f, 5.0f);
            GL.Vertex3(-5.0f, 5.0f, -5.0f);

            GL.Color3(Color.Yellow);
            GL.Vertex3(-5.0f, -5.0f, 5.0f);
            GL.Vertex3(5.0f, -5.0f, 5.0f);
            GL.Vertex3(5.0f, 5.0f, 5.0f);
            GL.Vertex3(-5.0f, 5.0f, 5.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-5.0f, 5.0f, -5.0f);
            GL.Vertex3(-5.0f, 5.0f, 5.0f);
            GL.Vertex3(5.0f, 5.0f, 5.0f);
            GL.Vertex3(5.0f, 5.0f, -5.0f);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(5.0f, -5.0f, -5.0f);
            GL.Vertex3(5.0f, 5.0f, -5.0f);
            GL.Vertex3(5.0f, 5.0f, 5.0f);
            GL.Vertex3(5.0f, -5.0f, 5.0f);

            GL.End();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (ProgramSimplu nou = new ProgramSimplu())
            {
                nou.Run(30.0, 0.0);
            }
        }
    }

}
