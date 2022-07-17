using UnityEngine;

namespace CustomGrid
{
    public sealed partial class GridGeneration
    {
        bool initilize = true;
        private void SetVerticesNumber(uint verticesDensity)
        {
            meshSample = new Mesh() { name = "StoredMesh" };

            width = (float)Screen.width / 100.0f;
            height = (float)Screen.height / 100.0f;
            screenRatio = height / width;

            verticesWidthNumber = (int)(verticesDensity * 10);
            verticesHeightNumber = (int)((float)verticesWidthNumber * screenRatio);
            verticesNumber = (++verticesHeightNumber) * (++verticesWidthNumber);

            if (verticesWidthNumber <= 10 || verticesHeightNumber <= 5)
            {
                Debug.Log("Vertices are too few, generation error.");
                initilize = false;
                return;
            }
        }

        private void SetVertices(Vector3[] verticesData = null, Vector2[] UVData = null)
        {
            float verticesWidthDistance = width / (verticesWidthNumber - 1);
            float verticesHeightDistance = height / (verticesHeightNumber - 1);

            Vector3[] verticesPosition = new Vector3[verticesNumber];
            Vector2[] UVCoordinate = new Vector2[verticesNumber];

            for (int yIndex=0; yIndex < verticesHeightNumber; ++yIndex)
            {
                for (int xIndex = 0; xIndex < verticesWidthNumber; ++xIndex)
                {
                    int index = xIndex + yIndex * verticesWidthNumber;

                    if (verticesData == null)
                        verticesPosition[index] = new Vector3(xIndex * verticesWidthDistance - width / 2,
                            yIndex * verticesHeightDistance - height / 2, 0);

                    if (UVData == null)
                        UVCoordinate[index] = new Vector2((xIndex * verticesWidthDistance) / width,
                            (yIndex * verticesHeightDistance) / height);
                }
            }

            meshSample.vertices = (verticesData == null ? verticesPosition : verticesData);
            meshSample.uv = (UVData == null ? UVCoordinate : UVData);
        }

        void SetTriangles()
        {
            int Index = 0;
            int[] triangles = new int[(verticesHeightNumber - 1) * (verticesWidthNumber - 1) * 6];

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

            meshSample.triangles = triangles;
        }

        public Mesh Initilize(uint verticesDensity = 1)
        {
            if (verticesDensity > 4)
            {
                Debug.Log("Too much vertices.");
                initilize = false;
                return null;
            }

            subdivisionLevel = verticesDensity;

            SetVerticesNumber(verticesDensity);
            SetVertices();
            SetTriangles();

            if (!initilize)
            {
                Debug.LogError("Grid generation error.");
                return null;
            }

            return meshSample;
        }
    }
}