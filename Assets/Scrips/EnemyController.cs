using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    private Animator animator;
    private bool facingRight = true;  // Inicia olhando para a direita

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

            // Move o inimigo em direção ao player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Verifica se precisa virar o inimigo
            if(direction.x > 0 && !facingRight)
                Flip();
            else if(direction.x < 0 && facingRight)
                Flip();

            // Atualiza o parâmetro Speed do Animator para controlar a animação
            animator.SetFloat("Speed", direction.magnitude);
        }
    }

    // Método que inverte o inimigo horizontalmente
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;  // Inverte a escala no eixo X
        transform.localScale = scale;
    }

    // Método para ativar o trigger Hit quando tomar dano
    public void TakeDamage()
    {
        animator.SetTrigger("Hit");
        // Aqui você pode adicionar a lógica para diminuir a vida do inimigo, se quiser
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
