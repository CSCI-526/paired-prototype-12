using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToFunction2 : MonoBehaviour
{
    public string targetScene = "Function2"; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}
