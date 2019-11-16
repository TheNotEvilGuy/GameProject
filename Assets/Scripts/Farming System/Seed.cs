using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public Sprite seed;
    public Sprite initial;
    public Sprite second;
    public Sprite full;
    public float growthTime = 2f;
    [HideInInspector]
    public bool planted = false;

    private void Update()
    {
        if (planted)
        {
            StartCoroutine(Grow());
            planted = false;
        }
    }

    private IEnumerator Grow() //"Types" the dialogue lines letter by letter
    {
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        GetComponent<SpriteRenderer>().sprite = initial;
        yield return new WaitForSeconds(growthTime);
        GetComponent<SpriteRenderer>().sprite = second;
        yield return new WaitForSeconds(growthTime);
        GetComponent<SpriteRenderer>().sprite = full;
    }
}
