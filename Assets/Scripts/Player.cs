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

    [Header("Animation")]
    [SerializeField] Animator animator;

    [Header("Effect")]
    [SerializeField] TrailRenderer trail;
    [SerializeField] ParticleSystem particle;

    [Header("Jarak")]
    public float jarakTempuh;

    [Header("Speedometer")]
    public float maxSpeedometer;
    public float minAngleArrow;
    public float maxAngleArrow;
    float speedKMH;

    [Header("Baterai")]
    public float baterai;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        uiGameplay = UIGameplay.instance;

        jarakTempuh = SaveData.instance.gameData.jarakTempuh;
    }


    private void Update()
    {
        Move();
        AkselerasiSpeed();
        RemPC();
        SpeedometerUI();
        JarakTempuh();
    }

    void Move()
    {
        float inputX = SimpleInput.GetAxis("Horizontal");

        Vector3 v3 = charController.transform.forward;

        charController.Move(v3 * m_speedMove / 3.6f * Time.deltaTime);
        charController.transform.Rotate(Vector3.up * inputX * speedRot * Time.deltaTime);

        //Animation
        if (inputX > 0) PlayAnimation("Right");
        else if (inputX < 0) PlayAnimation("Left");
        else PlayAnimation("Forward");

        if (tanpaTrail) return;
        //Trail
        var inputminmax07 = (inputX > 0.7f || inputX < -0.7f);
        if (inputminmax07 && speedKMH > 10 && rem 
            || speedKMH > 15 && rem 
            || inputminmax07 && speedKMH < 2)
        {
            trail.emitting = true;
            var emission = particle.emission;
            emission.rateOverTime = 40;
        }
        else 
        {
            trail.emitting = false;
            var emission = particle.emission;
            emission.rateOverTime = 0;
        }
    }
    void PlayAnimation(string value)
    {
        animator.Play(value);
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

    bool tanpaTrail;
    public void StartRem(float value)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            tanpaTrail = true;
            Rem(true);
            yield return new WaitForSeconds(1);
            tanpaTrail = false;
            Rem(false);
        }
    }


    void SpeedometerUI()
    {
        speedKMH = charController.velocity.magnitude * 3.6f;

        uiGameplay.speedText.text = ((int)speedKMH) + " km/h";
        uiGameplay.arrowRectT.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minAngleArrow, maxAngleArrow, speedKMH / maxSpeedometer));
    }

    void JarakTempuh()
    {
        jarakTempuh += charController.velocity.magnitude * Time.deltaTime / 1000;
        uiGameplay.jarakTempuhText.text = "Total : " + jarakTempuh.ToString("F1") + " km";
        SaveData.instance.gameData.jarakTempuh = jarakTempuh;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    
}
