using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public float powerUpStrength = 10;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    private bool hasPowerup = false;
    public float powerupDuration=5.0f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {   
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position=transform.position+new Vector3(0,-0.3f,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
          other.gameObject.SetActive(false);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(powerupDuration);
        hasPowerup=false;
                    powerupIndicator.SetActive(false);

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFormPlayer = other.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFormPlayer.normalized * powerUpStrength, ForceMode.Impulse);
        }

    }
}
