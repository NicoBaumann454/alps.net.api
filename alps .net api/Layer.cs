using System;
using System.Collections.Generic;

namespace alps.net_api
{
    class Layer : PASSProcessModelElement
    {
        private List<FullySpecifiedSubject> fullySpecifiedSubjects = new List<FullySpecifiedSubject>();
        private List<Subject> subjects = new List<Subject>();
        private List<InterfaceSubject> interfaceSubjects = new List<InterfaceSubject>();
        private List<MultiSubject> multiSubjects = new List<MultiSubject>();
        private List<MessageExchange> messageExchanges = new List<MessageExchange>();
        private List<State> states = new List<State>();
        private List<Transition> transitions = new List<Transition>();
        private List<DoState> doStates = new List<DoState>();
        private List<SendState> sendStates = new List<SendState>();
        private List<ReceiveState> receiveStates = new List<ReceiveState>();
        private List<SubjectBehavior> subjectBehaviors = new List<SubjectBehavior>();
        private List<SubjectBaseBehavior> subjectBaseBehaviors = new List<SubjectBaseBehavior>();
        private List<InputPoolConstraint> inputPoolConstraints = new List<InputPoolConstraint>();
        private List<SubjectDataDefinition> subjectDataDefinitions = new List<SubjectDataDefinition>();
        private List<MessageSpecification> messageSpecifications = new List<MessageSpecification>();
        private List<BehaviorDescriptionComponent> behaviorDescriptionComponents = new List<BehaviorDescriptionComponent>();
        private List<InitialStateOfBehavior> initialStateOfBehaviors = new List<InitialStateOfBehavior>();
        private List<SendTransition> sendTransitions = new List<SendTransition>();
        private List<ReceiveTransition> receiveTransitions = new List<ReceiveTransition>();
        private List<DataMappingIncomingToLocal> dataMappingIncomingToLocals = new List<DataMappingIncomingToLocal>();
        private List<ReceiveTransitionCondition> receiveTransitionConditions = new List<ReceiveTransitionCondition>();
        private List<MessageExchangeCondition> messageExchangeConditions = new List<MessageExchangeCondition>();
        private List<Action> actions = new List<Action>();
        private List<TransitionCondition> transitionConditions = new List<TransitionCondition>();


        private List<OwlThing> owlThings = new List<OwlThing>();

