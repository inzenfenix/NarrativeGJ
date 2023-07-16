using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BoatSystem : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float m_rateTime = 0.1f;
    [SerializeField] float m_strength = 5f;
    private bool moving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 move = PlayerController._Instance.Movement();
        if (!moving && move.magnitude > 0f)
        {
            moving = true;
            StartCoroutine(Moving());
        }
    }

    private IEnumerator Moving()
    {
        while (moving)
        {
            Vector2 move = PlayerController._Instance.Movement();
            rb.AddForce(new Vector3(move.x * m_strength, 0, move.y * m_strength));
            yield return new WaitForSeconds(m_rateTime);
            if (move.magnitude == 0f)
                moving = false;
        }
    }
}
