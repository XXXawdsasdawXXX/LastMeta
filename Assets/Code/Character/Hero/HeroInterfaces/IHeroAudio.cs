namespace Code.Character.Hero
{
    public interface IHeroAudio
    {
        void PlayStepSound();
        void PlaySoftStepSound();
        void PlayOnLandAudio();
        void PlayPunchAudio();
        void PlayDamageAudio();
        void PlayJump();
    }
}