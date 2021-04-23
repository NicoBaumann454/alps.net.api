using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a message type constraint
    /// </summary>

    public class MessageTypeConstraint : InputPoolConstraint, IMessageTypeConstraint
    {
        private IMessageSpecification messageSpecification;
        private string tmpMessageSpecification;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "MessageTypeConstraint";

        /// <summary>
        /// Constructor that creates a new empty instance of the message type constraint class
        /// </summary>
        public MessageTypeConstraint()
        {
            setModelComponentID("MessageTypeConstraint");
            setComment("The standart Element for MessageTypeConstraint");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the message type constraint class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="messageSpecification"></param>
        public MessageTypeConstraint(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy, int limit, MessageSpecification messageSpecification)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setHandlingStrategy(inputPoolConstraintHandlingStrategy);
            setLimit(limit);
            setReferncesMessageSpecification(messageSpecification);

        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the message type constraint class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="messageSpecification"></param>
        /// <param name="additionalAttribute"></param>
        public MessageTypeConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, IMessageSpecification messageSpecification = null, List<string> additionalAttribute = null) : base(label, comment, inputPoolConstraintHandlingStrategy, limit, additionalAttribute)
        {
            if (messageSpecification != null)
            {
                this.messageSpecification = messageSpecification;
            }

        }

        /// <summary>
        /// Method that sets the message specification attribute of the instance
        /// </summary>
        /// <param name="messageSpecification"></param>
        public void setReferncesMessageSpecification(IMessageSpecification messageSpecification)
        {
            this.messageSpecification = messageSpecification;
        }

        /// <summary>
        /// Method that returns the message specification attribute of the instance
        /// </summary>
        /// <returns>The message specification attribute of the instance</returns>
        public IMessageSpecification getMessageSpecification()
        {
            return messageSpecification;
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
        /// Factory method that creates and returns a new empty instance of the message type constraint class
        /// </summary>
        /// <returns>A new empty instance of the message type constraint class</returns>
        new public MessageTypeConstraint factoryMethod()
        {
            MessageTypeConstraint messageTypeConstraint = new MessageTypeConstraint();

            return messageTypeConstraint;
        }

        /// <summary>
        /// Method that creates a new instance of the message type constraint class
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
                    sw.WriteLine("      <standard-pass-ont:references" + " rdf:resource=\"" + messageSpecification.getModelComponentID() + "\" ></standard-pass-ont:references>");
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
