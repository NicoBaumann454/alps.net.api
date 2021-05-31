using System;
using System.Collections.Generic;
using System.Linq;
using VDS.RDF;

namespace alps.net_api
{
     
    /// <summary>
    /// Class that represents a model layer 
    /// </summary>
    public class ModelLayer : ALPSModelElement, IModelLayer
    {
        Guid guid = new Guid();

        private PassProcessModel belongsToModel;
        private List<string> tmpElements = new List<string>();
        private Dictionary<string, IPASSProcessModellElement> elements = new Dictionary<string, IPASSProcessModellElement>();

        /// <summary>
        /// Standart constructor of the model layer class
        /// </summary>
        public ModelLayer()
        {
            setModelComponentID("ModelLayer");
            setComment("The standart Element for ModelLayer");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void addElement(string key, PASSProcessModelElement value)
        {
            elements.Add(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ref Dictionary<string, IPASSProcessModellElement> getElements()
        {
            return ref elements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void addStringElement(string element)
        {
            this.tmpElements.Add(element);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> getStringElement()
        {
            return tmpElements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passProcessModel"></param>
        public void setBelongsToPASSProcessModel(PassProcessModel passProcessModel)
        {
            this.belongsToModel = passProcessModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PassProcessModel getBelongsToPASSProcessModel()
        {
            return this.belongsToModel;
        }

        /// <summary>
        /// Method that can be used to create a new subject and add it to the model.The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="maxSubjectInstanceRestriction"></param>
        /// <param name="subjectDataDefinition"></param>
        /// <param name="inputPoolConstraint"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public FullySpecifiedSubject addFullySpecifiedSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 1, ISubjectDataDefinition subjectDataDefinition = null, IInputPoolConstraint inputPoolConstraint = null, List<string> additionalAttribute = null)
        {
            FullySpecifiedSubject fullySpecifiedSubject = new FullySpecifiedSubject(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, subjectDataDefinition, inputPoolConstraint, additionalAttribute);

            elements.Add(fullySpecifiedSubject.getModelComponentID(), fullySpecifiedSubject);
            elements.Add(fullySpecifiedSubject.getSubjectBehavior().getModelComponentID(), fullySpecifiedSubject.getSubjectBehavior());

            belongsToModel.addElements(fullySpecifiedSubject.getModelComponentID(), fullySpecifiedSubject);

            PASSProcessModelElement test = (PASSProcessModelElement)fullySpecifiedSubject.getSubjectBehavior();
            fullySpecifiedSubject.getSubjectBehavior().setBelongsToPassProcessModel(this.belongsToModel);
            belongsToModel.addElements(fullySpecifiedSubject.getSubjectBehavior().getModelComponentID(), test);

            return fullySpecifiedSubject;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public FullySpecifiedSubject getFullySpecifiedSubject(int numberOfElement)
        {
            return elements.Values.OfType<FullySpecifiedSubject>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullySpecifiedSubject"></param>
        public void deleteSubject(FullySpecifiedSubject fullySpecifiedSubject)
        {
            foreach (KeyValuePair<string, IPASSProcessModellElement> i in elements)
            {

                if (elements[i.Key].GetType().Equals(new MessageExchange().GetType()))
                {
                    if (((MessageExchange)elements[i.Key]).getSender().Equals(fullySpecifiedSubject))
                    {
                        ((MessageExchange)elements[i.Key]).setSender(null);
                    }
                    else
                    {
                        if (((MessageExchange)elements[i.Key]).getReceiver().Equals(fullySpecifiedSubject))
                        {
                            ((MessageExchange)elements[i.Key]).setReceiver(null);
                        }
                    }
                }
            }

            elements.Remove(fullySpecifiedSubject.getSubjectBehavior().getModelComponentID());
            elements.Remove(fullySpecifiedSubject.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new instance of the interface subject class and adds it to the corresponding model layer
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="maxSubjectInstanceRestriction"></param>
        /// <param name="fullySpecifiedSubject"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public InterfaceSubject addInterfaceSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 1, IFullySpecifiedSubject fullySpecifiedSubject = null, List<string> additionalAttribute = null)
        {

            InterfaceSubject interfaceSubject = new InterfaceSubject(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, fullySpecifiedSubject, additionalAttribute);

            elements.Add(interfaceSubject.getModelComponentID(), interfaceSubject);
            belongsToModel.addElements(interfaceSubject.getModelComponentID(), interfaceSubject);

            return interfaceSubject;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public InterfaceSubject getInterfaceSubject(int numberOfElement)
        {
            return elements.Values.OfType<InterfaceSubject>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceSubject"></param>
        public void deleteInterfaceSubject(InterfaceSubject interfaceSubject)
        {
            elements.Remove(interfaceSubject.getModelComponentID());
        }

        /// <summary>
        /// Method that can be used to create a new interface subject and add it to the model. The parameter label creates the label of the subject and the ID will also be created with the label and an unique string.
        /// Without a given layer the subject will be added to a default layer.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="maxSubjectInstanceRestriction"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public MultiSubject addMultiSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 2, List<string> additionalAttribute = null)
        {
            MultiSubject multiSubject = new MultiSubject(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, additionalAttribute);

            elements.Add(multiSubject.getModelComponentID(), multiSubject);
            belongsToModel.addElements(multiSubject.getModelComponentID(), multiSubject);

            return multiSubject;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public MultiSubject getMultiSubject(int numberOfElement)
        {
            return elements.Values.OfType<MultiSubject>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="multiSubject"></param>
        public void deleteMultiSubject(MultiSubject multiSubject)
        {
            elements.Remove(multiSubject.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="maxSubjectInstanceRestriction"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public SingleSubject addSingleSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 2, List<string> additionalAttribute = null)
        {
            SingleSubject singleSubject = new SingleSubject(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, additionalAttribute);

            elements.Add(singleSubject.getModelComponentID(), singleSubject);
            belongsToModel.addElements(singleSubject.getModelComponentID(), singleSubject);

            return singleSubject;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public SingleSubject getSingleSubject(int numberOfElement)
        {
            return elements.Values.OfType<SingleSubject>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="singleSubject"></param>
        public void deleteSingleSubject(SingleSubject singleSubject)
        {
            elements.Remove(singleSubject.getModelComponentID());
        }

        /// <summary>
        /// Method that creates a new message exchange between two subjects with a message specification and returns the message exchange object
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="senderSubject"></param>
        /// <param name="receiverSubject"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public MessageExchange addMessageExchange(string label, string comment = "", IMessageSpecification messageSpecification = null, ISubject senderSubject = null, ISubject receiverSubject = null, List<string> additionalAttribute = null)
        {

            MessageExchange messageExchange = new MessageExchange(label, comment, messageSpecification, senderSubject, receiverSubject, additionalAttribute);

            elements.Add(messageExchange.getModelComponentID(), messageExchange);
            belongsToModel.addElements(messageExchange.getModelComponentID(), messageExchange);

            return messageExchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns></returns>
        public MessageExchange getMessageExchange(int numberOfElement)
        {
            return elements.Values.OfType<MessageExchange>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageExchange"></param>
        public void deleteMessageExchange(IMessageExchange messageExchange)
        {
            foreach (KeyValuePair<string, IPASSProcessModellElement> i in elements)
            {

                if (elements[i.Key].GetType().Equals(new FullySpecifiedSubject().GetType()))
                {
                    if (((FullySpecifiedSubject)elements[i.Key]).getIncomingMessageExchange().Equals(messageExchange))
                    {
                        ((FullySpecifiedSubject)elements[i.Key]).setIncomingMessageExchange(null);
                    }
                    else
                    {
                        if (((FullySpecifiedSubject)elements[i.Key]).getOutgoingMessageExchange().Equals(messageExchange))
                        {
                            ((FullySpecifiedSubject)elements[i.Key]).setOutgoingMessageExchange(null);
                        }
                    }
                }
            }

            elements.Remove(messageExchange.getModelComponentID());
        }


        /// <summary>
        /// Method that creates a new Input pool constraint in the model layer
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public InputPoolConstraint addInputPoolConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, List<string> additionalAttribute = null)
        {

            InputPoolConstraint inputPoolConstraint = new InputPoolConstraint(label, comment, inputPoolConstraintHandlingStrategy, limit, additionalAttribute);

            elements.Add(inputPoolConstraint.getModelComponentID(), inputPoolConstraint);
            belongsToModel.addElements(inputPoolConstraint.getModelComponentID(), inputPoolConstraint);

            return inputPoolConstraint;
        }

        /// <summary>
        /// Method that returns a input pool constraint at a certain number within the elements
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns>The object</returns>
        public InputPoolConstraint getInputPoolConstraint(int numberOfElement)
        {
            return elements.Values.OfType<InputPoolConstraint>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputPoolConstraint"></param>
        public void deleteInputPoolConstraint(InputPoolConstraint inputPoolConstraint)
        {
            elements.Remove(inputPoolConstraint.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="subject"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public MessageSenderTypeConstraint addMessageSenderTypeConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, IMessageSpecification messageSpecification = null, ISubject subject = null, List<string> additionalAttribute = null)
        {
            MessageSenderTypeConstraint messageSenderTypeConstraint = new MessageSenderTypeConstraint(label, comment, inputPoolConstraintHandlingStrategy, limit, messageSpecification, subject, additionalAttribute);

            elements.Add(messageSenderTypeConstraint.getModelComponentID(), messageSenderTypeConstraint);
            belongsToModel.addElements(messageSenderTypeConstraint.getModelComponentID(), messageSenderTypeConstraint);

            return messageSenderTypeConstraint;
        }

        /// <summary>
        /// Method that returns a input pool constraint at a certain number within the elements
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns>The object</returns>
        public MessageSenderTypeConstraint getMessageSenderTypeConstraint(int numberOfElement)
        {
            return elements.Values.OfType<MessageSenderTypeConstraint>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageSenderTypeConstraint"></param>
        public void deleteMessageSenderTypeConstraint(MessageSenderTypeConstraint messageSenderTypeConstraint)
        {
            elements.Remove(messageSenderTypeConstraint.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public MessageTypeConstraint addMessageTypeConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, IMessageSpecification messageSpecification = null, List<string> additionalAttribute = null)
        {
            MessageTypeConstraint messageTypeConstraint = new MessageTypeConstraint(label, comment, inputPoolConstraintHandlingStrategy, limit, messageSpecification, additionalAttribute);

            elements.Add(messageTypeConstraint.getModelComponentID(), messageTypeConstraint);
            belongsToModel.addElements(messageTypeConstraint.getModelComponentID(), messageTypeConstraint);

            return messageTypeConstraint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="subject"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public SenderTypeConstraint addSenderTypeConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, ISubject subject = null, List<string> additionalAttribute = null)
        {
            SenderTypeConstraint senderTypeConstraint = new SenderTypeConstraint(label, comment, inputPoolConstraintHandlingStrategy, limit, subject, additionalAttribute);

            elements.Add(senderTypeConstraint.getModelComponentID(), senderTypeConstraint);
            belongsToModel.addElements(senderTypeConstraint.getModelComponentID(), senderTypeConstraint);

            return senderTypeConstraint;
        }

        /// <summary>
        /// Method that returns a input pool constraint at a certain number within the elements
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns>The object</returns>
        public SenderTypeConstraint getSenderTypeConstraint(int numberOfElement)
        {
            return elements.Values.OfType<SenderTypeConstraint>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderTypeConstraint"></param>
        public void deleteSenderTypeConstraint(SenderTypeConstraint senderTypeConstraint)
        {
            elements.Remove(senderTypeConstraint.getModelComponentID());
        }

        /// <summary>
        /// Method that returns a input pool constraint at a certain number within the elements
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns>The object</returns>
        public MessageTypeConstraint getMessageTypeConstraint(int numberOfElement)
        {
            return elements.Values.OfType<MessageTypeConstraint>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageTypeConstraint"></param>
        public void deleteMessageTypeConstraint(MessageTypeConstraint messageTypeConstraint)
        {
            elements.Remove(messageTypeConstraint.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public InputPoolConstraintHandlingStrategy addInputPoolConstraintHandlingStrategy(string label, string comment = "")
        {
            guid = Guid.NewGuid();

            InputPoolConstraintHandlingStrategy messageSenderTypeConstraint = new InputPoolConstraintHandlingStrategy();
            messageSenderTypeConstraint.setModelComponentID(label + guid.ToString());
            messageSenderTypeConstraint.setModelComponentLabel(messageSenderTypeConstraint.getModelComponentID());

            messageSenderTypeConstraint.setComment(comment);

            elements.Add(messageSenderTypeConstraint.getModelComponentID(), messageSenderTypeConstraint);
            belongsToModel.addElements(messageSenderTypeConstraint.getModelComponentID(), messageSenderTypeConstraint);

            return messageSenderTypeConstraint;
        }

        /// <summary>
        /// Method that returns a input pool constraint at a certain number within the elements
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns>The object</returns>
        public InputPoolConstraintHandlingStrategy getInputPoolConstraintHandlingStrategy(int numberOfElement)
        {
            return elements.Values.OfType<InputPoolConstraintHandlingStrategy>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        public void deleteInputPoolConstraintHandlingStrategy(InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy)
        {
            elements.Remove(inputPoolConstraintHandlingStrategy.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="messageExchanges"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public MessageExchangeList addMessageExchangeList(string label, string comment = "", Dictionary<string, IMessageExchange> messageExchanges = null, List<string> additionalAttribute = null)
        {
            MessageExchangeList messageExchangeList = new MessageExchangeList(label, comment, messageExchanges, additionalAttribute);

            elements.Add(messageExchangeList.getModelComponentID(), messageExchangeList);
            belongsToModel.addElements(messageExchangeList.getModelComponentID(), messageExchangeList);

            return messageExchangeList;
        }

        /// <summary>
        /// Method that returns a input pool constraint at a certain number within the elements
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns>The object</returns>
        public MessageExchangeList getMessageExchangeList(int numberOfElement)
        {
            return elements.Values.OfType<MessageExchangeList>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageExchangeList"></param>
        public void deleteMessageExchangeList(MessageExchangeList messageExchangeList)
        {
            foreach (KeyValuePair<string, IMessageExchange> i in messageExchangeList.getMessageExchange())
            {
                deleteMessageExchange(i.Value);
            }

            elements.Remove(messageExchangeList.getModelComponentID());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="payloadDescription"></param>
        /// <param name="additionalAttribute"></param>
        /// <returns></returns>
        public MessageSpecification addMessageSpecification(string label, string comment = "", IPayloadDescription payloadDescription = null, List<string> additionalAttribute = null)
        {
            MessageSpecification messageSpecification = new MessageSpecification(label, comment, payloadDescription, additionalAttribute);

            elements.Add(messageSpecification.getModelComponentID(), messageSpecification);
            belongsToModel.addElements(messageSpecification.getModelComponentID(), messageSpecification);

            return messageSpecification;
        }

        /// <summary>
        /// Method that returns a input pool constraint at a certain number within the elements
        /// </summary>
        /// <param name="numberOfElement"></param>
        /// <returns>The object</returns>
        public MessageSpecification getMessageSpecification(int numberOfElement)
        {
            return elements.Values.OfType<MessageSpecification>().ElementAt(numberOfElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageSpecification"></param>
        public void deleteMessageSpecification(MessageSpecification messageSpecification)
        {

            elements.Remove(messageSpecification.getModelComponentID());
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
            List<int> toBeRemoved = new List<int>();

            toBeRemoved.Sort();
            toBeRemoved.Reverse();

            foreach (int i in toBeRemoved)
            {

                attribute.RemoveAt(i);
                attributeType.RemoveAt(i);
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

            int count = 0;

            foreach (string i in getAdditionalAttributeType())
            {
                if (i.Contains("contains"))
                {
                    this.tmpElements.Add(getAdditionalAttribute()[count]);
                }

                count++;
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
    }
}
