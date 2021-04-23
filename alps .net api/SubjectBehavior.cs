using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a subject behavior
    /// </summary>
    public class SubjectBehavior : InteractionDescriptionComponent, ISubjectBehavior
    {
        private Dictionary<string, BehaviorDescriptionComponent> behaviorDescriptionComponent = new Dictionary<string, BehaviorDescriptionComponent>();
        private IState endState;
        private IInitialStateOfBehavior initialStateOfBehavior;
        private int priorityNumber;
        private Guid guid;
        private string tmpBehaviorDescriptionComponent;
        private string tmpEndState;
        private string tmpInitialStateOfBehavior;
        private string tmpPriorityNumber;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SubjectBehavior";

        /// <summary>
        /// Constructor that creates a new empty instance of the subject behavior class
        /// </summary>
        public SubjectBehavior()
        {
            setModelComponentID("SubjectBehavior");
            setComment("The standart Element for SubjectBehavior");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the subject behavior class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="behaviorDescriptionComponent"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfBehavior"></param>
        /// <param name="priorityNumber"></param>
        public SubjectBehavior(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, BehaviorDescriptionComponent behaviorDescriptionComponent, State endState, InitialStateOfBehavior initialStateOfBehavior, int priorityNumber)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsBehaviorDescribingComponent(behaviorDescriptionComponent);
            setEndState(endState);
            setInitialState(initialStateOfBehavior);
            setPriorityNumber(priorityNumber);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfBehavior"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="additionalAttribute"></param>
        public SubjectBehavior(string label, string comment = "", IEndState endState = null, IInitialStateOfBehavior initialStateOfBehavior = null, int priorityNumber = 0, List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            if (endState != null)
            {
                this.endState = endState;
            }

            if (initialStateOfBehavior != null)
            {
                this.initialStateOfBehavior = initialStateOfBehavior;
            }

            this.priorityNumber = priorityNumber;
        }

        /// <summary>
        /// Method that sets the behavior description component attribute of the instance
        /// </summary>
        /// <param name="behaviorDescriptionComponent"></param>
        public void setContainsBehaviorDescribingComponent(BehaviorDescriptionComponent behaviorDescriptionComponent)
        {
            this.behaviorDescriptionComponent.Add(behaviorDescriptionComponent.getModelComponentID(), behaviorDescriptionComponent);
        }

        /// <summary>
        /// Method that sets the end state attribute of the instance
        /// </summary>
        /// <param name="endState"></param>
        public void setEndState(IState endState)
        {
            this.endState = endState;
        }

        /// <summary>
        /// Method that sets the initial state of behaviors attribute of the instance
        /// </summary>
        /// <param name="initialStateOfBehavior"></param>
        public void setInitialState(IInitialStateOfBehavior initialStateOfBehavior)
        {
            this.initialStateOfBehavior = initialStateOfBehavior;
        }

        /// <summary>
        /// Method that sets the priotity number attribute of the instance
        /// </summary>
        /// <param name="nonNegativNumber"></param>
        public void setPriorityNumber(int nonNegativNumber)
        {
            this.priorityNumber = nonNegativNumber;
        }

        /// <summary>
        /// Method that returns the behavior description component attribute of the instance
        /// </summary>
        /// <returns>The behavior description component attribute of the instance</returns>
        public Dictionary<string, BehaviorDescriptionComponent> getBehaviorDescriptionComponent()
        {
            return behaviorDescriptionComponent;
        }

        /// <summary>
        /// Method that returns the end state attribute of the instance
        /// </summary>
        /// <returns>The end state attribute of the instance</returns>
        public IState getEndState()
        {
            return endState;
        }

        /// <summary>
        /// Method that returns the initial state of behaviors attribute of the instance
        /// </summary>
        /// <returns>The initial state of behaviors attribute of the instance</returns>
        public IInitialStateOfBehavior getInitialStateOfBehavior()
        {
            return initialStateOfBehavior;
        }

        /// <summary>
        /// Method that returns the priotity number attribute of the instance
        /// </summary>
        /// <returns>The priotity number attribute of the instance</returns>
        public int getPriorityNumber()
        {
            return priorityNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpBehaviorDescriptionComponent()
        {
            return tmpBehaviorDescriptionComponent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpEndState()
        {
            return tmpEndState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpInitialStateOfBehavior()
        {
            return tmpInitialStateOfBehavior;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpPriorityNumber()
        {
            return tmpPriorityNumber;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the subject behavior class
        /// </summary>
        /// <returns>A new empty instance of the subject behavior class</returns>
        new public SubjectBehavior factoryMethod()
        {
            SubjectBehavior subjectBehavior = new SubjectBehavior();

            return subjectBehavior;
        }

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="state"></param>
        /// <param name="transitions"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IAction addAction(string label, string comment = "", IState state = null, Dictionary<string, ITransition> transitions = null, List<string> additionalAttribute = null)
        {
            Action action = new Action(label, comment, state, transitions, additionalAttribute);

            action.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(action.getModelComponentID(), action);

            return action;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IAction getAction(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<Action>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void deleteAction(IAction action)
        {
            deleteState(action.getState());

            Dictionary<string, ITransition> transitions = action.getTransition();

            foreach (KeyValuePair<string, ITransition> i in transitions)
            {
                deleteTransition(i.Value);
            }

            behaviorDescriptionComponent.Remove(action.getModelComponentID());
        }

        /// <summary>
        /// Method that can be used to create a new  subject behavior and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IFunctionSpecification addFunctionSpecification(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null)
        {
            FunctionSpecification functionSpecification = new FunctionSpecification(label, comment, toolSpecificDefinition, additionalAttribute);

            functionSpecification.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(functionSpecification.getModelComponentID(), functionSpecification);

            return functionSpecification;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IFunctionSpecification getFunctionSpecification(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<FunctionSpecification>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionSpecification"></param>
        public void deleteFunctionSpecification(IFunctionSpecification functionSpecification)
        {
            behaviorDescriptionComponent.Remove(functionSpecification.getModelComponentID());
        }

        /// <summary>
        /// Method that adds a new communication act to the given model where all the parameters of the object can be set 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ICommunicationAct addCommunicationAct(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null)
        {
            CommunicationAct communicationAct = new CommunicationAct(label, comment, toolSpecificDefinition, additionalAttribute);

            communicationAct.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(communicationAct.getModelComponentID(), communicationAct);

            return communicationAct;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ICommunicationAct getCommunicationAct(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<CommunicationAct>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communicationAct"></param>
        public void deletCommunicationAct(ICommunicationAct communicationAct)
        {
            behaviorDescriptionComponent.Remove(communicationAct.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new Receive Function and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IReceiveFunction addReceiveFunction(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null)
        {
            ReceiveFunction receiveFunction = new ReceiveFunction(label, comment, toolSpecificDefinition, additionalAttribute);

            receiveFunction.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(receiveFunction.getModelComponentID(), receiveFunction);

            return receiveFunction;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IReceiveFunction getReceiveFunction(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ReceiveFunction>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveFunction"></param>
        public void deleteReceiveFunction(IReceiveFunction receiveFunction)
        {
            behaviorDescriptionComponent.Remove(receiveFunction.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new send function and adds it to the corresponding subject behavior 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ISendFunction addSendFunction(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null)
        {
            SendFunction sendFunction = new SendFunction(label, comment, toolSpecificDefinition, additionalAttribute);

            sendFunction.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(sendFunction.getModelComponentID(), sendFunction);

            return sendFunction;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ISendFunction getSendFunction(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<SendFunction>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendFunction"></param>
        public void deleteSendFunction(ISendFunction sendFunction)
        {
            behaviorDescriptionComponent.Remove(sendFunction.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the do function class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IDoFunction addDoFunction(string label, string comment = "", string toolSpecificDefintion = "", List<string> additionalAttribute = null)
        {
            DoFunction doFunction = new DoFunction(label, comment, toolSpecificDefintion, additionalAttribute);

            doFunction.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(doFunction.getModelComponentID(), doFunction);

            return doFunction;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IDoFunction getDoFunction(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<DoFunction>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doFunction"></param>
        public void deleteDoFunction(IDoFunction doFunction)
        {
            behaviorDescriptionComponent.Remove(doFunction.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the receive type class and adds it to the corresponding subject bahavior 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IReceiveType addReceiveType(string label, string comment = "", List<string> additionalAttribute = null)
        {
            ReceiveType receiveType = new ReceiveType(label, comment, additionalAttribute);

            receiveType.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(receiveType.getModelComponentID(), receiveType);

            return receiveType;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IReceiveType getReceiveType(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ReceiveType>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveType"></param>
        public void deleteReceiveType(IReceiveType receiveType)
        {
            behaviorDescriptionComponent.Remove(receiveType.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the send type class and adds it to the corresponding subject behavior 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ISendType addSendType(string label, string comment = "", List<string> additionalAttribute = null)
        {
            SendType sendType = new SendType(label, comment, additionalAttribute);

            sendType.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(sendType.getModelComponentID(), sendType);

            return sendType;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ISendType getSendType(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<SendType>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendType"></param>
        public void deleteSendType(ISendType sendType)
        {
            behaviorDescriptionComponent.Remove(sendType.getModelComponentID());
        }

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
        public IState addState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null)
        {
            State state = new State(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute);

            state.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(state.getModelComponentID(), state);

            return state;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IState getState(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<State>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void deleteState(IState state)
        {
            deleteAction(state.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(state.getFunctionSpecification());
            deleteTransition(state.getIncomingTransition());
            deleteTransition(state.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(state.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the choice segment class and adds it to the corresponding subject behavior
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
        public IChoiceSegment addChoiceSegment(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, Dictionary<string, IChoiceSegmentPath> choiceSegmentPath = null, List<string> additionalAttribute = null)
        {
            guid = Guid.NewGuid();

            ChoiceSegment choiceSegment = new ChoiceSegment(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, choiceSegmentPath, additionalAttribute);


            choiceSegment.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(choiceSegment.getModelComponentID(), choiceSegment);

            return choiceSegment;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IChoiceSegment getChoiceSegment(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ChoiceSegment>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceSegment"></param>
        public void deleteChoiceSegment(IChoiceSegment choiceSegment)
        {
            behaviorDescriptionComponent.Remove(choiceSegment.getModelComponentID());
        }

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
        public IChoiceSegmentPath addChoiceSegmentPath(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IChoiceSegment choiceSegment = null, IState containsState = null, IEndState endState = null, InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = null, bool isOptionalToEndChoiceSegmentPath = false, bool isOptionalToStartChoiceSegmentPath = false, bool isMandatoryToEndChoiceSegmentPath = false, bool isMandatoryToStartChoiceSegmentPath = false, List<string> additionalAttribute = null)
        {
            ChoiceSegmentPath choiceSegmentPath = new ChoiceSegmentPath(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, choiceSegment, containsState, endState, initialStateOfChoiceSegmentPath, isOptionalToEndChoiceSegmentPath, isOptionalToStartChoiceSegmentPath, isMandatoryToEndChoiceSegmentPath, isMandatoryToStartChoiceSegmentPath, additionalAttribute);

            choiceSegmentPath.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(choiceSegmentPath.getModelComponentID(), choiceSegmentPath);

            return choiceSegmentPath;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IChoiceSegmentPath getChoiceSegmentPath(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ChoiceSegmentPath>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceSegmentPath"></param>
        public void deleteChoiceSegmentPath(IChoiceSegmentPath choiceSegmentPath)
        {
            deleteAction(choiceSegmentPath.getAction());
            //deleteState(choiceSegmentPath.getInitialState());
            //deleteEndState(choiceSegmentPath.getEndState());
            behaviorDescriptionComponent.Remove(choiceSegmentPath.getModelComponentID());
        }

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
        public IEndState addEndState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null)
        {
            EndState endState = new EndState(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute);

            endState.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(endState.getModelComponentID(), endState);

            return endState;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IEndState getEndState(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<EndState>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endState"></param>
        public void deleteEndState(IEndState endState)
        {
            deleteAction(endState.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(endState.getFunctionSpecification());
            deleteTransition(endState.getIncomingTransition());
            deleteTransition(endState.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(endState.getModelComponentID());
        }

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
        public IGenericReturnToOriginRefrence addGenericReturnToOriginReference(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null)
        {

            GenericReturnToOriginReference genericReturnToOriginReference = new GenericReturnToOriginReference(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute);

            genericReturnToOriginReference.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(genericReturnToOriginReference.getModelComponentID(), genericReturnToOriginReference);

            return genericReturnToOriginReference;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IGenericReturnToOriginRefrence getGenericReturnToOriginReference(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<GenericReturnToOriginReference>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genericReturnToOriginReference"></param>
        public void deleteGenericReturnToOriginReference(IGenericReturnToOriginRefrence genericReturnToOriginReference)
        {
            deleteAction(genericReturnToOriginReference.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(genericReturnToOriginReference.getFunctionSpecification());
            deleteTransition(genericReturnToOriginReference.getIncomingTransition());
            deleteTransition(genericReturnToOriginReference.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(genericReturnToOriginReference.getModelComponentID());
        }

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
        public IInitialStateOfBehavior getInitialStateOfBehavior(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null)
        {

            InitialStateOfBehavior initialStateOfBehavior = new InitialStateOfBehavior(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute);

            initialStateOfBehavior.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(initialStateOfBehavior.getModelComponentID(), initialStateOfBehavior);

            return initialStateOfBehavior;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IInitialStateOfBehavior getInitialStateOfBehavior(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<InitialStateOfBehavior>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialStateOfBehavior"></param>
        public void deleteInitialStateOfBehavior(IInitialStateOfBehavior initialStateOfBehavior)
        {
            deleteAction(initialStateOfBehavior.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(initialStateOfBehavior.getFunctionSpecification());
            deleteTransition(initialStateOfBehavior.getIncomingTransition());
            deleteTransition(initialStateOfBehavior.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(initialStateOfBehavior.getModelComponentID());
        }

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
        public IInitialstateOfChoiceSegmentPath addInitialStateOfChoiceSegmentPath(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IChoiceSegmentPath choiceSegmentPath = null, List<string> additionalAttribute = null)
        {

            InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = new InitialStateOfChoiceSegmentPath(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, choiceSegmentPath, additionalAttribute);

            initialStateOfChoiceSegmentPath.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(initialStateOfChoiceSegmentPath.getModelComponentID(), initialStateOfChoiceSegmentPath);

            return initialStateOfChoiceSegmentPath;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IInitialstateOfChoiceSegmentPath getStateOfChoiceSegmentPath(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<InitialStateOfChoiceSegmentPath>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialStateOfChoiceSegmentPath"></param>
        public void deleteInitialStateOfChoiceSegmentPath(IInitialstateOfChoiceSegmentPath initialStateOfChoiceSegmentPath)
        {
            deleteAction(initialStateOfChoiceSegmentPath.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(initialStateOfBehavior.getFunctionSpecification());
            deleteTransition(initialStateOfBehavior.getIncomingTransition());
            deleteTransition(initialStateOfBehavior.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(initialStateOfChoiceSegmentPath.getModelComponentID());
        }

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
        public IMacroState addMacroState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, Dictionary<string, IStateReference> stateReference = null, IMacroBehavior macroBehavior = null, List<string> additionalAttribute = null)
        {

            MacroState macroState = new MacroState(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, stateReference, macroBehavior, additionalAttribute);

            macroState.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(macroState.getModelComponentID(), macroState);

            return macroState;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IMacroState getMacroState(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<MacroState>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="macroState"></param>
        public void deleteMacroState(IMacroState macroState)
        {
            deleteAction(macroState.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(macroState.getFunctionSpecification());
            deleteTransition(macroState.getIncomingTransition());
            deleteTransition(macroState.getOutgoingTransition());
            //deleteMacroBehavior(macroState.getReferenceMacroBehavior());
            behaviorDescriptionComponent.Remove(macroState.getModelComponentID());
        }

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
        public IStandartPASSState addStandartPASSState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null)
        {

            StandartPASSState standartPASSState = new StandartPASSState(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute);

            standartPASSState.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(standartPASSState.getModelComponentID(), standartPASSState);

            return standartPASSState;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IStandartPASSState getStandartPASSState(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<StandartPASSState>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="standartPASSState"></param>
        public void deleteStandartPASSState(IStandartPASSState standartPASSState)
        {
            deleteAction(standartPASSState.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(standartPASSState.getFunctionSpecification());
            deleteTransition(standartPASSState.getIncomingTransition());
            deleteTransition(standartPASSState.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(standartPASSState.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the do State class and adds it to the corresponding subject behavior
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
        public IDoState addDoState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IDataMappingIncomingToLocal dataMappingIncomingToLocal = null, IDataMappingLocalToOutgoing dataMappingLocalToOutgoing = null, IDoFunction doFunction = null)
        {

            DoState doState = new DoState(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, dataMappingIncomingToLocal, dataMappingLocalToOutgoing, doFunction);

            doState.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(doState.getModelComponentID(), doState);

            return doState;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IDoState getDoState(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<DoState>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doState"></param>
        public void deleteDoState(IDoState doState)
        {
            deleteAction(doState.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(doState.getFunctionSpecification());
            deleteTransition(doState.getIncomingTransition());
            deleteTransition(doState.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(doState.getModelComponentID());
        }

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
        public IReceiveState addReceiveState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IReceiveFunction receiveFunction = null)
        {
            ReceiveState receiveState = new ReceiveState(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, receiveFunction);

            receiveState.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(receiveState.getModelComponentID(), receiveState);

            return receiveState;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IReceiveState getReceiveState(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ReceiveState>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveState"></param>
        public void deleteReceiveState(IReceiveState receiveState)
        {
            deleteAction(receiveState.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(receiveState.getFunctionSpecification());
            //deleteTransition(state.getIncomingTransition());
            //deleteTransition(state.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(receiveState.getModelComponentID());
        }

        /// <summary>
        /// Message that creates a new instance of the send state class and adds it to the corresponding subject behavior
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
        public ISendState addSendState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, ISendFunction sendFunction = null, ISendTransition sendTransition = null, Dictionary<string, ISendingFailedTransition> sendingFailedTransition = null, List<string> additionalAttribute = null)
        {
            SendState sendState = new SendState(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, sendFunction, sendTransition, sendingFailedTransition, additionalAttribute);

            sendState.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(sendState.getModelComponentID(), sendState);

            return sendState;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ISendState getSendState(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<SendState>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendState"></param>
        public void deleteSendState(ISendState sendState)
        {
            deleteAction(sendState.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            //deleteFunctionSpecification(state.getFunctionSpecification());
            //deleteTransition(state.getIncomingTransition());
            //deleteTransition(state.getOutgoingTransition());
            behaviorDescriptionComponent.Remove(sendState.getModelComponentID());
        }

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
        public IStateReference addStateReference(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IState state = null, List<string> additionalAttribute = null)
        {
            StateReference stateReference = new StateReference(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, state, additionalAttribute);

            state.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(stateReference.getModelComponentID(), stateReference);

            return stateReference;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IStateReference getStateReference(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<StateReference>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateReference"></param>
        public void deleteStateReference(IStateReference stateReference)
        {
            deleteAction(stateReference.getAction());
            //deleteGuardBehavior(state.getModelComponentID());
            deleteFunctionSpecification(stateReference.getFunctionSpecification());
            deleteTransition(stateReference.getIncomingTransition());
            deleteTransition(stateReference.getOutgoingTransition());
            deleteState(stateReference.getReferencesState());
            behaviorDescriptionComponent.Remove(stateReference.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the transition class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ITransition addTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {

            Transition transition = new Transition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            transition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(transition.getModelComponentID(), transition);

            return transition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ITransition getTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<Transition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteTransition(ITransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the communication transition class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="messageExchangeCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ICommunicationTransition addCommunicationTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, IMessageExchangeCondition messageExchangeCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {

            CommunicationTransition communicationTransition = new CommunicationTransition(label, comment, action, sourceState, targetState, transitionCondition, messageExchangeCondition, TransitionType, additionalAttribute);

            communicationTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(communicationTransition.getModelComponentID(), communicationTransition);

            return communicationTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ICommunicationTransition getCommunicationTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<CommunicationTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communicationTransition"></param>
        public void deleteCommunicationTransition(ICommunicationTransition communicationTransition)
        {
            deleteAction(communicationTransition.getBelongsToAction());
            deleteState(communicationTransition.getSourceState());
            deleteState(communicationTransition.getTargetState());
            deleteTransitionCondition(communicationTransition.getMessageExchangeCondition());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(communicationTransition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the receive transition class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="messageExchangeCondition"></param>
        /// <param name="dataMappingIncomingToLocal"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="receiveTransitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IReceiveTransition addReceiveTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, IMessageExchangeCondition messageExchangeCondition = null, IDataMappingIncomingToLocal dataMappingIncomingToLocal = null, int priorityNumber = 0, IReceiveTransitionCondition receiveTransitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {

            ReceiveTransition receiveTransition = new ReceiveTransition(label, comment, action, sourceState, targetState, transitionCondition, messageExchangeCondition, dataMappingIncomingToLocal, priorityNumber, receiveTransitionCondition, TransitionType, additionalAttribute);

            receiveTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(receiveTransition.getModelComponentID(), receiveTransition);

            return receiveTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IReceiveTransition getReceiveTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ReceiveTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveTransition"></param>
        public void deleteReceiveTransition(IReceiveTransition receiveTransition)
        {
            deleteAction(receiveTransition.getBelongsToAction());
            deleteState(receiveTransition.getSourceState());
            deleteState(receiveTransition.getTargetState());
            //deleteReceiveTransitionCondition(receiveTransition.getReceiveTransitionCondition());
            //deleteDataMappingIncomingToLocal(receiveTransition.getDataMappingIncomingToLocal());
            //deleteTransitionCondition(communicationTransition.getMessageExchangeCondition());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(receiveTransition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the send transition class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="messageExchangeCondition"></param>
        /// <param name="dataMappingLocalToOutgoing"></param>
        /// <param name="sendTransitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ISendTransition addSendTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, IMessageExchangeCondition messageExchangeCondition = null, IDataMappingLocalToOutgoing dataMappingLocalToOutgoing = null, ISendTransitionCondition sendTransitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {

            SendTransition sendTransition = new SendTransition(label, comment, action, sourceState, targetState, transitionCondition, messageExchangeCondition, dataMappingLocalToOutgoing, sendTransitionCondition, TransitionType, additionalAttribute);

            sendTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(sendTransition.getModelComponentID(), sendTransition);

            return sendTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ISendTransition getSendTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<SendTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendTransition"></param>
        public void deleteSendTransition(ISendTransition sendTransition)
        {
            deleteAction(sendTransition.getBelongsToAction());
            deleteState(sendTransition.getSourceState());
            deleteState(sendTransition.getTargetState());
            //deleteReceiveTransitionCondition(receiveTransition.getReceiveTransitionCondition());
            //deleteDataMappingIncomingToLocal(receiveTransition.getDataMappingIncomingToLocal());
            //deleteTransitionCondition(communicationTransition.getMessageExchangeCondition());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(sendTransition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the do transition class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IDoTransition addDoTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, int priorityNumber = 0, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            DoTransition doTransition = new DoTransition(label, comment, action, sourceState, targetState, transitionCondition, priorityNumber, TransitionType, additionalAttribute);

            doTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(doTransition.getModelComponentID(), doTransition);

            return doTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IDoTransition getDoTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<DoTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteDoTransition(IDoTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the sending failed transition class and adds it to the corresponding subject behavior 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="sendState"></param>
        /// <param name="sendingFailedCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ISendingFailedTransition addSendingFailedTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, ISendState sendState = null, ISendingFailedCondition sendingFailedCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            SendingFailedTransition sendingFailedTransition = new SendingFailedTransition(label, comment, action, sourceState, targetState, transitionCondition, sendState, sendingFailedCondition, TransitionType, additionalAttribute);

            sendingFailedTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(sendingFailedTransition.getModelComponentID(), sendingFailedTransition);

            return sendingFailedTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ISendingFailedTransition getSendingFailedTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<SendingFailedTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteSendingFailedTransition(ISendingFailedTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the time transition class and adds it to the corresponding subect behavior 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ITimeTransition addTimeTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            TimeTransition timeTransition = new TimeTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            timeTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(timeTransition.getModelComponentID(), timeTransition);

            return timeTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ITimeTransition getTimeTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<TimeTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteTimeTransition(ITimeTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the reminder transition class and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IReminderTransition addReminderTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            ReminderTransition reminderTransition = new ReminderTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            reminderTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(reminderTransition.getModelComponentID(), reminderTransition);

            return reminderTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IReminderTransition getReminderTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ReminderTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteReminderTransition(IReminderTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the calender based reminder transition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ICalenderBasedReminderTransition addCalenderBasedReminderTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            CalenderBasedReminderTransition calenderBasedReminderTransition = new CalenderBasedReminderTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            calenderBasedReminderTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(calenderBasedReminderTransition.getModelComponentID(), calenderBasedReminderTransition);

            return calenderBasedReminderTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ICalenderBasedReminderTransition getCalenderBasedReminderTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<CalenderBasedReminderTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteCalenderBasedReminderTranistion(ICalenderBasedReminderTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the time based reminder transition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ITimeBasedReminderTransition addTimeBasedReminderTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            TimeBasedReminderTransition timeBasedReminderTransition = new TimeBasedReminderTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            timeBasedReminderTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(timeBasedReminderTransition.getModelComponentID(), timeBasedReminderTransition);

            return timeBasedReminderTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ITimeBasedReminderTransition getTimeBasedReminderTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<TimeBasedReminderTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteTimeBasedReminderTransition(ITimeBasedReminderTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the timer transition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ITimerTransition addTimerTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            TimerTransition timerTransition = new TimerTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            timerTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(timerTransition.getModelComponentID(), timerTransition);

            return timerTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ITimerTransition getTimerTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<TimerTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteTimerTransition(ITimerTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the business day timer transition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IBuisnessDayTimerTransition addBuisnessDayTimerTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            BuisnessDayTimerTransition buisnessDayTimerTransition = new BuisnessDayTimerTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            buisnessDayTimerTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(buisnessDayTimerTransition.getModelComponentID(), buisnessDayTimerTransition);

            return buisnessDayTimerTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IBuisnessDayTimerTransition getBuisnessDayTimerTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<BuisnessDayTimerTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteBusinessDayTimerTransition(IBuisnessDayTimerTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the day time timer transition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IDayTimeTimerTransition addDayTimeTimerTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            DayTimeTimerTransition dayTimeTimerTransition = new DayTimeTimerTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            dayTimeTimerTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(dayTimeTimerTransition.getModelComponentID(), dayTimeTimerTransition);

            return dayTimeTimerTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IDayTimeTimerTransition getDayTimeTimerTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<DayTimeTimerTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteDayTimeTimerTransition(IDayTimeTimerTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the year month timer transition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IYearMonthTimerTransition addYearMonthTimerTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            YearMonthTimerTransition yearMonthTimerTransition = new YearMonthTimerTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            yearMonthTimerTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(yearMonthTimerTransition.getModelComponentID(), yearMonthTimerTransition);

            return yearMonthTimerTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IYearMonthTimerTransition getYearMonthTimerTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<YearMonthTimerTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteYearMonthTimerTransition(IYearMonthTimerTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the user cancel transition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IUserCancelTransition IUserCancelTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, Transition.transitionType TransitionType = Transition.transitionType.Standard, List<string> additionalAttribute = null)
        {
            UserCancelTransition userCancelTransition = new UserCancelTransition(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute);

            userCancelTransition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(userCancelTransition.getModelComponentID(), userCancelTransition);

            return userCancelTransition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IUserCancelTransition getUserCancelTransition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<UserCancelTransition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteUserCancelTransition(IUserCancelTransition transition)
        {
            deleteAction(transition.getBelongsToAction());
            deleteState(transition.getSourceState());
            deleteState(transition.getTargetState());
            //deleteTransitionCondition(transition.getTransitionCondition());
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the transition condition and adds it to the corresponding subject behavior
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ITransitionCondition addTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", List<string> additionalAttribute = null)
        {

            TransitionCondition transitionCondition = new TransitionCondition(label, comment, toolSpecificDefintion, additionalAttribute);

            transitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(transitionCondition.getModelComponentID(), transitionCondition);

            return transitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ITransitionCondition getTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<TransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void deleteTransitionCondition(ITransitionCondition transition)
        {
            behaviorDescriptionComponent.Remove(transition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="messageExchange"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IMessageExchangeCondition addMessageExchangeCondition(string label, string comment = "", string toolSpecificDefintion = "", IMessageExchange messageExchange = null, List<string> additionalAttribute = null)
        {

            MessageExchangeCondition messageExchangeCondition = new MessageExchangeCondition(label, comment, toolSpecificDefintion, messageExchange, additionalAttribute);

            messageExchangeCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(messageExchangeCondition.getModelComponentID(), messageExchangeCondition);

            return messageExchangeCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IMessageExchangeCondition getMessageExchangeCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<MessageExchangeCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageExchangeCondition"></param>
        public void deleteMessageExchangeCondition(IMessageExchangeCondition messageExchangeCondition)
        {
            behaviorDescriptionComponent.Remove(messageExchangeCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="messageExchange"></param>
        /// <param name="upperBound"></param>
        /// <param name="lowerBound"></param>
        /// <param name="receiveType"></param>
        /// <param name="requiredMessageSendFromSubject"></param>
        /// <param name="requiresReceptionOfMessage"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IReceiveTransitionCondition addReceiveTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", IMessageExchange messageExchange = null, int upperBound = 0, int lowerBound = 0, IReceiveType receiveType = null, ISubject requiredMessageSendFromSubject = null, IMessageSpecification requiresReceptionOfMessage = null, List<string> additionalAttribute = null)
        {

            ReceiveTransitionCondition receiveTransitionCondition = new ReceiveTransitionCondition(label, comment, toolSpecificDefintion, messageExchange, upperBound, lowerBound, receiveType, requiredMessageSendFromSubject, requiresReceptionOfMessage, additionalAttribute);

            receiveTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(receiveTransitionCondition.getModelComponentID(), receiveTransitionCondition);

            return receiveTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IReceiveTransitionCondition getReceiveTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ReceiveTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveTransitionCondition"></param>
        public void deleteReceiveTransitionCondition(IReceiveTransitionCondition receiveTransitionCondition)
        {
            deleteReceiveType(receiveTransitionCondition.getReceiveType());
            behaviorDescriptionComponent.Remove(receiveTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="messageExchange"></param>
        /// <param name="upperBound"></param>
        /// <param name="lowerBound"></param>
        /// <param name="sendType"></param>
        /// <param name="requiredMessageSendToSubject"></param>
        /// <param name="requiresSendingOfMessage"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ISendTransitionCondition ISendTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", IMessageExchange messageExchange = null, int upperBound = 0, int lowerBound = 0, ISendType sendType = null, ISubject requiredMessageSendToSubject = null, IMessageSpecification requiresSendingOfMessage = null, List<string> additionalAttribute = null)
        {

            SendTransitionCondition sendTransitionCondition = new SendTransitionCondition(label, comment, toolSpecificDefintion, messageExchange, upperBound, lowerBound, sendType, requiredMessageSendToSubject, requiresSendingOfMessage, additionalAttribute);

            sendTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(sendTransitionCondition.getModelComponentID(), sendTransitionCondition);

            return sendTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ISendTransitionCondition getSendTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<SendTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendTransitionCondition"></param>
        public void deleteSendTransitionCondition(ISendTransitionCondition sendTransitionCondition)
        {
            deleteSendType(sendTransitionCondition.getSendType());
            behaviorDescriptionComponent.Remove(sendTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ISendingFailedCondition addSendingFailedCondition(string label, string comment = "", string toolSpecificDefintion = "", List<string> additionalAttribute = null)
        {

            SendingFailedCondition sendingFailedCondition = new SendingFailedCondition(label, comment, toolSpecificDefintion, additionalAttribute);

            sendingFailedCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(sendingFailedCondition.getModelComponentID(), sendingFailedCondition);

            return sendingFailedCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ISendingFailedCondition getSendingFailedCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<SendingFailedCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendingFailedCondition"></param>
        public void deleteSendingFailedCondition(ISendingFailedCondition sendingFailedCondition)
        {
            behaviorDescriptionComponent.Remove(sendingFailedCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ITimeTransitionCondition addTimeTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null)
        {

            TimeTransitionCondition timeTransitionCondition = new TimeTransitionCondition(label, comment, toolSpecificDefintion, timeValue, additionalAttribute);

            timeTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(timeTransitionCondition.getModelComponentID(), timeTransitionCondition);

            return timeTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ITimeTransitionCondition getTimeTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<TimeTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeTransitionCondition"></param>
        public void deleteTimeTransitionCondition(ITimeTransitionCondition timeTransitionCondition)
        {
            behaviorDescriptionComponent.Remove(timeTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IReminderEventTransitionCondition addReminderEventTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null)
        {

            ReminderEventTransitionCondition reminderEventTransitionCondition = new ReminderEventTransitionCondition(label, comment, toolSpecificDefintion, timeValue, additionalAttribute);

            reminderEventTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(reminderEventTransitionCondition.getModelComponentID(), reminderEventTransitionCondition);

            return reminderEventTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IReminderEventTransitionCondition getReminderEventTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<ReminderEventTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reminderEventTransitionCondition"></param>
        public void deleteReminderEventTransitionCondition(IReminderEventTransitionCondition reminderEventTransitionCondition)
        {
            behaviorDescriptionComponent.Remove(reminderEventTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ICalenderBasedReminderTransitionCondition addCalenderBasedReminderTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null)
        {

            CalenderBasedReminderTransitionCondition calenderBasedReminderTransitionCondition = new CalenderBasedReminderTransitionCondition(label, comment, toolSpecificDefintion, timeValue, additionalAttribute);

            calenderBasedReminderTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(calenderBasedReminderTransitionCondition.getModelComponentID(), calenderBasedReminderTransitionCondition);

            return calenderBasedReminderTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ICalenderBasedReminderTransitionCondition getCalenderBasedReminderTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<CalenderBasedReminderTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="calenderBasedReminderTransitionCondition"></param>
        public void deleteCalenderBasedReminderTransitionCondition(ICalenderBasedReminderTransitionCondition calenderBasedReminderTransitionCondition)
        {
            behaviorDescriptionComponent.Remove(calenderBasedReminderTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public ITimerTransitionCondition addTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null)
        {

            TimerTransitionCondition timerTransitionCondition = new TimerTransitionCondition(label, comment, toolSpecificDefintion, timeValue, additionalAttribute);

            timerTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(timerTransitionCondition.getModelComponentID(), timerTransitionCondition);

            return timerTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public ITimerTransitionCondition GetTimerTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<TimeTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timerTransitionCondition"></param>
        public void deleteTimerTransitionCondition(ITimerTransitionCondition timerTransitionCondition)
        {
            behaviorDescriptionComponent.Remove(timerTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public BuisnessDayTimerTransitionCondition addBusinessDayTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null)
        {

            BuisnessDayTimerTransitionCondition buisnessDayTimerTransitionCondition = new BuisnessDayTimerTransitionCondition(label, comment, toolSpecificDefintion, timeValue, additionalAttribute);

            buisnessDayTimerTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(buisnessDayTimerTransitionCondition.getModelComponentID(), buisnessDayTimerTransitionCondition);

            return buisnessDayTimerTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public BuisnessDayTimerTransitionCondition getBusinessDayTimerTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<BuisnessDayTimerTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buisnessDayTimerTransitionCondition"></param>
        public void deleteBuisnessDayTimerTransitionCondition(BuisnessDayTimerTransitionCondition buisnessDayTimerTransitionCondition)
        {
            behaviorDescriptionComponent.Remove(buisnessDayTimerTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public DayTimeTimerTransitionCondition addDayTimeTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null)
        {

            DayTimeTimerTransitionCondition dayTimeTimerTransitionCondition = new DayTimeTimerTransitionCondition(label, comment, toolSpecificDefintion, timeValue, additionalAttribute);

            //dayTimeTimerTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(dayTimeTimerTransitionCondition.getModelComponentID(), dayTimeTimerTransitionCondition);

            return dayTimeTimerTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public DayTimeTimerTransitionCondition getDayTimeTimerTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<DayTimeTimerTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayTimerTransitionCondition"></param>
        public void deleteDayTimeTimerTransitionCondition(DayTimeTimerTransitionCondition dayTimerTransitionCondition)
        {
            behaviorDescriptionComponent.Remove(dayTimerTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public IYearMonthTimerTransitionCondition addYearMonthTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null)
        {

            YearMonthTimerTransitionCondition yearMonthTimerTransitionCondition = new YearMonthTimerTransitionCondition(label, comment, toolSpecificDefintion, timeValue, additionalAttribute);

            yearMonthTimerTransitionCondition.setBelongsToSubjectBehavior(this);

            behaviorDescriptionComponent.Add(yearMonthTimerTransitionCondition.getModelComponentID(), yearMonthTimerTransitionCondition);

            return yearMonthTimerTransitionCondition;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public IYearMonthTimerTransitionCondition getYearMonthTimerTransitionCondition(int numberOfElement)
        {
            return behaviorDescriptionComponent.Values.OfType<YearMonthTimerTransitionCondition>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearMonthTimerTransitionCondition"></param>
        public void deleteYearMonthTimerTransitionCondition(IYearMonthTimerTransitionCondition yearMonthTimerTransitionCondition)
        {
            behaviorDescriptionComponent.Remove(yearMonthTimerTransitionCondition.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {
                if (s.ToLower().Contains("hasBehaviorDescriptionComponent"))
                {
                    tmpBehaviorDescriptionComponent = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasEndState"))
                {
                    tmpEndState = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasInitialStateOfBehavior"))
                {
                    tmpInitialStateOfBehavior = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasPriorityNumber"))
                {
                    tmpPriorityNumber = attribute[counter];
                    tmpPriorityNumber = tmpPriorityNumber.Split('^')[0];
                    priorityNumber = Int32.Parse(tmpPriorityNumber);
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

            foreach (int i in toBeRemoved)
            {
                if (i < attribute.Count)
                {
                    attribute.RemoveAt(i);
                    attributeType.RemoveAt(i);
                }

            }

            setAdditionalAttribute(attribute);
            setAdditionalAttributeType(attributeType);

            return result;

        }

        /// <summary>
        /// Method that sets the Object Properties of the created Objects, it first takes the base Class to this and asks if the Object can take 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        /// 
        public override void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp)
        {
            base.completeObject(ref allElements, ref tmp);

            foreach (string s in tmp)
            {

                if (allElements.ContainsKey(s))
                {
                    if (new BehaviorDescriptionComponent().GetType().IsInstanceOfType(allElements[s]) && !(behaviorDescriptionComponent.ContainsKey(allElements[s].getModelComponentID())))
                    {
                        this.behaviorDescriptionComponent.Add(allElements[s].getModelComponentID(), (BehaviorDescriptionComponent)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);

                        if (getAdditionalAttribute().IndexOf(s) >= 0 && getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("contains"))
                        {
                            place = getAdditionalAttribute().IndexOf(s);
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }

                    }

                    if (new EndState().GetType().IsInstanceOfType(allElements[s]))
                    {
                        if (getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("EndState"))
                        {
                            this.endState = (EndState)allElements[s];
                            int place = getAdditionalAttribute().IndexOf(s);
                            if (place >= 0)
                            {
                                getAdditionalAttributeType().RemoveAt(place);
                                getAdditionalAttribute().Remove(s);
                            }
                        }
                        //tmp.Remove(s);
                    }

                    if (new InitialStateOfBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.initialStateOfBehavior = (InitialStateOfBehavior)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> getAllStringAttributes()
        {
            List<string> stringAttributes = new List<string>();
            stringAttributes.Add(tmpBehaviorDescriptionComponent);
            stringAttributes.Add(tmpEndState);
            stringAttributes.Add(tmpInitialStateOfBehavior);

            return stringAttributes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public override void export(ref Graph g)
        {
            base.export(ref g);
            //Graph g = new Graph();
            INode subject;
            INode predicate;
            INode objec;
            Triple test;

            string nameString = getModelComponentID();

            Uri name = new Uri(nameString);
            //Console.WriteLine(name);
            //Console.WriteLine();

            foreach (KeyValuePair<string, BehaviorDescriptionComponent> s in this.behaviorDescriptionComponent)
            {
                if (s.Value != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("standard-pass-ont:contains");
                    objec = g.CreateUriNode("standard-pass-ont:" + s.Value.getModelComponentID());

                    test = new Triple(subject, predicate, objec);
                    g.Assert(test);

                    //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
                }
            }

            if (this.endState != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasEndState");
                objec = g.CreateUriNode("standard-pass-ont:" + this.endState.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);

            }

            if (this.initialStateOfBehavior != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasInitialStateOfBehavior");
                objec = g.CreateUriNode("standard-pass-ont:" + this.initialStateOfBehavior.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (this.priorityNumber >= 0)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasPriorityNumber");
                objec = g.CreateUriNode("standard-pass-ont:" + this.priorityNumber);

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (priorityNumber > -1)
                {
                    sw.WriteLine("      <standard-pass-ont:hasPriorityNumber rdf:datatype=\"http://www.w3.org/2001/XMLSchema#positiveInteger\" >" + priorityNumber + "</standard-pass-ont:hasPriorityNumber>");
                }

                if (endState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasEndState" + " rdf:resource=\"" + endState.getModelComponentID() + "\" ></standard-pass-ont:hasEndState>");
                }

                if (initialStateOfBehavior != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasInitialStateOfBehavior" + " rdf:resource=\"" + initialStateOfBehavior.getModelComponentID() + "\" ></standard-pass-ont:hasInitialStateOfBehavior>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
