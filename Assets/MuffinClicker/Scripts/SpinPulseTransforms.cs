using UnityEngine;
/// <summary>
///4. Spin the transform animation.
/// 5. Scale transform animation.
/// </summary>
public class SpinPulseTransforms : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spinLights;

    [SerializeField]
    private float[] _spinSpeeds;

    [SerializeField]
    private float _waveSpeed = 0, _waveAmplitude = 0, _waveOffset = 0;

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < _spinLights.Length; i++)
        {
            //rotate
            Vector3 rotation = new Vector3();
            rotation.z = _spinSpeeds[i] * Time.deltaTime;

            _spinLights[i].Rotate(rotation);

            //wave
            float wave = Mathf.Sin(Time.time + _waveSpeed) * _waveAmplitude + _waveOffset;
            Vector3 wavescale = new Vector3(wave, wave, wave);
            _spinLights[i].localScale = wavescale;

            //Debug.Log(Time.time); time start from 0
            //Debug.Log(Mathf.Sin(Time.time)); continuous oscillating between 0-1
            //RandomNumber rnd = new RandomNumber();//ctrl shift space
        }
    }
}
