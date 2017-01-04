using UnityEngine;

public class ContinuousVelocity : MonoBehaviour {
	// The Velocity
    public Vector2 velocity;
    public Vector3 rotate;

    private Rigidbody2D _rbody2d;
	
	void Start() {
        _rbody2d = GetComponent<Rigidbody2D>();
        transform.Rotate(Vector3.forward * rotate.y);
    }
    void FixedUpdate() {
        
        _rbody2d.velocity = velocity;
    }
}
