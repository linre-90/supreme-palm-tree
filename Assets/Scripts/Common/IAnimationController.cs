
namespace Footkin.Common
{
    /// <summary>
    /// Interface to use on components that play animation.<br></br>
    /// Goal is to abstract away shared animation controlling.
    /// </summary>
    public interface IAnimationController
    {
        public void SetBoolean(string name, bool value);

        public void ResetBooleanToFalse(string name);

    } 
}
