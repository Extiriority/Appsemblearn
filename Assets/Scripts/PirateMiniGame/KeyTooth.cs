using UnityEngine;

namespace PirateMiniGame
{
    public class KeyTooth : MonoBehaviour
    {
        [Range(1, 5)] private int _toothValue = 5;

        public void SetKeyValue(int newValue)
        {
            _toothValue = newValue;
            transform.localPosition = new Vector3(_toothValue, 0f, 0f);
        }
    }
}
