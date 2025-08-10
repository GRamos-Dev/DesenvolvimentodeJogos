using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // arraste o jogador aqui no Inspector
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // ajuste no inspector se quiser afastar a câmera

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
