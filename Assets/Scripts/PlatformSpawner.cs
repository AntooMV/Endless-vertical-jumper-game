using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] float secondSpawn;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    float auxTras;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y - 40 * i);
            GameObject gameObject = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], position, Quaternion.identity);
            auxTras = minTras;
            minTras = -maxTras;
            maxTras = -auxTras;
        }
        StartCoroutine(PlatformSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlatformSpawn() 
    {
        while (true) 
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y);
            GameObject gameObject = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(secondSpawn);
            Destroy(gameObject, 50f);
            auxTras = minTras;
            minTras = -maxTras;
            maxTras = -auxTras;
        }
    }


}
