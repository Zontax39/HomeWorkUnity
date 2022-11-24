using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControlls : MonoBehaviour
{
    [SerializeField] float _increamentVolume = 0.1f;
    private AudioSource _alarm;
    private float _volumeTarget;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _alarm.Play();
    }

    public void IncreaseVolume()
    {
        _volumeTarget = 1;
        _alarm.volume = Mathf.MoveTowards(_alarm.volume, _volumeTarget, _increamentVolume * Time.deltaTime);
    }

    public void Stop()
    {
        StartCoroutine(DecrementVolume());
    }

    private IEnumerator DecrementVolume()
    {
        _volumeTarget = 0;
        while (_alarm.volume > 0)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _volumeTarget, _increamentVolume * Time.deltaTime);
            yield return null;
        }
    }
}
