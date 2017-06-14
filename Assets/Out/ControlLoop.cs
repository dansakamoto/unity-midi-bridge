using UnityEngine;
using System.Collections;

public class ControlLoop : MonoBehaviour
{
    public MidiChannel channel = MidiChannel.Ch1;
    public float delay = 2.0f;
    public float length = 0.1f;

    float scale;

    IEnumerator Start ()
    {
        MidiBridge.instance.Warmup();

        if (delay > 0.0f) {
            yield return new WaitForSeconds (delay);
        }

        while (true) {
           // MidiOut.SendNoteOn (channel, noteNumber, velocity);
			MidiOut.SendControlChange(channel, 2, (1+Mathf.Sin(Time.fixedTime))/2f);
			scale = (1+Mathf.Sin(Time.fixedTime))/2f;
            yield return new WaitForSeconds (length);
		
        }
    }

    void Update ()
    {
        transform.localScale = Vector3.one * scale;
    }
}
