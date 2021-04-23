namespace alps.net_api
{
    /// <summary>
    /// Interface to the GenericReturnToOriginReference class
    /// </summary>

    public interface IGenericReturnToOriginRefrence : IState
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
        new GenericReturnToOriginReference factoryMethod();
    }

}
