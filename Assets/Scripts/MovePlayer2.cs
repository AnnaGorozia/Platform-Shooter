using UnityEngine;

public class MovePlayer2 : MonoBehaviour {

    public int moveSpeed;

    public int jumpHeight;

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;
    public AudioClip jumpClip;

    bool isGrounded;
    Rigidbody2D rb2D;

    public Transform _bulletLeft;
    public Transform _bulletRight;
    public Transform _bulletUp;
    public Transform _bulletDown;


    void Start() {
        enableRight();
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
        if (rb2D.position.y > screenBounds.y || rb2D.position.y < screenOrigo.y)
        {
            rb2D.position = new Vector2(rb2D.position.x, Mathf.Abs(rb2D.position.y));
        }

        Vector2 moveDir = new Vector2(Input.GetAxisRaw("P2_horizontal") * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = moveDir;

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        if (Input.GetKey(KeyCode.D))
        {
            enableRight();
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            enableLeft();
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            GetComponent<Animator>().SetBool("Jumping", true);
            rb2D.AddForce(new Vector2(0, jumpHeight));
            SoundManager.instance.PlaySingle(jumpClip);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jumping", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetBool("Shooting", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Shooting", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            enableUp();
            GetComponent<Animator>().SetBool("PointingUp", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            enableShootingPosition();
            GetComponent<Animator>().SetBool("PointingUp", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            enableDown();
            GetComponent<Animator>().SetBool("PointingDown", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            enableShootingPosition();
            GetComponent<Animator>().SetBool("PointingDown", false);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.E))
        {
            moveSpeed = 7;
            GetComponent<Animator>().SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.E))
        {
            moveSpeed = 7;
            GetComponent<Animator>().SetBool("Running", true);
        }
        else
        {
            moveSpeed = 5;
            GetComponent<Animator>().SetBool("Running", false);
        }


    }

    void enableShootingPosition()
    {
        if (transform.localScale.x == 1)
        {
            enableRight();
        }
        if (transform.localScale.x == -1)
        {
            enableLeft();
        }
    }

    void enableRight()
    {
        _bulletRight.gameObject.SetActive(true);
        _bulletLeft.gameObject.SetActive(false);
        _bulletUp.gameObject.SetActive(false);
        _bulletDown.gameObject.SetActive(false);
    }

    void enableLeft()
    {
        _bulletRight.gameObject.SetActive(false);
        _bulletLeft.gameObject.SetActive(true);
        _bulletUp.gameObject.SetActive(false);
        _bulletDown.gameObject.SetActive(false);
    }

    void enableDown()
    {
        _bulletRight.gameObject.SetActive(false);
        _bulletLeft.gameObject.SetActive(false);
        _bulletUp.gameObject.SetActive(false);
        _bulletDown.gameObject.SetActive(true);
    }

    void enableUp()
    {
        _bulletRight.gameObject.SetActive(false);
        _bulletLeft.gameObject.SetActive(false);
        _bulletUp.gameObject.SetActive(true);
        _bulletDown.gameObject.SetActive(false);
    }
}
