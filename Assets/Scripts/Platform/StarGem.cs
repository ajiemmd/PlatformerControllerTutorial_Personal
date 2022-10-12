using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] float resetTime = 3.0f;

    [SerializeField] AudioClip pickUpSFX;

    [SerializeField] ParticleSystem pickUpVFX;

    AudioSource audioSource;

    new Collider collider;

    MeshRenderer meshRenderer;

    WaitForSeconds waitResetTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

            audioSource.PlayOneShot(pickUpSFX);
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
