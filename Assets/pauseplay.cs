using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseplay : MonoBehaviour
{

    [SerializeField] Button pause;
    [SerializeField] Button play;
    [SerializeField] playerinfo p;
    [SerializeField] GameObject panel;
    float t = 0.0f;
    public Text oxygen;
    public Text score;
    public Text hscore;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (p.stop)
        {
            t += Time.deltaTime;

            if (t > 0.4f)
            {
                panel.SetActive(true);
                t = 0;
            }
        }
    }
    public void onpause()
    {
        Time.timeScale = 0;
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
    }
    public void onplay()
    {
        Time.timeScale = 1;
        play.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }

    public void replay()
    {
        SceneManager.LoadScene(2);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }
}
