using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class Walk : MonoBehaviour {

    // Ship speed
    /*public float speed = 5;
	public float jumpForce = 10;
	private Rigidbody2D _rbody2d;

	public void Start() {
		//GetComponent<Animator>().SetBool("Walking", true);
		_rbody2d = GetComponent<Rigidbody2D>();
	}

	public void Update() {

		Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
		if (_rbody2d.position.y > screenBounds.y || _rbody2d.position.y < screenOrigo.y)
		{
			_rbody2d.position = new Vector2(_rbody2d.position.x,Mathf.Abs (_rbody2d.position.y));
		}

		float h = Input.GetAxisRaw("Horizontal");
		//float v = Input.GetAxisRaw("Vertical");

		// Set the Rigidbody's Velocity
		Vector2 dir = new Vector2(h, 0);
		_rbody2d.velocity = dir.normalized * speed;


		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			_rbody2d.velocity = new Vector2(0, jumpForce);
		}

		// Set Animation Parameter
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
			GetComponent<Animator> ().SetBool ("Walking", true);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
			GetComponent<Animator> ().SetBool ("Walking", true);
		} else {
			GetComponent<Animator> ().SetBool ("Walking", false);
		}

	}

	public void FixedUpdate() {
		// Input.GetAxis - smoothed value, gradual transition
		// Input.GetAxisRaw - real value



	}*/
    public int moveSpeed;
    public int jumpHeight;

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;

    bool isGrounded;
    Rigidbody2D rb2D;


    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update() {

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
        if (rb2D.position.y > screenBounds.y || rb2D.position.y < screenOrigo.y) {
            rb2D.position = new Vector2(rb2D.position.x, Mathf.Abs(rb2D.position.y));
        }

        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = moveDir;

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);
        

        

        if (Input.GetAxisRaw("Horizontal") == 1) {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Animator>().SetBool("Walking", true);
        } else if (Input.GetAxisRaw("Horizontal") == -1) {
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Animator>().SetBool("Walking", true);
        } else {
            GetComponent<Animator>().SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            GetComponent<Animator>().SetBool("Jumping", true);
            rb2D.AddForce(new Vector2(0, jumpHeight));
        } else {
            GetComponent<Animator>().SetBool("Jumping", false);
        }

        if (Input.GetKeyDown(KeyCode.RightControl)) {
            GetComponent<Animator>().SetBool("Shooting", true);
        } else {
            GetComponent<Animator>().SetBool("Shooting", false);
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            GetComponent<Animator>().SetBool("PointingUp", true);
        } else {
            GetComponent<Animator>().SetBool("PointingUp", false);
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            GetComponent<Animator>().SetBool("PointingDown", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("PointingDown", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.RightShift))
        {

            moveSpeed = 7;
            //transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Animator>().SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = 7;
            //transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Animator>().SetBool("Running", true);
        }
        else
        {
            moveSpeed = 5;
            GetComponent<Animator>().SetBool("Running", false);
        }


        /*if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1)
            {
                GetComponent<Animator>().SetBool("PointingDownDiagonally", true);
            
        }
        else
        {
            GetComponent<Animator>().SetBool("PointingDownDiagonally", false);
        }

        if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 1)
            {
                GetComponent<Animator>().SetBool("PointingUpDiagonally", true);
            
        }
        else
        {
            GetComponent<Animator>().SetBool("PointingUpDiagonally", false);
        }*/

    }
}
