using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem dieParticle;

    void PlayParticleSystem()
    {
        ParticleSystem particleSystem = Instantiate(dieParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        particleSystem.Play();
        StartCoroutine(StopParticleSystemCo(particleSystem, 1));
    }

    IEnumerator StopParticleSystemCo(ParticleSystem particleSystem, float time)
    {
        yield return new WaitForSeconds(time);
        particleSystem.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var train = collision.gameObject.GetComponent<RouteSwitch>();
        if (train != null)
        {
            //dieParticle.transform.position = transform.position;
            //dieParticle.Play();
            PlayParticleSystem();
        }
    }
}
