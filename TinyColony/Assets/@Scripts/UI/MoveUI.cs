using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class MoveUI : UIBase
{
    private RectTransform rectTransform;
    private Vector3 originalScale;
    private Quaternion originalRotation;

    public float scaleMultiplier = 1.2f;
    public float rotationAngle = 10f;
    public float effectDuration = 0.2f;   //회전하는 데 걸리는 시간

    private Coroutine effectCoroutine;

    private AudioSource soundManager;
    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        originalRotation = rectTransform.localRotation;

        gameObject.BindEvent(OnPointerEnter, EUIEvent.PointerEnter);
        gameObject.BindEvent(OnPointerExit, EUIEvent.PointerExit);

        if(soundManager == null)
        {
            soundManager = GameObject.Find("UISoundManager").GetComponent<AudioSource>();
        }
        return true;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        if(effectCoroutine != null)
        {
            StopCoroutine(effectCoroutine);
        }
        float randomAngle = Random.Range(0, 2) == 0 ? -rotationAngle : rotationAngle;

        effectCoroutine = StartCoroutine(EnterAnimateTransform(randomAngle, scaleMultiplier));
        if (soundManager == null)
        {
            soundManager = GameObject.Find("UISoundManager").GetComponent<AudioSource>();
        }
        soundManager.Play();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (effectCoroutine != null)
        {
            StopCoroutine(effectCoroutine);
        }
        effectCoroutine = StartCoroutine(ExitAnimateTransform());
    }
    private IEnumerator EnterAnimateTransform(float targetRotation, float targetScale)
    {
        float elapsedTime = 0;
        Quaternion startRotation = Quaternion.Euler(0, 0, targetRotation);
        rectTransform.localScale = originalScale * targetScale;

        while (elapsedTime < effectDuration)
        {
            rectTransform.localRotation = Quaternion.Lerp(startRotation, originalRotation, elapsedTime / effectDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        rectTransform.localRotation = originalRotation;
    }
    private IEnumerator ExitAnimateTransform()
    {
        float elapsedTime = 0;
        Quaternion currentRotation = rectTransform.localRotation;
        Vector3 currentScale = rectTransform.localScale;
        while (elapsedTime < effectDuration)
        {
            rectTransform.localRotation = Quaternion.Lerp(currentRotation, originalRotation, elapsedTime / effectDuration);
            rectTransform.localScale = Vector3.Lerp(currentScale,originalScale, elapsedTime/effectDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        rectTransform.localRotation = originalRotation;
        rectTransform.localScale = originalScale;
    }
}
