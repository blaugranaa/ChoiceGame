using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] GameObject dieParticle;
    

    private void OnEnable()
    {
        EventManager.OnCharacterDie.AddListener(() => Instantiate(dieParticle, transform.position, Quaternion.identity));
        //EventManager.OnCharacterDie.AddListener(SpawnParticleSystem);
    }
    private void OnDisable()
    {
        EventManager.OnCharacterDie.RemoveListener(() => Instantiate(dieParticle, transform.position, Quaternion.identity));
        //EventManager.OnCharacterDie.RemoveListener(SpawnParticleSystem);
    }



    void SpawnDieParticle()
    { }
    void SpawnParticleSystem()
    {
        ParticleSystem particleSystem = Instantiate(dieParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        particleSystem.Play();
        StartCoroutine(StopParticleSystem(particleSystem, 1));
    }

    IEnumerator StopParticleSystem(ParticleSystem particleSystem, float time)
    {
        yield return new WaitForSeconds(time);
        particleSystem.Stop();
    }
}
