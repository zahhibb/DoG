using UnityEngine;
using System.Collections;

public class StagingManager : MonoBehaviour
{


    public void BackToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

        Destroy(GameObject.FindGameObjectWithTag("ManagerP1").gameObject);
        Destroy(GameObject.FindGameObjectWithTag("ManagerP2").gameObject);
        Destroy(GameObject.FindGameObjectWithTag("ManagerP3").gameObject);
        Destroy(GameObject.FindGameObjectWithTag("ManagerP4").gameObject);

    }
}
