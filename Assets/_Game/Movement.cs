using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float horizontalSpeed;
        [SerializeReference] private float verticalSpeed;
        [FormerlySerializedAs("_rb")] [SerializeField]private Rigidbody rb;

        private void Start()
        {
            rb.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            rb.AddForce(Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            
        }

        private Vector3 Move(float horizontalAxis, float verticalAxis)
        {
            return new Vector3(horizontalAxis * horizontalSpeed, 0, verticalAxis * verticalSpeed);
        }
    }
}
