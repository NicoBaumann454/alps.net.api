namespace alps.net_api
{
    /// <summary>
    /// Interface to the state reference class
    /// </summary>
    public interface IStateReference : IState
    {
        /// <summary>
        /// Method that sets the state attribute of the instance
        /// </summary>
        /// <param name="state"></param>
        void setReferencesState(IState state);

        /// <summary>
        /// Method that returns the state attribute of the instance
        /// </summary>
        /// <returns>The state attribute of the instance</returns>
        IState getReferencesState();
    }

}
