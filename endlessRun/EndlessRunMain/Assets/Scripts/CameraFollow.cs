
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.position;  //pozycja kamery za graczem
    }

    
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;                                //kamera nie porusza się w lewo ani prawo
        transform.position = targetPos;
    }
}
