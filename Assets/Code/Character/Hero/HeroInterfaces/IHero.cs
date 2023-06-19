using Code.Character.Common.CommonCharacterInterfaces;
using UnityEngine;

namespace Code.Character.Hero.HeroInterfaces
{
    public interface IHero
    {
        Constants.GameMode GameMode { get; }
 
        Transform Transform { get; }
        IHeroAnimator Animator { get; }
        IHeroAudio Audio { get; }
        IHeroCollision Collision { get;  }
        IHeroMovement Movement { get; }
        IHeroJump Jump { get; }


        IHeroModeToggle ModeToggle { get; }
        IHeroAttack HandAttack { get; }
        IHeroRangeAttack GunAttack { get; }
        IHeroBuff Buff { get; }
        IHealth Health { get; }
        IHeroDeath Death { get; }
        IHeroUpgrade Upgrade { get; }
        IHeroAbility Ability { get; }
        IHeroVFX VFX { get; }
        HeroStateListener StateListener { get; }
    
    }
    
}