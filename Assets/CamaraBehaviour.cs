using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraBehaviour : MonoBehaviour
{
    float cameraHeight;
    public float maxHeight, minHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform background;
    public bool cameraFollows;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollows = transform.position.y < player.position.y + 15 && (cameraHeight <= maxHeight && cameraHeight >= minHeight);
        cameraHeight = cameraFollows ? player.position.y + 15 : cameraHeight;
        keepOnStage();
        transform.position = new Vector3(0, cameraHeight, -2);
    }

    void keepOnStage() 
    {
        maxHeight = background.position.y + 133;
        minHeight = background.position.y - 133;
        if (cameraHeight > maxHeight)
        {
            cameraHeight = maxHeight;
            return;
        }
        if (cameraHeight < minHeight) 
        {
            cameraHeight = minHeight;
            return;
        }
        return;
    }
}
