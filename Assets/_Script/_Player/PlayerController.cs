using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;

    [SerializeField] private int onGroundYVal;
    [SerializeField] private float gravity;

    public CharacterController Controller { get; private set; }
    private float yVal;

    public bool IsGround => Controller.isGrounded;
    private void Awake()
    {
        Controller = GetComponentInChildren<CharacterController>();
    }
    public void ApplyMovement(Vector3 _input)
    {
        Vector3 result = CalculateMovement(_input);
        Controller.Move(result * speed);
    }
    private Vector3 CalculateMovement(Vector3 inputDirection)
    {
        Vector3 moveVector = inputDirection * Time.fixedDeltaTime;
        if (IsGround && yVal < 0) yVal = onGroundYVal;
        else yVal += gravity * Time.fixedDeltaTime;
        moveVector.y = yVal;
        return moveVector;
    }
}
