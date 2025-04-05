using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStuff : MonoBehaviour
{
    public List<GameObject> fallingObjects;
    public float spawnInterval = 1.0f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnObject();
            timer = spawnInterval;
        }
    }

    void SpawnObject()
    {
        int index = Random.Range(0, fallingObjects.Count);
        GameObject obj = Instantiate(fallingObjects[index], new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), Screen.height / 2 + Random.Range(500, 2000), 0), Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        obj.transform.SetParent(transform, false);
    }
}
