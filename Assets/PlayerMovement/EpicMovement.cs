using UnityEngine;
 
public class EpicMovement : MonoBehaviour
{
    public CharacterController _controller;
    public float _speed = 10;
    public float _rotationSpeed = 180;
 
    private Vector3 rotation;

    private Vector3 move = Vector3.zero;
    public float gravity = 20f;
    public float jumpSpeed = 8.0f;
 
    public void Update()
    {
        if (_controller.isGrounded) {
            this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
 
            Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
            move = this.transform.TransformDirection(move);
            _controller.Move(move * _speed);
            this.transform.Rotate(this.rotation);
            //if (Input.GetButton("Jump"))
            //     move.y = jumpSpeed;
        }
        move.y -= gravity * Time.deltaTime;
        _controller.Move(move * Time.deltaTime);
    }
}
