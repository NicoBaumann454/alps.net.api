namespace alps.net_api
{
    interface IGroupState
    {
        /// <summary>
        /// Method that sets the incoming transition attribute of the instance
        /// </summary>
        /// <param name="transition"></param>
        void setIncomingTransition(ITransition transition);

        /// <summary>
        /// Method that returns the incoming transition attribute of the instance
        /// </summary>
        /// <returns>The incoming transition attribute of the instance</returns>
        ITransition getIncomingTransition();

        /// <summary>
        /// Method that sets the outgoing transition attribute of the instance
        /// </summary>
        /// <param name="transition"></param>
        void setOutgoingTransition(ITransition transition);

        /// <summary>
        /// Method that returns the outgoing transition attribute of the instance
        /// </summary>
        /// <returns>The outgoing transition attribute of the instance</returns>
        ITransition getOutgoingTransition();

        /// <summary>
        /// Method that sets the function specification attribute of the instance
        /// </summary>
        /// <param name="functionSpecification"></param>
        void setFunctionSpecification(IFunctionSpecification functionSpecification);

        /// <summary>
        /// Method that returns the function specification attribute of the instance
        /// </summary>
        /// <returns>The function specification attribute of the instance</returns>
        IFunctionSpecification getFunctionSpecification();

        /// <summary>
        /// Method that sets the guard behavior attribute of the instance
        /// </summary>
        /// <param name="guardBehavior"></param>
        void setGuardBehavior(IGuardBehavior guardBehavior);

        /// <summary>
        /// Method that returns the guard behavior attribute of the instance
        /// </summary>
        /// <returns>The guard behavior attribute of the instance</returns>
        IGuardBehavior getGuardBehavior();

        /// <summary>
        /// Method that sets the action attribute of the instance
        /// </summary>
        /// <param name="action"></param>
        void setAction(IAction action);

        /// <summary>
        /// Method that returns the action attribute of the instance
        /// </summary>
        /// <returns>The action attribute of the instance</returns>
        IAction getAction();
    }
}
