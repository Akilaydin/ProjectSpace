using UnityEngine;

public class PositionCopier : MonoBehaviour
{
	[SerializeField]
	private Transform _objectToCopyPositionFrom;

	public void SetDynamicPosition(Transform objectToCopyPositionFrom)
	{
		_objectToCopyPositionFrom = objectToCopyPositionFrom;
	}

	public void SetPosition(GameObject gameObjectToSetPosition) => SetPosition(gameObjectToSetPosition.transform);

	public void SetPosition(Transform transformToSetPosition)
	{
		transformToSetPosition.transform.position = _objectToCopyPositionFrom.position;
	}
}
