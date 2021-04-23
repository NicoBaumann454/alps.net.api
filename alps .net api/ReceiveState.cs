using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a receive state
    /// </summary>
    public class ReceiveState : StandartPASSState, IReceiveState
    {
        private IReceiveFunction receiveFunction;
        private string tmpReceiveFunction;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "ReceiveState";

        /// <summary>
        /// Constructor that creates a new empty instance of the receive state class
        /// </summary>
        public ReceiveState()
        {
            setModelComponentID("ReceiveState");
            setComment("The standart Element for ReceiveState");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the receive state class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="action"></param>
        /// <param name="receiveFunction"></param>
        public ReceiveState(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, ReceiveFunction receiveFunction)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setIncomingTransition(incomingTransition);
            setOutgoingTransition(outgoingTransition);
            setFunctionSpecification(functionSpecification);
            setGuardBehavior(guardBehavior);
            setAction(action);
            setFunctionSpecification(receiveFunction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="receiveFunction"></param>
        public ReceiveState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IReceiveFunction receiveFunction = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition)
        {
            if (receiveFunction != null)
            {
                this.receiveFunction = receiveFunction;
            }
        }

        /// <summary>
        /// Method that sets the receive function attribute of the instance
        /// </summary>
        /// <param name="receiveFunction"></param>
        public void setFunctionSpecification(IReceiveFunction receiveFunction)
        {
            this.receiveFunction = receiveFunction;
        }

        /// <summary>
        /// Method that returns the receive function attribute of the instance
        /// </summary>
        /// <returns>The receive function attribute of the instance</returns>
        public IReceiveFunction getReceiveFunctionSpecification()
        {
            return receiveFunction;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the receive state class
        /// </summary>
        /// <returns>A new empty instance of the receive state class</returns>
        new public ReceiveState factoryMethod()
        {
            ReceiveState receiveState = new ReceiveState();

            return receiveState;
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

                if (s.Contains("hasReceiveFunction"))
                {
                    tmpReceiveFunction = attribute[counter];
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
                    if (new ReceiveFunction().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.receiveFunction = (ReceiveFunction)allElements[s];
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

            if (receiveFunction != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasReceiveFunction");
                objec = g.CreateUriNode("standard-pass-ont:" + receiveFunction.getModelComponentID());

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
                if (receiveFunction != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasFunctionSpecification" + " rdf:resource=\"" + receiveFunction.getModelComponentID() + "\" ></standard-pass-ont:hasFunctionSpecification>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void showAllAttributes()
        {
            foreach (string s in getModelComponentLabel())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(getModelComponentID());
            Console.WriteLine(tmpReceiveFunction);
            Console.WriteLine(getComment());
            Console.WriteLine(getFunctionSpecification());
            Console.WriteLine(getGuardBehavior());
            Console.WriteLine(getIncomingTransition());
            Console.WriteLine(getOutgoingTransition());
            Console.WriteLine(getSubjectBehavior());
            Console.WriteLine(getAction());
            Console.WriteLine("Done");
            Console.WriteLine();




            //foreach (string s in getAdditionalAttribute())
            //{
            //    Console.WriteLine(s);
            //}
        }
    }
}