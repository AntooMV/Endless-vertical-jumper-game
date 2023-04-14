using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] float secondSpawn;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y - i*20);
            GameObject gameObject = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], position, Quaternion.identity);
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
            yield return new WaitForSeconds(secondSpawn * Time.deltaTime * 60);
            Destroy(gameObject, 50f);
        }
    }
}
