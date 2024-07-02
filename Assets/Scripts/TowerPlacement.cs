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
            Ray camRay = camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(camRay,out RaycastHit hitInfo, 100f))
            {
                placingTower.transform.position = new Vector3(hitInfo.point.x,1, hitInfo.point.z);
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
