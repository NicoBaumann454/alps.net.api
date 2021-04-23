using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a sender type constraint
    /// </summary>
    public class SenderTypeConstraint : InputPoolConstraint, ISenderTypeConstraint
    {
        private ISubject subject;
        private string tmpSubject;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SenderTypeConstraint";

        /// <summary>
        /// Constructor that creates a new empty instance of the sender type constraint class
        /// </summary>
        public SenderTypeConstraint()
        {
            setModelComponentID("SenderTypeConstraint");
            setComment("The standart Element for SenderTypeConstraint");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the sender type constraint class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="subject"></param>
        public SenderTypeConstraint(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy, int limit, Subject subject)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setHandlingStrategy(inputPoolConstraintHandlingStrategy);
            setLimit(limit);
            setReferencesSubject(subject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        /// <param name="subject"></param>
        /// <param name="additionalAttribute"></param>
        public SenderTypeConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, ISubject subject = null, List<string> additionalAttribute = null) : base(label, comment, inputPoolConstraintHandlingStrategy, limit, additionalAttribute)
        {

            if (subject != null)
            {
                this.subject = subject;
            }
        }

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        public void setReferencesSubject(ISubject subject)
        {
            this.subject = subject;
        }

        /// <summary>
        /// Method that returns the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        public ISubject getReferenceSubject()
        {
            return subject;
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
        /// Factory method that creates and returns a empty instance of the sender type constraint class
        /// </summary>
        /// <returns>A empty instance of the sender type constraint class</returns>
        new public SenderTypeConstraint factoryMethod()
        {
            SenderTypeConstraint senderTypeConstraint = new SenderTypeConstraint();

            return senderTypeConstraint;
        }

        /// <summary>
        /// Method that creates a new instance of the sender type constraint class
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

            if (this.subject != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasSubjct");
                objec = g.CreateUriNode("standard-pass-ont:" + this.subject.getModelComponentID());

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