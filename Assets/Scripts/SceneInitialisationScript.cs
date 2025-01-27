using System.Collections.Generic;
using UnityEngine;

public class SceneInitialisationScript : MonoBehaviour
{
    public GameObject PredatorEntity;
    public GameObject PreyEntity;
    public GameObject TreeEntity;
    public GameObject Water;
    public GameObject Scene;

    public int numPredators = 10;
    public int numPreys = 10;
    public int numTrees = 10;

    public float stageSize = 50;
    public float countRate;

    private GameObject lake;
    private GameObject WallPosX, WallNegX, WallPosZ, WallNegZ;
    private float timer = 0;

    private List<GameObject> predatorList = new List<GameObject>();
    private List<GameObject> preyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InitialiseStage();
        SpawnEntities();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= countRate && countRate > 0)
        {
            timer = 0;
            Debug.Log(predatorList.Count);
            Debug.Log(preyList.Count);
        }
    }

    void InitialiseStage()
    {
        GameObject Stage = Scene.transform.GetChild(0).gameObject;

        GameObject Floor = Stage.transform.GetChild(0).gameObject;
        GameObject Wall = Stage.transform.GetChild(1).gameObject;

        // create Floor
        Floor.transform.position = new Vector3(0, -1, 0);
        Floor.transform.localScale = new Vector3(stageSize, 1, stageSize);

        // create Walls with offset 
        WallPosX = Instantiate(Wall, new Vector3(stageSize / 2, 0.5f, 0), Quaternion.identity, Stage.transform);
        WallPosX.transform.localScale = new Vector3(0, 2, stageSize);

        WallNegX = Instantiate(Wall, new Vector3(-stageSize / 2, 0.5f, 0), Quaternion.identity, Stage.transform);
        WallNegX.transform.localScale = new Vector3(0, 2, stageSize);

        WallPosZ = Instantiate(Wall, new Vector3(0, 0.5f, stageSize / 2), Quaternion.identity, Stage.transform);
        WallPosZ.transform.RotateAround(WallPosZ.transform.position, new Vector3(0, 1, 0), 90);
        WallPosZ.transform.localScale = new Vector3(0, 2, stageSize);

        WallNegZ = Instantiate(Wall, new Vector3(0, 0.5f, -stageSize / 2), Quaternion.identity, Stage.transform);
        WallNegZ.transform.RotateAround(WallNegZ.transform.position, new Vector3(0, 1, 0), 90);
        WallNegZ.transform.localScale = new Vector3(0, 2, stageSize);

        Destroy(Wall);
        CreateLake();
    }

    void CreateLake()
    {
        lake = Instantiate(Water, transform.position + new Vector3(0, -0.99f, 0), transform.localRotation); // hacky way for draw order
        lake.transform.localScale = new Vector3(300, 1, 3);
    }

    void SpawnEntities()
    {
        float minx = transform.localPosition.x - stageSize / 2;
        float minz = transform.localPosition.z - stageSize / 2;
        float maxx = transform.localPosition.x + stageSize / 2;
        float maxz = transform.localPosition.z + stageSize / 2;

        for (int i = 0; i < numPredators; i++)
        {
            Vector3 bbox = PredatorEntity.transform.localScale;
            Instantiate(PredatorEntity,
                new Vector3(Random.Range(minx + bbox.x, maxx - bbox.z),
                            0,
                            Random.Range(minz + bbox.x, maxz - bbox.z)),
                transform.localRotation);
        }
        for (int i = 0; i < numPreys; i++)
        {
            Vector3 bbox = PreyEntity.transform.localScale;
            Instantiate(PreyEntity,
                new Vector3(Random.Range(minx + bbox[0], maxx - bbox[2]),
                            0,
                            Random.Range(minz + bbox[0], maxz - bbox[2])),
                transform.localRotation);
        }
        for (int i = 0; i < numTrees; i++)
        {
            Vector3 bbox = TreeEntity.transform.localScale;
            Instantiate(TreeEntity,
                new Vector3(Random.Range(minx + bbox[0], maxx - bbox[2]),
                            0,
                            Random.Range(minz + bbox[0], maxz - bbox[2])),
                transform.localRotation);
        }
    }
}
