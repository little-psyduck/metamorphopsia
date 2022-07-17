using UnityEngine;
using UnityEditor;
using CustomGrid;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
//[ExecuteInEditMode]
public class GridManager : MonoBehaviour
{
    GridDecoration gridDecorator;

    void InitializeGrid()
    {
        GetComponent<MeshFilter>().mesh = GridGeneration.Instance().Initilize();
        if (GetComponent<MeshFilter>().mesh == null)
        {
            Debug.Log("Mesh initialization fault.");
        }
    }

    void ExportGrid()
    {
        AssetDatabase.CreateAsset(GetComponent<MeshFilter>().mesh, "Assets/EyesSample/Left.asset");
    }

    private void Start()
    {
        InitializeGrid();

        gridDecorator = new GridDecoration(GetComponent<MeshFilter>().mesh);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            GetComponent<MeshFilter>().mesh = GridGeneration.Instance().Subdivision(GetComponent<MeshFilter>().mesh);
        if (Input.GetKeyDown(KeyCode.X))
            ExportGrid();
        gridDecorator.Update(GetComponent<MeshFilter>().mesh, transform);
    }

    private void OnRenderObject()
    {
        gridDecorator.DrawWire();
    }
}