using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTimer : MonoBehaviour
{
    [SerializeField] Text timeText;

    [SerializeField] VoidEventChannel levelStartedEventChannel;
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] StringEventChannel clearTimeTextEventChannel;
    [SerializeField] VoidEventChannel playerDefeatedEventChannel;


    bool stop = true;

    float clearTime;

    private void OnEnable()
    {
        levelStartedEventChannel.AddListener(LevelStart);
        levelClearedEventChannel.AddListener(LevelClear);
        playerDefeatedEventChannel.AddListener(HideUI);
    }

    private void OnDisable()
    {
        levelStartedEventChannel.RemoveListener(LevelStart);
        levelClearedEventChannel.RemoveListener(LevelClear);
        playerDefeatedEventChannel.RemoveListener(HideUI);
    }

    private void FixedUpdate()
    {
        if (stop) return;

        clearTime += Time.fixedDeltaTime;
        timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }

    private void LevelStart()
    {
        stop = false;
    }


    private void LevelClear()
    {
        HideUI();
        clearTimeTextEventChannel.Broadcast(timeText.text);
    }
   
    void HideUI()
    {
        stop = true;
        GetComponent<Canvas>().enabled = false;
    }

}
