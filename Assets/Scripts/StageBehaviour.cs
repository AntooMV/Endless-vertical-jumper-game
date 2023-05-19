using UnityEngine;

public class StageBehaviour : MonoBehaviour
{
    void Update()
    {
        if (!PauseMenu.isPaused) transform.position += Vector3.up * Time.deltaTime * 15;        
    }
}
