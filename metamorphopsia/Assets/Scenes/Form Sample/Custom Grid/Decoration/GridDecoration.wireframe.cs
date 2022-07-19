using UnityEngine;

namespace CustomGrid
{
    public partial class GridDecoration
    {
        GameObject lineDecoration;

        Line[] linesRow;
        Line[] linesColumn;

        int row;
        int column;

        Vector3[][] rowVertices;
        Vector3[][] columnVertices;

        Material lineMaterial;
        private void InitilizeWireframe()
        {
            lineDecoration = new GameObject("Lines");
            lineMaterial = new Material(Shader.Find("Sample/LineShader"));

            GenerateWireframe();
        }

        private void GenerateWireframe()
        {
            row = GridGeneration.Instance().GetHeightVerticesNumber();
            column = GridGeneration.Instance().GetWidthVerticesNumber();

            linesRow = new Line[row];
            linesColumn = new Line[column];

            rowVertices = new Vector3[row][];
            columnVertices = new Vector3[column][];

            for (int i = 0; i < row; ++i)
                rowVertices[i] = new Vector3[column];
            for (int i = 0; i < column; ++i)
                columnVertices[i] = new Vector3[row];

            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {
                    rowVertices[i][j] = vertices[i * column + j];
                    columnVertices[j][i] = vertices[i * column + j];
                }
            }

            for (int i = 0; i < row; ++i)
            {
                linesRow[i] = new Line(rowVertices[i], lineMaterial, 0.01f);
                linesRow[i].SetTransfomParent(lineDecoration.transform);
            }
            for (int i = 0; i < column; ++i)
            {
                linesColumn[i] = new Line(columnVertices[i], lineMaterial, 0.01f);
                linesColumn[i].SetTransfomParent(lineDecoration.transform);
            }
        }

        private void DestroyLines()
        {
            int childCount = lineDecoration.transform.childCount;
            if (childCount > 0)
            {
                for (int i = 0; i < childCount; ++i)
                {
                    GameObject.Destroy(lineDecoration.transform.GetChild(i).gameObject);
                }
            }
            if (lineDecoration.transform.childCount == 0)
                GameObject.Destroy(lineDecoration);
        }

        private void UpdateLines()
        {
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {
                    rowVertices[i][j] = vertices[i * column + j];
                    columnVertices[j][i] = vertices[i * column + j];
                }
            }
            for (int i = 0; i < row; ++i)
            {
                linesRow[i].ResetPoints(rowVertices[i]);
            }
            for (int i = 0; i < column; ++i)
            {
                linesColumn[i].ResetPoints(columnVertices[i]);
            }
        }

        private void ReconstructLines()
        {
            DestroyLines();
            GenerateWireframe();
        }
    }
}