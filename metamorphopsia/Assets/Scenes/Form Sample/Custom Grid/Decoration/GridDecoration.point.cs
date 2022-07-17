using UnityEngine;

namespace CustomGrid
{
    public partial class GridDecoration
    {
        GameObject pointDecal;
        GameObject pointImage;
        GameObject[] points;

        private void LoadPointModel()
        {
            const string pointPath = "Images/Point";
            pointImage = Resources.Load(pointPath) as GameObject;
            pointDecal = new GameObject("Points");
            if (pointImage == null)
            {
                Debug.Log("Loading point image fault.");
            }
        }
        private void initilizePoints()
        {
            points = new GameObject[vertices.Length];
            Vector3 pointScale = Vector3.one * (0.1f - (0.02f * (GridGeneration.Instance().subdivisionLevel - 1)));

            for (int i = 0; i < points.Length; ++i)
            {
                points[i] = GameObject.Instantiate(pointImage);
                points[i].transform.SetParent(pointDecal.transform);
                points[i].transform.localScale = pointScale;
            }
        }

        void UpdatePoints()
        {
            if (points.Length != vertices.Length)
            {
                DestroyPoints();
                initilizePoints();
            }

            for (int i = 0; i < vertices.Length; ++i)
            {
                points[i].transform.position = vertices[i];
            }
        }

        public void DestroyPoints()
        {
            int childCount = pointDecal.transform.childCount;
            if (childCount > 0)
            {
                for (int i = 0; i < childCount; ++i)
                {
                    GameObject.Destroy(pointDecal.transform.GetChild(i).gameObject);
                }
            }
            if (pointDecal.transform.childCount == 0)
                GameObject.Destroy(pointDecal);
        }

    }
}
