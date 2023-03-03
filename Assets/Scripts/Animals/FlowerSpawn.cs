using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawn : MonoBehaviour
{
    [SerializeField]GameObject flowerPrefab;
    int flowers;

    private void Update()
    {
        //spawn flower every 5 sec
        flowers = GameObject.FindGameObjectsWithTag("Flower").Length;
        if (flowers < 15) SpawnFlower();
        
    }

    public void SpawnFlower()
    {
        //The code will request a GameObject to become active, and set the properties of that given GameObject.
        //It removes the need to instantiate a new object and efficiently requests
        //and acquires a GameObject that is only pre-instantiated,
        //relieving the burden from the CPU of having to create and destroy a new one.

        GameObject flower = ObjectPool.SharedInstance.GetPooledObject();
        if (flower != null)
        {
            flower.transform.position = SpawnRandomPosition();
            flower.transform.rotation = flowerPrefab.transform.rotation;
            flower.transform.localScale = SpawnRandomScale();
            flower.SetActive(true);
        }
    }

    Vector3 SpawnRandomPosition()
    {
        float x = Random.Range(-58,-22);
        float z = Random.Range(-35,-2);
        Vector3 position = new Vector3(x,-1,z);
        return position;
    }

    Vector3 SpawnRandomScale()
    {
        float x = Random.Range(100, 250);
        Vector3 scale = new Vector3(x, x, x);
        return scale;
    }

}
