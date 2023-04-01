using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Rigidbody bala; // Objeto da bala que será instanciado
    public Transform spawnBala; // Posição da arma onde a bala será instanciada
    public float forcaTiro = 1000f; // Força do tiro

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Verifica se o botão de atirar foi pressionado
        {
            Rigidbody balaClone = Instantiate(bala, spawnBala.position, spawnBala.rotation) as Rigidbody; // Instancia a bala
            balaClone.AddForce(spawnBala.forward * forcaTiro); // Adiciona força à bala
        }
    }
}