using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 1000;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(horizontal, 0 , vertical) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("CheckPoint")) return;
        GameManager._instance.SetCheckPoint(other.gameObject);

    }
}
