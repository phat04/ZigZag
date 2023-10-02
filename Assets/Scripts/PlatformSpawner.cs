using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    public bool gameOver;

    Vector3 lastPos;
    float size;

    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 5; i++)
        {
            SpawnPlatform();
        }
    }

    
    public void StartSpawn()
    {
        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
    }

    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            CancelInvoke("SpawnPlatform");
        }
    }

    void SpawnPlatform()
    {
        int rand =Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, diamond.transform.position.y, pos.z), diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, diamond.transform.position.y, pos.z), diamond.transform.rotation);
        }
    }
}
