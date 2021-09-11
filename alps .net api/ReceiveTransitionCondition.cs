using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{

    /// <summary>
    /// Class that represents a receive transition condition
    /// </summary>
    public class ReceiveTransitionCondition : MessageExchangeCondition, IReceiveTransitionCondition
    {
        private int lowerBound;
        private int upperBound;
        private IReceiveType receiveType;
        private ISubject messageSentFromSubject;
        private IMessageSpecification receptionOfMessage;
        private string tmpLowerBound;
        private string tmpUpperBound;
        private string tmpReceiveType;
        private string tmpMessageSentFromSubject;
        private string tmpReceptionOfMessage;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "ReceiveTransitionCondition";

        /// <summary>
        /// Constructor that creates a new empty instance of the receive transition condition class
        /// </summary>
        public ReceiveTransitionCondition()
        {
            setModelComponentID("ReceiveTransitionCondition");
            setComment("The standart Element for ReceiveTransitionCondition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the receive transition condition class
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
        /// <param name="receiveType"></param>
        /// <param name="messageSentFromSubject"></param>
        /// <param name="receptionOfMessage"></param>
        public ReceiveTransitionCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion, MessageExchange messageExchange, int lowerBound, int upperBound, ReceiveType receiveType, Subject messageSentFromSubject, MessageSpecification receptionOfMessage)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);
            setRequiresPerformedMessageExchange(messageExchange);
            setMultipleReceiveLowerBound(lowerBound);
            setMultipleReceiveUpperBound(upperBound);
            setReceiveType(receiveType);
            setRequiresMessageSentFrom(messageSentFromSubject);
            setRequiresReceptionOfMessage(receptionOfMessage);

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
        public ReceiveTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", IMessageExchange messageExchange = null, int upperBound = 0, int lowerBound = 0, IReceiveType receiveType = null, ISubject requiredMessageSendFromSubject = null, IMessageSpecification requiresReceptionOfMessage = null, List<string> additionalAttribute = null) : base(label, comment, toolSpecificDefintion, messageExchange, additionalAttribute)
        {
            if (requiredMessageSendFromSubject != null)
            {
                this.messageSentFromSubject = requiredMessageSendFromSubject;
            }

            if (receiveType != null)
            {
                this.receiveType = receiveType;
            }

            if (requiresReceptionOfMessage != null)
            {
                this.receptionOfMessage = requiresReceptionOfMessage;
            }
        }

        /// <summary>
        /// Method that sets the lower bound attribute of the instance
        /// </summary>
        /// <param name="lowerBound"></param>
        public void setMultipleReceiveLowerBound(int lowerBound)
        {
            this.lowerBound = lowerBound;
        }

        /// <summary>
        /// Method that sets the upper bound attribute of the instance
        /// </summary>
        /// <param name="upperBound"></param>
        public void setMultipleReceiveUpperBound(int upperBound)
        {
            this.upperBound = upperBound;
        }

        /// <summary>
        /// Method that sets the receive type attribute of the instance
        /// </summary>
        /// <param name="receiveType"></param>
        public void setReceiveType(IReceiveType receiveType)
        {
            this.receiveType = receiveType;
        }

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        public void setRequiresMessageSentFrom(ISubject subject)
        {
            this.messageSentFromSubject = subject;
        }

        /// <summary>
        /// Method that sets the message specification attribute of the instance
        /// </summary>
        /// <param name="messageSpecification"></param>
        public void setRequiresReceptionOfMessage(IMessageSpecification messageSpecification)
        {
            this.receptionOfMessage = messageSpecification;
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
        /// Method that returns the upper bound attribute of the instance
        /// </summary>
        /// <returns>The upper bound attribute of the instance</returns>
        public int getMultipleUpperBound()
        {
            return upperBound;
        }

        /// <summary>
        /// Method that returns the receive type attribute of the instance
        /// </summary>
        /// <returns>The receive type attribute of the instance</returns>
        public IReceiveType getReceiveType()
        {
            return receiveType;
        }

        /// <summary>
        /// Method that returns the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        public ISubject getMessageSentFrom()
        {
            return messageSentFromSubject;
        }

        /// <summary>
        /// Method that returns the message specification attribute of the instance
        /// </summary>
        /// <returns>The message specification attribute of the instance</returns>
        public IMessageSpecification getReceptionOfMessage()
        {
            return receptionOfMessage;
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
        public string getTmpReceiveType()
        {
            return tmpReceiveType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpMessageSentFromSubject()
        {
            return tmpMessageSentFromSubject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpReceptionOfMessage()
        {
            return tmpReceptionOfMessage;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the receive transition condition class
        /// </summary>
        /// <returns>A new empty instance of the receive transition condition class</returns>
        new public ReceiveTransitionCondition factoryMethod()
        {
            ReceiveTransitionCondition receiveTransitionCondition = new ReceiveTransitionCondition();

            return receiveTransitionCondition;
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

                if (s.Contains("requiresMessageSentFrom"))
                {
                    tmpMessageSentFromSubject = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasInputPoolConstraint"))
                {
                    tmpReceptionOfMessage = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasInputPoolConstraint"))
                {
                    tmpMessageSentFromSubject = attribute[counter];
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
                    if (new ReceiveType().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.receiveType = (ReceiveType)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new Subject().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.messageSentFromSubject = (Subject)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new MessageSpecification().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.receptionOfMessage = (MessageSpecification)allElements[s];
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
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (lowerBound > -1)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMultiReceiveLowerBound rdf:datatype=\"http://www.w3.org/2001/XMLSchema#nonNegativeInteger\" >" + lowerBound + "</standard-pass-ont:hasMultiReceiveLowerBound>");
                }

                if (upperBound > -1)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMultiReceiveUpperBound rdf:datatype=\"http://www.w3.org/2001/XMLSchema#nonNegativeInteger\" >" + lowerBound + "</standard-pass-ont:hasMultiReceiveUpperBound>");
                }

                if (receiveType != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasReceiveType" + " rdf:resource=\"" + receiveType.getModelComponentID() + "\" ></standard-pass-ont:hasReceiveType>");
                }

                if (messageSentFromSubject != null)
                {
                    sw.WriteLine("      <standard-pass-ont:requiresMessageSentFrom" + " rdf:resource=\"" + messageSentFromSubject.getModelComponentID() + "\" ></standard-pass-ont:requiresMessageSentFrom>");
                }

                if (receptionOfMessage != null)
                {
                    sw.WriteLine("      <standard-pass-ont:requiresReceptionOfMessage" + " rdf:resource=\"" + receptionOfMessage.getModelComponentID() + "\" ></standard-pass-ont:requiresReceptionOfMessage>");
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