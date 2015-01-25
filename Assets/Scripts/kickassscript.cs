using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class kickassscript : MonoBehaviour
{
    public Image KickassImage;
    public Image WhatDowWeDoNowImage;

    public AudioSource a;
    public AudioSource b;

	void Start () {

        a = GameObject.Find("abc").GetComponent<AudioSource>();
        b = GameObject.Find("cde").GetComponent<AudioSource>();
        StartCoroutine(CrossFade(KickassImage,WhatDowWeDoNowImage ,1f, 0));
	}

    private IEnumerator CrossFade(Image KickassImage, Image WhatDowWeDoNowImage, float fadeFor, float delayFor)
    {
        a.Play();

        float time = 0;
        while (time <= fadeFor)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;

            // fade in
            var c2 = WhatDowWeDoNowImage.color;
            c2.a = Mathf.Lerp(0, 1, Easing.Ease(Easing.Type.SinusoidalEaseIn, time));
            WhatDowWeDoNowImage.color = c2;
        }

        yield return new WaitForSeconds(1f);

    

        time = 0;
        while (time <= fadeFor)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;

            // fade in
            var c2 = KickassImage.color;
            c2.a = Mathf.Lerp(0, 1, Easing.Ease(Easing.Type.SinusoidalEaseIn, time));
            KickassImage.color = c2;
        }


        Vector3 scale = KickassImage.rectTransform.localScale;
        b.Play();
        time = 0;
        while (time <= fadeFor)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;

            // fade in
            KickassImage.rectTransform.localScale = new Vector3(
                Mathf.Lerp(scale.x, .58f, Easing.Ease(Easing.Type.BounceEaseInOut, time)),
                Mathf.Lerp(scale.y, .58f, Easing.Ease(Easing.Type.BounceEaseInOut, time)),
                Mathf.Lerp(scale.z,.58f, Easing.Ease(Easing.Type.BounceEaseInOut, time))
            );
        }

        yield return new WaitForSeconds(.3f);

        time = 0;
        while (time <= fadeFor)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;

            // fade in
            var c2 = WhatDowWeDoNowImage.color;
            c2.a = Mathf.Lerp(1, 0, Easing.Ease(Easing.Type.SinusoidalEaseIn, time));
            WhatDowWeDoNowImage.color = c2;

            var c3 = KickassImage.color;
            c3.a = Mathf.Lerp(1, 0, Easing.Ease(Easing.Type.SinusoidalEaseIn, time));
            WhatDowWeDoNowImage.color = c3;
        }

        Destroy(KickassImage.gameObject);
        Destroy(WhatDowWeDoNowImage.gameObject);

    }
    public static void SetSize(RectTransform trans, Vector2 newSize)
    {
        Vector2 oldSize = trans.rect.size;
        Vector2 deltaSize = newSize - oldSize;
        trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
    }
}
