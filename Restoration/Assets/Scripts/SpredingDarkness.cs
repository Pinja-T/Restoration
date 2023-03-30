using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpredingDarkness : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Lerp(60f));
    }

    IEnumerator Lerp(float duration)
    {
        
        Vector3 startValue = transform.localScale;
        Vector3 endValue = new Vector3(153, 153, 153);
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startValue, endValue, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = endValue;
    }
}
