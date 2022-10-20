using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryGem : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVFX;


    private void OnTriggerEnter(Collider other)
    {
        levelClearedEventChannel.Broadcast();
        SoundEffectPlayer.AudioSource.PlayOneShot(pickUpSFX);
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
