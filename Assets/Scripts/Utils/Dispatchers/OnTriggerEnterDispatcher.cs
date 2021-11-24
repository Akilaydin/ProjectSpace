using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterDispatcher : MonoBehaviour
{
	[SerializeField]
	private UnityGameObjectEvent _entered;

	private void OnTriggerEnter2D(Collider2D other)
	{
		_entered?.Invoke(other.gameObject);
	}
}
