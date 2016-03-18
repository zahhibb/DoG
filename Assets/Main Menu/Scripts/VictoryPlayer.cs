using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryPlayer : MonoBehaviour
{
    [SerializeField] private RawImage[] m_victoryMovies = null;
    [SerializeField] private float m_displayTime = 10f;
    [SerializeField] private string m_victor = "Pepper-Green Granola";

    void Start ()
    {
        //foreach (RawImage movie in m_victoryMovies)
        //{
        //    MovieTexture movieTexture = (MovieTexture)movie.texture;
        //    //movieTexture.loop = false;
        //}

        StartCoroutine(BackToMain(m_displayTime));

        if (GameObject.FindGameObjectWithTag("ManagerP1"))
        {
            m_victor = GameObject.FindGameObjectWithTag("ManagerP1").GetComponent<Manager>().ChosenScene;
        }
        switch (m_victor)
        {
            case "Pepper-Green Granola":
                m_victoryMovies[0].GetComponent<PlayImage>().PlayLoop();
                m_victoryMovies[1].gameObject.SetActive(false);
                m_victoryMovies[2].gameObject.SetActive(false);
                m_victoryMovies[3].gameObject.SetActive(false);

                //StartCoroutine(PauseMe(3.3f, m_victoryMovies[0]));
                //playergreenshit
                break;
            case "Pink Pelican Parachute":
                m_victoryMovies[0].gameObject.SetActive(false);
                m_victoryMovies[1].GetComponent<PlayImage>().PlayLoop();
                m_victoryMovies[2].gameObject.SetActive(false);
                m_victoryMovies[3].gameObject.SetActive(false);
                //playpinkshit
                break;
            case "Lemon Truck":
                m_victoryMovies[0].gameObject.SetActive(false);
                m_victoryMovies[1].gameObject.SetActive(false);
                m_victoryMovies[2].GetComponent<PlayImage>().PlayLoop();
                m_victoryMovies[3].gameObject.SetActive(false);
                //playYwllowshit
                break;
            case "Blue Coathanger":
                m_victoryMovies[0].gameObject.SetActive(false);
                m_victoryMovies[1].gameObject.SetActive(false);
                m_victoryMovies[2].gameObject.SetActive(false);
                m_victoryMovies[3].GetComponent<PlayImage>().PlayLoop();
                //playblueshit
                break;
            default:
                //something is wrong
                Debug.Log("switch in VictoryPlayer is unhappy");
                //m_greenMovie.GetComponent<PlayImage>().PlayLoop();
                m_victoryMovies[0].gameObject.SetActive(false);
                m_victoryMovies[1].gameObject.SetActive(false);
                m_victoryMovies[2].gameObject.SetActive(false);
                m_victoryMovies[3].gameObject.SetActive(false);
                break;
        }
    }

    private IEnumerator BackToMain(float time)
    {
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator PauseMe(float time, RawImage image)
    {
        yield return new WaitForSeconds(time);
        MovieTexture movie = (MovieTexture)image.texture;
        movie.Pause();
    }
}
