using UnityEngine;

namespace RRJJ.EventManager.Example
{
    public class Example : MonoBehaviour
    {
        private void Awake()
        {
            EventManager.Subscribe<OnExampleSignal>(Callback);
        }

        private void Callback(OnExampleSignal args)
        {
            Debug.Log($"{args.Text}");
            EventManager.Unsubscribe<OnExampleSignal>(Callback);
        }
    }
}
