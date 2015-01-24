using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image TeamImage;
    public Image LogoImage;
    public float Delay;
    public float FadeTime;
    public Button StartButton;

	void Start ()
	{
	    StartCoroutine(CrossFade(TeamImage, LogoImage, FadeTime, Delay));
	}

    private IEnumerator CrossFade(Image startImage, Image endImage, float fadeFor, float delayFor)
    {
        yield return new WaitForSeconds(delayFor);

        float time = 0;
        while (time <= fadeFor)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;

            // fade out
            var c1 = startImage.color;
            c1.a = Mathf.Lerp(1, 0, Easing.Ease(Easing.Type.SinusoidalEaseIn, time));
            startImage.color = c1;

            // fade in
            var c2 = endImage.color;
            c2.a = Mathf.Lerp(0, 1, Easing.Ease(Easing.Type.SinusoidalEaseIn, time));
            endImage.color = c2;

            var c3 = StartButton.image.color;
            c3.a = Mathf.Lerp(0, .5f, Easing.Ease(Easing.Type.SinusoidalEaseIn, time));
            StartButton.image.color = c3;
        }
    }

    public void LoadLevel(string levelId)
    {
        StartCoroutine(WaitForAudioSource(Sounds.Shared.StartButton.Instantiate().GetComponent<AudioSource>(), ()=> Application.LoadLevel(levelId)));
    }

    public IEnumerator WaitForAudioSource(AudioSource clip, Action action)
    {
        while (clip.isPlaying)
            yield return new WaitForEndOfFrame();

        action();
    }
}
