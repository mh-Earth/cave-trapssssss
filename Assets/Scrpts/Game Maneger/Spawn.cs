using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    private void Awake() {

        Instantiate(player,transform.position,Quaternion.identity);


    }

}
