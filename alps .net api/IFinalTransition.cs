namespace alps.net_api
{
    interface IFinalTransition
    {
        /// <summary>
        /// Method that sets the action attribute of the instance
        /// </summary>
        /// <param name="action"></param>
        void setBelongsToAction(IAction action);

        /// <summary>
        /// Method that returns the action attribute of the instance
        /// </summary>
        /// <returns>The action attribute of the instance</returns>
        IAction getBelongsToAction();

        /// <summary>
        /// Method that sets the source state attribute of the instance
        /// </summary>
        /// <param name="sourceState"></param>
        void setSourceState(IState sourceState);

        /// <summary>
        /// Method that returns the source state attribute of the instance
        /// </summary>
        /// <returns>The source state attribute of the instance</returns>
        IState getSourceState();

        /// <summary>
        /// Method that sets the target state attribute of the instance
        /// </summary>
        /// <param name="targetState"></param>
        void setTargetState(IState targetState);

        /// <summary>
        /// Method that returns the target action attribute of the instance
        /// </summary>
        /// <returns>The target action attribute of the instance</returns>
        IState getTargetState();

        /// <summary>
        /// Method that sets the transition condition attribute of the instance
        /// </summary>
        /// <param name="transitionCondition"></param>
        void setTransitionCondition(ITransitionCondition transitionCondition);

        /// <summary>
        /// Method that returns the transition condition attribute of the instance
        /// </summary>
        /// <returns>The transition condition attribute of the instance</returns>
        ITransitionCondition getTransitionCondition();
    }
}
