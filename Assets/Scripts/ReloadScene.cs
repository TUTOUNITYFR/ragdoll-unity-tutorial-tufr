using UnityEngine;
using UnityEngine.SceneManagement;

// Permet de recharger la scène actuelle
public class ReloadScene : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
