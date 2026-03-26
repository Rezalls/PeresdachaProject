using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameArea");
    }

    public void OpenSettings() { _settingsPanel.SetActive(true); }
    public void CloseSettings() { _settingsPanel.SetActive(false); }
}
