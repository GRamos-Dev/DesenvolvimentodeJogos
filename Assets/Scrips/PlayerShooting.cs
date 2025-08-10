using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;         // ponto de saída da bala
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Pega a posição do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // para 2D, z=0

        // Calcula a direção do tiro
        Vector3 direction = (mousePos - firePoint.position).normalized;

        // Instancia a bala com rotação na direção do mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle - 90f); // ajusta para sprite apontar para cima

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

        // Define a velocidade da bala (supondo que o script da bala usa Rigidbody2D)
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f; // ajuste a velocidade aqui
        }
    }
}
