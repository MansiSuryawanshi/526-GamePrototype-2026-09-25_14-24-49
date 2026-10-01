using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Transform leftLeg;
    public Transform rightLeg;

    public float walkSpeed = 8f;
    public float legAngle = 25f;

    private float walkTime = 0f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move != 0)
        {
            walkTime += Time.deltaTime * walkSpeed;

            float swing = Mathf.Sin(walkTime) * legAngle;

            leftLeg.localRotation = Quaternion.Euler(0, 0, swing);
            rightLeg.localRotation = Quaternion.Euler(0, 0, -swing);
        }
        else
        {
            leftLeg.localRotation = Quaternion.identity;
            rightLeg.localRotation = Quaternion.identity;
        }
    }
}