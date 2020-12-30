using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    [SerializeField] private float zoom = -15;
    [SerializeField] private float zoomChangeAmount = 0.1f;

    private float mouseX = 0.0f;
    private float mouseY = 0.0f;
    private Vector3 originalTargetPos;
    private Vector3 originalCameraPos;
    private bool aiming = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;
    [SerializeField] private GunArm gunArm;
    [SerializeField] private GameObject gun;
    private Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        gunArm.enabled = false;
        originalTargetPos = target.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //camera rotation
        mouseX += speedH * Input.GetAxis("Mouse X");
        mouseY -= speedV * Input.GetAxis("Mouse Y");

        transform.LookAt(target.transform);
        target.transform.rotation = Quaternion.Euler(Mathf.Clamp(mouseY, -50, 55), mouseX-90, 0);
        if (playerAnimator.GetFloat("Speed") > 0.1 || aiming)
        {
            player.transform.rotation = Quaternion.Euler(0, mouseX, 0);
        }

        //camera zoom
        if (!aiming)
        {
            if (Input.mouseScrollDelta.y > 0 && zoom > -16.02931f)
            {
                zoom -= zoomChangeAmount * Input.mouseScrollDelta.y;
                transform.position -= -transform.forward * zoomChangeAmount * Input.mouseScrollDelta.y;
            }
            if (Input.mouseScrollDelta.y < 0 && zoom < -11.9059f)
            {
                zoom -= zoomChangeAmount * Input.mouseScrollDelta.y;
                transform.position += -transform.forward * zoomChangeAmount * -Input.mouseScrollDelta.y;
            }
        }
        zoom = Mathf.Clamp(zoom, -16.08931f, -11.9059f);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -Mathf.Infinity, 0), transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, -Mathf.Infinity, 0));

        //aiming mode
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            originalCameraPos = transform.localPosition;
            transform.position = player.transform.position - transform.forward * 2;
            target.transform.position += transform.right * 0.5f;
            gunArm.enabled = true;
            gun.SetActive(true);
            aiming = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            target.transform.localPosition = originalTargetPos;
            gunArm.enabled = false;
            gun.SetActive(false);
            aiming = false;
            transform.localPosition = originalCameraPos;
        }
        if (aiming)
        {
            target.transform.position = player.transform.position;
            target.transform.position = gameObject.transform.parent.TransformPoint(originalTargetPos) + transform.right * 0.5f;
        }

    }
}
