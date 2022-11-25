using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] AudioControlls _alarm;
    [SerializeField] Animator _animator;
    private int AlarmHash = Animator.StringToHash("Alarm");
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _alarm.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _animator.SetTrigger(AlarmHash);
        _alarm.IncreaseVolume();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _alarm.Stop();
    }
}
