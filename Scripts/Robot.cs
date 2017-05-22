using UnityEngine;
using System.Collections;
using IsoTools;

namespace IsoTools.Examples
{
    [RequireComponent(typeof(IsoRigidbody))]
    public class Robot : MonoBehaviour
    {
        [Header("Speed & Jump Settings")]

        public float speed = 2.0f;
        public float jumpspeed = 5.0f;
        public IsoRigidbody _isoRigidbodyRobot = null;

        //animator + velocity
        public Animator robotAnimator;
        float speedAxisX;
        float speedAxisY;
        float lastSpeedAxisX;
        float lastSpeedAxisY;

        void Start()
        {
            _isoRigidbodyRobot = GetComponent<IsoRigidbody>();
            if (!_isoRigidbodyRobot)
            {
                throw new UnityException("PlayerController. IsoRigidbody component not found!");
            }

        }

        void Update()
        {
        }

        void FixedUpdate()
        {
            speedAxisX = Input.GetAxisRaw("Horizontal");
            speedAxisY = Input.GetAxisRaw("Vertical");
            if (speedAxisX != 0f || speedAxisY != 0f)
            {
                lastSpeedAxisX = speedAxisX;
                lastSpeedAxisY = speedAxisY;
                robotAnimator.SetFloat("velx", _isoRigidbodyRobot.velocity.x);
                robotAnimator.SetFloat("vely", _isoRigidbodyRobot.velocity.y);
            }
            else
            {
                //				print ("speedAxisX " + lastSpeedAxisX);
                //				print ("speedAxisY " + lastSpeedAxisY);
                robotAnimator.SetFloat("velx", Mathf.Clamp(-lastSpeedAxisX, -0.1f, 0.1f));
                robotAnimator.SetFloat("vely", Mathf.Clamp(-lastSpeedAxisY, -0.1f, 0.1f));
            }
        }

    }
} // namespace IsoTools.Examples
