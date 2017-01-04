using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public Vector2 spawnValues;
    public int shipCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public UnityEngine.UI.Text score1Text;
    public UnityEngine.UI.Text score2Text;
    public GameObject menu;

    int score1;
    int score2;

    void Start()
    {
        foreach (MenuController menuController in FindObjectsOfType<MenuController>())
        {
            menuController.OnStartClickedEvent += HandleOnStartButtonClicked;
        }
        
    }

    private void HandleOnStartButtonClicked ()
    {

        destroyPlayersIfExist();
        Instantiate(Resources.Load("Prefabs/Player1", typeof(GameObject)), new Vector2((float)7.66, (float)-3.83), Quaternion.identity);
        Instantiate(Resources.Load("Prefabs/Player2", typeof(GameObject)), new Vector2((float)-7.66, (float)-3.83), Quaternion.identity);

        score1 = 0;
        score2 = 0;
        score1Text.text = "" + score2;
        score2Text.text = "" + score1;

        StartCoroutine(SpawnWaves());
    }

    private void destroyPlayersIfExist ()
    {
        if (GameObject.Find("Player1") != null)
        {
            Destroy(GameObject.Find("Player1"));
        }

        if (GameObject.Find("Player1(Clone)") != null)
        {
            Destroy(GameObject.Find("Player1(Clone)"));
        }

        if (GameObject.Find("Player2(Clone)") != null)
        {
            Destroy(GameObject.Find("Player2(Clone)"));
        }

        if (GameObject.Find("Player2") != null)
        {
            Destroy(GameObject.Find("Player2"));
        }

        if (GameObject.Find("Life(Clone)") != null)
        {
            Destroy(GameObject.Find("Life(Clone)"));
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), getRandomY());
            Instantiate(Resources.Load("Prefabs/Life", typeof(GameObject)), spawnPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            if (GameObject.Find("Life(Clone)") == null)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), getRandomY());
                Instantiate(Resources.Load("Prefabs/Life", typeof(GameObject)), spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }

            if (GameObject.Find("Player1") == null && GameObject.Find("Player1(Clone)") == null)
            {
                score2++;
                score1Text.text = "" + score2;
                score2Text.text = "" + score1;
                Instantiate(Resources.Load("Prefabs/Player1", typeof(GameObject)), new Vector2((float)7.66, (float)-3.83), Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }

            if (GameObject.Find("Player2") == null && GameObject.Find("Player2(Clone)") == null)
            {
                score1++;
                score1Text.text = "" + score2;
                score2Text.text = "" + score1;
                Instantiate(Resources.Load("Prefabs/Player2", typeof(GameObject)), new Vector2((float)-7.66, (float)-3.83), Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    private float getRandomY ()
    {
        float rand = Random.Range(-spawnValues.y, spawnValues.y);

        if ((rand > -3.13 && rand < -1.87) || (rand < 3.13 && rand > 1.87) || (rand > -0.74 && rand < 0.67))
        {
            while (((rand > -3.13 && rand < -1.87) || (rand < 3.13 && rand > 1.87) || (rand > -0.74 && rand < 0.67)))
            {
                rand = Random.Range(-spawnValues.y, spawnValues.y);
            }
        }

        return rand;
    }
}
