using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{

    [SerializeField] VoidEventChannel gateTriggeredEventChannel;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVFX;


    private void OnTriggerEnter(Collider other)
    {
        gateTriggeredEventChannel.Broadcast();
        SoundEffectPlayer.AudioSource.PlayOneShot(pickUpSFX);
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
