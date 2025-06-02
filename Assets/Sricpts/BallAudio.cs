using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class BallAudio : MonoBehaviour
{
    private AudioSource ballAudio;

    private void Start()
    {
        ballAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballAudio.Play();
            Debug.Log("Audio Play");
        }
    }
}
