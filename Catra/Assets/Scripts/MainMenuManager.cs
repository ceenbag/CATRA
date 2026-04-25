using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class MainMenuManager : MonoBehaviour
{
    // Public methods can be seen and triggered by UI Buttons
    public void StartGame()
    {
        // Loads the scene at Build Index 1 (your game level)
        // You can also use SceneManager.LoadScene("YourLevelName");
        SceneManager.LoadScene(1); 
    }

    public void QuitGame()
    {
        Debug.Log("Exiting game ---");
        
        Application.Quit(); 
    }
}