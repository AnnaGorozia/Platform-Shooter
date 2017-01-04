using UnityEngine;

public class BulletDamage : MonoBehaviour {

    public AudioClip shootClip;

    void OnCollisionEnter2D(Collision2D coll) {

    	if (coll.gameObject.tag == "Player1") {
            SoundManager.instance.PlaySingle(shootClip);
            float distance = calculatePlayer2Distance(coll.gameObject.transform.position);
            if (isDead(distance, coll.gameObject)) {
                Destroy(coll.gameObject);
            }
        }
        if (coll.gameObject.tag == "Player2")
        {
            SoundManager.instance.PlaySingle(shootClip);
            float distance = calculatePlayer1Distance(coll.gameObject.transform.position);
            if (isDead(distance, coll.gameObject)) {
                Destroy(coll.gameObject);
            }
        }
        if (coll.gameObject.tag == "Platform" || coll.gameObject.tag == "Life")
        {
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), coll.collider);
        }
        if (coll.gameObject.tag != "Platform" && coll.gameObject.tag != "Life")
        {
            Destroy(gameObject);
        }

    }

    bool isDead(float distance, GameObject gameObject)
    {
        int life = gameObject.GetComponent<LifeController>().life;
        if (distance > 5)
        {
            life = (int)(life - 25);
        }
        if (distance <= 5 && distance >= 1)
        {
            life = (int)(life - 50);
        }
        if (distance < 1)
        {
            life = (int)(life - 100);
        }
        gameObject.GetComponent<LifeController>().life = life;
        if (life <= 0)
        {
            gameObject.GetComponent<LifeController>().life = 0;
            return true;
        }
        return false;
    }

    float calculatePlayer2Distance(Vector3 position)
    {
        Vector3 p2Position = new Vector3(0, 0, 0);
        if (GameObject.Find("Player2") != null)
        {
            p2Position = GameObject.Find("Player2").transform.position;
        }
        else if (GameObject.Find("Player2(Clone)") != null)
        {
            p2Position = GameObject.Find("Player2(Clone)").transform.position;
        }
        return Vector3.Distance(p2Position, position) - 2;
    }

    float calculatePlayer1Distance(Vector3 position)
    {
        Vector3 p1Position = new Vector3(0, 0, 0);
        if (GameObject.Find("Player1") != null)
        {
            p1Position = GameObject.Find("Player1").transform.position;
        }
        else if (GameObject.Find("Player1(Clone)") != null)
        {
            p1Position = GameObject.Find("Player1(Clone)").transform.position;
        }
        return Vector3.Distance(p1Position, position) - 2;
    }
}
