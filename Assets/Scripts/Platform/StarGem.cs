using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] float resetTime = 3.0f;

    [SerializeField] AudioClip pickUpSFX;

    [SerializeField] ParticleSystem pickUpVFX;

    new Collider collider;

    MeshRenderer meshRenderer;

    WaitForSeconds waitResetTime;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        waitResetTime = new WaitForSeconds(resetTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.CanAirJump = true;

            collider.enabled = false;
            meshRenderer.enabled = false;

            SoundEffectPlayer.AudioSource.PlayOneShot(pickUpSFX);
            Instantiate(pickUpVFX, transform.position, transform.rotation);

            StartCoroutine(ResetCoroutine());
            //Invoke(nameof(Reset), resetTime);//协程或者Invoke()方法都行

        }
    }

    private void Reset()
    {
        collider.enabled = true;
        meshRenderer.enabled = true;
    }

    IEnumerator ResetCoroutine()
    {
        yield return waitResetTime;

        Reset();
    }

}
