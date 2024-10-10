using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    private PlayerController playerController;
    private PlayerCamera playerCamera;
    #endregion
    #region Memebers

    private Vector3 inputDirection;

    #endregion
    #region UnityMessages
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        void GetInput()
        {
            inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
        GetInput();

    }
    private void FixedUpdate()
    {
        playerController.ApplyMovement(inputDirection);
    }
    #endregion
    #region Funcs

    #endregion
}
