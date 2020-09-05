using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour {
    [SerializeField] private float moveSpeed;

    private Rigidbody rbody;
    private InputActions Actions;
    private Vector2 movementInput;

    private void Awake() {
        rbody = GetComponent<Rigidbody>();
        Actions = new InputActions();
        Actions.Player.Enable();
    }

    private void Start() {
        Actions.Player.Movement.performed += PerformMovement;
    }

    private void PerformMovement(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        movementInput = obj.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        float yVelocity = rbody.velocity.y;
        rbody.velocity = new Vector3(moveSpeed * movementInput.x, yVelocity, moveSpeed * movementInput.y);
    }
}