        private Dictionary<string, Action> actions1 = new Dictionary<string, Action>();
        private Dictionary<string, BehaviorDescriptionComponent> behaviorDescriptionComponents1 = new Dictionary<string, BehaviorDescriptionComponent>();
        private Dictionary<string, BuisnessDayTimerTransition> buisnessDayTimerTransitions = new Dictionary<string, BuisnessDayTimerTransition>();
        private Dictionary<string, BuisnessDayTimerTransitionCondition> buisnessDayTimerTransitionConditions = new Dictionary<string, BuisnessDayTimerTransitionCondition>();
        private Dictionary<string, CalenderBasedReminderTransition> calenderBasedReminderTransitions = new Dictionary<string, CalenderBasedReminderTransition>();
        private Dictionary<string, CalenderBasedReminderTransitionCondition> calenderBasedReminderTransitionConditions = new Dictionary<string, CalenderBasedReminderTransitionCondition>();
        private Dictionary<string, ChoiceSegment> choiceSements = new Dictionary<string, ChoiceSegment>();
        private Dictionary<string, ChoiceSegmentPath> choiceSegmentPaths = new Dictionary<string, ChoiceSegmentPath>();
        private Dictionary<string, CommunicationAct> communicationActs = new Dictionary<string, CommunicationAct>();
        private Dictionary<string, CommunicationTransition> communicationTransitions = new Dictionary<string, CommunicationTransition>();
        private Dictionary<string, CustomOrExternalDataTypeDefinition> customOrExternalDataTypeDefintions = new Dictionary<string, CustomOrExternalDataTypeDefinition>();
        private Dictionary<string, DataDescribingComponent> dataDescriptionComponents = new Dictionary<string, DataDescribingComponent>();
        private Dictionary<string, DataMappingFunction> dataMappingFunctions = new Dictionary<string, DataMappingFunction>();
        private Dictionary<string, DataMappingIncomingToLocal> dataMappingIncomingToLocals1 = new Dictionary<string, DataMappingIncomingToLocal>();
        private Dictionary<string, DataMappingLocalToOutgoing> dataMappingLocalToOutgoings = new Dictionary<string, DataMappingLocalToOutgoing>();
        private Dictionary<string, DataObjectDefinition> dataObjectDefinitions = new Dictionary<string, DataObjectDefinition>();
        private Dictionary<string, DataObjectListDefiniton> dataObjectListDefinitons = new Dictionary<string, DataObjectListDefiniton>();
        private Dictionary<string, DataTypeDefinition> dataTypeDefinitions = new Dictionary<string, DataTypeDefinition>();
        private Dictionary<string, DayTimerTransitionCondition> dayTimerTransitionConditions = new Dictionary<string, DayTimerTransitionCondition>();
        private Dictionary<string, DayTimeTimerTransition> dayTimeTimerTransitions = new Dictionary<string, DayTimeTimerTransition>();
        private Dictionary<string, DayTimeTimerTransitionCondition> dayTimeTimerTransitionConditions = new Dictionary<string, DayTimeTimerTransitionCondition>();
        private Dictionary<string, DoFunction> doFunctions = new Dictionary<string, DoFunction>();
        private Dictionary<string, DoState> doStates1 = new Dictionary<string, DoState>();
        private Dictionary<string, DoTransition> doTransitions = new Dictionary<string, DoTransition>();
        private Dictionary<string, DoTransitionCondition> doTransitionConditions = new Dictionary<string, DoTransitionCondition>();
        private Dictionary<string, EndState> endStates = new Dictionary<string, EndState>();
        private Dictionary<string, FullySpecifiedSubject> fullySpecifiedSubjects1 = new Dictionary<string, FullySpecifiedSubject>();
        private Dictionary<string, FunctionSpecification> functionSpecifications = new Dictionary<string, FunctionSpecification>();
        private Dictionary<string, GenericReturnToOriginReference> genericReturnToOriginReferences = new Dictionary<string, GenericReturnToOriginReference>();
        private Dictionary<string, GuardBehavior> guardBehaviors = new Dictionary<string, GuardBehavior>();
        private Dictionary<string, InitialStateOfBehavior> initialStateOfBehaviors1 = new Dictionary<string, InitialStateOfBehavior>();
        private Dictionary<string, InitialStateOfChoiceSegmentPath> initialStateOfChoiceSegmentPaths = new Dictionary<string, InitialStateOfChoiceSegmentPath>();
        private Dictionary<string, InputPoolConstraint> inputPoolConstraints1 = new Dictionary<string, InputPoolConstraint>();
        private Dictionary<string, InputPoolConstraintHandlingStrategy> inputPoolConstraintHandlingStrategys = new Dictionary<string, InputPoolConstraintHandlingStrategy>();
        private Dictionary<string, InteractionDescriptionComponent> interactionDescriptionComponents = new Dictionary<string, InteractionDescriptionComponent>();
        private Dictionary<string, InterfaceSubject> interfaceSubjects1 = new Dictionary<string, InterfaceSubject>();
        private Dictionary<string, JSONDataTypeDefinition> jSONDataTypeDefintions = new Dictionary<string, JSONDataTypeDefinition>();
        private Dictionary<string, MacroBehavior> macroBehaviors = new Dictionary<string, MacroBehavior>();
        private Dictionary<string, MacroState> macrostates = new Dictionary<string, MacroState>();
        private Dictionary<string, MandatoryToEndChoiceSegment> mandatoryToEndChoiceSegments = new Dictionary<string, MandatoryToEndChoiceSegment>();
        private Dictionary<string, MandatoryToStartChoiceSegment> mandatoryToStartChoiceSegments = new Dictionary<string, MandatoryToStartChoiceSegment>();
        private Dictionary<string, MessageExchange> messageExchanges1 = new Dictionary<string, MessageExchange>();
        private Dictionary<string, MessageExchangeCondition> messageExchangeConditions1 = new Dictionary<string, MessageExchangeCondition>();
        private Dictionary<string, MessageExchangeList> messageExchangeLists = new Dictionary<string, MessageExchangeList>();
        private Dictionary<string, MessageSenderTypeConstraint> messageSenderTypeConstraints = new Dictionary<string, MessageSenderTypeConstraint>();
        private Dictionary<string, MessageSpecification> messageSpecifications1 = new Dictionary<string, MessageSpecification>();
        private Dictionary<string, MessageTypeConstraint> messageTypeConstraints = new Dictionary<string, MessageTypeConstraint>();
        private Dictionary<string, ModelBuiltInDataTypes> modelBuiltInDataTypess = new Dictionary<string, ModelBuiltInDataTypes>();
        private Dictionary<string, MultiSubject> multiSubjects1 = new Dictionary<string, MultiSubject>();
        private Dictionary<string, OptionalToEndChoiceSegmentPath> optionalToEndChoiceSegmentPaths = new Dictionary<string, OptionalToEndChoiceSegmentPath>();
        private Dictionary<string, OptionalToStartChoiceSegmentPath> optionalToStartChoiceSegmentPaths = new Dictionary<string, OptionalToStartChoiceSegmentPath>();
        private Dictionary<string, OWLDataTypeDefintion> oWLDataTypeDefintions = new Dictionary<string, OWLDataTypeDefintion>();
        private Dictionary<string, PayloadDataObjectDefinition> payloadDataObjectDefinitions = new Dictionary<string, PayloadDataObjectDefinition>();
        private Dictionary<string, PayloadDescription> payloadDescriptions = new Dictionary<string, PayloadDescription>();
        //Das muss noch implementiert werden
        private Dictionary<string, ReceiveFunction> receiveFunctions = new Dictionary<string, ReceiveFunction>();
        private Dictionary<string, ReceiveState> receiveStates1 = new Dictionary<string, ReceiveState>();
        private Dictionary<string, ReceiveTransition> receiveTransitions1 = new Dictionary<string, ReceiveTransition>();
        private Dictionary<string, ReceiveTransitionCondition> receiveTransitionConditions1 = new Dictionary<string, ReceiveTransitionCondition>();
        private Dictionary<string, ReceiveType> receiveTypes = new Dictionary<string, ReceiveType>();
        private Dictionary<string, ReminderEventTransitionCondition> reminderEventTransitionConditions = new Dictionary<string, ReminderEventTransitionCondition>();
        private Dictionary<string, ReminderTransition> reminderTransitions = new Dictionary<string, ReminderTransition>();
        private Dictionary<string, SenderTypeConstraint> senderTypeConstraints = new Dictionary<string, SenderTypeConstraint>();
        private Dictionary<string, SendFunction> sendFunctions = new Dictionary<string, SendFunction>();
        private Dictionary<string, SendingFailedCondition> sendingFailedConditions = new Dictionary<string, SendingFailedCondition>();
        private Dictionary<string, SendingFailedTransition> sendingFailedTransitions = new Dictionary<string, SendingFailedTransition>();
        private Dictionary<string, SendState> sendStates1 = new Dictionary<string, SendState>();
        private Dictionary<string, SendTransition> sendTransitions1 = new Dictionary<string, SendTransition>();
        private Dictionary<string, SendTransitionCondition> sendTransitionConditions = new Dictionary<string, SendTransitionCondition>();
        private Dictionary<string, SendType> sendTypes = new Dictionary<string, SendType>();
        private Dictionary<string, SingleSubject> singleSubjects = new Dictionary<string, SingleSubject>();
        private Dictionary<string, StandartPASSState> standartPASSStates = new Dictionary<string, StandartPASSState>();
        private Dictionary<string, StartSubject> startSubjects = new Dictionary<string, StartSubject>();
        private Dictionary<string, State> states1 = new Dictionary<string, State>();
        private Dictionary<string, StateReference> stateReferences = new Dictionary<string, StateReference>();
        private Dictionary<string, Subject> subjects1 = new Dictionary<string, Subject>();
        private Dictionary<string, SubjectBaseBehavior> subjectBaseBahaviors1 = new Dictionary<string, SubjectBaseBehavior>();
        private Dictionary<string, SubjectBehavior> subjectBehaviors1 = new Dictionary<string, SubjectBehavior>();
        private Dictionary<string, SubjectDataDefinition> subjectDataDefintions1 = new Dictionary<string, SubjectDataDefinition>();
        private Dictionary<string, TimeBasedReminderTransition> timeBasedReminderTransitions = new Dictionary<string, TimeBasedReminderTransition>();
        private Dictionary<string, TimeBasedReminderTransitionCondition> timeBasedReminderTransitionConditions = new Dictionary<string, TimeBasedReminderTransitionCondition>();
        private Dictionary<string, TimerTransition> timerTransitions = new Dictionary<string, TimerTransition>();
        private Dictionary<string, TimerTransitionCondition> timerTransitionConditions = new Dictionary<string, TimerTransitionCondition>();
        private Dictionary<string, TimeTransition> timeTransitions = new Dictionary<string, TimeTransition>();
        private Dictionary<string, TimeTransitionCondition> timeTransitionConditions = new Dictionary<string, TimeTransitionCondition>();
        private Dictionary<string, Transition> transitions1 = new Dictionary<string, Transition>();
        private Dictionary<string, TransitionCondition> transitionConditions1 = new Dictionary<string, TransitionCondition>();
        private Dictionary<string, UserCancelTransition> userCancelTransitions = new Dictionary<string, UserCancelTransition>();
        private Dictionary<string, XSDDataTypeDefintion> xSDDataTypeDefintions = new Dictionary<string, XSDDataTypeDefintion>();
        private Dictionary<string, YearMonthTimerTransition> yearMonthTimerTransitions = new Dictionary<string, YearMonthTimerTransition>();
        private Dictionary<string, YearMonthTimerTransitionCondition> yearMonthTimerTransitionCondtions = new Dictionary<string, YearMonthTimerTransitionCondition>();

        public Layer()
        {

        }

        public void Add(FullySpecifiedSubject fullySpecifiedSubject)
        {
            fullySpecifiedSubjects.Add(fullySpecifiedSubject);
        }

