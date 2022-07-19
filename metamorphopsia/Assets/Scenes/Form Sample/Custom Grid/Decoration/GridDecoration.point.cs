using UnityEngine;

namespace CustomGrid
{
    public partial class GridDecoration
    {
        GameObject pointDecoration;
        GameObject pointImage;
        GameObject[] points;

        private void LoadPointModel()
        {
            const string pointPath = "Images/Point";
            pointImage = Resources.Load(pointPath) as GameObject;
            pointDecoration = new GameObject("Points");
            if (pointImage == null)
            {
                Debug.Log("Loading point image fault.");
            }
        }
        private void InitilizePoints()
        {
            points = new GameObject[vertices.Length];
            Vector3 pointScale = Vector3.one * (0.1f - (0.02f * (GridGeneration.Instance().subdivisionLevel - 1)));

            for (int i = 0; i < points.Length; ++i)
            {
                points[i] = GameObject.Instantiate(pointImage);
                points[i].transform.SetParent(pointDecoration.transform);
                points[i].transform.localScale = pointScale;
            }
        }

        private void ReconstructPoints()
        {
            DestroyPoints();
            InitilizePoints();
        }

        void UpdatePoints()
        {
            for (int i = 0; i < vertices.Length; ++i)
            {
                points[i].transform.position = vertices[i];
            }
        }

        public void DestroyPoints()
        {
            int childCount = pointDecoration.transform.childCount;
            if (childCount > 0)
            {
                for (int i = 0; i < childCount; ++i)
                {
                    GameObject.Destroy(pointDecoration.transform.GetChild(i).gameObject);
                }
            }
            if (pointDecoration.transform.childCount == 0)
                GameObject.Destroy(pointDecoration);
        }

    }
}
