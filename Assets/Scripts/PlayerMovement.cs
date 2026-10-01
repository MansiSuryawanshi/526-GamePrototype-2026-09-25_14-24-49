using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * move * moveSpeed * Time.deltaTime;
    }
}