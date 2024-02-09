using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    MenuManager scMenu;
    Rigidbody rb;
    RaycastHit hit;
    [SerializeField] float speed;
    bool isLeft;

    void Start()
    {
        scMenu = FindObjectOfType<MenuManager>();
        rb = GetComponent<Rigidbody>();
        isLeft = false;
    }

    void Update()
    {
        Physics.Raycast(this.transform.position, Vector3.down, out hit);
        if (hit.collider == null)
        {
            rb.useGravity = true;
            scMenu.LosePanel();
            Invoke("DelayEnd", 1);
            scMenu.isStarted = false;
        }
        if (Input.GetMouseButtonDown(0) && scMenu.isStarted)
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
    void DelayEnd()
    {
        rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            scMenu.WinPanel();
            Invoke("DelayEnd", 0.25f);
            scMenu.isStarted = false;
        }
    }
}
