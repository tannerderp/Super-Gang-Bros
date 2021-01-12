using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunArm : MonoBehaviour
{
    [SerializeField] public int bulletStrength = 1;

    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject target;
    [SerializeField] private AudioClip shotSound;

    private AudioSource audioSource;
    private Ray ray;
    private RaycastHit hit;

    private int shotCooldown = 15;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        shotCooldown++;
        if(Input.GetMouseButton(0) && shotCooldown > 20)
        {
            shotCooldown = 0;
            audioSource.Play();
            ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<HitByBulletSound>())
                {
                    hit.collider.gameObject.GetComponent<HitByBulletSound>().PlayHitSound();
                }
                if (hit.collider.gameObject.GetComponent<EnemyHealthManager>())
                {
                    hit.collider.gameObject.GetComponent<EnemyHealthManager>().LoseHealth(bulletStrength);
                }
            }
        }
    }

    void LateUpdate()
    {
        transform.localRotation = Quaternion.identity;
        hand.transform.localRotation = Quaternion.identity;
        transform.localEulerAngles = new Vector3(10.668f, target.transform.localEulerAngles.x-90, -66.806f);
        hand.transform.localEulerAngles = new Vector3(-6.362f, hand.transform.localEulerAngles.y, -34.413f);
    }
}
