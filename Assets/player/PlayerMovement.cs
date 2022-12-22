using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 2.5f;

    void Update()
    {
        Vector3 inputMovementVec = Vector3.zero;
        inputMovementVec.x = Input.GetAxis("Horizontal");
        inputMovementVec.z = Input.GetAxis("Vertical");
        inputMovementVec = Vector3.ClampMagnitude(inputMovementVec, speed);
        transform.position += inputMovementVec * speed * Time.deltaTime;
    }
}
