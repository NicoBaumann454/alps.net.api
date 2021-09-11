using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an message sender type constraint
    /// </summary>

    public class MessageSenderTypeConstraint : InputPoolConstraint, IMessageSenderTypeConstraint
    {
        private IMessageSpecification messageSpecification;
        private ISubject subject;
        private string tmpMessageSpecification;
        private string tmpSubject;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "MessageSenderTypeConstraint";

        /// <summary>
        /// Constructor that creates an empty instance of the MessageSenderTypeConstraint class
        /// </summary>
        public MessageSenderTypeConstraint()
        {
            setModelComponentID("MessageSenderTypeConstraint");
            setComment("The standart Element for MessageSenderTypeConstraint");
        }

        /// <summary>
        /// Constructor that creates an completly specified instance of the MessageSenderTypeConstraint class
        /// </summary>
        public MessageSenderTypeConstraint(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy, int limit, MessageSpecification messageSpecification, Subject subject)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setHandlingStrategy(inputPoolConstraintHandlingStrategy);
            setLimit(limit);
            setReferncesMessageSpecification(messageSpecification);
            setReferencesSubject(subject);
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
        public MessageSenderTypeConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, IMessageSpecification messageSpecification = null, ISubject subject = null, List<string> additionalAttribute = null) : base(label, comment, inputPoolConstraintHandlingStrategy, limit, additionalAttribute)
        {
            if (messageSpecification != null)
            {
                this.messageSpecification = messageSpecification;
            }

            if (subject != null)
            {
                this.subject = subject;
            }
        }

        /// <summary>
        /// Method that sets the message specification attribute
        /// </summary>
        /// <param name="messageSpecification"></param>
        public void setReferncesMessageSpecification(IMessageSpecification messageSpecification)
        {
            this.messageSpecification = messageSpecification;
        }

        /// <summary>
        /// Method that sets the subject attribute
        /// </summary>
        /// <param name="subject"></param>
        public void setReferencesSubject(ISubject subject)
        {
            this.subject = subject;
        }

        /// <summary>
        /// Method that returns the message specification attribute
        /// </summary>
        /// <returns>Returns the object specific message specification</returns>
        public IMessageSpecification getMessageSpecification()
        {
            return messageSpecification;
        }

        /// <summary>
        /// Method that returns the subject attribute
        /// </summary>
        /// <returns>The object specific subject</returns>
        public ISubject getReferenceSubject()
        {
            return subject;
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
        public string getTmpSubject()
        {
            return tmpSubject;
        }

        /// <summary>
        /// Method that creates a new empty instance of the Message Sender Type Constraint class
        /// </summary>
        /// <returns>A new instance of the Message Sender Type Constraint</returns>
        new public MessageSenderTypeConstraint factoryMethod()
        {
            MessageSenderTypeConstraint messageSenderTypeConstraint = new MessageSenderTypeConstraint();

            return messageSenderTypeConstraint;
        }

        /// <summary>
        /// Method that creates a new instance of the message sender type constraint class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);
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
                        this.subject = (Subject)allElements[s];
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

                if (messageSpecification != null)
                {
                    sw.WriteLine("      <standard-pass-ont:refrences" + " rdf:resource=\"" + messageSpecification.getModelComponentID() + "\" ></standard-pass-ont:references>");
                }

                if (subject != null)
                {
                    sw.WriteLine("      <standard-pass-ont:references" + " rdf:resource=\"" + subject.getModelComponentID() + "\" ></standard-pass-ont:references>");
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