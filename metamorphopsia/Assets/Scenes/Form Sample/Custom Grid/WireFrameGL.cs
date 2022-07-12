using UnityEngine;

public class WireFrameGL : MonoBehaviour
{
    public Material lineMaterial;

    private Shader shader;
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        triangles = mesh.triangles;

        shader = Shader.Find("Sample/LineShader");
        lineMaterial = new Material(shader);

        //int color = Shader.PropertyToID("_Color");
        //lineMaterial.SetColor(color, new Vector4(1, 1, 0, 1));
    }

    public void OnRenderObject()
    {
        if (!lineMaterial.SetPass(0))
        {
            Debug.Log("Error happens at line render.");
            return;
        }
        GL.PushMatrix();
        GL.MultMatrix(gameObject.transform.localToWorldMatrix);

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