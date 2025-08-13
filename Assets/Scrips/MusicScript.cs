using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    void Start()
    {
        // Garante que a música toque apenas nesta cena
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        
        // Impede que o objeto seja destruído ao carregar nova cena (se necessário)
        // DontDestroyOnLoad(gameObject);
    }
}