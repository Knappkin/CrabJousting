using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void Loading()
    {
        SceneManager.LoadScene("CrabJousting");
    }
}
