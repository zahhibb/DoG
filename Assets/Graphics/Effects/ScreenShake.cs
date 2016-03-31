using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
	// Transform of the camera to shake

	[SerializeField] private Transform m_cameraTransform;

	// Duration of the shake.
	[SerializeField] private float m_shakeDuration = 0f;


	// Amplitude of the shake. A larger value shakes the camera harder.
	[SerializeField] private float m_shakeAmount = 0.7f;
	[SerializeField] private float m_decrease = 1.0f;

	private Vector3 m_originalPos;

	void Awake()
	{

	// If no camera is assigned try and grab own transform
		if (m_cameraTransform == null)
		{
			m_cameraTransform = GetComponent<Transform> ();
		}
	}

	void OnEnable()
	{
		m_originalPos = m_cameraTransform.localPosition;
	}

	void Update()
	{
		if (m_shakeDuration > 0)
		{
			m_cameraTransform.localPosition = m_originalPos + Random.insideUnitSphere * m_shakeAmount;
			m_shakeDuration -= Time.deltaTime * m_decrease;
		}
		else
		{
			m_shakeDuration = 0f;
			m_cameraTransform.localPosition = m_originalPos;
		}
	}

	public void shake(float duration, float shakeAmount){
		m_originalPos = m_cameraTransform.localPosition;
		m_shakeDuration = duration;
		m_shakeAmount = shakeAmount;

	}
}

