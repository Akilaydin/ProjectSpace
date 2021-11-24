using System.Collections;

using UnityEngine;
using UnityEngine.Events;

public class LoopedRoutine : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _occured;

	[SerializeField]
	private float _delay;
	
	private WaitForSeconds _waiter;
	
	private void Awake()
	{
		_waiter = new WaitForSeconds(_delay);
	}

	public void Begin()
	{
		StartCoroutine(IncreaseRoutine());
	}

	public void Stop()
	{
		StopCoroutine(IncreaseRoutine());
	}

	private IEnumerator IncreaseRoutine()
	{
		while (true)
		{
			_occured?.Invoke();

			yield return _waiter;
		}
	}
}
