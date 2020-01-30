using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float walkSpeed = 2f;
    public float runSpeed = 6f;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    Transform cameraT;

    Animator TheAnim;
    // Start is called before the first frame update
    void Start()
    {
        TheAnim = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float correctorH = Input.GetAxis("Horizontal");
        float correctorV = Input.GetAxis("Vertical");

        if (correctorV < 0f)
        {
            correctorV *= -1;
        }

        if (correctorH < 0f)
        {
            correctorH *= -1;
        }

        float corrector = correctorH + correctorV;
        corrector = Mathf.Clamp(corrector, 0f, 1f);

        if (corrector < 0f)
        {
            corrector *= -1;
        }

        TheAnim.SetFloat("MoveSpeed", corrector);

        if (TheAnim.GetFloat("MoveSpeed") == 0)
        {
            TheAnim.SetBool("isMoving", false);
        }
        else
        {
            TheAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TheAnim.SetBool("Sprint", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            TheAnim.SetBool("Sprint", false);
        }

    }
}
