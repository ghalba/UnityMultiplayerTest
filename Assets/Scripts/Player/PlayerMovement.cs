using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 720f;
    private CharacterController controller;
    Animator animator;
    PhotonView view;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if(view.IsMine)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(h, 0, v);

            Quaternion toRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
            animator.SetFloat("Blend", move.magnitude);
            controller.Move(move * moveSpeed * Time.deltaTime);
        }
        
    }
}
