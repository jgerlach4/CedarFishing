using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1; // pause the game
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void JournalButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FishCollectionScene");
    }
}
