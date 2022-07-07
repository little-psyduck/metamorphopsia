using UnityEngine;

namespace CustomGrid
{
    public partial class MeshAdjuster
    {
        LineRenderer lineRenderer;
        public void DrawLayout(ref Mesh mesh)
        {
            lineRenderer.SetPositions(verticesPosition);
        }
    }
}
