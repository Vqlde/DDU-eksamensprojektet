using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallakse : MonoBehaviour
{
    public Camera camera;
    public GameObject target;
    public Transform subject;
    Vector2 startPos;
    float startZ;
    private Vector2 previousCamPos;

    Vector2 travel => (Vector2)camera.transform.position - startPos;
    Vector2 parallaxFator;
    float DistanceFromSubject => transform.position.z - subject.position.z;
    float ClippingPlane => (camera.transform.position.z + (DistanceFromSubject > 0 ? camera.farClipPlane : camera.nearClipPlane));

    float parallax => Mathf.Abs(DistanceFromSubject) / ClippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startZ = transform.position.z;
        previousCamPos = camera.transform.position;

        // character indlæsning
        StartCoroutine(StartChar());


    }

    private IEnumerator StartChar()
    {
        yield return new WaitForSeconds(0.1f);
        target = GameObject.FindWithTag("Player");
        subject = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        startPos = camera.transform.position;
        Vector2 newPos = startPos + travel * parallax;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}