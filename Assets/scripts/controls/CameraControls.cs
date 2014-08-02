using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
		public Transform target;

		private Transform tf;
		// Use this for initialization
		void Start ()
		{
				tf = transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				tf.position = new Vector3 (target.position.x, target.position.y + 5, target.position.z - 10);
		}
}
