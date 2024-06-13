using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float fireRate = 2f; 
    public float bulletSpeed = 20f; 

    private void Start()
    {
        InvokeRepeating("FireAtEnemy", fireRate, fireRate);
    }

    void FireAtEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            GameObject nearestEnemy = FindNearestEnemy(enemies);

            if (nearestEnemy != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 direction = (nearestEnemy.transform.position - firePoint.position).normalized;
                    rb.velocity = direction * bulletSpeed;
                }
            }
        }
    }

    GameObject FindNearestEnemy(GameObject[] enemies)
    {
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
