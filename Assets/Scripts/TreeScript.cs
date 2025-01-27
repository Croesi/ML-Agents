using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private float timer = 0;
    private int numFruits;
    private Vector3 randomPosition;

    public GameObject TreeEntity;
    public GameObject FruitEntity;
    public float spawnRate;
    public int maxSpawnedFruits;

    private List<GameObject> fruitList = new List<GameObject>();
    private float radius;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        radius = TreeEntity.transform.GetChild(0).gameObject.transform.localScale.y / 2;
        height = TreeEntity.transform.GetChild(0).gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate && spawnRate > 0)
        {
            timer = 0;
            SpawnFruit();
            Debug.Log(fruitList.Count);
        }
    }

    void SpawnFruit()
    {
        numFruits = Random.Range(0, maxSpawnedFruits);
        for (int i = 0; i < numFruits; i++)
        {
            randomPosition = transform.position + Random.onUnitSphere * radius;
            randomPosition.y += height;
            fruitList.Add(Instantiate(FruitEntity, randomPosition, Random.rotation, TreeEntity.transform));
        }
    }
}
