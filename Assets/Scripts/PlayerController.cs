using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 12f;
    CharacterController cc;

    float gravity = -9.82f;
    float jumpForce = 5f;
    float velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!cc)
            cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);

        if (move.magnitude > 1f)
        {
            move = move.normalized;
        }

        move *= speed;

        if (cc.isGrounded)
        {
            if (velocity < 0)
                velocity = -2f;

            if (Input.GetButtonDown("Jump"))
                velocity = jumpForce;
        }

        velocity += gravity * Time.deltaTime;
        move.y = velocity;

        cc.Move(move * Time.deltaTime);
    }
}