        public void Add(Subject subject)
        {
            subjects.Add(subject);
        }

        public void Add(MultiSubject multiSubject)
        {
            multiSubjects.Add(multiSubject);
        }

        public void Add(InterfaceSubject interfaceSubject)
        {
            interfaceSubjects.Add(interfaceSubject);
        }

        public void Add(MessageExchange messageExchange)
        {
            messageExchanges.Add(messageExchange);
        }

        public void Add(SendState sendState)
        {
            sendStates.Add(sendState);
        }

        public void Add(string key, SendState sendState)
        {
            if (!sendStates1.ContainsKey(key))
            {
                sendStates1.Add(key, sendState);
            }

        }

        public void Add(ReceiveState receiveState)
        {
            receiveStates.Add(receiveState);
        }

        public void Add(string key, ReceiveState receiveState)
        {
            if (!receiveStates1.ContainsKey(key))
            {
                receiveStates1.Add(key, receiveState);
            }
        }

        public void Add(DoState doState)
        {
            doStates.Add(doState);
        }

        public void Add(string key, DoState doState)
        {
            if (!doStates1.ContainsKey(key))
            {
                doStates1.Add(key, doState);
            }
        }

        public void Add(Transition transition)
        {
            transitions.Add(transition);
        }

        public void Add(string key, Transition transition)
        {
            if (!transitions1.ContainsKey(key))
            {
                transitions1.Add(key, transition);
            }
        }

        public void Add(SubjectBehavior subjectBehavior)
        {
            subjectBehaviors.Add(subjectBehavior);
        }

        public void Add(string key, SubjectBehavior subjectBehavior)
        {
            if (!subjectBehaviors1.ContainsKey(key))
            {
                subjectBehaviors1.Add(key, subjectBehavior);
            }

        }

        public void Add(SubjectBaseBehavior subjectBaseBehavior)
        {
            subjectBaseBehaviors.Add(subjectBaseBehavior);
        }

        public void Add(string key, SubjectBaseBehavior subjectBaseBehavior)
        {
            if (!subjectBaseBahaviors1.ContainsKey(key))
            {
                subjectBaseBahaviors1.Add(key, subjectBaseBehavior);
            }

        }

        public void Add(InitialStateOfBehavior initialStateOfBehavior)
        {
            initialStateOfBehaviors.Add(initialStateOfBehavior);
        }

        public void Add(string key, InitialStateOfBehavior initialStateOfBehavior)
        {
            if (!initialStateOfBehaviors1.ContainsKey(key))
            {
                initialStateOfBehaviors1.Add(key, initialStateOfBehavior);
            }

        }

        public void Add(BehaviorDescriptionComponent behaviorDescriptionComponent)
        {
            behaviorDescriptionComponents.Add(behaviorDescriptionComponent);
        }

        public void Add(string key, BehaviorDescriptionComponent behaviorDescriptionComponent)
        {
            if (!behaviorDescriptionComponents1.ContainsKey(key))
            {
                behaviorDescriptionComponents1.Add(key, behaviorDescriptionComponent);
            }

        }

        public void Add(ReceiveTransition receiveTransition)
        {
            receiveTransitions.Add(receiveTransition);
        }

        public void Add(string key, ReceiveTransition receiveTransition)
        {
            if (!receiveTransitions1.ContainsKey(key))
            {
                receiveTransitions1.Add(key, receiveTransition);
            }
        }

        public void Add(DataMappingIncomingToLocal dataMappingIncomingToLocal)
        {
            dataMappingIncomingToLocals.Add(dataMappingIncomingToLocal);
        }

        public void Add(string key, DataMappingIncomingToLocal dataMappingIncomingToLocal)
        {
            if (!dataMappingIncomingToLocals1.ContainsKey(key))
            {
                dataMappingIncomingToLocals1.Add(key, dataMappingIncomingToLocal);
            }

        }

        public void Add(ReceiveTransitionCondition receiveTransitionCondition)
        {
            receiveTransitionConditions.Add(receiveTransitionCondition);
        }

        public void Add(string key, ReceiveTransitionCondition receiveTransitionCondition)
        {
            if (!receiveTransitionConditions1.ContainsKey(key))
            {
                receiveTransitionConditions1.Add(key, receiveTransitionCondition);
            }

        }

        public void Add(MessageExchangeCondition messageExchangeCondition)
        {
            messageExchangeConditions.Add(messageExchangeCondition);
        }

        public void Add(string key, MessageExchangeCondition messageExchangeCondition)
        {
            if (!messageExchangeConditions1.ContainsKey(key))
            {
                messageExchangeConditions1.Add(key, messageExchangeCondition);
            }
        }

        public void Add(Action action)
        {
            actions.Add(action);
        }

        public void Add(string key, Action action)
        {
            if (!actions1.ContainsKey(key))
            {
                actions1.Add(key, action);
            }

        }

        public void Add(string key, FullySpecifiedSubject fullySpecifiedSubject)
        {

            if (!fullySpecifiedSubjects1.ContainsKey(key))
            {
                fullySpecifiedSubjects1.Add(key, fullySpecifiedSubject);
            }
        }

        public void Add(string key, MessageExchange messageExchange)
        {
            if (!messageExchanges1.ContainsKey(key))
            {
                messageExchanges1.Add(key, messageExchange);
            }

        }

        public void Add(string key, State state)
        {
            if (!states1.ContainsKey(key))
            {
                states1.Add(key, state);
            }
        }

        public void Add(string key, FunctionSpecification functionSpecification)
        {
            if (!functionSpecifications.ContainsKey(key))
            {
                functionSpecifications.Add(key, functionSpecification);
            }
        }

        public void Add(string key, GuardBehavior guardBehavior)
        {
            if (!guardBehaviors.ContainsKey(key))
            {
                guardBehaviors.Add(key, guardBehavior);
            }
        }

        public void Add(string key, DataMappingLocalToOutgoing dataMappingLocalToOutgoing)
        {
            if (!dataMappingLocalToOutgoings.ContainsKey(key))
            {
                dataMappingLocalToOutgoings.Add(key, dataMappingLocalToOutgoing);
            }
        }

        public void Add(string key, SendingFailedTransition sendingFailedTransition)
        {
            if (!sendingFailedTransitions.ContainsKey(key))
            {
                sendingFailedTransitions.Add(key, sendingFailedTransition);
            }
        }

        public void Add(string key, PayloadDescription payloadDescription)
        {
            if (!payloadDescriptions.ContainsKey(key))
            {
                payloadDescriptions.Add(key, payloadDescription);
            }
        }

        public void Add(string key, DoTransition doTransition)
        {
            if (!doTransitions.ContainsKey(key))
            {
                doTransitions.Add(key, doTransition);
            }
        }

        public void Add(string key, ReceiveType receiveType)
        {
            if (!receiveTypes.ContainsKey(key))
            {
                receiveTypes.Add(key, receiveType);
            }
        }

        public void Add(string key, Subject subject)
        {
            if (!subjects1.ContainsKey(key))
            {
                subjects1.Add(key, subject);
            }
        }

        public void Add(string key, DataTypeDefinition dataTypeDefintion)
        {
            if (!dataTypeDefinitions.ContainsKey(key))
            {
                dataTypeDefinitions.Add(key, dataTypeDefintion);
            }
        }

