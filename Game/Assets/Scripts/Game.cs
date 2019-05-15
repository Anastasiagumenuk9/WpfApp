using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject player;
    public GameObject roadPrefab;
    public GameObject ment;
    public GameObject coin;
    private GameObject road;

    void Start()
    {
        player = Instantiate(player, new Vector3(0f, -3f, 0f), Quaternion.identity) as GameObject;
        road = Instantiate(roadPrefab, new Vector3(-0.05f, 14.05f, 0.09470454f), Quaternion.identity) as GameObject;
        road.name = "Road";
        fillRoad();
    }

    void fillRoad()
    {
        float y = 18f;
        float x = -8.5f;
        for (int i = 0; i < 3; i++)
        {
            x = -8.5f;
            for (int j = 0; j < 3; j++)
            {
                int temp = Random.Range(0, 5);
                if (temp == 0)
                {
                    Instantiate(coin, new Vector3(x, y, 0f), Quaternion.identity, road.transform);
                }
                else if (temp == 1)
                {
                    Instantiate(ment, new Vector3(x, y, 0f), Quaternion.identity, road.transform);
                }
                x += 8.5f;
            }
            y -= 8f; 
        }
    }

    void Update()
    {
        road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y - 0.2f, road.transform.position.z);
        if (road.transform.position.y < -11.71f)
        {
            Destroy(road);
            road = Instantiate(roadPrefab, new Vector3(-0.05f, 14.05f, 0.09470454f), Quaternion.identity) as GameObject;
            road.name = "Road";
            fillRoad();
        }
    }
}
