using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> pathList;
    public float baseSpeed = 2f;
    public float chaseSpeed = 3f;
    private float radiusPath = 0.2f;
    public float detectionRadius = 3f;
    public float chaseRadius = 4f;
    private int pathIndex = 0;
    private GameObject player;
    private List<GameObject> ennemies;

    public static bool IsChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ennemies = new List<GameObject>();
        pathIndex = 0;
        foreach (GameObject pathPoint in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            ennemies.Add(pathPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, pathList[pathIndex].position) <= radiusPath)
        {
            pathIndex++;
            pathIndex = pathIndex % pathList.Count;
        }
        float speed = IsChasing ? chaseSpeed : baseSpeed;
        transform.position = Vector2.MoveTowards(transform.position, pathList[pathIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRadius)
        {
            IsChasing = true;
        }
        if (ennemies.TrueForAll(ennemy => Vector3.Distance(ennemy.transform.position, player.transform.position) > chaseRadius))
        {
            IsChasing = false;
        }

        if (IsChasing)
        {
           
         pathList.Insert(pathIndex, player.transform);
        }
        else
        {
            pathList.RemoveAll(e => e.tag == "Player");
            pathIndex = pathIndex % pathList.Count;
        }
    }
}
