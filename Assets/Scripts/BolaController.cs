using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    // Criando a variável para o rigidbody
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;

    public Transform transformCam;

    public float velocidade = 5f;
    // Start is called before the first frame update

    public float limiteHorizonal = 12f;

    public AudioClip sound;

    public float delay = 2f;

    private bool jogoIniciado = false;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // Iniciando a bola com delay
        delay -= Time.deltaTime;

        // Checando se o delay chegou em 0
        if (delay <= 0 && jogoIniciado == false)
        {
            jogoIniciado = true;

            // Passando a velocidade para a minha velocidade

            // Tentando gerar um valor aleatório
            int direcao = Random.Range(0, 4);

            switch (direcao)
            {
                case 0:
                    minhaVelocidade.x = +velocidade;
                    minhaVelocidade.y = +velocidade;
                    break;
                case 1:
                    minhaVelocidade.x = -velocidade;
                    minhaVelocidade.y = +velocidade;
                    break;
                case 2:
                    minhaVelocidade.x = -velocidade;
                    minhaVelocidade.y = -velocidade;
                    break;
                case 3:
                    minhaVelocidade.x = +velocidade;
                    minhaVelocidade.y = -velocidade;
                    break;

            }
            // Adicionando velocidade para a esquerda
            meuRB.velocity = minhaVelocidade;
        }

        // Checando se a bola saiu da tela
        if (transform.position.x < -limiteHorizonal || transform.position.x > limiteHorizonal)
        {
            // Recarregando a minha cena
            SceneManager.LoadScene(0);
        }
    }

    // Criando o meu evento de colisão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(sound, transformCam.position);
    }
}
