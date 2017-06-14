using UnityEngine;
using System.Collections;

public class ControlLoop : MonoBehaviour
{
    public MidiChannel channel = MidiChannel.Ch1;
    public int noteNumber = 48;
    public float velocity = 0.9f;
    public float delay = 2.0f;
    public float length = 0.1f;
    public float interval = 1.0f;

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
           // MidiOut.SendNoteOff (channel, noteNumber);
            //yield return new WaitForSeconds (interval - length);




        }
    }

    void Update ()
    {
       // scale = 1.0f - (1.0f - scale) * Mathf.Exp (Time.deltaTime * -4.0f);
        transform.localScale = Vector3.one * scale;
    }
}
