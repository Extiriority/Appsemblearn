using System;
using UnityEngine;

namespace PirateMiniGame
{
    public class KeyTooth : MonoBehaviour
    {
        private int _value = 1;
        private int _index = 1;
        
        public void SetToothValue(int newValue)
        {
            _value = newValue;
            SetPosition();
        }

        public void SetToothIndex(int newIndex)
        {
            _index = newIndex;
            SetPosition();
        }

        private void SetPosition()
        {
            transform.localPosition = new Vector3(_value*.1f, 0f, _index*.5f);
        }
    }
}
