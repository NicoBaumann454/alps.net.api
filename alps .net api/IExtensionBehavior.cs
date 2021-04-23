using System.Collections.Generic;

namespace alps.net_api
{
    interface IExtensionBehavior
    {
        /// <summary>
        /// Method that sets the behavior description component attribute of the instance
        /// </summary>
        /// <param name="behaviorDescriptionComponent"></param>
        void setContainsBehaviorDescribingComponent(IBehaviorDescriptionComponent behaviorDescriptionComponent);

        /// <summary>
        /// Method that returns the behavior description component attribute of the instance
        /// </summary>
        /// <returns>The behavior description component attribute of the instance</returns>
        List<IBehaviorDescriptionComponent> getBehaviorDescriptionComponent();

        /// <summary>
        /// Method that sets the end state attribute of the instance
        /// </summary>
        /// <param name="endState"></param>
        void setEndState(IState endState);

        /// <summary>
        /// Method that returns the end state attribute of the instance
        /// </summary>
        /// <returns>The end state attribute of the instance</returns>
        IState getEndState();

        /// <summary>
        /// Method that sets the initial state of behaviors attribute of the instance
        /// </summary>
        /// <param name="initialStateOfBehavior"></param>
        void setInitialState(IInitialStateOfBehavior initialStateOfBehavior);

        /// <summary>
        /// Method that returns the initial state of behaviors attribute of the instance
        /// </summary>
        /// <returns>The initial state of behaviors attribute of the instance</returns>
        IInitialStateOfBehavior getInitialStateOfBehavior();

        /// <summary>
        /// Method that sets the priotity number attribute of the instance
        /// </summary>
        /// <param name="nonNegativNumber"></param>
        void setPriorityNumber(int nonNegativNumber);

        /// <summary>
        /// Method that returns the priotity number attribute of the instance
        /// </summary>
        /// <returns>The priotity number attribute of the instance</returns>
        int getPriorityNumber();
    }
}
