using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour
{
    [SerializeField] Animator tr;
    [SerializeField] List<GameObject> Patsaat = new List<GameObject>();
    [SerializeField] HealthCounter healthScript;
    [SerializeField] ParticleSystem particles;
    [SerializeField] GameObject _B;
    [SerializeField] GameObject _W;
    [SerializeField] GameObject bwP;
    int pL = 0;
    [HideInInspector]public int i = 0;
    Image B;
    Image W;
    [SerializeField] BoxCollider portal;

    GameObject pE;
    // Start is called before the first frame update
    void Start()
    {
        pE = GameObject.Find("PortalEff");
        pE.SetActive(false);
        bwP.SetActive(true);
        B = _B.GetComponent<Image>();
        W = _W.GetComponent<Image>();
        pL = Patsaat.Count;
        StartCoroutine(FadeFromWhite());
        portal.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (i >= pL) Win();

        if (!healthScript.isAlive) StartCoroutine(Lose());

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Transition());
        }
        
    }
    IEnumerator Transition()
    {
        tr.SetTrigger("Transition");
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Menu");
    }

    void Win()
    {
        Debug.Log("Win");
        if(!particles.isPlaying) particles.Play();
        portal.enabled = true;
        pE.SetActive(true);
    }

    IEnumerator Lose()
    {
        StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Game");
    }
    IEnumerator FadeFromWhite()
    {
        _W.SetActive(true);
        B.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1);
        _B.SetActive(false);
        W.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1);
        _W.SetActive(false);
    }
    IEnumerator FadeToBlack()
    {
        _B.SetActive(true);
        B.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1);
    }
    public IEnumerator FadeToWhite()
    {
        _W.SetActive(true);
        W.CrossFadeAlpha(1, .75f, false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }
}
