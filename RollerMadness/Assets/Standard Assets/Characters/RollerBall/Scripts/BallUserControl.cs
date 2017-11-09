using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball {
	public class BallUserControl: MonoBehaviour {
		private Ball ball; // Reference to the ball controller.

		private Vector3 move;
		// the world-relative desired move direction, calculated from the camForward and user input.

		//private Transform cam; // A reference to the main camera in the scenes transform
		private Vector3 camForward; // The current forward direction of the camera
		private bool jump; // whether the jump button is currently pressed

		private int pos = 0;

		public ConstantForce gravityVector;
		public float gravityScale;

		private void Awake() {
			// Set up the reference.
			ball = GetComponent<Ball>();
		}

		private void Update() {
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Vertical");
			jump = CrossPlatformInputManager.GetButton("Jump");

			switch (pos) {
				case 0:
					move = (v * Vector3.forward + h * Vector3.right).normalized;
					break;

				case 1:
					move = (v * Vector3.up + h * Vector3.right).normalized;
					break;
			}
		}

		private void FixedUpdate() {
			// Call the Move function of the ball controller
			ball.Move(move, jump, this.pos);
			jump = false;
		}

		void OnCollisionEnter(Collision collision) {
			switch (collision.gameObject.tag) {
				case "Chao":
					this.gravityVector.force = Vector3.down * this.gravityScale;
					this.pos = 0;
					break;

				case "Parede":
					this.gravityVector.force = Vector3.forward * this.gravityScale;
					this.pos = 1;
					break;
			}
		}
	}
}
