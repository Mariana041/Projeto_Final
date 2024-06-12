using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Debug.Log("Colisão com o terreno detectada.");
        }
    }

    void Update()
    {
        // Certifique-se de que o personagem está acima de uma altura mínima
        if (transform.position.y < -10)
        {
            Debug.LogWarning("Personagem está caindo!");
            // Resete a posição do personagem para uma posição segura
            transform.position = new Vector3(0, 10, 0);
        }
    }
}