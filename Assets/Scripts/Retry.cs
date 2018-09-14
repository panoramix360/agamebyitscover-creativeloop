using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour {

    [SerializeField]
    private SceneFader sceneFader;

    private void Start()
    {
        StartCoroutine(PlayGame());
    }

    private IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(6f);
        sceneFader.FadeTo("MainScene");
    }
}
