using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public GameObject journalContainer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            container.SetActive(true);
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        journalContainer.SetActive(false);
        Time.timeScale = 1; // pause the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void JournalButton()
    {
        journalContainer.SetActive(true);
        container.SetActive(false);
        Time.timeScale = 0; // pause the game
        Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
}
