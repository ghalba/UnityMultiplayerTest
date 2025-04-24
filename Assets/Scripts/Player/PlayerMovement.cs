using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    public float moveSpeed = 5f;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        // Disable movement on remote players
        if (!photonView.IsMine)
        {
            enabled = false;
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
