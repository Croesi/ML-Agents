using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private float timer = 0;
    private Vector3 randomPosition;

    public GameObject TreeEntity;
    public GameObject FruitEntity;
    public float spawnRate;
    public int maxSpawnedFruits;

    private List<GameObject> inactiveFruits = new List<GameObject>();
    private List<GameObject> activeFruits = new List<GameObject>();

    private float radius;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        radius = TreeEntity.transform.GetChild(0).gameObject.transform.localScale.y / 2;
        height = TreeEntity.transform.GetChild(0).gameObject.transform.localPosition.y;
        CreateFruits();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inactiveFruits.Count);
        Debug.Log(activeFruits.Count);
        timer += Time.deltaTime;
        if (timer >= spawnRate && spawnRate > 0 && inactiveFruits.Count > 0)
        {
            timer = 0;
            GameObject fruit = inactiveFruits[0];
            fruit.SetActive(true);
            activeFruits.Add(fruit);
            inactiveFruits.Remove(fruit);
        }
    }

    void CreateFruits()
    {
        for (int i = 0; i < maxSpawnedFruits; i++)
        {
            randomPosition = transform.position + Random.onUnitSphere * radius;
            randomPosition.y += height;
            GameObject tempFruit = Instantiate(FruitEntity, randomPosition, Random.rotation, TreeEntity.transform);
            tempFruit.SetActive(false);
            inactiveFruits.Add(tempFruit);
        }
    }
}
