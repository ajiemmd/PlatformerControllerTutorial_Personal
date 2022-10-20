using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBall : MonoBehaviour
{
    [SerializeField] VoidEventChannel GateTriggerEventChannel;
    [SerializeField] float lifeTime = 7;

    private void OnEnable()
    {
        GateTriggerEventChannel.AddListener(OnGateTriggerd);
    }

    private void OnDisable()
    {
        GateTriggerEventChannel.RemoveListener(OnGateTriggerd);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.OnDefeated();
        }
    }

    void OnGateTriggerd()
    {
        Destroy(gameObject, lifeTime);
    }
}
