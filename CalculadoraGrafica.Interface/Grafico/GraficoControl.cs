using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Threading;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace CalculadoraGrafica.Interface.Grafico
{
    public class GraficoControl : OpenGlControlBase
    {

            //será removido, só para teste da API
        private int _vertexBufferObject;
        private int _vertexArrayObject;
        private Shader? _shader;
        private AvaloniaTkContext? _avaloniaTKContext;
        private GlInterface? _gl;

            //será removido, só para teste da API
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };

        protected override void OnOpenGlRender(GlInterface gl, int fb)
        {
            _gl = gl;
            GL.Viewport(0, 0, 500, 800);
            //será removido, só para teste da API
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);

            GL.ClearColor(new Color4(0, 32, 48, 255));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            _shader?.Use();

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            Dispatcher.UIThread.Post(RequestNextFrameRendering, DispatcherPriority.Background);
        }

        protected override void OnOpenGlInit(GlInterface gl)
        {
            base.OnOpenGlInit(gl);

            //será removido, só para teste da API
            _avaloniaTKContext = new AvaloniaTKContext(gl);
            GL.LoadBindings(_avaloniaTKContext);
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.EnableVertexAttribArray(0);

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");

            _shader.Use();
        }
    }

    internal class AvaloniaTKContext : AvaloniaTkContext
    {
        public AvaloniaTKContext(GlInterface glInterface) : base(glInterface)
        {
        }
    }
}