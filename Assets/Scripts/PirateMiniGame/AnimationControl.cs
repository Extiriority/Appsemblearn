using UnityEngine;

namespace PirateMiniGame
{
    [RequireComponent(typeof(Animator))]
    public class AnimationControl : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed = 1f;
        private Animator _animator;
        
        void Start()
        {
            _animator = GetComponent<Animator>();
            PauseAnimation();
        }
        

        public void StartAnimation()
        {
            _animator.Play(0,0 ,0);
        }

        public void PauseAnimation()
        {
            _animator.speed = 0f;
        }
    }
}
