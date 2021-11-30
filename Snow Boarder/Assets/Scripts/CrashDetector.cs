using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashedEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && hasCrashed == false)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashedEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
