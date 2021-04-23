using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an EndState
    /// </summary>

    public class EndState : State, IEndState
    {
        private IAction belongsToAction;
        private string tmpBelongsToAction;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "EndState";

        /// <summary>
        /// Constructor that creates a new empty instance of the end state class
        /// </summary>
        public EndState()
        {
            setModelComponentID("EndState");
            setComment("The standart Element for EndState");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the end state class
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
        /// <param name="belongsToaction"></param>
        public EndState(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, Action belongsToaction)
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
            setBelongsToAction(belongsToaction);

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
        /// <param name="additionalAttribute"></param>
        public EndState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, List<string> additionalAttribute = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute)
        {

        }

        /// <summary>
        /// Method that sets the action attribute
        /// </summary>
        /// <param name="action"></param>
        public void setBelongsToAction(IAction action)
        {
            this.belongsToAction = action;
        }

        /// <summary>
        /// Method that returns the action attribute
        /// </summary>
        /// <returns>The action attribute</returns>
        public IAction getBelongsToAction()
        {
            return belongsToAction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpBelongsToAction()
        {
            return tmpBelongsToAction;
        }

        /// <summary>
        /// Factory method that creates and returns a new instance of the end state class
        /// </summary>
        /// <returns>A new instance of the end state class</returns>
        new public EndState factoryMethod()
        {
            EndState endState = new EndState();

            return endState;
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
                //Nachsehen ob der String so stimmt, wenn ja kann es so bleiben, sonst hasBelongsToAction
                if (s.Contains("belongsTo"))
                {
                    tmpBelongsToAction = attribute[counter];
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
                    if (new Action().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.belongsToAction = (Action)allElements[s];
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

            if (belongsToAction != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:belongsToAction");
                objec = g.CreateUriNode("standard-pass-ont:" + belongsToAction.getModelComponentID());

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
                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
