using System.Collections.Generic;

namespace alps.net_api
{
    interface IAbstractPASSTransition
    {
        void setBelongsToAction(IAction action);

        /// <summary>
        /// Method that sets the source state attribute of the instance
        /// </summary>
        /// <param name="sourceState"></param>
        void setSourceState(IState sourceState);

        /// <summary>
        /// Method that sets the target state attribute of the instance
        /// </summary>
        /// <param name="targetState"></param>
        void setTargetState(IState targetState);

        /// <summary>
        /// Method that sets the transition condition attribute of the instance
        /// </summary>
        /// <param name="transitionCondition"></param>
        void setTransitionCondition(ITransitionCondition transitionCondition);

        /// <summary>
        /// Method that returns the action attribute of the instance
        /// </summary>
        /// <returns>The action attribute of the instance</returns>
        IAction getBelongsToAction();

        /// <summary>
        /// Method that returns the source state attribute of the instance
        /// </summary>
        /// <returns>The source state attribute of the instance</returns>
        IState getSourceState();

        /// <summary>
        /// Method that returns the target action attribute of the instance
        /// </summary>
        /// <returns>The target action attribute of the instance</returns>
        IState getTargetState();

        /// <summary>
        /// Method that returns the transition condition attribute of the instance
        /// </summary>
        /// <returns>The transition condition attribute of the instance</returns>
        ITransitionCondition getTransitionCondition();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getTmpBelonstToAction();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getTmpSourceState();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getTmpTargetState();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getTmpTransitionCondition();

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the transition class
        /// </summary>
        /// <returns>A new empty instance of the transition class</returns>
        AbstractPASSTransition factoryMethod();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        bool createInstance(List<string> attribute, List<string> attributeType);

        /// <summary>
        /// Method that sets the Object Properties of the created Objects, it first takes the base Class to this and asks if the Object can take 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        /// 
        void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp);

    }
}
