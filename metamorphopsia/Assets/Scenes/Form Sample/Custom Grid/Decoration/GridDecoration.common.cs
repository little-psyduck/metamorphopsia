using UnityEngine;

namespace CustomGrid
{
    public partial class GridDecoration
    {
        public GridDecoration(Mesh mesh) 
        {
            triangles = mesh.triangles;
            vertices = mesh.vertices;

            LoadPointModel();
            InitilizePoints();
            InitilizeWireframe();
        }

        public void Update(Mesh mesh, Transform transform_)
        {
            triangles = mesh.triangles;
            vertices = mesh.vertices;
            transform = transform_;

            if (points.Length != vertices.Length)
            {
                Reconstruct();
            }

            UpdatePoints();
            UpdateLines();
        }

        private void Reconstruct()
        {
            ReconstructPoints();
            ReconstructLines();
        }

        //attribute
        private int[] triangles;
        private Vector3[] vertices;
        private Transform transform;
    }
}
