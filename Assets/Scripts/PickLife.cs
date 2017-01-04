using UnityEngine;

public class PickLife : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player1") 
        {
            coll.gameObject.GetComponent<LifeController>().life = 100;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Player2")
        {
            coll.gameObject.GetComponent<LifeController>().life = 100;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Platform")
        {
            Debug.Log("platform");
            Destroy(gameObject);
        }

    }
}
