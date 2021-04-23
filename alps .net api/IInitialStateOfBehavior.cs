namespace alps.net_api
{
    /// <summary>
    /// Interface to the InitialStateOfBehavior class
    /// </summary>

    public interface IInitialStateOfBehavior : IState
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
        new InitialStateOfBehavior factoryMethod();
    }

}
