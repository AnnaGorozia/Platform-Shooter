using UnityEngine;

public class FirePlayer2 : MonoBehaviour
{

    // Bullet prefab
    public GameObject bullet;

    public AudioClip fireClip;

    private Collider2D _playerCollider;

    public Vector3 position;

    public void Start()
    {
        _playerCollider = transform.parent.GetComponent<Collider2D>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            position = transform.position;
            GameObject projectile = (GameObject)Instantiate(bullet,
                                                             transform.position,
                                                             Quaternion.identity);
            SoundManager.instance.PlaySingle(fireClip);
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), _playerCollider);
        }
    }
}
