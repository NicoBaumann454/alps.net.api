using System;
using System.Collections.Generic;
using VDS.RDF;

namespace alps.net_api
{
    class FinalizedMessageExchange : ALPSSIDComponent
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
        new public const string className = "FinalizedMessageExchange";

        /// <summary>
        /// Constructor that creates a new empty instance of the finalized message exchange class
        /// </summary>
        public FinalizedMessageExchange()
        {
            setModelComponentID("FinalizedMessageExchange");
            setComment("The standart Element for FinalizedMessageExchange");
        }

        /// <summary>
        /// Constructor that creates a fully specified empty instance of the finalized message exchange class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="receiver"></param>
        /// <param name="sender"></param>
        public FinalizedMessageExchange(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageSpecification messageSpecification, Subject receiver, Subject sender)
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
        new public FinalizedMessageExchange factoryMethod()
        {
            FinalizedMessageExchange messageExchange = new FinalizedMessageExchange();

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

            if (messageSpecification != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasMessageSpecification");
                objec = g.CreateUriNode("standard-pass-ont:" + messageSpecification.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (sender != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasSender");
                objec = g.CreateUriNode("standard-pass-ont:" + sender.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);

            }

            if (receiver != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasReceiver");
                objec = g.CreateUriNode("standard-pass-ont:" + receiver);

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);
            }
        }
    }
}
