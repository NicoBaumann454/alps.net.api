using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a send transition condition
    /// </summary>
    public class SendTransitionCondition : MessageExchangeCondition, ISendTransitionCondition
    {
        private int lowerBound;
        private int upperBound;
        private ISendType sendType;
        private ISubject messageSentTo;
        private IMessageSpecification senderOfMessage;
        private string tmpLowerBound;
        private string tmpUpperBound;
        private string tmpSendType;
        private string tmpMessageSentTo;
        private string tmpSenderOfMessage;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SendTransitionCondition";

        /// <summary>
        /// Constructor that creates a new empty instance of the send transition condition class
        /// </summary>
        public SendTransitionCondition()
        {
            setModelComponentID("SendTransitionCondition");
            setComment("The standart Element for SendTransitionCondition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the send transition condition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="messageExchange"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="sendType"></param>
        /// <param name="messageSentFromSubject"></param>
        /// <param name="receptionOfMessage"></param>
        public SendTransitionCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion, MessageExchange messageExchange, int lowerBound, int upperBound, SendType sendType, Subject messageSentFromSubject, MessageSpecification receptionOfMessage)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);
            setRequiresPerformedMessageExchange(messageExchange);
            setMultipleSendLowerBound(lowerBound);
            setMultipleSendUpperBound(upperBound);
            setSendType(sendType);
            setRequiresMessageSentTo(messageSentFromSubject);
            setRequiresSendingOfMessage(receptionOfMessage);

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
        public SendTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", IMessageExchange messageExchange = null, int upperBound = 0, int lowerBound = 0, ISendType sendType = null, ISubject requiredMessageSendToSubject = null, IMessageSpecification requiresSendingOfMessage = null, List<string> additionalAttribute = null) : base(label, comment, toolSpecificDefintion, messageExchange, additionalAttribute)
        {
            if (requiredMessageSendToSubject != null)
            {
                this.messageSentTo = requiredMessageSendToSubject;
            }

            if (sendType != null)
            {
                this.sendType = sendType;
            }

            if (requiresSendingOfMessage != null)
            {
                this.senderOfMessage = requiresSendingOfMessage;
            }

            this.upperBound = upperBound;
            this.lowerBound = lowerBound;

        }

        /// <summary>
        /// Method that sets the lower bound attribute of the instance
        /// </summary>
        /// <param name="lowerBound"></param>
        public void setMultipleSendLowerBound(int lowerBound)
        {
            this.lowerBound = lowerBound;
        }

        /// <summary>
        /// Method that sets the upper bound attribute of the instance
        /// </summary>
        /// <param name="upperBound"></param>
        public void setMultipleSendUpperBound(int upperBound)
        {
            this.upperBound = upperBound;
        }

        /// <summary>
        /// Method that sets the send type attribute of the instance
        /// </summary>
        /// <param name="sendType"></param>
        public void setSendType(ISendType sendType)
        {
            this.sendType = sendType;
        }

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        public void setRequiresMessageSentTo(ISubject subject)
        {
            this.messageSentTo = subject;
        }

        /// <summary>
        /// Method that sets the message specification attribute of the instance
        /// </summary>
        /// <param name="messageSpecification"></param>
        public void setRequiresSendingOfMessage(IMessageSpecification messageSpecification)
        {
            this.senderOfMessage = messageSpecification;
        }

        /// <summary>
        /// Method that returns the lower bound attribute of the instance 
        /// </summary>
        /// <returns>The lower bound attribute of the instance</returns>
        public int getMultilpleLowerBound()
        {
            return lowerBound;
        }

        /// <summary>
        ///  Method that returns the upper bound attribute of the instance
        /// </summary>
        /// <returns>The upper bound attribute of the instance</returns>
        public int getMultipleUpperBound()
        {
            return upperBound;
        }

        /// <summary>
        ///  Method that returns the send type attribute of the instance
        /// </summary>
        /// <returns>The send type attribute of the instance</returns>
        public ISendType getSendType()
        {
            return sendType;
        }

        /// <summary>
        ///  Method that sets the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        public ISubject getMessageSentTo()
        {
            return messageSentTo;
        }

        /// <summary>
        ///  Method that sets the message specification attribute of the instance
        /// </summary>
        /// <returns>The message specification attribute of the instance</returns>
        public IMessageSpecification getSenderOfMessage()
        {
            return senderOfMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpLowerBound()
        {
            return tmpLowerBound;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpUpperBound()
        {
            return tmpUpperBound;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSendType()
        {
            return tmpSendType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpMessageSentTo()
        {
            return tmpMessageSentTo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSenderOfMessage()
        {
            return tmpSenderOfMessage;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the send transition condition class
        /// </summary>
        /// <returns>A new empty instance of the send transition condition class</returns>
        new public SendTransitionCondition factoryMethod()
        {
            SendTransitionCondition sendTransitionCondition = new SendTransitionCondition();

            return sendTransitionCondition;
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

                if (s.Contains("hasMultiSendLowerBound"))
                {
                    tmpLowerBound = attribute[counter];
                    tmpLowerBound = tmpLowerBound.Split('^')[0];
                    lowerBound = Int32.Parse(tmpLowerBound);
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasMultiSendUpperBound"))
                {
                    tmpUpperBound = attribute[counter];
                    tmpUpperBound = tmpUpperBound.Split('^')[0];
                    upperBound = Int32.Parse(tmpUpperBound);
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("requiresMessageSentTo"))
                {
                    tmpMessageSentTo = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("requiresSendingOfMessage"))
                {
                    tmpSenderOfMessage = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasSendType"))
                {
                    tmpSendType = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

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

            foreach (string s in tmp)
            {

                if (allElements.ContainsKey(s))
                {
                    if (new Subject().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.messageSentTo = (Subject)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new MessageSpecification().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.senderOfMessage = (MessageSpecification)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new SendType().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sendType = (SendType)allElements[s];
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
            try
            {
                Uri name = new Uri(nameString);
                //Console.WriteLine(name);
                //Console.WriteLine();

                if (upperBound >= 0)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasUpperBound");
                    objec = g.CreateUriNode("standard-pass-ont:" + upperBound);

                    test = new Triple(subject, predicate, objec);
                    g.Assert(test);

                    //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
                }

                if (this.lowerBound >= 0)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasLowerBound");
                    objec = g.CreateUriNode("standard-pass-ont:" + this.lowerBound);

                    test = new Triple(subject, predicate, objec);
                    //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                    g.Assert(test);

                }

                if (sendType != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasSendType");
                    objec = g.CreateUriNode("standard-pass-ont:" + sendType.getModelComponentID());

                    test = new Triple(subject, predicate, objec);
                    g.Assert(test);

                    //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
                }

                if (this.senderOfMessage != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasSenderOfMessage");
                    objec = g.CreateUriNode("standard-pass-ont:" + this.senderOfMessage.getModelComponentID());

                    test = new Triple(subject, predicate, objec);
                    g.Assert(test);

                    //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
                }

                if (this.messageSentTo != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasMessageSentTo");
                    objec = g.CreateUriNode("standard-pass-ont:" + messageSentTo.getModelComponentID());

                    test = new Triple(subject, predicate, objec);
                    g.Assert(test);

                    //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
                }
            }
            catch { }
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

                if (lowerBound > -1)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMultiSendLowerBound rdf:datatype=\"http://www.w3.org/2001/XMLSchema#nonNegativeInteger\" >" + lowerBound + "</standard-pass-ont:hasMultiSendLowerBound>");
                }

                if (upperBound > -1)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMultiSendUpperBound rdf:datatype=\"http://www.w3.org/2001/XMLSchema#nonNegativeInteger\" >" + lowerBound + "</standard-pass-ont:hasMultiSendUpperBound>");
                }

                if (sendType != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasSendType" + " rdf:resource=\"" + sendType.getModelComponentID() + "\" ></standard-pass-ont:hasSendType>");
                }

                if (messageSentTo != null)
                {
                    sw.WriteLine("      <standard-pass-ont:requiresMessageSentTo" + " rdf:resource=\"" + messageSentTo.getModelComponentID() + "\" ></standard-pass-ont:requiresMessageSentTo>");
                }

                if (senderOfMessage != null)
                {
                    sw.WriteLine("      <standard-pass-ont:requiresSendingOfMessage" + " rdf:resource=\"" + senderOfMessage.getModelComponentID() + "\" ></standard-pass-ont:requiresSendingOfMessage>");
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