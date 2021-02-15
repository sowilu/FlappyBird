using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birb : MonoBehaviour
{
    public float force;
    public AudioClip crash;
    public float rotation;

    Rigidbody2D rb;
    AudioSource audioSource;
    bool isAlive = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        if (!isAlive) return;

        if (rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
            audioSource.Play();
        }

    }

    private void Update()
    {
        if (rb.velocity.y > 0)
            rb.rotation = rotation;
        else if (rb.velocity.y == 0)
            rb.rotation = 0;
        else
            rb.rotation = -rotation;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.clip = crash;
        audioSource.Play();

        isAlive = false;

        Invoke(nameof(Reload), 0.5f);
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
