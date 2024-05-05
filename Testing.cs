using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GridMap grid;
    int width = 10;
    int height = 7;
    float cellSize = 10f;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridMap(width, height, 10f, new Vector3(width * cellSize / -2, height * cellSize / -2, 1f)); ; ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePosition = GetMouseWorldPosition();
            var x = mousePosition.x;
            var y = mousePosition.y;

            grid.SetValue(GetMouseWorldPosition(), (int)x);
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log(grid.GetValue(GetMouseWorldPosition()));
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
