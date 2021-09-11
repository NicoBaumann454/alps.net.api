using System;
using System.Collections.Generic;
using VDS.RDF;
using System.IO;

namespace alps.net_api
{
    class LayeredPASSProcessModel : PassProcessModel, IALPSModelElement, ILayeredPassProcessModel
    {
        private Dictionary<string, PASSProcessModelElement> allElements = new Dictionary<string, PASSProcessModelElement>();
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "LayeredPASSProcessModel";

        /// <summary>
        /// Constructor that creates a new empty instance of the layered pass process model class
        /// </summary>
        public LayeredPASSProcessModel()
        {
            setModelComponentID("LayeredPASSProcessModel");
            setComment("The standart Element for LayeredPASSProcessModel");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the layered pass process modell class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="messageExchange"></param>
        /// <param name="relationToModelComponent"></param>
        /// <param name="startSubject"></param>
        public LayeredPASSProcessModel(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange messageExchange, Subject relationToModelComponent, StartSubject startSubject)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setRelationToModelComponent(messageExchange);
            setRelationToModelComponent(relationToModelComponent);
            setStartSubject(startSubject);
        }


        /// <summary>
        /// 
        /// </summary>
        new public void completeObjects()
        {

            foreach (KeyValuePair<string, PASSProcessModelElement> i in allElements)
            {

                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = i.Value.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = i.Value.getMultiAttributes();

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

                int count = 0;

                if (new FullySpecifiedSubject().GetType().IsInstanceOfType(allElements[i.Key]))
                {
                    Console.WriteLine(allElements[i.Key].getModelComponentID());

                    ((FullySpecifiedSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                }

                count++;

                for (int counter = 0; counter < tmp.Count; counter++)
                {
                    string name = tmp[counter];
                    string[] splittedURI;
                    splittedURI = name.Split('#');
                    if (splittedURI.Length > 1)
                    {
                        name = splittedURI[1];
                        tmp[counter] = name;
                    }
                }


                string nameOfObject = allElements[i.Key].GetType().Name;
                Console.WriteLine(nameOfObject);

                switch (nameOfObject)
                {

                    case "Action":

                        ((Action)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "BehaviorDescriptionComponent":

                        ((BehaviorDescriptionComponent)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "BuisnessDayTimerTransition":

                        ((BuisnessDayTimerTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "BuisnessDayTimerTransitionCondition":

                        //((BuisnessDayTimerTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "CalenderBasedReminderTransition":

                        ((CalenderBasedReminderTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "CalenderBasedReminderTransitionCondition":

                        ((CalenderBasedReminderTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ChoiceSegment":

                        ((ChoiceSegment)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ChoiceSegmentPath":

                        ((ChoiceSegmentPath)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "CommunicationAct":

                        ((CommunicationAct)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "CommunicationTransition":

                        ((CommunicationTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    //hier ist ein Schreibfehler !!!!!!!!!!!!
                    case "CustomOrExternalDataTypeDefinition":

                        ((CustomOrExternalDataTypeDefinition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DataDescribingComponent":

                        ((DataDescribingComponent)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DataMappingFunction":

                        ((DataMappingFunction)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DataMappingLocalIncomingToLocal":

                        ((DataMappingIncomingToLocal)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DataMappingLocalToOutgoing":

                        ((DataMappingLocalToOutgoing)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    //Schreibfehler !!!!!!!!!!!!!!!!
                    case "DataObjectDefinition":

                        ((DataObjectDefinition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    //Schreibfehler !!!!!!!!!!!!!!!!
                    case "DataObjectListDefinition":

                        ((DataObjectListDefiniton)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    //Schreibfehler !!!!!!!!!!!!!!!!
                    case "DataTypeDefinition":

                        ((DataTypeDefinition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DayTimerTransitionCondition":

                        ((DayTimerTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DayTimeTimerTransition":

                        ((DayTimeTimerTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    //Muss noch implementiert werden !!!!!!!!!!!!!!
                    case "DayTimeTimerTransitionCondition":

                        //((DayTimeTimerTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DoFunction":

                        ((DoFunction)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DoState":

                        ((DoState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DoTransition":

                        ((DoTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "DoTransitionCondition":

                        ((DoTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "EndState":

                        ((EndState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FullySpecifiedSubject":

                        //((FullySpecifiedSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        (allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FunctionSpecification":

                        ((FunctionSpecification)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "GenericReturnToOriginReference":

                        ((GenericReturnToOriginReference)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "GuardBehavior":

                        ((GuardBehavior)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "InitialStateOfBehavior":

                        ((InitialStateOfBehavior)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "InitialStateOfChoiceSegmentPath":

                        ((InitialStateOfChoiceSegmentPath)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "InputPoolConstrain":

                        ((InputPoolConstraint)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "InputPoolConstraintHandlingStrategy":

                        ((InputPoolConstraintHandlingStrategy)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "InterfaceSubject":

                        ((InterfaceSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    //Schreibfehler !!!!!!!!!!!!!!
                    case "JSONDataTypeDefinition":

                        ((JSONDataTypeDefinition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MacroBehavior":

                        ((MacroBehavior)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MacroState":

                        ((MacroState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    
                    case "MessageExchange":

                        ((MessageExchange)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MessageExchangeCondition":

                        ((MessageExchangeCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MessageExchangeList":

                        ((MessageExchangeList)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MessageSenderTypeConstraint":

                        ((MessageSenderTypeConstraint)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MessageSpecification":

                        ((MessageSpecification)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MessageTypeConstraint":

                        ((MessageTypeConstraint)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ModelBuiltInDataTypes":

                        ((ModelBuiltInDataTypes)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MultiSubject":

                        ((MultiSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;


                    case "OWLDataTypeDefintion":

                        ((OWLDataTypeDefintion)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "PASSProcessModelElement":

                        ((PASSProcessModelElement)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "PayloadDataObjectDefinition":

                        ((PayloadDataObjectDefinition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "PayloadDescription":

                        ((PayloadDescription)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ReceiveFunction":

                        ((ReceiveFunction)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ReceiveState":

                        ((ReceiveState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ReceiveTransition":

                        ((ReceiveTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ReceiveTransitionCondition":

                        ((ReceiveTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ReceiveType":

                        ((ReceiveType)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ReminderEventTransitionCondition":

                        ((ReminderEventTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ReminderTransition":

                        ((ReminderTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SenderTypeConstraint":

                        ((SenderTypeConstraint)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SendFunction":

                        ((SendFunction)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SendingFailedCondition":

                        ((SendingFailedCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SendingFailedTransition":

                        ((SendingFailedTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SendState":

                        ((SendState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SendTransition":

                        ((SendTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SendTransitionCondition":

                        ((SendTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SendType":

                        ((SendType)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SingleSubject":

                        ((SingleSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "StandartPASSState":

                        ((StandartPASSState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "StartSubject":

                        ((StartSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "State":

                        ((State)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "StateReference":

                        ((StateReference)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "Subject":

                        ((Subject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SubjectBaseBehavior":

                        ((SubjectBaseBehavior)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SubjectBehavior":

                        ((SubjectBehavior)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "SubjectDataDefinition":

                        ((SubjectDataDefinition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TimeBasedReminderTransition":

                        ((TimeBasedReminderTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TimeBasedReminderTransitionCondition":

                        ((TimeBasedReminderTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TimerTransition":

                        ((TimerTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TimerTransitionCondition":

                        ((TimerTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TimeTransition":

                        ((TimeTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "Transition":

                        ((Transition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TransitionCondition":

                        ((TransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "UserCancelTransition":

                        ((UserCancelTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "XSDDataTypeDefinition":

                        ((XSDDataTypeDefintion)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "YearMonthTimerTransition":

                        ((YearMonthTimerTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "YearMonthTimerTransitionCondition":

                        ((YearMonthTimerTransitionCondition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    default:
                        Console.WriteLine("WARNING: Object: " + nameOfObject + " not handeld properly");
                        break;
                }
            }
        }

        /// <summary>
        /// Method that exports an layered pass process model object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {
                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the pass process model element class
        /// </summary>
        /// <returns></returns>
        new public LayeredPASSProcessModel factoryMethod()
        {
            LayeredPASSProcessModel passProcessModell = new LayeredPASSProcessModel();

            return passProcessModell;
        }

    }

}
