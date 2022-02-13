using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using Chronos;

public class LoopedRoutine : MonoBehaviour
{
	[SerializeField]
	private float _delay;

	[SerializeField]
	private UnityEvent _occured;

	private bool _isStopped;

	private Coroutine _coroutine; 

	public void Begin()
	{
		_isStopped = false;

		if (_coroutine==null)
        {
			_coroutine = StartCoroutine(IncreaseRoutine());
		}
	}

	public void Stop()
	{
		_isStopped = true;
		
		StopCoroutine(IncreaseRoutine());

		_coroutine = null;
	}

	private IEnumerator IncreaseRoutine()
	{
		while (_isStopped == false)
		{
			_occured?.Invoke();
			
			 yield return new WaitForSeconds(_delay *  Timekeeper.instance.Clock("GameTime").localTimeScale);
			//_timeline.WaitForSeconds(_delay);
		}
		
		yield break;
	}
}
