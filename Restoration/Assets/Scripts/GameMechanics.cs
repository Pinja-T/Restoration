using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour
{
    [SerializeField] List<GameObject> Patsaat = new List<GameObject>();
    [SerializeField] HealthCounter healthScript;
    int pL = 0;

    // Start is called before the first frame update
    void Start()
    {
        pL = Patsaat.Count;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (var patsas in Patsaat)
        {
            Statue s = patsas.GetComponent<Statue>();
            if(s.isStatueDone) i++;
            
            
        }
        if (i >= pL) Win();

        if (!healthScript.isAlive) StartCoroutine(Lose());

    }

    void Win()
    {

    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Game");
    }
}
