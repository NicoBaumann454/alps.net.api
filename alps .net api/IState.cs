using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the state class
    /// </summary>
    public interface IState : IBehaviorDescriptionComponent
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
        Dictionary<string, ITransition> getIncomingTransition();

        /// <summary>
        /// Method that sets the outgoing transition attribute of the instance
        /// </summary>
        /// <param name="transition"></param>
        void setOutgoingTransition(ITransition transition);

        /// <summary>
        /// Method that returns the outgoing transition attribute of the instance
        /// </summary>
        /// <returns>The outgoing transition attribute of the instance</returns>
        Dictionary<string, ITransition> getOutgoingTransition();

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
