using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour {

	private Animator animator;

	//const int countOfDamageAnimations = 3;
	//int lastDamageAnimation = -1;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	public void Stay () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool ("isPushed", false);
		animator.SetFloat ("ClimbSpeed", 0);
		}

	public void Walk () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0.5f);
		animator.SetBool ("isPushed", false);
		animator.SetFloat ("ClimbSpeed", 0);
	}

	public void walkBackwards(){
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", -0.5f);
		animator.SetBool ("isPushed", false);
		animator.SetFloat ("ClimbSpeed", 0);
	}

	public void Run () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 1f);
		animator.SetBool ("isPushed", false);
		animator.SetFloat ("ClimbSpeed", 0);
	}

/*	public void Attack () {
		Aiming ();
		animator.SetTrigger ("Attack");
	}*/

	public void Death () {
			animator.SetTrigger ("Death");
	}

/*	public void Damage () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death")) return;
		int id = Random.Range(0, countOfDamageAnimations);
		if (countOfDamageAnimations > 1)
			while (id == lastDamageAnimation)
				id = Random.Range(0, countOfDamageAnimations);
		lastDamageAnimation = id;
		animator.SetInteger ("DamageID", id);
		animator.SetTrigger ("Damage");
	}*/

	public void Jump () {
		animator.SetBool ("Squat", false);
		animator.SetBool("Aiming", false);
		animator.SetTrigger ("Jump");
		animator.SetBool ("isPushed", false);
		animator.SetFloat ("ClimbSpeed", 0);
	}

/*	public void RunJump () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 1f);
		animator.SetBool("Aiming", false);
		animator.SetTrigger ("Jump");
		animator.SetBool ("isPushed", false);
	}

	public void Aiming () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", true);
	}

	public void Sitting () {
		animator.SetBool ("Squat", !animator.GetBool("Squat"));
		animator.SetBool("Aiming", false);
	}*/

	public void Push()
	{
		animator.SetBool ("isPushed", true);
		animator.SetBool ("Squat", false);
		animator.SetFloat ("ClimbSpeed", 0);
	}

	/*public void Climb(float speed)
	{
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool ("isPushed", false);
		animator.SetFloat ("ClimbSpeed", speed);
	}*/
}
