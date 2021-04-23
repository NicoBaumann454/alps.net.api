using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that contains a certain message specification
    /// </summary>

    public class MessageSpecification : InteractionDescriptionComponent, IMessageSpecification
    {
        private IPayloadDescription payloadDescription;
        private string tmpPayloadDescription;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "MessageSpecification";

        /// <summary>
        /// Constructor that creates a new empty instance of the message specifiaction class
        /// </summary>
        public MessageSpecification()
        {
            setModelComponentID("MessageSpecification");
            setComment("The standart Element for MessageSpecification");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the message specifiaction class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="payloadDescription"></param>
        public MessageSpecification(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, PayloadDescription payloadDescription)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsPayloadDescription(payloadDescription);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="payloadDescription"></param>
        /// <param name="additionalAttribute"></param>
        public MessageSpecification(string label, string comment = "", IPayloadDescription payloadDescription = null, List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            this.payloadDescription = payloadDescription;
        }

        /// <summary>
        /// Method that sets the payload description attribute of the instance
        /// </summary>
        /// <param name="payloadDescription"></param>
        public void setContainsPayloadDescription(IPayloadDescription payloadDescription)
        {
            this.payloadDescription = payloadDescription;
        }

        /// <summary>
        /// Method that returns the payload description attribute of the instance
        /// </summary>
        /// <returns>The payload description attribute of the instance</returns>
        public IPayloadDescription getPayloadDescription()
        {
            return payloadDescription;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpPayloadDescription()
        {
            return tmpPayloadDescription;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the message specification class
        /// </summary>
        /// <returns>A new empty instance of the message specification class</returns>
        new public MessageSpecification factoryMethod()
        {
            MessageSpecification messageSpecification = new MessageSpecification();

            return messageSpecification;
        }

        /// <summary>
        /// Method that creates a new instance of the message specification class
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
                    if (new PayloadDescription().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.payloadDescription = (PayloadDescription)allElements[s];
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

                if (payloadDescription != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasPayloadDescription");
                    objec = g.CreateUriNode("standard-pass-ont:" + payloadDescription.getModelComponentID());

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

                if (payloadDescription != null)
                {
                    sw.WriteLine("      <standard-pass-ont:containsPayloadDescription" + " rdf:resource=\"" + payloadDescription.getModelComponentID() + "\" ></standard-pass-ont:containsPayloadDescription>");
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