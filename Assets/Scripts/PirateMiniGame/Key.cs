using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PirateMiniGame
{
    public class Key : MonoBehaviour
    {
        [Range(10000f, 99999f)][SerializeField] private int keyLayout;
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
                t.SetToothValue(keyLayout.ToString()[i]);
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

        private void SetRandomCode()
        {
            keyLayout = Random.Range(10000, 99999);
        }
    }
}
