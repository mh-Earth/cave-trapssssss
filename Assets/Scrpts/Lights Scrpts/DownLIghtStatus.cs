using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class DownLIghtStatus : MonoBehaviour
{

    private Light2D downLight;
    private void Start() {
        downLight = GetComponent<Light2D>();

    }


    private void OnBecameVisible() {
       downLight.enabled = true;
    }
    private void OnBecameInvisible() {
        downLight.enabled = false;
    }
    
}
