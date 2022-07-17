using UnityEngine;

namespace CustomGrid
{
    public partial class GridDecoration
    {
        private Material lineMaterial;
        private Shader shader;

        private void initilizeWireframe()
        {
            shader = Shader.Find("Sample/LineShader");
            lineMaterial = new Material(shader);
        }

        public void DrawWire()
        {
            if (!lineMaterial.SetPass(0))
            {
                Debug.Log("Error happens at line render.");
                return;
            }
            GL.PushMatrix();
            GL.MultMatrix(transform.localToWorldMatrix);

            GL.Begin(GL.LINES);

            for (int i = 0; i < triangles.Length; i += 6)
            {
                GL.Vertex(vertices[triangles[i]]);
                GL.Vertex(vertices[triangles[i + 1]]);

                GL.Vertex(vertices[triangles[i + 1]]);
                GL.Vertex(vertices[triangles[i + 2]]);

                GL.Vertex(vertices[triangles[i + 2]]);
                GL.Vertex(vertices[triangles[i + 5]]);

                GL.Vertex(vertices[triangles[i + 5]]);
                GL.Vertex(vertices[triangles[i + 0]]);
            }

            GL.End();
            GL.PopMatrix();
        }
    }
}