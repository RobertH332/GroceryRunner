using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject floorSection;
    public Transform generationPoint;
    public GameObject levelObj;

    private static int maxItemsPerLine = 5;
    private static int maxSpawnOffsetX = 6;
    private static int maxSpawnOffsetY = 3;

    private List<float> usedValues = new List<float>();
    private int sinceLastObjectSpawn = maxSpawnOffsetY;

    private void Update() {
        if (transform.position.y < generationPoint.position.y) {
            usedValues.Clear();
            GenerateFloor();
            if (GameManager.instance.isPlaying && sinceLastObjectSpawn >= maxSpawnOffsetY) {
                GenerateObjects();
            }

            sinceLastObjectSpawn++;
        }
    }

    private void GenerateObjects() {
        int oCount = Random.Range(1, maxItemsPerLine);
        for (int i = 0; i <= oCount; i++) {
            Instantiate(GameManager.instance.items[Random.Range(0, GameManager.instance.items.Length)], new Vector3(transform.position.x + UniqueRandomXPos(-maxSpawnOffsetX, maxSpawnOffsetX), transform.position.y, transform.position.z), transform.rotation, levelObj.transform);
        }
        sinceLastObjectSpawn = 0;
    }

    private void GenerateFloor() {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(floorSection, transform.position, transform.rotation, levelObj.transform);
    }

    public int UniqueRandomXPos(int min, int max) {
        int val = Random.Range(min, max);

        while (usedValues.Contains(val)) {
            val = Random.Range(min, max);
        }

        usedValues.Add(val);
        usedValues.Add(val + 1);
        usedValues.Add(val - 1);
        return val;
    }
}
