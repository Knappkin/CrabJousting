using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayersReadyCheck : MonoBehaviour
{
    public GameObject p1, p2;


    void Update()
    {
        if ((p1.GetComponent<Ready1>().isReady) && (p2.GetComponent<Ready2>().isReady))
        {
            SceneManager.LoadScene("CrabJousting");
        }
    }
}
