using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using Chronos;

[RequireComponent(typeof(Timeline))]
public class LoopedRoutine : MonoBehaviour
{
	[SerializeField]
	private float _delay;
	
	[SerializeField]
	private UnityEvent _occured;

	private Timeline _timeline;

	private bool _isStopped;
	
	private void Awake()
	{
		_timeline = GetComponent<Timeline>();
	}

	public void Begin()
	{
		_isStopped = false;
		
		StartCoroutine(IncreaseRoutine());
	}

	public void Stop()
	{
		_isStopped = true;
		
		StopCoroutine(IncreaseRoutine());
	}

	private IEnumerator IncreaseRoutine()
	{
		while (_isStopped == false)
		{
			_occured?.Invoke();
			
			// yield return new WaitForSeconds(_delay *  Timekeeper.instance.Clock("GameTime").localTimeScale);
			_timeline.WaitForSeconds(_delay);
		}
		
		yield break;
	}
}
