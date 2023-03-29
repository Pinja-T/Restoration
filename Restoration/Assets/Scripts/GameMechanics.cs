using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        bwP.SetActive(true);
        B = _B.GetComponent<Image>();
        W = _W.GetComponent<Image>();
        pL = Patsaat.Count;
        StartCoroutine(FadeFromWhite());
    }

    // Update is called once per frame
    void Update()
    {
        if (i >= pL) Win();

        if (!healthScript.isAlive) StartCoroutine(Lose());

    }

    void Win()
    {
        Debug.Log("Win");
        particles.Play();
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
}
