using UnityEngine;

public class FishCollection : MonoBehaviour
{
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void JournalButton()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        UnityEngine.SceneManagement.SceneManager.LoadScene("CedarLakeArea");
    }
}
