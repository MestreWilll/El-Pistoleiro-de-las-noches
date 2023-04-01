import UnityEngine
from UnityEngine import Vector3

class Movimentacao(UnityEngine.MonoBehaviour):
    velocidade = 10.0 # Velocidade do personagem
    
    def Update(self):
        horizontal = Input.GetAxis("Horizontal") # Entrada horizontal
        vertical = Input.GetAxis("Vertical") # Entrada vertical
        
        movimento = Vector3(horizontal, 0, vertical) * self.velocidade * Time.deltaTime # Movimento do personagem
        self.transform.position += movimento # Aplica movimento ao transform do objeto
