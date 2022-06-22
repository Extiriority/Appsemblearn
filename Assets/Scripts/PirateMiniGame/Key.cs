using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PirateMiniGame
{
    public class Key : MonoBehaviour
    {
        [Range(00000f, 99999f)][SerializeField] private int keyLayout;
        private List<KeyTooth> _teeth;
    
        void Start()
        {
            SetVariables();
        }


        private void SetKeyLayout()
        {
            int i = 0;
            int j = 0;
            foreach (KeyTooth t in _teeth)
            {
                t.SetToothValue(keyLayout.ToString("00000")[i]);
                t.SetToothIndex(j);
                i++;
                j++;
            }
        }

        private void OnValidate()
        {
            SetVariables();
            SetKeyLayout();
        }

        private void SetVariables()
        {
            _teeth = GetComponentsInChildren<KeyTooth>().ToList();
        }

        public void SetRandomCode()
        {
            keyLayout = Random.Range(0, 99999);
            SetKeyLayout();
        }
    }
}
