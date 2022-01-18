using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class PlayerScript : MonoBehaviour
{
    public GameObject particles;
    public GameObject deathMenu;

    public AudioClip JumpAudio;
    public AudioClip ImpactAudio;

    private InputManager inputManager;
    private Rigidbody2D rb;
    private AudioSource AudioSrc;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        deathMenu.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        AudioSrc = GetComponent<AudioSource>();
        inputManager = GetComponent<InputManager>();
        dead = false;

        AudioSrc.clip = JumpAudio;
    }

    private void Update()
    {
        
        if (inputManager.jumpKeyboard || inputManager.jumpAndroid)
        {
            AudioSrc.Play();
        }
    }

    public void die()
    {
        if (!dead)
        {
            dead = true;

            AudioSrc.clip = ImpactAudio;
            AudioSrc.Play();

            Destroy(this.GetComponent<Movement>());

            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddForce(rb.velocity * -60, ForceMode2D.Impulse);

            Instantiate(particles, transform.position, Quaternion.identity);

            StartCoroutine("stopTime");

            PointsManager pointsManager = FindObjectOfType<PointsManager>();

            pointsManager.saveHighScore();
            pointsManager.saveCurrency();

        }
    }

    IEnumerator stopTime()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        deathMenu.SetActive(true);
    }

}
