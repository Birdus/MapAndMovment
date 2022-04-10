using UnityEngine;

public class Menu_paused : MonoBehaviour
{
    public GameObject menuPaused;
    public GameObject MovmentUser;
    

    [SerializeField] KeyCode keyMenuPaused;

    PlayerControler scriptMov;

    bool isMenuPaused = false;

    private void Start()
    {
        menuPaused.SetActive(false);
        scriptMov = MovmentUser.GetComponent<PlayerControler>();
    }

    private void Update()
    {
        AcriveMenu();
    }

    void AcriveMenu()
    {
        
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
        }
        if (isMenuPaused)
        {
            menuPaused.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            scriptMov.enabled = false;
            Time.timeScale = 0f;
        }
        else
        {
            menuPaused.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            scriptMov.enabled = true;
            Time.timeScale = 1f;
        }
    }

    public void MunePausedCountinue()
    {
        isMenuPaused = false;
    }

    public void MunePausedSettings()
    {
        Debug.Log("Настройки");
    }

    public void MunePausedExit()
    {
        Application.Quit();
    }
}
