using System.Collections;
using UnityEngine;

public class ShakeCamera : MonoBehaviour { 

    public static ShakeCamera Instance {get;private set;}
    public AnimationCurve curve;
    public float duration = 1f;


    public IEnumerator shaking(float duration, AnimationCurve shakingCurve) { 
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }


}