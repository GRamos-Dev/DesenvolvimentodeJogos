using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // A velocidade já foi definida no PlayerShoot, então só destruímos depois do tempo
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
    if (collision.CompareTag("Enemy"))
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1); // Aplica 1 ponto de dano, pode ajustar
        }
        Destroy(gameObject); // Destroi a bala
    }
    else if (collision.CompareTag("Obstacle"))
    {
        Destroy(gameObject);
    }
}

}
