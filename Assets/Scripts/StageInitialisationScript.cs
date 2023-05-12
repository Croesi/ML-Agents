using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitialisationScript : MonoBehaviour
{

    public GameObject PredatorEntity;
    public GameObject PreyEntity;
    public GameObject TreeEntity;

    public int numPredators = 10;
    public int numPreys = 10;
    public int numTrees = 10;

    public float heightOffset = 50;
    // Start is called before the first frame update
    void Start()
    {
        initialiseStage();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (timer < spawnRate)
    //    {
    //        timer += Time.deltaTime;
    //    }
    //    else
    //    {
    //        initialiseStage();
    //        timer = 0;
    //    }
    //}

    void initialiseStage()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;


        // TODO for schleifen
        // TODO random x
        for (int i = 0; i < numPredators; i++)
        {
            Instantiate(PredatorEntity, new Vector3(Random.Range(lowestPoint, highestPoint), 1, Random.Range(lowestPoint, highestPoint)), transform.rotation);
        }
        for (int i = 0; i < numPreys; i++)
        {
            Instantiate(PreyEntity, new Vector3(Random.Range(lowestPoint, highestPoint), 1, Random.Range(lowestPoint, highestPoint)), transform.rotation);
        }
        for (int i = 0; i < numTrees; i++)
        {
            Instantiate(TreeEntity, new Vector3(Random.Range(lowestPoint, highestPoint), 1, Random.Range(lowestPoint, highestPoint)), transform.rotation);
        }
    }
}
