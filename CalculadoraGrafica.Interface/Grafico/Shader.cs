using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL4;

namespace CalculadoraGrafica.Interface.Grafico
{
    public class Shader
    {
        private readonly int _handle;
        private readonly Dictionary<string, int> _uniformLocations;

        public Shader(string vertPath, string fragPath)
        {
            var vertFile = File.ReadAllText(vertPath);
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertFile);

            CompilarShader(vertexShader);

            var fragFile = File.ReadAllText(fragPath);
            Console.WriteLine(fragFile);
            var fragShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragShader, fragFile);

            CompilarShader(fragShader);

            _handle = GL.CreateProgram();

            GL.AttachShader(_handle, vertexShader);
            GL.AttachShader(_handle, fragShader);

            LinkProgram();

            GL.DetachShader(_handle, vertexShader);
            GL.DeleteShader(vertexShader);

            GL.DetachShader(_handle, fragShader);
            GL.DeleteShader(fragShader);

            _uniformLocations = new();

            GL.GetProgram(_handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

            for (int i = 0; i < numberOfUniforms;i++)
            {
                var key = GL.GetActiveUniform(_handle, i, out _, out _);
            }
        }

        private void LinkProgram()
        {
            GL.LinkProgram(_handle);
            GL.GetProgram(_handle, GetProgramParameterName.LinkStatus, out var status);
            if (status != (int)All.True)
            {
                throw new Exception($"Falha ao linkar o programa {_handle}");
            }
        }

        private static void CompilarShader(int shader)
        {
            GL.CompileShader(shader);
            GL.GetShader(shader, ShaderParameter.CompileStatus, out var status);
            if (status != (int)All.True)
            {
                var infolog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Erro ao compilar o shader {shader}. {infolog}");
            }
        }

        internal void Use()
        {
            GL.UseProgram(_handle);
        }
    }
}