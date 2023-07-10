using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirForaDaCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Verifica se o laser está fora dos limites da câmera
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            // Destroi o laser
            Destroy(gameObject);
        }
    }
}
