using System.Collections.Generic;
namespace alps.net_api
{
    /// <summary>
    /// Interface to the Subject behavior class
    /// </summary>
    public interface ISubjectBehavior : IInteractionDescriptionComponent
    {
        /// <summary>
        /// Method that sets the behavior description component attribute of the instance
        /// </summary>
        /// <param name="behaviorDescriptionComponent"></param>
        void setContainsBehaviorDescribingComponent(BehaviorDescriptionComponent behaviorDescriptionComponent);

        /// <summary>
        /// Method that returns the behavior description component attribute of the instance
        /// </summary>
        /// <returns>The behavior description component attribute of the instance</returns>
        Dictionary<string, BehaviorDescriptionComponent> getBehaviorDescriptionComponent();

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
        void setInitialState(IState initialStateOfBehavior);

        /// <summary>
        /// Method that returns the initial state of behaviors attribute of the instance
        /// </summary>
        /// <returns>The initial state of behaviors attribute of the instance</returns>
        IState getInitialStateOfBehavior();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passProcessModel"></param>
        void setBelongsToPassProcessModel(PassProcessModel passProcessModel);

        /// <summary>
        ///  Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="state"></param>
        /// <param name="transitions"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IAction addAction(string label, string comment = "", IState state = null, Dictionary<string, ITransition> transitions = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IAction getAction(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        void deleteAction(IAction action);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        IFunctionSpecification addFunctionSpecification(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IFunctionSpecification getFunctionSpecification(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionSpecification"></param>
        void deleteFunctionSpecification(IFunctionSpecification functionSpecification);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        ICommunicationAct addCommunicationAct(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        ICommunicationAct getCommunicationAct(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communicationAct"></param>
        void deletCommunicationAct(ICommunicationAct communicationAct);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        IReceiveFunction addReceiveFunction(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IReceiveFunction getReceiveFunction(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveFunction"></param>
        void deleteReceiveFunction(IReceiveFunction receiveFunction);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        ISendFunction addSendFunction(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        ISendFunction getSendFunction(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendFunction"></param>
        void deleteSendFunction(ISendFunction sendFunction);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        IDoFunction addDoFunction(string label, string comment = "", string toolSpecificDefintion = "", List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IDoFunction getDoFunction(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doFunction"></param>
        void deleteDoFunction(IDoFunction doFunction);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="additionalAttribute"></param>
        /// <param name="comment"></param>
        IReceiveType addReceiveType(string label, string comment = "", List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IReceiveType getReceiveType(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveType"></param>
        void deleteReceiveType(IReceiveType receiveType);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="additionalAttribute"></param>
        /// <param name="comment"></param>
        ISendType addSendType(string label, string comment = "", List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        ISendType getSendType(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendType"></param>
        void deleteSendType(ISendType sendType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IState addState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IState getState(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        void deleteState(IState state);

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="choiceSegmentPath"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IChoiceSegment addChoiceSegment(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, Dictionary<string, IChoiceSegmentPath> choiceSegmentPath = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IChoiceSegment getChoiceSegment(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceSegment"></param>
        void deleteChoiceSegment(IChoiceSegment choiceSegment);

        /// <summary>
        /// Method that creates a new instance of the choice segment path class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="choiceSegment"></param>
        /// <param name="containsState"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfChoiceSegmentPath"></param>
        /// <param name="isOptionalToEndChoiceSegmentPath"></param>
        /// <param name="isOptionalToStartChoiceSegmentPath"></param>
        /// <param name="isMandatoryToEndChoiceSegmentPath"></param>
        /// <param name="isMandatoryToStartChoiceSegmentPath"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IChoiceSegmentPath addChoiceSegmentPath(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IChoiceSegment choiceSegment = null, IState containsState = null, IEndState endState = null, InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = null, bool isOptionalToEndChoiceSegmentPath = false, bool isOptionalToStartChoiceSegmentPath = false, bool isMandatoryToEndChoiceSegmentPath = false, bool isMandatoryToStartChoiceSegmentPath = false, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IChoiceSegmentPath getChoiceSegmentPath(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceSegmentPath"></param>
        void deleteChoiceSegmentPath(IChoiceSegmentPath choiceSegmentPath);

        /// <summary>
        /// Method that creates a new instance of the end state class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IEndState addEndState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IEndState getEndState(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endState"></param>
        void deleteEndState(IEndState endState);

        /// <summary>
        /// Method that creates a new instance of the generic return to origin reference class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IGenericReturnToOriginRefrence addGenericReturnToOriginReference(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IGenericReturnToOriginRefrence getGenericReturnToOriginReference(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genericReturnToOriginReference"></param>
        void deleteGenericReturnToOriginReference(IGenericReturnToOriginRefrence genericReturnToOriginReference);

        /// <summary>
        /// Method that creates a new instance of the initial state of behavior class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IInitialStateOfBehavior getInitialStateOfBehavior(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IInitialStateOfBehavior getInitialStateOfBehavior(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialStateOfBehavior"></param>
        void deleteInitialStateOfBehavior(IInitialStateOfBehavior initialStateOfBehavior);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="choiceSegmentPath"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IInitialstateOfChoiceSegmentPath addInitialStateOfChoiceSegmentPath(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IChoiceSegmentPath choiceSegmentPath = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IInitialstateOfChoiceSegmentPath getStateOfChoiceSegmentPath(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialStateOfChoiceSegmentPath"></param>
        void deleteInitialStateOfChoiceSegmentPath(IInitialstateOfChoiceSegmentPath initialStateOfChoiceSegmentPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="stateReference"></param>
        /// <param name="macroBehavior"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IMacroState addMacroState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, Dictionary<string, IStateReference> stateReference = null, IMacroBehavior macroBehavior = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IMacroState getMacroState(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="macroState"></param>
        void deleteMacroState(IMacroState macroState);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IStandartPASSState addStandartPASSState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IStandartPASSState getStandartPASSState(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="standartPASSState"></param>
        void deleteStandartPASSState(IStandartPASSState standartPASSState);

        /// <summary>
        /// Method that creates a new instance of the do state class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="dataMappingIncomingToLocal"></param>
        /// <param name="dataMappingLocalToOutgoing"></param>
        /// <param name="doFunction"></param>
        /// <returns></returns>
        IDoState addDoState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IDataMappingIncomingToLocal dataMappingIncomingToLocal = null, IDataMappingLocalToOutgoing dataMappingLocalToOutgoing = null, IDoFunction doFunction = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IDoState getDoState(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doState"></param>
        void deleteDoState(IDoState doState);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="receiveFunction"></param>
        /// <returns></returns>
        IReceiveState addReceiveState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IReceiveFunction receiveFunction = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IReceiveState getReceiveState(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveState"></param>
        void deleteReceiveState(IReceiveState receiveState);

        /// <summary>
        /// Method that creates a new instance of the send state class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="sendFunction"></param>
        /// <param name="sendTransition"></param>
        /// <param name="sendingFailedTransition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        ISendState addSendState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, ISendFunction sendFunction = null, ISendTransition sendTransition = null, Dictionary<string, ISendingFailedTransition> sendingFailedTransition = null, List<string> additionalAttribute = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        ISendState getSendState(int numberOfElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendState"></param>
        void deleteSendState(ISendState sendState);

        /// <summary>
        /// Method that creates a new instance of the state reference class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="state"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        IStateReference addStateReference(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IState state = null, List<string> additionalAttribute = null);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        IStateReference getStateReference(int numberOfElement);

    }

}
