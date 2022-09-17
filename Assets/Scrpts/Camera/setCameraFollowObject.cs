using UnityEngine;
using Cinemachine;
public class setCameraFollowObject : MonoBehaviour
{
    // Start is called before the first frame update

    private CinemachineVirtualCamera cinemachine;
    private GameObject player;
    private void Start() {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
        cinemachine.Follow = player.transform;
        cinemachine.LookAt = player.transform;
    }


}
