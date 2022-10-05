using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject PigPrefab;
    public int numPig;
    public GameObject[] allPig;

    [Header("All Pigs")]
    public Vector3 limits;
    public bool bounded;
    public bool randomize;
    public bool followLider;
    public GameObject lider;

    [Header("Pig Settings")]
    [Range(0.0f, 5.0f)] public float minSpeed;
    [Range(0.0f, 5.0f)] public float maxSpeed;
    [Range(0.0f, 5.0f)] public float neighbourDistance;
    [Range(0.0f, 5.0f)] public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        allPig = new GameObject[numPig];
        for (int i = 0; i < numPig; ++i)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));// random position
            Vector3 randomize = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f)); // random vector direction
            allPig[i] = (GameObject)Instantiate(PigPrefab, pos,
                                Quaternion.LookRotation(randomize));
            allPig[i].GetComponent<flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
