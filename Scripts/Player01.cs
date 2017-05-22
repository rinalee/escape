using UnityEngine;
using System.Collections;
using IsoTools;

namespace IsoTools.Examples {
	[RequireComponent(typeof(IsoRigidbody))]
	public class Player01 : MonoBehaviour {
		[Header("Speed & Jump Settings")]

		public float speed = 2.0f;
		public float jumpspeed = 5.0f;
		public IsoRigidbody _isoRigidbody01 = null;

		//animator + velocity
		public Animator playerAnimator;
		float speedAxisX;
		float speedAxisY;
		float lastSpeedAxisX;
		float lastSpeedAxisY;

		void Start() {
			_isoRigidbody01 = GetComponent<IsoRigidbody>();
			if ( !_isoRigidbody01 ) {
				throw new UnityException("PlayerController. IsoRigidbody component not found!");
			}

		}

		void Update () {
			

			if ( Input.GetKey(KeyCode.S) || Input.GetAxisRaw("Vertical") < 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.x = -speed;
				_isoRigidbody01.velocity = velocity;
                //GetComponentInChildren<SpriteRenderer>().flipX = true;
			}
			if ( Input.GetKey(KeyCode.Z) || Input.GetAxisRaw("Vertical") > 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.x = speed;
				_isoRigidbody01.velocity = velocity;
                //GetComponentInChildren<SpriteRenderer>().flipX = false;
			}
			if ( Input.GetKey(KeyCode.D) || Input.GetAxisRaw("Horizontal") > 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.y = -speed;
				_isoRigidbody01.velocity = velocity;
                //GetComponentInChildren<SpriteRenderer>().flipX = false;
			}
			if ( Input.GetKey(KeyCode.Q) || Input.GetAxisRaw("Horizontal") < 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.y = speed;
				_isoRigidbody01.velocity = velocity;
                //GetComponentInChildren<SpriteRenderer>().flipX = true;
			}

			if ( Input.GetKeyUp(KeyCode.S) || Input.GetAxisRaw("Vertical") == 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.x = 0;
				_isoRigidbody01.velocity = velocity;
			}
			if ( Input.GetKeyUp(KeyCode.Z) || Input.GetAxisRaw("Vertical") == 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.x = 0;
				_isoRigidbody01.velocity = velocity;
			}
			if ( Input.GetKeyUp(KeyCode.Q) || Input.GetAxisRaw("Horizontal") == 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.y = 0;
				_isoRigidbody01.velocity = velocity;
			}
			if ( Input.GetKeyUp(KeyCode.D) || Input.GetAxisRaw("Horizontal") == 0) {
				var velocity = _isoRigidbody01.velocity;
				velocity.y = 0;
				_isoRigidbody01.velocity = velocity;
			}

			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton2)) {
				var velocity = _isoRigidbody01.velocity;
				velocity.z = jumpspeed;
				_isoRigidbody01.velocity = velocity;
                playerAnimator.SetTrigger("climb");
            }
				
		}

		void FixedUpdate(){
			speedAxisX = Input.GetAxisRaw ("Horizontal");
			speedAxisY = Input.GetAxisRaw ("Vertical");
			if (speedAxisX != 0f || speedAxisY != 0f) {
				lastSpeedAxisX = speedAxisX;
				lastSpeedAxisY = speedAxisY;
				playerAnimator.SetFloat ("velx", _isoRigidbody01.velocity.x);
				playerAnimator.SetFloat ("vely", _isoRigidbody01.velocity.y);
			} else {
//				print ("speedAxisX " + lastSpeedAxisX);
//				print ("speedAxisY " + lastSpeedAxisY);
				playerAnimator.SetFloat ("velx", Mathf.Clamp(-lastSpeedAxisX,-0.1f,0.1f));
				playerAnimator.SetFloat ("vely", Mathf.Clamp(-lastSpeedAxisY,-0.1f,0.1f));
			}
		}

	}
} // namespace IsoTools.Examples