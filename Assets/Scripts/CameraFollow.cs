using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // O alvo que a câmera vai seguir (nave)
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera
    public Vector3 offset;         // Offset (deslocamento) da câmera em relação ao alvo

    void LateUpdate()
    {
        // Calcula a posição desejada da câmera
        Vector3 desiredPosition = target.position + offset;

        // Suaviza a transição da posição atual para a desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }
}
