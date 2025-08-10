using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    // Método para ativar o trigger Hit quando tomar dano
    public void TakeDamage()
    {
        animator.SetTrigger("Hit");
        // Aqui você pode também diminuir vida, se tiver variável de vida
    }

    // Detecta colisão com a bala
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject); // destrói a bala
        }
    }
}
