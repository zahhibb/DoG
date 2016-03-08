using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayImage : MonoBehaviour
{
    [SerializeField] private bool m_startOnLoad = false;
    private RawImage m_myImage;
    private MovieTexture m_movie;  

    void Awake()
    {
        m_myImage = gameObject.GetComponent<RawImage>();
        m_movie = (MovieTexture)m_myImage.texture;
        m_movie.loop = true;
        m_movie.Stop();

    }

    void Start()
    {
        if (m_startOnLoad)
        {
            m_movie.Play();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_movie.isPlaying)
            {
                m_movie.Pause();
            }
            else
            {
                m_movie.Play();
            }
        }
    }
    
    public void PlayLoop()
    {
        m_movie.Play();
    }

    public void PauseLoop()
    {
        RawImage r = gameObject.GetComponent<RawImage>();
        MovieTexture movie = (MovieTexture)r.texture;
        movie.loop = true;
    }
}

