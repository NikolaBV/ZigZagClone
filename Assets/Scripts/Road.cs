using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public float offset = 0.7071068f;
    public Vector3 lastPos;
    private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, .5f);
    }

    public void CreateNewRoadPart()
    {
        Debug.Log("Create new road part");
        Vector3 spawnPosition = Vector3.zero;
        float chance = Random.Range(0, 100);
        if(chance < 50)
        {
            spawnPosition = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPosition = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }
        GameObject g = Instantiate(roadPrefab, spawnPosition, Quaternion.Euler(0,45,0));
        lastPos = g.transform.position;
        roadCount++;
        if(roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    
   
}
