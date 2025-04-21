using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScens : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
