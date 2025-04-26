using UnityEngine;

public class DebugLineDrawer : MonoBehaviour
{
	public Transform[] targetPoints;

	private Color[] lineColors;

	void Start()
	{
		// Assign random colors for each target
		lineColors = new Color[targetPoints.Length];
		for (int i = 0; i < targetPoints.Length; i++)
		{
			lineColors[i] = new Color(Random.value, Random.value, Random.value);
		}
	}

	void OnDrawGizmos()
	{
		if (targetPoints == null || targetPoints.Length == 0)
			return;

		// Use black if game not playing (random colors not initialized)
		bool useRandomColors = Application.isPlaying && lineColors != null;

		for (int i = 0; i < targetPoints.Length; i++)
		{
			if (targetPoints[i] != null)
			{
				Gizmos.color = useRandomColors ? lineColors[i] : Color.black;
				Gizmos.DrawLine(transform.position, targetPoints[i].position);
			}
		}
	}
}
