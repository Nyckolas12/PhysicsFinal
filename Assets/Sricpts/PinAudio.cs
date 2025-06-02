using UnityEngine;

public class PinAudio : MonoBehaviour
{
    public AudioSource pinsAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            pinsAudio.Play();
        }
    }
}
