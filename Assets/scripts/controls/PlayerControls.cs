using UnityEngine;
using System.Collections;

public class PlayerControls: MonoBehaviour
{
		public float speed;
		private Vector3 targetposition;
		private Transform tf;

		public Transform target;
		// Use this for initialization
		void Start ()
		{
				tf = transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Mouse0)) {
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit, 100.0f)) {
								if (hit.collider.tag == "Targetable") {
										target = hit.collider.transform;
										target.renderer.material.color = Color.red;
								} else {
										Plane plane = new Plane (Vector3.up, tf.position);
										float hitdist = 0.0f;
										if (plane.Raycast (ray, out hitdist)) {
												Vector3 target = ray.GetPoint (hitdist);
												targetposition = ray.GetPoint (hitdist);
												Quaternion rotation = Quaternion.LookRotation (target - tf.position);
												transform.rotation = rotation;
										}
								} 
						}
						
				}
				if (Input.GetKeyDown (KeyCode.Mouse1)) { 
						if (target) {
								target.renderer.material.color = Color.white;
								target = null;
						}
				}
				if (Vector3.Distance (tf.position, targetposition) > 0.1f) {
						Debug.Log (Vector3.Distance (tf.position, targetposition));
						tf.position = Vector3.MoveTowards (tf.position, targetposition, Time.deltaTime * speed);
				}
		}
}
