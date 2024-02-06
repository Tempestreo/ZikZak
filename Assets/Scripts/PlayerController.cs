using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hit;
    private float speed = 1;
    bool isLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isLeft = false;
    }

    void Update()
    {
        Physics.Raycast(this.transform.position, Vector3.down, out hit);
        if (hit.collider == null)
        {
            rb.useGravity = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider == null)
            {
                rb.useGravity = true;
            }
            if (isLeft == false)
                isLeft = true;

            else
                isLeft = false;

            Move();
        }
    }
    void Move()
    {
        rb.velocity.Set(0,0,0);

        if (isLeft)
        {
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
        else
        {
            rb.velocity = new Vector3(1, 0, 0) * speed;
        }
    }
}
