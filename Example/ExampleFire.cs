using UnityEngine;

namespace RRJJ.EventManager.Example
{
    public class ExampleFire : MonoBehaviour
    {
        private void Start()
        {
            string text = "Event fire example";
            EventManager.FireEvent(new OnExampleSignal(text));
        }
    }
}