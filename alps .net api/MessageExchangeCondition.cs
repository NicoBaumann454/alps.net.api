using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an message exchange conditon
    /// </summary>

    public class MessageExchangeCondition : TransitionCondition, IMessageExchangeCondition
    {
        private IMessageExchange messageExchange;
        private string tmpMessageExchange;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "MessageExchangeCondition";

        /// <summary>
        /// Constructor that creates a new empty instance of the message exchange condition class
        /// </summary>
        public MessageExchangeCondition()
        {
            setModelComponentID("MessageExchangeCondition");
            setComment("The standart Element for MessageExchangeCondition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the message exchange condition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="messageExchange"></param>
        public MessageExchangeCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion, MessageExchange messageExchange)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);
            setRequiresPerformedMessageExchange(messageExchange);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="messageExchange"></param>
        /// <param name="additionalAttribute"></param>
        public MessageExchangeCondition(string label, string comment = "", string toolSpecificDefintion = "", IMessageExchange messageExchange = null, List<string> additionalAttribute = null)
        {
            if (messageExchange != null)
            {
                this.messageExchange = messageExchange;
            }
        }

        /// <summary>
        /// Method that sets the message exchange attribute of the instance
        /// </summary>
        /// <param name="messageExchange"></param>
        public void setRequiresPerformedMessageExchange(IMessageExchange messageExchange)
        {
            this.messageExchange = messageExchange;
        }

        /// <summary>
        /// Method that returns the message exchange attribute of the instance
        /// </summary>
        /// <returns>The message exchange attribute of the instance</returns>
        public IMessageExchange getRequiresPerformedMessageExchange()
        {
            return messageExchange;
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
        /// Factory method that creates and returns a new empty instance of the message exchange condition class
        /// </summary>
        /// <returns>A new empty instance of the message exchange condition class</returns>
        new public MessageExchangeCondition factoryMethod()
        {
            MessageExchangeCondition messageExchangeCondition = new MessageExchangeCondition();

            return messageExchangeCondition;
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
            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {
                if (s.ToLower().Contains("hasMessageExchange"))
                {
                    tmpMessageExchange = attribute[counter];
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
                    if (new MessageExchange().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.messageExchange = (MessageExchange)allElements[s];
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

                if (messageExchange != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasMessageExchange");
                    objec = g.CreateUriNode("standard-pass-ont:" + messageExchange.getModelComponentID());

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

                if (messageExchange != null)
                {
                    sw.WriteLine("      <standard-pass-ont:requiresPerformedMessageExchange" + " rdf:resource=\"" + messageExchange.getModelComponentID() + "\" ></standard-pass-ont:requiresPerformedMessageExchange>");
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