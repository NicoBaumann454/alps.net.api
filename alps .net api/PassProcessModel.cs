using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a Pass process modell, Schreibfehler !!!!!!!!!!
    /// </summary>
    public class PassProcessModel : InteractionDescriptionComponent, IPassProcessModell
    {
        private List<IMessageExchange> messageExchange = new List<IMessageExchange>();
        private List<ISubject> relationToModelComponent = new List<ISubject>();
        private List<IStartSubject> startSubject;

        private Dictionary<string, ModelLayer> layerDic = new Dictionary<string, ModelLayer>();
        private Dictionary<string, PASSProcessModelElement> elements = new Dictionary<string, PASSProcessModelElement>();
        private Guid guid = new Guid();

        private Graph modelGraph = new Graph();

        private string tmpMessageExchange;
        private string tmpRelationToModelComponent;
        private string tmpStartSubject;
        private List<Layer> layers = new List<Layer>();
        private Dictionary<string, PASSProcessModelElement> allElements = new Dictionary<string, PASSProcessModelElement>();
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "PassProcessModel";

        /// <summary>
        /// Constructor that creates a new empty instance of the pass process modell class
        /// </summary>
        public PassProcessModel()
        {
            setModelComponentID("PassProcessModel");
            setComment("The standart Element for PassProcessModel");

            modelGraph.NamespaceMap.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            modelGraph.NamespaceMap.AddNamespace("rdfs", new Uri("http://www.w3.org/2001/XMLSchema#"));
            modelGraph.NamespaceMap.AddNamespace("xml", new Uri("http://www.w3.org/XML/1998/namespace"));
            modelGraph.NamespaceMap.AddNamespace("abstract-pass-ont", new Uri("http://www.imi.kit.edu/abstract-pass-ont#"));
            modelGraph.NamespaceMap.AddNamespace("standard-pass-ont", new Uri("http://www.i2pm.net/standard-pass-ont#"));
            modelGraph.NamespaceMap.AddNamespace("owl", new Uri("http://www.w3.org/2002/07/owl#"));
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the pass process modell class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="messageExchange"></param>
        /// <param name="relationToModelComponent"></param>
        /// <param name="startSubject"></param>
        public PassProcessModel(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange messageExchange, Subject relationToModelComponent, StartSubject startSubject)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setRelationToModelComponent(messageExchange);
            setRelationToModelComponent(relationToModelComponent);
            setStartSubject(startSubject);

            modelGraph.NamespaceMap.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            modelGraph.NamespaceMap.AddNamespace("rdfs", new Uri("http://www.w3.org/2001/XMLSchema#"));
            modelGraph.NamespaceMap.AddNamespace("xml", new Uri("http://www.w3.org/XML/1998/namespace"));
            modelGraph.NamespaceMap.AddNamespace("abstract-pass-ont", new Uri("http://www.imi.kit.edu/abstract-pass-ont#"));
            modelGraph.NamespaceMap.AddNamespace("standard-pass-ont", new Uri("http://www.i2pm.net/standard-pass-ont#"));
            modelGraph.NamespaceMap.AddNamespace("owl", new Uri("http://www.w3.org/2002/07/owl#"));
        }

        /// <summary>
        /// Method that sets the message exchange attribute of the instance
        /// </summary>
        /// <param name="messageExchange"></param>
        public void setRelationToModelComponent(IMessageExchange messageExchange)
        {
            this.messageExchange.Add(messageExchange);
        }

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        public void setRelationToModelComponent(ISubject subject)
        {
            this.relationToModelComponent.Add(subject);
        }

        /// <summary>
        /// Method that sets the start subject attribute of the instance
        /// </summary>
        /// <param name="startSubject"></param>
        public void setStartSubject(IStartSubject startSubject)
        {
            this.startSubject.Add(startSubject);
        }

        /// <summary>
        /// Method that sets the message exchange attribute of the instance
        /// </summary>
        /// <returns>The message exchange attribute of the instance</returns>
        public List<IMessageExchange> getRelationToModelComponentMessageExchange()
        {
            return messageExchange;
        }

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        public List<ISubject> getRelationToModelComponentSubject()
        {
            return relationToModelComponent;
        }

        /// <summary>
        /// Method that sets the start subject attribute of the instance
        /// </summary>
        /// <returns>The start subject attribute of the instance</returns>
        public List<IStartSubject> getStartSubject()
        {
            return startSubject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpMessageExchange()
        {
            return tmpMessageExchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpRelationToModelComponent()
        {
            return tmpRelationToModelComponent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpStartSubject()
        {
            return tmpStartSubject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, PASSProcessModelElement> getAllElements()
        {
            return allElements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pASSProcessModelElement"></param>
        public void addElements(string key, PASSProcessModelElement pASSProcessModelElement)
        {

            if (!allElements.ContainsKey(key))
            {
                allElements.Add(key, pASSProcessModelElement);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, PASSProcessModelElement> getPASSProcessModelElements()
        {
            return allElements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, ModelLayer> getModelLayer()
        {
            return layerDic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            bool result = false;
            result = base.createInstance(attribute, attributeType);

            return result;
        }

        /// <summary>
        /// Method that sets all the object attributes of the named individuals
        /// </summary>
        public void completeObjects()
        {
            List<MessageExchangeList> messageExchangeLists = new List<MessageExchangeList>();
            List<ModelLayer> modelLayers = new List<ModelLayer>();

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

                if (!(new MessageExchangeList().GetType().IsInstanceOfType(allElements[i.Key])))
                {
                    allElements[i.Key].completeObject(ref allElements, ref tmp);
                }

                if ((new MessageExchangeList().GetType().IsInstanceOfType(allElements[i.Key])))
                {
                    messageExchangeLists.Add((MessageExchangeList)allElements[i.Key]);
                }

                if ((new ModelLayer().GetType().IsInstanceOfType(allElements[i.Key])))
                {
                    modelLayers.Add((ModelLayer)allElements[i.Key]);
                }

            }

            Console.WriteLine("[##########################    ]");

            foreach (MessageExchangeList i in messageExchangeLists)
            {
                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = i.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = i.getMultiAttributes();

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

                i.completeObject(ref allElements, ref tmp);
            }


            foreach (ModelLayer i in modelLayers)
            {
                foreach (string j in i.getStringElement())
                {
                    if (allElements.ContainsKey(j))
                    {
                        if (!i.getElements().ContainsKey(j))
                        {
                            i.addElement(j, allElements[j]);
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, PASSProcessModelElement> m in allElements)
            {
                int repeat = 0;
                List<int> remove = new List<int>();
                for (int i = 0; i < m.Value.getAdditionalAttribute().Count; i++)
                {

                    for (int l = 0; l < m.Value.getAdditionalAttribute().Count; l++)
                    {
                        if (m.Value.getAdditionalAttribute()[i].Equals(m.Value.getAdditionalAttribute()[l]))
                        {
                            repeat++;
                            if (repeat > 1)
                            {
                                remove.Add(l);
                            }
                        }
                    }

                    remove.Sort();
                    remove.Reverse();

                    foreach (int l in remove)
                    {
                        if (l >= 0 && l < m.Value.getAdditionalAttribute().Count())
                        {
                            m.Value.getAdditionalAttribute().RemoveAt(l);
                            m.Value.getAdditionalAttributeType().RemoveAt(l);
                        }

                    }

                    repeat = 0;
                    remove.Clear();
                }
            }

            Console.WriteLine("[############################  ]");
        }


        /// <summary>
        /// Obsolete
        /// </summary>
        public void completeObjects(int m)
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
                //Console.WriteLine(nameOfObject);

                switch (nameOfObject)
                {
                    case "AbstractCommunicationChannel":

                        ((AbstractCommunicationChannel)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractDoState":

                        ((AbstractDoState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractLayer":

                        ((AbstractLayer)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractMessageExchange":

                        ((AbstractMessageExchange)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractMultiSubject":

                        ((AbstractMultiSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractPASSTransition":

                        ((AbstractPASSTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractReceiveState":

                        ((AbstractReceiveState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractSendState":

                        ((AbstractSendState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractSingleSubject":

                        ((AbstractSingleSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractState":

                        ((AbstractState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "AbstractSubject":

                        ((AbstractSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "Action":

                        ((Action)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ActorPlaceHolder":

                        ((ActorPlaceHolder)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ALPSModelElement":

                        ((ALPSModelElement)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ALPSSBDComponent":

                        ((ALPSSBDComponent)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ALPSSIDComponent":

                        ((ALPSSIDComponent)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "BaseLayer":

                        ((BaseLayer)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "BehaviorDescriptionComponent":

                        ((BehaviorDescriptionComponent)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "BiDirectionalCommunicationChannel":

                        ((BiDirectionalCommunicationChannel)allElements[i.Key]).completeObject(ref allElements, ref tmp);
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
                    case "DataObjectListDefiniton":

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

                    case "ExtensionBehavior":

                        ((ExtensionBehavior)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ExtensionLayer":

                        ((ExtensionLayer)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FinalizedMessageExchange":

                        ((FinalizedMessageExchange)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FinalReceiveTransition":

                        ((FinalReceiveTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FinalSendTransition":

                        ((FinalSendTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FinalTransition":

                        ((FinalTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FinalTransitionType":

                        ((FinalTransitionType)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "FullySpecifiedSubject":

                        //((FullySpecifiedSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        Console.WriteLine("Hier ist ein Subject **************************************************************++");
                        allElements[i.Key].completeObject(ref allElements, ref tmp);
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

                    case "GroupState":

                        ((GroupState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
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
                    case "JSONDataTypeDefintion":

                        ((JSONDataTypeDefinition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "LayeredPASSProcessModel":

                        ((LayeredPASSProcessModel)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MacroBehavior":

                        ((MacroBehavior)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MacroState":

                        ((MacroState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MandatoryToEndChoiceSegment":

                        ((MandatoryToEndChoiceSegment)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MandatoryToStartChoiceSegment":

                        ((MandatoryToStartChoiceSegment)allElements[i.Key]).completeObject(ref allElements, ref tmp);
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

                    case "ModelLayer":

                        ((ModelLayer)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "ModelBuiltInDataTypes":

                        ((ModelBuiltInDataTypes)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "MultiSubject":

                        ((MultiSubject)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "OptionalToEndChoiceSegmentPath":

                        ((OptionalToEndChoiceSegmentPath)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "OptionalToStartChoiceSegmentPath":

                        ((OptionalToStartChoiceSegmentPath)allElements[i.Key]).completeObject(ref allElements, ref tmp);
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

                    case "PrecedenceReceiveTransition":

                        ((PrecedenceReceiveTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "PrecedenceSendTransition":

                        ((PrecedenceSendTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "PrecedenceTransition":

                        ((PrecedenceTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "PrecedenceTransitionType":

                        ((PrecedenceTransitionType)allElements[i.Key]).completeObject(ref allElements, ref tmp);
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

                    case "SubjectExtension":

                        ((SubjectExtension)allElements[i.Key]).completeObject(ref allElements, ref tmp);
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

                    case "TriggerReceiveTransition":

                        ((TriggerReceiveTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TriggerSendTransition":

                        ((TriggerSendTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TriggerTransition":

                        ((TriggerTransition)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "TriggerTransitionType":

                        ((TriggerTransitionType)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    case "UniDirectionalCommunicationChannel":

                        ((UniDirectionalCommunicationChannel)allElements[i.Key]).completeObject(ref allElements, ref tmp);
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

                    case "GuardReceiveState":

                        ((GuardReceiveState)allElements[i.Key]).completeObject(ref allElements, ref tmp);
                        break;

                    default:
                        Console.WriteLine("WARNING: Object: " + nameOfObject + " not handeld properly");
                        break;
                }
            }
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the pass process model element class
        /// </summary>
        /// <returns></returns>
        new public PassProcessModel factoryMethod()
        {
            PassProcessModel passProcessModell = new PassProcessModel();

            return passProcessModell;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public ModelLayer addLayer(string label)
        {
            guid = Guid.NewGuid();

            ModelLayer modelLayer = new ModelLayer();

            modelLayer.setModelComponentID(modelLayer.GetType().ToString() + guid.ToString());
            modelLayer.setModelComponentLabel(label);

            layerDic.Add(modelLayer.getModelComponentID(), modelLayer);

            return modelLayer;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="modelLayer"></param>
        public void addLayer(string name, ModelLayer modelLayer)
        {
            layerDic.Add(name, modelLayer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelLayer"></param>
        /// <returns></returns>
        public ModelLayer getModelLayer(ModelLayer modelLayer)
        {
            return (layerDic[modelLayer.getModelComponentID()]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posOfLayer"></param>
        /// <returns></returns>
        public ModelLayer getModelLayer(int posOfLayer)
        {
            return layerDic[layerDic.ElementAt(posOfLayer).Key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void deleteModelElement(string name)
        {
            //deletes element
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objects"></param>
        public void createLayer(Dictionary<string, PASSProcessModelElement> objects)
        {
            Dictionary<string, PASSProcessModelElement>.KeyCollection keyColl = objects.Keys;

            foreach (string s in keyColl)
            {
                if (s.Contains("Layer"))
                {
                    Layer layer = (Layer)objects[s];
                    layers.Add(layer);
                }
            }

            if (layers.Count == 0)
            {
                Layer layer = new Layer();
                layer.setModelComponentID("standart-pass-ont#defaultLayer");
                layers.Add(layer);
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public override void export(ref Graph g)
        {
            base.export(ref g);
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
                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + "PASSProcessModel" + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
