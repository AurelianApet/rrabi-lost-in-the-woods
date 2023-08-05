using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class SpiderActions : MonoBehaviour {

	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	public void walk(){
		animator.SetBool ("Jump", false);
		animator.SetBool ("death", false);
		animator.SetBool ("Attack", false);
		animator.SetFloat ("walkSpeed", 2f);
	}

	public void walkBackwards(){
		animator.SetBool ("Jump", false);
		animator.SetBool ("death", false);
		animator.SetBool ("Attack", false);
		animator.SetFloat ("walkSpeed", -1f);
	}

	public void jump(){
		animator.SetBool ("Jump", true);
		animator.SetBool ("death", false);
		animator.SetBool ("Attack", false);
		animator.SetFloat ("walkSpeed", 2f);
	}

	public void die(){
		animator.SetBool ("death", true);
		animator.SetBool ("Jump", false);
		animator.SetBool ("Attack", false);
		animator.SetFloat ("walkSpeed", 0f);
	}

	public void attack(){
		animator.SetBool ("Jump", false);
		animator.SetBool ("death", false);
		animator.SetFloat ("walkSpeed", 0f);
		animator.SetBool ("Attack", true);
	}

	public void stay()
	{
		animator.SetBool ("Jump", false);
		animator.SetBool ("death", false);
		animator.SetBool ("Attack", false);
		animator.SetFloat ("walkSpeed", 0f);

		}
}
