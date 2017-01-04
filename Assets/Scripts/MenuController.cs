using UnityEngine;
using System.Collections;

public delegate void OnStartClickedEvent();
public delegate void OnReStartClickedEvent();

public class MenuController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject start;
    public GameObject restart;
    public GameObject quit;
    public GameObject resume;

    public event OnStartClickedEvent OnStartClickedEvent;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (start != null) start.SetActive(true);
            if (restart != null) restart.SetActive(false);
            if (resume != null) resume.SetActive(false);
            if (quit != null) quit.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas != null ) canvas.gameObject.SetActive(true);
            if (start != null) start.SetActive(false);
            if (restart != null) restart.SetActive(true);
            if (resume != null) resume.SetActive(true);
            if (quit != null) quit.SetActive(true);
        }
    }

    public void onStartClicked ()
    {
        if (OnStartClickedEvent != null)
        {
            OnStartClickedEvent();
        }
        if (canvas != null) canvas.gameObject.SetActive(false);
    }

    public void onResumeClicked()
    {
        if (canvas != null) canvas.gameObject.SetActive(false);
    }

    public void onQuitClicked()
    {
        Application.Quit();
    }
}