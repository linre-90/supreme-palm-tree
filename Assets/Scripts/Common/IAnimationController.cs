namespace Footkin.Common
{
    /// <summary>
    /// Interface to use on components that play animation.<br></br>
    /// Goal is to abstract away shared animation controlling.
    /// </summary>
    public interface IAnimationController
    {
        public void SetMoveAnimation(bool state);
        public void SetRangedAnimation(bool state);
        public void SetMeleeAnimation(bool state);
        public void SetCollectAnimation(bool state);
    } 
}
