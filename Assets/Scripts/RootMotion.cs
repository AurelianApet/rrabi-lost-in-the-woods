using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class RootMotion : MonoBehaviour {
	
	void OnAnimatorMove()
	{
		Animator animator = GetComponent<Animator>(); 
		//animator.state
		if(animator)
		{
			Vector3 newPosition = transform.position;


			if(transform.rotation.eulerAngles.y > 260){
				newPosition.x -= animator.GetFloat("walkSpeed") * Time.deltaTime; 
				transform.position = newPosition;
			}else{
				newPosition.x += animator.GetFloat("walkSpeed") * Time.deltaTime; 
				transform.position = newPosition;
			}
		}
	}
}
