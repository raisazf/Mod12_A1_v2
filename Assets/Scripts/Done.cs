using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done : MonoBehaviour
{

    public ParticleSystem confetti;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            confetti.gameObject.SetActive(true);
        }
    }
}
