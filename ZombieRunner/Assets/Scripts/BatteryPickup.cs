using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    AudioSource audioSource;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip equipSound;

    void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(addIntensity);
            audioSource.clip = equipSound;
            audioSource.Play();
            Invoke("Destroy", 1);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

}
