using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingleMono<InputManager>
{
    private float moveVertical => Input.GetAxisRaw("Vertical");
    private float moveHorizontal => Input.GetAxisRaw("Horizontal");
    private Vector3 moveInput => new Vector3(moveHorizontal, 0f, moveVertical);

    private float mouseY => Input.GetAxisRaw("Mouse Y");
    private float mouseX => Input.GetAxisRaw("Mouse X");

    public float GetMoveVertical => moveVertical;
    public float GetMoveHorizontal => moveHorizontal;
    public Vector3 GetMoveInput => moveInput;

    public float GetMouseY => mouseY;
    public float GetMouseX => mouseX;
}
