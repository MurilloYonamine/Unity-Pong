using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RaqueteController : MonoBehaviour
{
    // Criando o meu vector 3.
    private Vector3 minhaPosicao;
    private float meuY;
    public float minhaVelocidade = 5f;
    private float limite = 3.4f;
    public bool player2;

    // Variável para chegar se ele deve ser controlado pela inteligência artificial
    public bool automatico = false;

    // Pegando a posição da bola
    public Transform transformBola;

    // Start is called before the first frame update.
    void Start()
    {
        // Pegando a posição inicial da raquete e aplicando à minha posição.
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Velocidade publicada pelo deltatime
        float deltaVelocidade = minhaVelocidade * Time.deltaTime;
        minhaPosicao.y = meuY;

        // Pegando a setinha para cima.
        // Se eu apertar a setinha para cima, ele subirá a raquete.

        // Modificar a posição da minha raquete.
        transform.position = minhaPosicao;

        if (!automatico)
        {
            if (!player2)
            {
                // Controlando a raquete como o player 1
                if (Input.GetKey(KeyCode.W))
                {
                    // Aumentar o valor do Y.
                    meuY += deltaVelocidade;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    // Diminuir o valor do Y.
                    meuY -= deltaVelocidade;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    automatico = true;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    meuY += deltaVelocidade;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    meuY -= deltaVelocidade;
                }
            }
        }
        else
        {
            // tirando ele do automático
            // chegcando se as setinhas foram pressionados
            if (Input.GetKey(KeyCode.UpArrow))
            {
                automatico = false;
            }

            // Para acessar funções matemáticas, nós usamos a classe Mathf
            meuY = Mathf.Lerp(meuY, transformBola.position.y, 0.02f);
            // se meu valor é 0 e o da bola é 10 a diferença entre eles é 10, 10% de 10 é 1
        }


        // impedindo que eu saia por baixa da tela
        if (meuY < -limite)
        {
            meuY = -limite;
        }
        if (meuY > limite)
        {
            meuY = limite;
        }
    }
}
