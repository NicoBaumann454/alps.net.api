using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Method that represents an abstract message exchange class
    /// </summary>
    class AbstractMessageExchange : ALPSSIDComponent, IAbstractMessageExchange
    {
        private IMessageSpecification messageSpecification;
        private ISubject receiver;
        private ISubject sender;
        private string tmpMessageSpecification;
        private string tmpReceiver;
        private string tmpSender;

        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "AbstractMessageExchange";

        /// <summary>
        /// Constructor that creates a new empty instance of the abstract message exchange class
        /// </summary>
        public AbstractMessageExchange()
        {
            setModelComponentID("AbstractMessageExchange");
            setComment("The standart Element for AbstractMessageExchange");
        }

        /// <summary>
        /// Constructor that creates a fully specified empty instance of the abstract message exchange class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="receiver"></param>
        /// <param name="sender"></param>
        public AbstractMessageExchange(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageSpecification messageSpecification, Subject receiver, Subject sender)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setMessageType(messageSpecification);
            setReceiver(receiver);
            setSender(sender);

        }

        /// <summary>
        /// Method that sets the message specification attribute of the instance
        /// </summary>
        /// <param name="messageSpecification"></param>
        public void setMessageType(IMessageSpecification messageSpecification)
        {
            this.messageSpecification = messageSpecification;
        }

        /// <summary>
        /// Method that sets the receiver attribute of the instance
        /// </summary>
        /// <param name="receiver"></param>
        public void setReceiver(ISubject receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Method that sets the sender attribute of the instance
        /// </summary>
        /// <param name="sender"></param>
        public void setSender(ISubject sender)
        {
            this.sender = sender;
        }

        /// <summary>
        /// Method that returns the message specification attribute of the instance
        /// </summary>
        /// <returns>The message specification attribute of the instance</returns>
        public IMessageSpecification getMessageType()
        {
            return messageSpecification;
        }

        /// <summary>
        /// Method that returns the receiver attribute of the instance
        /// </summary>
        /// <returns>The receiver attribute of the instance</returns>
        public ISubject getReceiver()
        {
            return receiver;
        }

        /// <summary>
        /// Method that returns the sender attribute of the instance
        /// </summary>
        /// <returns>The sender attribute of the instance</returns>
        public ISubject getSender()
        {
            return sender;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpMessageSpecification()
        {
            return tmpMessageSpecification;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpReceiver()
        {
            return tmpReceiver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSender()
        {
            return tmpSender;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the message exchange class
        /// </summary>
        /// <returns>A new empty instance of the message exchange class</returns>
        new public AbstractMessageExchange factoryMethod()
        {
            AbstractMessageExchange messageExchange = new AbstractMessageExchange();

            return messageExchange;
        }

        /// <summary>
        /// Method that creates a new instance of the abstract message exchange class
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
                if (s.ToLower().Contains("hasMessageType"))
                {
                    tmpMessageSpecification = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.ToLower().Contains("hasReceiver"))
                {
                    tmpReceiver = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.ToLower().Contains("hasSender"))
                {
                    tmpSender = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

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

            foreach (string s in tmp)
            {

                if (allElements.ContainsKey(s))
                {
                    if (new MessageSpecification().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.messageSpecification = (MessageSpecification)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new Subject().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.receiver = (Subject)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new Subject().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sender = (Subject)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Method that exports an abstract message exchange object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (sender != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasSender" + " rdf:resource=\"" + sender.getModelComponentID() + "\" ></standard-pass-ont:hasSender>");
                }

                if (receiver != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasReceiver" + " rdf:resource=\"" + receiver.getModelComponentID() + "\" ></standard-pass-ont:hasReceiver>");
                }

                if (messageSpecification != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMessageSpecification" + " rdf:resource=\"" + messageSpecification.getModelComponentID() + "\" ></standard-pass-ont:hasMessageSpecification>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&abstract-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
