using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private GameObject placingTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (placingTower != null)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, 0);

            if (plane.Raycast(ray, out float distance))
            {
                var worldPosition = ray.GetPoint(distance);
                var zPos = worldPosition.z < -10 ? worldPosition.z : -10;
                var xPos = worldPosition.x < 10 ? worldPosition.x : 10;
                xPos = worldPosition.x > -15 ? worldPosition.x : -15;
                placingTower.transform.position = new Vector3(xPos, 1,zPos);
            }

            if (Input.GetMouseButtonDown(0))
            {
                placingTower = null;
            }
        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        placingTower = Instantiate(tower,Vector3.zero,Quaternion.identity);
    }
}
