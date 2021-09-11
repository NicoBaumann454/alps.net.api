using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a subject
    /// </summary>
    public class Subject : InteractionDescriptionComponent, ISubject
    {
        private IMessageExchange incomingMessageExchange;
        private int instanceRestriction = 0;
        private IMessageExchange outgoingMessageExchange;
        private string tmpIncomingMessageExchange;
        private string tmpInstanceRestriction;
        private string tmpOutgoingMessageExchange;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "Subject";

        /// <summary>
        /// Constructor that creates a new empty instance of the subject class
        /// </summary>
        public Subject()
        {
            setModelComponentID("Subject");
            setComment("The standart Element for Subject");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the subject class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="instanceRestriction"></param>
        /// <param name="outgoingMessageExchange"></param>
        public Subject(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange incomingMessageExchange, int instanceRestriction, MessageExchange outgoingMessageExchange)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setIncomingMessageExchange(incomingMessageExchange);
            setMaximumSubjectInstanceRestriction(instanceRestriction);
            setOutgoingMessageExchange(outgoingMessageExchange);
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
        public Subject(string label, string comment = "", IMessageExchange incomingMessageExchange = null,
                        IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 1,
                          List<string> additionalAttribute = null) :
                            base(label, comment, additionalAttribute)
        {
            if (incomingMessageExchange != null)
            {
                this.incomingMessageExchange = incomingMessageExchange;
            }

            if (outgoingMessageExchange != null)
            {
                this.outgoingMessageExchange = outgoingMessageExchange;
            }

            this.setMaximumSubjectInstanceRestriction(maxSubjectInstanceRestriction);

        }

        /// <summary>
        /// Method that sets the incoming message exchange attribute of the instance
        /// </summary>
        /// <param name="incomingMessageExchange"></param>
        public void setIncomingMessageExchange(IMessageExchange incomingMessageExchange)
        {
            this.incomingMessageExchange = incomingMessageExchange;
        }

        /// <summary>
        /// Method that sets the instance restriction attribute of the instance
        /// </summary>
        /// <param name="instanceRestriction"></param>
        public void setMaximumSubjectInstanceRestriction(int instanceRestriction)
        {
            this.instanceRestriction = instanceRestriction;
        }

        /// <summary>
        /// Method that sets the outgoing message exchange attribute of the instance
        /// </summary>
        /// <param name="outgoingMessageExchange"></param>
        public void setOutgoingMessageExchange(IMessageExchange outgoingMessageExchange)
        {
            this.outgoingMessageExchange = outgoingMessageExchange;
        }

        /// <summary>
        /// Method that returns the incoming message exchange attribute of the instance
        /// </summary>
        /// <returns>The incoming message exchange attribute of the instance</returns>
        public IMessageExchange getIncomingMessageExchange()
        {
            return incomingMessageExchange;
        }

        /// <summary>
        /// Method that returns the instance restriction attribute of the instance
        /// </summary>
        /// <returns>The instance restriction attribute of the instance</returns>
        public int getInstanceRestriction()
        {
            return instanceRestriction;
        }

        /// <summary>
        /// Method that returns the outgoing message exchange attribute of the instance
        /// </summary>
        /// <returns>The outgoing message exchange attribute of the instance</returns>
        public IMessageExchange getOutgoingMessageExchange()
        {
            return outgoingMessageExchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpIncomingMessageExchange"></param>
        public void setTmpIncomingMessageExchange(string tmpIncomingMessageExchange)
        {
            this.tmpIncomingMessageExchange = tmpIncomingMessageExchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpIncomingMessageExchange()
        {
            return tmpIncomingMessageExchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpInstanceRestriction"></param>
        public void setTmpInstanceRestriction(string tmpInstanceRestriction)
        {
            this.tmpInstanceRestriction = tmpInstanceRestriction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpInstanceRestriction()
        {
            return tmpInstanceRestriction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpOutgoingMessageExchange"></param>
        public void setTmpOutgoingMessageExchange(string tmpOutgoingMessageExchange)
        {
            this.tmpOutgoingMessageExchange = tmpOutgoingMessageExchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpOutgoingMessageExchange()
        {
            return tmpOutgoingMessageExchange;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the subject class
        /// </summary>
        /// <returns>A new empty instance of the subject class</returns>
        new public Subject factoryMethod()
        {
            Subject subject = new Subject();

            return subject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            foreach (string s in attributeType)
            {

                if (s.ToLower().Contains("hasIncomingMessageExchange"))
                {
                    tmpIncomingMessageExchange = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasMaximumSubjectInstanceRestriction"))
                {
                    tmpInstanceRestriction = attribute[counter];
                    tmpInstanceRestriction = tmpInstanceRestriction.Split('^')[0];
                    //Console.WriteLine(getModelComponentID());
                    //Console.WriteLine(tmpInstanceRestriction);
                    instanceRestriction = Int32.Parse(tmpInstanceRestriction);
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasOutgoingMessageExchange"))
                {
                    tmpOutgoingMessageExchange = attribute[counter];
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
                    if (new MessageExchange().GetType().IsInstanceOfType(allElements[s]))
                    {
                        if (getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID()) >= 0)
                        {
                            if (getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID())].Contains("Incoming"))
                            {
                                this.incomingMessageExchange = (MessageExchange)allElements[s];
                                int place = getAdditionalAttribute().IndexOf(s);
                                if (place >= 0)
                                {
                                    getAdditionalAttributeType().RemoveAt(place);
                                    getAdditionalAttribute().Remove(s);
                                }
                            }
                            else
                            {
                                this.outgoingMessageExchange = (MessageExchange)allElements[s];
                                int place = getAdditionalAttribute().IndexOf(s);
                                if (place >= 0)
                                {
                                    getAdditionalAttributeType().RemoveAt(place);
                                    getAdditionalAttribute().Remove(s);
                                }
                            }
                        }
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
                if (incomingMessageExchange != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasIncomingMessageExchange" + " rdf:resource=\"" + incomingMessageExchange.getModelComponentID() + "\" ></standard-pass-ont:hasIncomingMessageExchange>");
                }

                if (outgoingMessageExchange != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasOutgoingMessageExchange" + " rdf:resource=\"" + outgoingMessageExchange.getModelComponentID() + "\" ></standard-pass-ont:hasOutgoingMessageExchange>");
                }

                if (instanceRestriction > 0)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMaximumSubjectInstanceRestriction rdf:datatype=\"http://www.w3.org/2001/XMLSchema#positiveInteger\" >" + instanceRestriction + "</standard-pass-ont:hasMaximumSubjectInstanceRestriction>");
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