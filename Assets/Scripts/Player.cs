using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float speedMove = 5;
    [ReadOnly] public float m_speedMove;

    public float speedRot = 30;
    float rot;

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
    }

    void Move()
    {
        float inputX = SimpleInput.GetAxis("Horizontal");

        Vector3 v3 = charController.transform.forward;

        charController.Move(v3 * m_speedMove * Time.deltaTime);
        charController.transform.Rotate(Vector3.up * inputX * 100 * Time.deltaTime);
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
        uiGameplay.speedText.text = "Speed Player : " + m_speedMove.ToString("F1");
    }

    bool rem;
    public void Rem(bool value)
    {
        rem = value;
    }
}
