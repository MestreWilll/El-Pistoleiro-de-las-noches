import UnityEngine
from UnityEngine import Vector3
from UnityEngine import Input
from UnityEngine import Time
from UnityEngine import Rigidbody

class PlayerMovement(UnityEngine.MonoBehaviour):
    moveSpeed = 5.0

    def Start(self):
        self.rb = self.GetComponent[Rigidbody]()

    def Update(self):
        move_horizontal = Input.GetAxis("Horizontal")
        move_vertical = Input.GetAxis("Vertical")

        self.move_direction = Vector3(move_horizontal, 0.0, move_vertical)

    def FixedUpdate(self):
        self.rb.MovePosition(self.transform.position + self.move_direction * self.moveSpeed * Time.fixedDeltaTime)
