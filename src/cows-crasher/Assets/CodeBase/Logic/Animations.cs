using UnityEngine;

namespace CodeBase.Logic
{
    public static class Animations
    {
        public static int Idle = Animator.StringToHash("Idle");
        public static int Move = Animator.StringToHash("Move");
        public static int Attack = Animator.StringToHash("Attack");
        public static int Recharge = Animator.StringToHash("Recharge");
        
        public static int Speed = Animator.StringToHash("Speed");
    }
    
    
}