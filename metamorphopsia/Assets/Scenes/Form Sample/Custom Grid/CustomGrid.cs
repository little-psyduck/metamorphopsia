using UnityEngine;

namespace CustomGrid
{
    public partial class MeshAdjuster
    {
        Vector3[] verticesPosition;
        int verticesWidthNumber = 0, verticesHeightNumber = 0;
        float width = 0, height = 0;

        Vector2[] UVCoordinate;
        int[] triangles;
        
        bool initilize = true;

        GameObject[] pointDecal;
        GameObject pointImage;

        private bool SetVerticesNumber(uint verticesDensity)
        {
            width = (float)Screen.width / 100.0f;
            height = (float)Screen.height / 100.0f;
            float screenRatio = height / width;

            verticesWidthNumber = (int)(verticesDensity * 10);
            verticesHeightNumber = (int)((float)verticesWidthNumber * screenRatio);
            int verticesNumber = (++verticesHeightNumber) * (++verticesWidthNumber);


            if (verticesWidthNumber <= 10 || verticesHeightNumber <= 5)
            {
                Debug.Log("Vertices are too few, generation error.");
                initilize = false;
                return false;
            }

            verticesPosition = new Vector3[verticesNumber];
            UVCoordinate = new Vector2[verticesNumber];
            pointDecal = new GameObject[verticesNumber];

            triangles = new int[(verticesHeightNumber - 1) * (verticesWidthNumber - 1) * 6];

            return true;
        }

        private void GenerateVertices()
        {
            float verticesWidthDistance = width / (verticesWidthNumber - 1);
            float verticesHeightDistance = height / (verticesHeightNumber - 1);


            for (int yIndex=0; yIndex < verticesHeightNumber; ++yIndex)
            {
                for (int xIndex = 0; xIndex < verticesWidthNumber; ++xIndex)
                {
                    int index = xIndex + yIndex * verticesWidthNumber;

                    verticesPosition[index] = new Vector3(xIndex * verticesWidthDistance - width / 2,
                        yIndex * verticesHeightDistance - height / 2, 0);

                    UVCoordinate[index] = new Vector2((xIndex * verticesWidthDistance) / width,
                        (yIndex * verticesHeightDistance) / height);
                    pointDecal[index] = GameObject.Instantiate(pointImage);
                    pointDecal[index].transform.position = verticesPosition[index];
                }
            }
        }

        void GenerateTriangle()
        {
            int Index = 0;
            for (int y = 0; y < verticesHeightNumber - 1; ++y)
            {
                for (int x = 0; x < verticesWidthNumber - 1; ++x)
                {
                    if (Index > triangles.Length)
                    {
                        Debug.Log("The generation of triangles's index is out of range.");
                        initilize = false;
                        return;
                    }

                    triangles[Index++] = (y + 0) * verticesWidthNumber + (x + 0);
                    triangles[Index++] = (y + 1) * verticesWidthNumber + (x + 0);
                    triangles[Index++] = (y + 1) * verticesWidthNumber + (x + 1);

                    triangles[Index++] = (y + 0) * verticesWidthNumber + (x + 0);
                    triangles[Index++] = (y + 1) * verticesWidthNumber + (x + 1);
                    triangles[Index++] = (y + 0) * verticesWidthNumber + (x + 1);
                }
            }
        }

        void LoadPointImage()
        {
            const string pointPath = "Images/Point";
            pointImage = Resources.Load(pointPath) as GameObject;
            if (pointImage == null)
            {
                Debug.Log("Loading point image fault.");
                initilize = false;
            }
        }

        public bool Initilize(ref Mesh mesh, uint verticesDensity = 1)
        {
            LoadPointImage();
            if (verticesDensity > 4)
            {
                Debug.Log("Too much vertices.");
                initilize = false;
                return initilize;
            }
            if (!SetVerticesNumber(verticesDensity))
            {
                return initilize;
            }

            GenerateVertices();
            GenerateTriangle();

            mesh.vertices = verticesPosition;
            mesh.triangles = triangles;
            mesh.uv = UVCoordinate;

            return initilize;
        }
    }
}