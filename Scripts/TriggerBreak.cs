using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBreak : MonoBehaviour
{
    [SerializeField] private AudioSource breakSource;
    [SerializeField] private AudioClip breakClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            breakSource.PlayOneShot(breakClip);
            Destroy(gameObject);
        }
    }
}
