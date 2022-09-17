using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optimal : MonoBehaviour
{

    private void Update() {
        OnBecameInvisible();
    }
   // If the GameObject will be active or not in out of camera view;
    [SerializeField]
    private bool RunInBackGround = false;
    private void OnBecameVisible() {
        enabled = true;
    }

    private void OnBecameInvisible() {
        if(!RunInBackGround){
            enabled = false;

        }
    }
    //////////////////////////////////////////////////////////
    
}
