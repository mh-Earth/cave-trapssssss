using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystems;

    public  void play(){

        particleSystems.Play();
        


    }

}
