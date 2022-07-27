using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerable Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float ellapsed = 0f;
        while(ellapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            ellapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
