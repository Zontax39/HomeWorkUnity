using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioControlls _alarm;
    private Color _colorAlarmHead;
    private Animator _animator;
    
    private void Awake()
    {
        GameObject alarmHead = GameObject.Find("AlarmHead");
        _alarm = alarmHead.GetComponent<AudioControlls>();
        _animator = alarmHead.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _alarm.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _animator.SetTrigger("Alarm");
        _alarm.IncreaseVolume();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _alarm.Stop();
    }
}
