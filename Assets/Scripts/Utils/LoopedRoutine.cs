using System.Collections;

using Chronos;

using UnityEngine;
using UnityEngine.Events;

public class LoopedRoutine : MonoBehaviour
{
	[SerializeField]
	private float _delay;
	
	[SerializeField]
	private UnityEvent _occured;

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

			yield return new WaitForSeconds(_delay *  Timekeeper.instance.Clock("GameTime").localTimeScale);
		}
	}
}