        public void Add(string key, DataObjectDefinition dataObjectDefiniton)
        {
            if (!dataObjectDefinitions.ContainsKey(key))
            {
                dataObjectDefinitions.Add(key, dataObjectDefiniton);
            }
        }

        public void Add(string key, SendingFailedCondition sendingFailedCondition)
        {
            if (!sendingFailedConditions.ContainsKey(key))
            {
                sendingFailedConditions.Add(key, sendingFailedCondition);
            }
        }

        public void Add(string key, MessageSpecification messageSpecification)
        {
            if (!messageSpecifications1.ContainsKey(key))
            {
                messageSpecifications1.Add(key, messageSpecification);
            }
        }

        public void Add(string key, MessageExchangeList messageExchangeList)
        {
            if (!messageExchangeLists.ContainsKey(key))
            {
                messageExchangeLists.Add(key, messageExchangeList);
            }
        }

        public void Add(string key, MultiSubject multiSubject)
        {
            if (!multiSubjects1.ContainsKey(key))
            {
                multiSubjects1.Add(key, multiSubject);
            }
        }

        public void Add(string key, BuisnessDayTimerTransition buisnessDayTimerTransition)
        {
            if (!buisnessDayTimerTransitions.ContainsKey(key))
            {
                buisnessDayTimerTransitions.Add(key, buisnessDayTimerTransition);
            }
        }

        public void Add(string key, BuisnessDayTimerTransitionCondition buisnessDayTimerTransitionCondition)
        {
            if (!buisnessDayTimerTransitionConditions.ContainsKey(key))
            {
                buisnessDayTimerTransitionConditions.Add(key, buisnessDayTimerTransitionCondition);
            }
        }

        public void Add(string key, CalenderBasedReminderTransition calenderBasedReminderTransition)
        {
            if (!calenderBasedReminderTransitionConditions.ContainsKey(key))
            {
                calenderBasedReminderTransitions.Add(key, calenderBasedReminderTransition);
            }
        }

        public void Add(string key, CalenderBasedReminderTransitionCondition calenderBasedReminderTransitionCondition)
        {
            if (!calenderBasedReminderTransitionConditions.ContainsKey(key))
            {
                calenderBasedReminderTransitionConditions.Add(key, calenderBasedReminderTransitionCondition);
            }
        }

        public void Add(string key, ChoiceSegment choiceSegment)
        {
            if (!choiceSements.ContainsKey(key))
            {
                choiceSements.Add(key, choiceSegment);
            }
        }

        public void Add(string key, ChoiceSegmentPath choiceSegmentPath)
        {
            if (!choiceSegmentPaths.ContainsKey(key))
            {
                choiceSegmentPaths.Add(key, choiceSegmentPath);
            }
        }

        public void Add(string key, CommunicationAct communicationAct)
        {
            if (!communicationActs.ContainsKey(key))
            {
                communicationActs.Add(key, communicationAct);
            }
        }

        public void Add(string key, CommunicationTransition communicationTransition)
        {
            if (!communicationTransitions.ContainsKey(key))
            {
                communicationTransitions.Add(key, communicationTransition);
            }
        }

        public void Add(string key, CustomOrExternalDataTypeDefinition customOrExternalDataTypeDefintion)
        {
            if (!customOrExternalDataTypeDefintions.ContainsKey(key))
            {
                customOrExternalDataTypeDefintions.Add(key, customOrExternalDataTypeDefintion);
            }
        }

        public void Add(string key, DataDescribingComponent dataDescribingComponent)
        {
            if (!dataDescriptionComponents.ContainsKey(key))
            {
                dataDescriptionComponents.Add(key, dataDescribingComponent);
            }
        }

        public void Add(string key, DataMappingFunction dataMappingFunction)
        {
            if (!dataMappingFunctions.ContainsKey(key))
            {
                dataMappingFunctions.Add(key, dataMappingFunction);
            }
        }

        public void Add(string key, DataObjectListDefiniton dataObjectListDefiniton)
        {
            if (!dataObjectListDefinitons.ContainsKey(key))
            {
                dataObjectListDefinitons.Add(key, dataObjectListDefiniton);
            }
        }

        public void Add(string key, DayTimerTransitionCondition dayTimerTransitionCondition)
        {
            if (!dayTimerTransitionConditions.ContainsKey(key))
            {
                dayTimerTransitionConditions.Add(key, dayTimerTransitionCondition);
            }
        }

        public void Add(string key, DayTimeTimerTransition dayTimeTimerTransition)
        {
            if (!dayTimeTimerTransitions.ContainsKey(key))
            {
                dayTimeTimerTransitions.Add(key, dayTimeTimerTransition);
            }
        }

        public void Add(string key, DayTimeTimerTransitionCondition dayTimeTimerTransitionCondition)
        {
            if (!dayTimeTimerTransitionConditions.ContainsKey(key))
            {
                dayTimeTimerTransitionConditions.Add(key, dayTimeTimerTransitionCondition);
            }
        }

        public void Add(string key, DoFunction doFunction)
        {
            if (!doFunctions.ContainsKey(key))
            {
                doFunctions.Add(key, doFunction);
            }
        }

        public void Add(string key, DoTransitionCondition doTransitionCondition)
        {
            if (!doTransitionConditions.ContainsKey(key))
            {
                doTransitionConditions.Add(key, doTransitionCondition);
            }
        }

        public void Add(string key, GenericReturnToOriginReference genericReturnToOriginReference)
        {
            if (!genericReturnToOriginReferences.ContainsKey(key))
            {
                genericReturnToOriginReferences.Add(key, genericReturnToOriginReference);
            }
        }

        public void Add(string key, InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath)
        {
            if (!initialStateOfChoiceSegmentPaths.ContainsKey(key))
            {
                initialStateOfChoiceSegmentPaths.Add(key, initialStateOfChoiceSegmentPath);
            }
        }

        public void Add(string key, InteractionDescriptionComponent interactionDescriptionComponent)
        {
            if (!interactionDescriptionComponents.ContainsKey(key))
            {
                interactionDescriptionComponents.Add(key, interactionDescriptionComponent);
            }
        }

        public void Add(string key, InterfaceSubject interfaceSubject)
        {
            if (!interfaceSubjects1.ContainsKey(key))
            {
                interfaceSubjects1.Add(key, interfaceSubject);
            }
        }

        public void Add(string key, JSONDataTypeDefinition jSONDataTypeDefintion)
        {
            if (!jSONDataTypeDefintions.ContainsKey(key))
            {
                jSONDataTypeDefintions.Add(key, jSONDataTypeDefintion);
            }
        }

        public void Add(string key, MacroBehavior macroBehavior)
        {
            if (!macroBehaviors.ContainsKey(key))
            {
                macroBehaviors.Add(key, macroBehavior);
            }
        }

        public void Add(string key, MacroState macroState)
        {
            if (!macrostates.ContainsKey(key))
            {
                macrostates.Add(key, macroState);
            }
        }

