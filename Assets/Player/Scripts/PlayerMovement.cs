using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private float _speed = 100f;

        [Range(1, 3)]
        [SerializeField] private float _mouseSenvistivity;

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _speed * Time.deltaTime;

            transform.localEulerAngles -= new Vector3(0f, -mouseX * _mouseSenvistivity, 0f);
        }

        private void FixedUpdate()
        {
            float verticalInput = Input.GetAxis("Vertical");
            LocalMovement(transform.forward, verticalInput);
        }

        private void LocalMovement(Vector3 direction, float input)
        {
            _rigidBody.velocity = direction * input * (_speed * Time.fixedDeltaTime);
        }
    }
}
