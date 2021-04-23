using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an interface subject
    /// </summary>

    public class InterfaceSubject : Subject, IInterfaceSubject
    {
        private IFullySpecifiedSubject fullySpecifiedSubject;
        private string tmpFullySpecifiedSubject;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "InterfaceSubject";

        /// <summary>
        /// Constructor that creates a new empty instance of the interface subject class
        /// </summary>
        public InterfaceSubject()
        {
            setModelComponentID("InterfaceSubject");
            setComment("The standart Element for InterfaceSubject");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the interface subject class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="instanceRestriction"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="fullySpecifiedSubject"></param>
        public InterfaceSubject(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange incomingMessageExchange, int instanceRestriction, MessageExchange outgoingMessageExchange, FullySpecifiedSubject fullySpecifiedSubject)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setIncomingMessageExchange(incomingMessageExchange);
            setMaximumSubjectInstanceRestriction(instanceRestriction);
            setOutgoingMessageExchange(outgoingMessageExchange);
            setReferences(fullySpecifiedSubject);
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
        /// <param name="fullySpecifiedSubject"></param>
        public InterfaceSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 1, IFullySpecifiedSubject fullySpecifiedSubject = null, List<string> additionalAttribute = null) : base(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, additionalAttribute)
        {
            if (fullySpecifiedSubject != null)
            {
                this.fullySpecifiedSubject = fullySpecifiedSubject;
            }
        }

        /// <summary>
        /// Method that sets the fully specified subject attribute of the instance
        /// </summary>
        /// <param name="fullySpecifiedSubject"></param>
        public void setReferences(IFullySpecifiedSubject fullySpecifiedSubject)
        {
            this.fullySpecifiedSubject = fullySpecifiedSubject;
        }

        /// <summary>
        /// Method that returns the fully specified subject attribute of the instance
        /// </summary>
        /// <returns></returns>
        public IFullySpecifiedSubject getFullySpecifiedSubject()
        {
            return this.fullySpecifiedSubject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpFullySpecifiedSubject()
        {
            return tmpFullySpecifiedSubject;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the interface subject class
        /// </summary>
        /// <returns></returns>
        new public InterfaceSubject factoryMethod()
        {
            InterfaceSubject interfaceSubject = new InterfaceSubject();

            return interfaceSubject;
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
                if (s.ToLower().Contains("hasFullySpecifiedSubject"))
                {
                    tmpFullySpecifiedSubject = attribute[counter];
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
                    if (new FullySpecifiedSubject().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.fullySpecifiedSubject = (FullySpecifiedSubject)allElements[s];
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

            if (fullySpecifiedSubject != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasFullySpecifiedSubject");
                objec = g.CreateUriNode("standard-pass-ont:" + fullySpecifiedSubject.getModelComponentID());

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

                if (fullySpecifiedSubject != null)
                {
                    sw.WriteLine("      <standard-pass-ont:refrences" + " rdf:resource=\"" + fullySpecifiedSubject.getModelComponentID() + "\" ></standard-pass-ont:refrences>");
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