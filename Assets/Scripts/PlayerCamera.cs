using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        StartCoroutine(StartChar());

    }
    private IEnumerator StartChar() {
        yield return new WaitForSeconds(0.1f);
        target = GameObject.FindWithTag("Player");
        if (target == null) {
            Debug.Log("Target blev ikke fundet!");
        } else {
            Debug.Log("Fandt" + target.name);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 25f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }
}