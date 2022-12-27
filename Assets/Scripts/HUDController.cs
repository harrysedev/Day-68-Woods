using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ItemPickupText;
    public int day;
    public TextMeshProUGUI text;
    public float fadeInTime = 5;
    public float fadeOutTime = 3;
    public float currentAlpha;
    public IEnumerator coroutine;
    public GameObject screen;
    public Image image;
    public Campfire campfire;
    public float currentImageAlpha;
    void Start()
    {
        ItemPickupText.SetActive(false);
        day = GameData.GetIntValue("day");
        if (day == 0)
        {
            day = 68;
        }
        text.text = "DAY " + day.ToString();
        currentAlpha = text.color.a;
        coroutine = FadeText();
        StartCoroutine(coroutine);
        image = screen.GetComponent<Image>();
        currentImageAlpha = 0.0f;
    }

    private void Update()
    {
        if (campfire.nearCampFire)
        {
            currentImageAlpha = 0.0f;
        } else
        {
            currentImageAlpha += Time.deltaTime / (float)campfire.secondsToDeath;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentImageAlpha);
    }

    IEnumerator FadeText()
    {
        while (currentAlpha < 1)
        {
            currentAlpha += Time.deltaTime / fadeInTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);
            yield return null;
        }

        while (currentAlpha > 0)
        {
            currentAlpha -= Time.deltaTime / fadeInTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);
            yield return null;
        }
    }
}
