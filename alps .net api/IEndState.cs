namespace alps.net_api
{
    /// <summary>
    /// Interface to the EndState class
    /// </summary>

    public interface IEndState : IState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        void setBelongsToAction(IAction action);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IAction getBelongsToAction();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new EndState factoryMethod();
    }

}
