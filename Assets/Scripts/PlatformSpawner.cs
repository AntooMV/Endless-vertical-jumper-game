using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] float secondSpawn;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    float auxTras;
    public float auxSpawn;

    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y - 60 * i);
            GameObject gameObject = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], position, Quaternion.identity);
            auxTras = minTras;
            minTras = -maxTras;
            maxTras = -auxTras;
        }
    }
    void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            auxSpawn -= Time.deltaTime;
            PlatformSpawn();
        }
        
    }
    void PlatformSpawn() 
    {
        if (auxSpawn <= 0) 
        {
            var randomBool = Random.Range(-1, 2) > 0;
            auxTras = minTras;
            minTras = randomBool ? -maxTras : maxTras;
            maxTras = randomBool ? -auxTras : auxTras;
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y);
            GameObject gameObject = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], position, Quaternion.identity);
            Destroy(gameObject, 30f);
            auxSpawn = secondSpawn;
        }
    }


}