        public void Add(string key, MandatoryToEndChoiceSegment mandatoryToEndChoiceSegment)
        {
            if (!mandatoryToEndChoiceSegments.ContainsKey(key))
            {
                mandatoryToEndChoiceSegments.Add(key, mandatoryToEndChoiceSegment);
            }
        }

        public void Add(string key, MandatoryToStartChoiceSegment mandatoryToStartChoiceSegment)
        {
            if (!mandatoryToStartChoiceSegments.ContainsKey(key))
            {
                mandatoryToStartChoiceSegments.Add(key, mandatoryToStartChoiceSegment);
            }
        }

        public void Add(string key, MessageSenderTypeConstraint messageSenderTypeConstraint)
        {
            if (!messageSenderTypeConstraints.ContainsKey(key))
            {
                messageSenderTypeConstraints.Add(key, messageSenderTypeConstraint);
            }
        }

        public void Add(string key, MessageTypeConstraint messageTypeConstraint)
        {
            if (!messageTypeConstraints.ContainsKey(key))
            {
                messageTypeConstraints.Add(key, messageTypeConstraint);
            }
        }

        public void Add(string key, ModelBuiltInDataTypes modelBuiltInDataTypes)
        {
            if (!modelBuiltInDataTypess.ContainsKey(key))
            {
                modelBuiltInDataTypess.Add(key, modelBuiltInDataTypes);
            }
        }

        public void Add(string key, OptionalToEndChoiceSegmentPath optionalToEndChoiceSegmentPath)
        {
            if (!optionalToEndChoiceSegmentPaths.ContainsKey(key))
            {
                optionalToEndChoiceSegmentPaths.Add(key, optionalToEndChoiceSegmentPath);
            }
        }

        public void Add(string key, OptionalToStartChoiceSegmentPath optionalToStartChoiceSegmentPath)
        {
            if (!optionalToStartChoiceSegmentPaths.ContainsKey(key))
            {
                optionalToStartChoiceSegmentPaths.Add(key, optionalToStartChoiceSegmentPath);
            }
        }

        public void Add(string key, OWLDataTypeDefintion oWLDataTypeDefintion)
        {
            if (!oWLDataTypeDefintions.ContainsKey(key))
            {
                oWLDataTypeDefintions.Add(key, oWLDataTypeDefintion);
            }
        }

        public void Add(string key, PayloadDataObjectDefinition payloadDataObjectDefinition)
        {
            if (!payloadDataObjectDefinitions.ContainsKey(key))
            {
                payloadDataObjectDefinitions.Add(key, payloadDataObjectDefinition);
            }
        }

        public void Add(string key, ReminderEventTransitionCondition reminderEventTransitionCondition)
        {
            if (!reminderEventTransitionConditions.ContainsKey(key))
            {
                reminderEventTransitionConditions.Add(key, reminderEventTransitionCondition);
            }
        }

        public void Add(string key, ReminderTransition reminderTransition)
        {
            if (!reminderTransitions.ContainsKey(key))
            {
                reminderTransitions.Add(key, reminderTransition);
            }
        }

        public void Add(string key, SenderTypeConstraint senderTypeConstraint)
        {
            if (!senderTypeConstraints.ContainsKey(key))
            {
                senderTypeConstraints.Add(key, senderTypeConstraint);
            }
        }

        public void Add(string key, SendFunction sendFunction)
        {
            if (!sendFunctions.ContainsKey(key))
            {
                sendFunctions.Add(key, sendFunction);
            }
        }

        public void Add(string key, SendType sendType)
        {
            if (!sendTypes.ContainsKey(key))
            {
                sendTypes.Add(key, sendType);
            }
        }

        public void Add(string key, SingleSubject singleSubject)
        {
            if (!singleSubjects.ContainsKey(key))
            {
                singleSubjects.Add(key, singleSubject);
            }
        }

        public void Add(string key, StandartPASSState standartPASSState)
        {
            if (!standartPASSStates.ContainsKey(key))
            {
                standartPASSStates.Add(key, standartPASSState);
            }
        }

        public void Add(string key, StartSubject startSubject)
        {
            if (!startSubjects.ContainsKey(key))
            {
                startSubjects.Add(key, startSubject);
            }
        }

        public void Add(string key, StateReference stateReference)
        {
            if (!stateReferences.ContainsKey(key))
            {
                stateReferences.Add(key, stateReference);
            }
        }

        public void Add(string key, TimeBasedReminderTransition timeBasedReminderTransition)
        {
            if (!timeBasedReminderTransitions.ContainsKey(key))
            {
                timeBasedReminderTransitions.Add(key, timeBasedReminderTransition);
            }
        }

        public void Add(string key, TimeBasedReminderTransitionCondition timeBasedReminderTransitionCondition)
        {
            if (!timeBasedReminderTransitionConditions.ContainsKey(key))
            {
                timeBasedReminderTransitionConditions.Add(key, timeBasedReminderTransitionCondition);
            }
        }

        public void Add(string key, TimerTransition timerTransition)
        {
            if (!timerTransitions.ContainsKey(key))
            {
                timerTransitions.Add(key, timerTransition);
            }
        }

        public void Add(string key, TimerTransitionCondition timerTransitionCondition)
        {
            if (!timerTransitionConditions.ContainsKey(key))
            {
                timerTransitionConditions.Add(key, timerTransitionCondition);
            }
        }

        public void Add(string key, TimeTransition timeTransition)
        {
            if (!timeTransitions.ContainsKey(key))
            {
                timeTransitions.Add(key, timeTransition);
            }
        }

        public void Add(string key, TimeTransitionCondition timeTransitionCondition)
        {
            if (!timeTransitionConditions.ContainsKey(key))
            {
                timeTransitionConditions.Add(key, timeTransitionCondition);
            }
        }

        public void Add(string key, UserCancelTransition userCancelTransition)
        {
            if (!userCancelTransitions.ContainsKey(key))
            {
                userCancelTransitions.Add(key, userCancelTransition);
            }
        }

        public void Add(string key, XSDDataTypeDefintion xSDDataTypeDefintion)
        {
            if (!xSDDataTypeDefintions.ContainsKey(key))
            {
                xSDDataTypeDefintions.Add(key, xSDDataTypeDefintion);
            }
        }

        public void Add(string key, YearMonthTimerTransition yearMonthTimerTransition)
        {
            if (!yearMonthTimerTransitions.ContainsKey(key))
            {
                yearMonthTimerTransitions.Add(key, yearMonthTimerTransition);
            }
        }

        public void Add(string key, YearMonthTimerTransitionCondition yearMonthTimerTransitionCondition)
        {
            if (!yearMonthTimerTransitionCondtions.ContainsKey(key))
            {
                yearMonthTimerTransitionCondtions.Add(key, yearMonthTimerTransitionCondition);
            }
        }

