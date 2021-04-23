using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{

    /// <summary>
    /// Class that represents an message exchange
    /// </summary>

    public class MessageExchange : InteractionDescriptionComponent, IMessageExchange
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
        new public const string className = "MessageExchange";

        /// <summary>
        /// Constructor that creates a new empty instance of the message exchange class
        /// </summary>
        public MessageExchange()
        {
            setModelComponentID("MessageExchange");
            setComment("The standart Element for MessageExchange");
        }

        /// <summary>
        /// Constructor that creates a fully specified empty instance of the message exchange class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="receiver"></param>
        /// <param name="sender"></param>
        public MessageExchange(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageSpecification messageSpecification, Subject receiver, Subject sender)
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
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="senderSubject"></param>
        /// <param name="receiverSubject"></param>
        /// <param name="additionalAttribute"></param>
        public MessageExchange(string label, string comment = "", IMessageSpecification messageSpecification = null, ISubject senderSubject = null, ISubject receiverSubject = null, List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            if (senderSubject != null)
            {
                this.sender = senderSubject;
            }

            if (receiverSubject != null)
            {
                this.receiver = receiverSubject;
            }

            if (messageSpecification != null)
            {
                this.messageSpecification = messageSpecification;
            }
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
        /// <param name="sender"></param>
        public void setTmpSender(string sender)
        {
            this.tmpSender = sender;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiver"></param>
        public void setTmpReceiver(string receiver)
        {
            this.tmpReceiver = receiver;
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
        new public MessageExchange factoryMethod()
        {
            MessageExchange messageExchange = new MessageExchange();

            return messageExchange;
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
                if (s.ToLower().Contains("hasMessageSpecification"))
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
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }

                        //tmp.Remove(s);
                    }

                    //int i = getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID());

                    if (new Subject().GetType().IsInstanceOfType(allElements[s]))
                    {
                        if (getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID()) >= 0)
                        {
                            if (getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID())].Contains("Receiver"))
                            {
                                this.receiver = (Subject)allElements[s];
                                int place = getAdditionalAttribute().IndexOf(s);
                                if (place >= 0)
                                {
                                    getAdditionalAttributeType().RemoveAt(place);
                                    getAdditionalAttribute().Remove(s);
                                }
                            }
                            if (getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID())].Contains("Sender"))
                            {
                                this.sender = (Subject)allElements[s];
                                int place = getAdditionalAttribute().IndexOf(s);
                                if (place >= 0)
                                {
                                    getAdditionalAttributeType().RemoveAt(place);
                                    getAdditionalAttribute().Remove(s);
                                }
                            }
                        }
                    }
                    //tmp.Remove(s);
                }
            }


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

            if (messageSpecification != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("standard-pass-ont:hasMessageSpecification");
                objec = g.CreateUriNode("standard-pass-ont:" + messageSpecification.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (sender != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("standard-pass-ont:hasSender");
                objec = g.CreateUriNode("standard-pass-ont:" + sender.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);

            }

            if (receiver != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("standard-pass-ont:hasReceiver");
                objec = g.CreateUriNode("standard-pass-ont:" + receiver.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);
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

                if (messageSpecification != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMessageType" + " rdf:resource=\"" + messageSpecification.getModelComponentID() + "\" ></standard-pass-ont:hasMessageType>");
                }

                if (sender != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasSender" + " rdf:resource=\"" + sender.getModelComponentID() + "\" ></standard-pass-ont:hasSender>");
                }

                if (receiver != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasReceiver" + " rdf:resource=\"" + receiver.getModelComponentID() + "\" ></standard-pass-ont:hasReceiver>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
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
            stringAttributes.Add(tmpMessageSpecification);
            stringAttributes.Add(tmpReceiver);
            stringAttributes.Add(tmpSender);
            return stringAttributes;
        }
    }
}
