using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float speedMove = 5;
    [ReadOnly] public float m_speedMove;

    public float speedRot = 100;

    [SerializeField] CharacterController charController;
    UIGameplay uiGameplay;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        uiGameplay = UIGameplay.instance;
    }


    private void Update()
    {
        Move();
        AkselerasiSpeed();
        RemPC();
    }

    void Move()
    {
        float inputX = SimpleInput.GetAxis("Horizontal");

        Vector3 v3 = charController.transform.forward;

        charController.Move(v3 * m_speedMove * Time.deltaTime);
        charController.transform.Rotate(Vector3.up * inputX * speedRot * Time.deltaTime);
    }


    void AkselerasiSpeed()
    {
        if (rem)
        {
            m_speedMove = Mathf.Lerp(m_speedMove, 0, 1 * Time.deltaTime);
        }
        else 
        {
            m_speedMove = Mathf.Lerp(m_speedMove, speedMove, 0.1f * Time.deltaTime);
        }

        float speedKMH = charController.velocity.magnitude * 3.6f;
        uiGameplay.speedText.text = "Kecepatan Player : " + speedKMH.ToString("F1") + " km/h";
    }

    bool rem;
    public void Rem(bool value)
    {
        rem = value;
    }
    public void RemPC()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rem = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rem = false;
        }
    }
}