        public void completeObjects()
        {
            Console.WriteLine();

            foreach (KeyValuePair<string, FullySpecifiedSubject> f in fullySpecifiedSubjects1)
            {
                //Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                int i = 0;

                foreach (string s in tmp)
                {
                    Console.WriteLine(s);

                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setContainsBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (subjectBaseBahaviors1.ContainsKey(s))
                        {
                            f.Value.setContainsBaseBehavior(subjectBaseBahaviors1[s]);
                        }
                        else
                        {
                            if (inputPoolConstraints1.ContainsKey(s))
                            {
                                f.Value.setInputPoolConstraint(inputPoolConstraints1[s]);
                            }
                            else
                            {
                                if (subjectDataDefintions1.ContainsKey(s))
                                {
                                    f.Value.setDataDefintion(subjectDataDefintions1[s]);
                                }
                                else
                                {
                                    if (messageExchanges1.ContainsKey(s))
                                    {
                                        f.Value.setIncomingMessageExchange(messageExchanges1[s]);
                                    }
                                    else
                                    {
                                        if (messageExchanges1.ContainsKey(s))
                                        {
                                            f.Value.setIncomingMessageExchange(messageExchanges1[s]);
                                        }
                                        else
                                        {
                                            if (i > 0)
                                            {
                                                Console.WriteLine("WARNING: Encounterd unkown attribute, Attribute will only be set as a String, test");
                                            }
                                            i++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, MessageExchange> f in messageExchanges1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (messageSpecifications1.ContainsKey(s))
                    {
                        f.Value.setMessageType(messageSpecifications1[s]);
                    }
                    else
                    {
                        if (fullySpecifiedSubjects1.ContainsKey(s))
                        {
                            f.Value.setReceiver(fullySpecifiedSubjects1[s]);
                        }
                        else
                        {
                            if (fullySpecifiedSubjects1.ContainsKey(s))
                            {
                                f.Value.setSender(fullySpecifiedSubjects1[s]);
                            }
                            else
                            {
                                Console.WriteLine("WARNING: Encounterd unkown attribute, Attribute will only be set as a String, test1");
                            }

                        }
                    }
                }

            }

            foreach (KeyValuePair<string, SubjectBehavior> f in subjectBehaviors1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (behaviorDescriptionComponents1.ContainsKey(s))
                    {
                        f.Value.setContainsBehaviorDescribingComponent(behaviorDescriptionComponents1[s]);
                    }
                    else
                    {
                        if (states1.ContainsKey(s))
                        {
                            f.Value.setEndState(states1[s]);
                        }
                        else
                        {
                            if (initialStateOfBehaviors1.ContainsKey(s))
                            {
                                f.Value.setInitialState(initialStateOfBehaviors1[s]);
                            }
                            else
                            {
                                Console.WriteLine("WARNING: Encounterd unkown attribute, Attribute will only be set as a String, test2");
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, ReceiveTransition> f in receiveTransitions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (dataMappingIncomingToLocals1.ContainsKey(s))
                    {
                        f.Value.setDataMappingFunctionIncomingToLocal(dataMappingIncomingToLocals1[s]);
                    }
                    else
                    {
                        if (messageExchangeConditions1.ContainsKey(s))
                        {
                            f.Value.setMessageExchangeCondition(messageExchangeConditions1[s]);
                        }
                        else
                        {
                            if (receiveTransitionConditions1.ContainsKey(s))
                            {
                                f.Value.setReceiveTransitionCondition(receiveTransitionConditions1[s]);
                            }
                            else
                            {
                                if (states1.ContainsKey(s))
                                {
                                    f.Value.setSourceState(states1[s]);
                                }
                                else
                                {
                                    if (states1.ContainsKey(s))
                                    {
                                        f.Value.setTargetState(states1[s]);
                                    }
                                    else
                                    {
                                        if (actions1.ContainsKey(s))
                                        {
                                            f.Value.setBelongsToAction(actions1[s]);
                                        }
                                        else
                                        {
                                            if (subjectBehaviors1.ContainsKey(s))
                                            {
                                                f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                                            }
                                            else
                                            {
                                                Console.WriteLine("WARNING: unkown attribute encountered, test3");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, State> f in states1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (functionSpecifications.ContainsKey(s))
                        {
                            f.Value.setFunctionSpecification(functionSpecifications[s]);
                        }
                        else
                        {
                            if (transitions1.ContainsKey(s))
                            {
                                f.Value.setIncomingTransition(transitions1[s]);
                            }
                            else
                            {
                                if (actions1.ContainsKey(s))
                                {
                                    f.Value.setAction(actions1[s]);
                                }
                                else
                                {
                                    if (guardBehaviors.ContainsKey(s))
                                    {
                                        f.Value.setGuardBehavior(guardBehaviors[s]);
                                    }
                                    else
                                    {
                                        if (transitions1.ContainsKey(s))
                                        {
                                            f.Value.setIncomingTransition(transitions1[s]);
                                        }
                                        else
                                        {
                                            if (transitions1.ContainsKey(s))
                                            {
                                                f.Value.setOutgoingTransition(transitions1[s]);
                                            }
                                            else
                                            {
                                                Console.WriteLine("WARNING: unkown attribute encountered, test4");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Transition> f in transitions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (actions1.ContainsKey(s))
                    {
                        f.Value.setBelongsToAction(actions1[s]);
                    }
                    else
                    {
                        if (subjectBehaviors1.ContainsKey(s))
                        {
                            f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                        }
                        else
                        {
                            if (states1.ContainsKey(s))
                            {
                                f.Value.setSourceState(states1[s]);
                            }
                            else
                            {
                                if (states1.ContainsKey(s))
                                {
                                    f.Value.setTargetState(states1[s]);
                                }
                                else
                                {
                                    if (transitionConditions1.ContainsKey(s))
                                    {
                                        f.Value.setTransitionCondition(transitionConditions1[s]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("WARNING: unkown attribute encountered, test5");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, DoState> f in doStates1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (actions1.ContainsKey(s))
                    {
                        f.Value.setAction(actions1[s]);
                    }
                    else
                    {
                        if (subjectBehaviors1.ContainsKey(s))
                        {
                            f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                        }
                        else
                        {
                            if (dataMappingIncomingToLocals1.ContainsKey(s))
                            {
                                f.Value.setDataMappingFunctionIncomingToLocal(dataMappingIncomingToLocals1[s]);
                            }
                            else
                            {
                                if (dataMappingLocalToOutgoings.ContainsKey(s))
                                {
                                    f.Value.setDataMappingFunctionLocalToOutgoing(dataMappingLocalToOutgoings[s]);
                                }
                                else
                                {
                                    if (functionSpecifications.ContainsKey(s))
                                    {
                                        f.Value.setFunctionSpecification(functionSpecifications[s]);
                                    }
                                    else
                                    {
                                        if (guardBehaviors.ContainsKey(s))
                                        {
                                            f.Value.setGuardBehavior(guardBehaviors[s]);
                                        }
                                        else
                                        {
                                            if (transitions1.ContainsKey(s))
                                            {
                                                f.Value.setIncomingTransition(transitions1[s]);
                                            }
                                            else
                                            {
                                                if (transitions1.ContainsKey(s))
                                                {
                                                    f.Value.setOutgoingTransition(transitions1[s]);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("WARNING: unkown attribute encountered, test6");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, SendState> f in sendStates1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (actions1.ContainsKey(s))
                    {
                        f.Value.setAction(actions1[s]);
                    }
                    else
                    {
                        if (subjectBehaviors1.ContainsKey(s))
                        {
                            f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                        }
                        else
                        {
                            if (sendingFailedTransitions.ContainsKey(s))
                            {
                                f.Value.setSendingFailedTransition(sendingFailedTransitions[s]);
                            }
                            else
                            {
                                if (sendTransitions1.ContainsKey(s))
                                {
                                    f.Value.setSendTransition(sendTransitions1[s]);
                                }
                                else
                                {
                                    if (functionSpecifications.ContainsKey(s))
                                    {
                                        f.Value.setFunctionSpecification(functionSpecifications[s]);
                                    }
                                    else
                                    {
                                        if (guardBehaviors.ContainsKey(s))
                                        {
                                            f.Value.setGuardBehavior(guardBehaviors[s]);
                                        }
                                        else
                                        {
                                            if (transitions1.ContainsKey(s))
                                            {
                                                f.Value.setIncomingTransition(transitions1[s]);
                                            }
                                            else
                                            {
                                                if (transitions1.ContainsKey(s))
                                                {
                                                    f.Value.setOutgoingTransition(transitions1[s]);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, ReceiveState> f in receiveStates1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (actions1.ContainsKey(s))
                    {
                        f.Value.setAction(actions1[s]);
                    }
                    else
                    {
                        if (subjectBehaviors1.ContainsKey(s))
                        {
                            f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                        }
                        else
                        {
                            if (functionSpecifications.ContainsKey(s))
                            {
                                f.Value.setFunctionSpecification(functionSpecifications[s]);
                            }
                            else
                            {
                                if (guardBehaviors.ContainsKey(s))
                                {
                                    f.Value.setGuardBehavior(guardBehaviors[s]);
                                }
                                else
                                {
                                    if (transitions1.ContainsKey(s))
                                    {
                                        f.Value.setIncomingTransition(transitions1[s]);
                                    }
                                    else
                                    {
                                        if (transitions1.ContainsKey(s))
                                        {
                                            f.Value.setOutgoingTransition(transitions1[s]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, SubjectBaseBehavior> f in subjectBaseBahaviors1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (initialStateOfBehaviors1.ContainsKey(s))
                    {
                        f.Value.setInitialState(initialStateOfBehaviors1[s]);
                    }
                    else
                    {
                        if (endStates.ContainsKey(s))
                        {
                            f.Value.setEndState(endStates[s]);
                        }
                        else
                        {
                            if (behaviorDescriptionComponents1.ContainsKey(s))
                            {
                                f.Value.setContainsBehaviorDescribingComponent(behaviorDescriptionComponents1[s]);
                            }
                            else
                            {
                                Console.WriteLine("WARNING: unkown attribute encountered, test7");
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, InputPoolConstraint> f in inputPoolConstraints1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (inputPoolConstraintHandlingStrategys.ContainsKey(s))
                    {
                        f.Value.setHandlingStrategy(inputPoolConstraintHandlingStrategys[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");

                    }
                }
            }

            foreach (KeyValuePair<string, SubjectDataDefinition> f in subjectDataDefintions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (dataTypeDefinitions.ContainsKey(s))
                    {
                        f.Value.setDataTypeDefinition(dataTypeDefinitions[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");

                    }
                }
            }

            foreach (KeyValuePair<string, InputPoolConstraint> f in inputPoolConstraints1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (inputPoolConstraintHandlingStrategys.ContainsKey(s))
                    {
                        f.Value.setHandlingStrategy(inputPoolConstraintHandlingStrategys[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");

                    }
                }
            }

            foreach (KeyValuePair<string, MessageSpecification> f in messageSpecifications1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (payloadDescriptions.ContainsKey(s))
                    {
                        f.Value.setContainsPayloadDescription(payloadDescriptions[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");

                    }
                }
            }

            foreach (KeyValuePair<string, BehaviorDescriptionComponent> f in behaviorDescriptionComponents1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");

                    }
                }
            }

            foreach (KeyValuePair<string, InitialStateOfBehavior> f in initialStateOfBehaviors1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (actions1.ContainsKey(s))
                        {
                            f.Value.setBelongsToAction(actions1[s]);
                        }
                        else
                        {
                            if (transitions1.ContainsKey(s))
                            {
                                f.Value.setIncomingTransition(transitions1[s]);
                            }
                            else
                            {
                                if (transitions1.ContainsKey(s))
                                {
                                    f.Value.setOutgoingTransition(transitions1[s]);
                                }
                                else
                                {
                                    if (guardBehaviors.ContainsKey(s))
                                    {
                                        f.Value.setGuardBehavior(guardBehaviors[s]);
                                    }
                                    else
                                    {
                                        if (functionSpecifications.ContainsKey(s))
                                        {
                                            f.Value.setFunctionSpecification(functionSpecifications[s]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, SendTransition> f in sendTransitions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (actions1.ContainsKey(s))
                        {
                            f.Value.setBelongsToAction(actions1[s]);
                        }
                        else
                        {
                            if (dataMappingLocalToOutgoings.ContainsKey(s))
                            {
                                f.Value.setDataMappingFunctionLocalToOutgoing(dataMappingLocalToOutgoings[s]);
                            }
                            else
                            {
                                if (messageExchangeConditions1.ContainsKey(s))
                                {
                                    f.Value.setMessageExchangeCondition(messageExchangeConditions1[s]);
                                }
                                else
                                {
                                    if (sendTransitionConditions.ContainsKey(s))
                                    {
                                        f.Value.setSendTransitionCondition(sendTransitionConditions[s]);
                                    }
                                    else
                                    {
                                        if (transitionConditions1.ContainsKey(s))
                                        {
                                            f.Value.setTransitionCondition(transitionConditions1[s]);
                                        }
                                        else
                                        {
                                            if (states1.ContainsKey(s))
                                            {
                                                f.Value.setSourceState(states1[s]);
                                            }
                                            else
                                            {
                                                if (states1.ContainsKey(s))
                                                {
                                                    f.Value.setTargetState(states1[s]);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, ReceiveTransition> f in receiveTransitions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (actions1.ContainsKey(s))
                        {
                            f.Value.setBelongsToAction(actions1[s]);
                        }
                        else
                        {
                            if (dataMappingIncomingToLocals1.ContainsKey(s))
                            {
                                f.Value.setDataMappingFunctionIncomingToLocal(dataMappingIncomingToLocals1[s]);
                            }
                            else
                            {
                                if (messageExchangeConditions1.ContainsKey(s))
                                {
                                    f.Value.setMessageExchangeCondition(messageExchangeConditions1[s]);
                                }
                                else
                                {
                                    if (receiveTransitionConditions1.ContainsKey(s))
                                    {
                                        f.Value.setReceiveTransitionCondition(receiveTransitionConditions1[s]);
                                    }
                                    else
                                    {
                                        if (transitionConditions1.ContainsKey(s))
                                        {
                                            f.Value.setTransitionCondition(transitionConditions1[s]);
                                        }
                                        else
                                        {
                                            if (states1.ContainsKey(s))
                                            {
                                                f.Value.setSourceState(states1[s]);
                                            }
                                            else
                                            {
                                                if (states1.ContainsKey(s))
                                                {
                                                    f.Value.setTargetState(states1[s]);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, DoTransition> f in doTransitions)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (actions1.ContainsKey(s))
                        {
                            f.Value.setBelongsToAction(actions1[s]);
                        }
                        else
                        {
                            if (transitionConditions1.ContainsKey(s))
                            {
                                f.Value.setTransitionCondition(transitionConditions1[s]);
                            }
                            else
                            {
                                if (states1.ContainsKey(s))
                                {
                                    f.Value.setSourceState(states1[s]);
                                }
                                else
                                {
                                    if (states1.ContainsKey(s))
                                    {
                                        f.Value.setTargetState(states1[s]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, ReceiveTransitionCondition> f in receiveTransitionConditions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (receiveTypes.ContainsKey(s))
                        {
                            f.Value.setReceiveType(receiveTypes[s]);
                        }
                        else
                        {
                            if (subjects1.ContainsKey(s))
                            {
                                f.Value.setRequiresMessageSentFrom(subjects1[s]);
                            }
                            else
                            {
                                if (messageExchanges1.ContainsKey(s))
                                {
                                    f.Value.setRequiresPerformedMessageExchange(messageExchanges1[s]);
                                }
                                else
                                {
                                    if (messageSpecifications1.ContainsKey(s))
                                    {
                                        f.Value.setRequiresReceptionOfMessage(messageSpecifications1[s]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                        Console.WriteLine(s);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, MessageExchangeCondition> f in messageExchangeConditions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (messageExchanges1.ContainsKey(s))
                        {
                            f.Value.setRequiresPerformedMessageExchange(messageExchanges1[s]);
                        }
                        else
                        {
                            Console.WriteLine("WARNING: unkown attribute encountered, test7");
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Action> f in actions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        if (states1.ContainsKey(s))
                        {
                            f.Value.setContainsState(states1[s]);
                        }
                        else
                        {
                            if (transitions1.ContainsKey(s))
                            {
                                f.Value.setContainsTransition(transitions1[s]);
                            }
                            else
                            {
                                Console.WriteLine("WARNING: unkown attribute encountered, test7");
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, TransitionCondition> f in transitionConditions1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }

            foreach (KeyValuePair<string, DataTypeDefinition> f in dataTypeDefinitions)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (dataObjectDefinitions.ContainsKey(s))
                    {
                        f.Value.setContainsDataObjectDefintion(dataObjectDefinitions[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }

            foreach (KeyValuePair<string, FunctionSpecification> f in functionSpecifications)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBaseBahaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBaseBahaviors1[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }

            foreach (KeyValuePair<string, GuardBehavior> f in guardBehaviors)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (behaviorDescriptionComponents1.ContainsKey(s))
                    {
                        f.Value.setContainsBehaviorDescribingComponent(behaviorDescriptionComponents1[s]);
                    }
                    else
                    {
                        if (endStates.ContainsKey(s))
                        {
                            f.Value.setEndState(endStates[s]);
                        }
                        else
                        {
                            if (subjectBehaviors1.ContainsKey(s))
                            {
                                f.Value.setGuardsBehavior(subjectBehaviors1[s]);
                            }
                            else
                            {
                                if (states1.ContainsKey(s))
                                {
                                    f.Value.setGuardsState(states1[s]);
                                }
                                else
                                {
                                    if (initialStateOfBehaviors1.ContainsKey(s))
                                    {
                                        f.Value.setInitialState(initialStateOfBehaviors1[s]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, SendingFailedTransition> f in sendingFailedTransitions)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (actions1.ContainsKey(s))
                    {
                        f.Value.setBelongsToAction(actions1[s]);
                    }
                    else
                    {
                        if (subjectBehaviors1.ContainsKey(s))
                        {
                            f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                        }
                        else
                        {
                            if (sendStates1.ContainsKey(s))
                            {
                                f.Value.setSourceState(sendStates1[s]);
                            }
                            else
                            {
                                if (states1.ContainsKey(s))
                                {
                                    f.Value.setTargetState(states1[s]);
                                }
                                else
                                {
                                    if (sendingFailedConditions.ContainsKey(s))
                                    {
                                        f.Value.setTransitionCondition(sendingFailedConditions[s]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, EndState> f in endStates)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (actions1.ContainsKey(s))
                    {
                        f.Value.setBelongsToAction(actions1[s]);
                    }
                    else
                    {
                        if (subjectBehaviors1.ContainsKey(s))
                        {
                            f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                        }
                        else
                        {
                            if (functionSpecifications.ContainsKey(s))
                            {
                                f.Value.setFunctionSpecification(functionSpecifications[s]);
                            }
                            else
                            {
                                if (guardBehaviors.ContainsKey(s))
                                {
                                    f.Value.setGuardBehavior(guardBehaviors[s]);
                                }
                                else
                                {
                                    if (transitions1.ContainsKey(s))
                                    {
                                        f.Value.setIncomingTransition(transitions1[s]);
                                    }
                                    else
                                    {
                                        if (transitions1.ContainsKey(s))
                                        {
                                            f.Value.setOutgoingTransition(transitions1[s]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, SendTransitionCondition> f in sendTransitionConditions)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjects1.ContainsKey(s))
                    {
                        f.Value.setRequiresMessageSentTo(subjects1[s]);
                    }
                    else
                    {
                        if (subjectBehaviors1.ContainsKey(s))
                        {
                            f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                        }
                        else
                        {
                            if (messageExchanges1.ContainsKey(s))
                            {
                                f.Value.setRequiresPerformedMessageExchange(messageExchanges1[s]);
                            }
                            else
                            {
                                if (messageSpecifications1.ContainsKey(s))
                                {
                                    f.Value.setRequiresSendingOfMessage(messageSpecifications1[s]);
                                }
                                else
                                {
                                    if (sendTypes.ContainsKey(s))
                                    {
                                        f.Value.setSendType(sendTypes[s]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, ReceiveType> f in receiveTypes)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }

            foreach (KeyValuePair<string, Subject> f in subjects1)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (messageExchanges1.ContainsKey(s))
                    {
                        f.Value.setIncomingMessageExchange(messageExchanges1[s]);
                    }
                    else
                    {
                        if (messageExchanges1.ContainsKey(s))
                        {
                            f.Value.setOutgoingMessageExchange(messageExchanges1[s]);
                        }
                        else
                        {
                            Console.WriteLine("WARNING: unkown attribute encountered, test7");
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, DataObjectDefinition> f in dataObjectDefinitions)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (dataTypeDefinitions.ContainsKey(s))
                    {
                        f.Value.setDataTypeDefinition(dataTypeDefinitions[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }

            foreach (KeyValuePair<string, SendingFailedCondition> f in sendingFailedConditions)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }

            foreach (KeyValuePair<string, SendType> f in sendTypes)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (subjectBehaviors1.ContainsKey(s))
                    {
                        f.Value.setBelongsToSubjectBehavior(subjectBehaviors1[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }

            foreach (KeyValuePair<string, DataTypeDefinition> f in dataTypeDefinitions)
            {
                Console.WriteLine(f.Value.getModelComponentID());

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = f.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = f.Value.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                foreach (string s in tmp)
                {
                    if (dataObjectDefinitions.ContainsKey(s))
                    {
                        f.Value.setContainsDataObjectDefintion(dataObjectDefinitions[s]);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: unkown attribute encountered, test7");
                    }
                }
            }


        }
    }
}
