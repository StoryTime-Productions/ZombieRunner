using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
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
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
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
