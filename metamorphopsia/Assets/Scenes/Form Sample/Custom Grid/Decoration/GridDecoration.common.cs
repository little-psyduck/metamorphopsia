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
            initilizePoints();
            initilizeWireframe();
        }

        public void Update(Mesh mesh, Transform transform_)
        {
            triangles = mesh.triangles;
            vertices = mesh.vertices;
            transform = transform_;
            UpdatePoints();
        }

        //attribute
        private int[] triangles;
        private Vector3[] vertices;
        private Transform transform;
    }
}
