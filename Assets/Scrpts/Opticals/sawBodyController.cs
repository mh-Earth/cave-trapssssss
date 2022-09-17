using UnityEngine;

public class sawBodyController : MonoBehaviour
{

    [SerializeField]
    private GameObject saw;

    private void Update() {
        OnBecameInvisible();
    }

    private bool RunInBackGround = false;
    private void OnBecameVisible() {
        saw.SetActive(true);
    }

    private void OnBecameInvisible() {
        if(!RunInBackGround){
            saw.SetActive(false);
            

        }
    }
    //////////////////////////////////////////////////////////

}
