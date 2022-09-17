using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spanwObj;

    private Transform spawnPoint;

    [SerializeField]
    private GameObject webPrefabs;

    [SerializeField]
    private float minShotWaitTime = 1f , maxShotWaitTime = 3f;

    private float waitTime;

    private void Awake()
    {
        spawnPoint = spanwObj.GetComponent<Transform>();
    }

    private void Start() {
        waitTime = Time.time + Random.Range(minShotWaitTime,maxShotWaitTime);
        OnBecameInvisible();
    }



    private void Update() {
            if(Time.time > waitTime){
                shoot();
                waitTime = Time.time + Random.Range(minShotWaitTime,maxShotWaitTime);
            }

    }
    void shoot(){

         Instantiate(webPrefabs,spawnPoint.position,Quaternion.identity);

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
