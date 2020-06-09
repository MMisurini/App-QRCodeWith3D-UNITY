using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void SceneReset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
