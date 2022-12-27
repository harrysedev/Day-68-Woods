using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTrigger : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject screen;
    public Image image;
    public float fadeInTime;
    public float currentAlpha;

    private void Start()
    {
        fadeInTime = 4;
        image = screen.GetComponent<Image>();
        currentAlpha = image.color.a;
        if (GameData.GetIntValue("JustLoaded") == 1)
        {
            currentAlpha = 1.0f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
            StartCoroutine(FadeIn());
            GameData.ResetTrack();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Fade());
        }
    }

    private void Update()
    {
        if (currentAlpha >= 1.0)
        {
            GameData.SaveCoords(0.0f, 0.0f, 0.0f);
            GameData.AddDay();
            GameData.Track();
            sceneLoader.LoadSceneByName("game");
        }
    }

    IEnumerator Fade()
    {
        while (currentAlpha < 1)
        {
            currentAlpha += Time.deltaTime / fadeInTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        while (currentAlpha > 0)
        {
            currentAlpha -= Time.deltaTime / fadeInTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
            yield return null;
        }
    }
}
