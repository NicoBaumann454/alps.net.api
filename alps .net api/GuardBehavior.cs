using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an GuardBehavior
    /// </summary>

    public class GuardBehavior : SubjectBehavior, IGuardBehavior
    {
        private ISubjectBehavior subjectBehavior;
        private IState state;
        private string tmpSubjectBehavior;
        private string tmpState;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "GuardBehavior";

        /// <summary>
        /// Constructor that creates a new empty instance of the guard behavior class
        /// </summary>
        public GuardBehavior()
        {
            setModelComponentID("GuardBehavior");
            setComment("The standart Element for GuardBehavior");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the guard behavior class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="behaviorDescriptionComponent"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfBehavior"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="state"></param>
        public GuardBehavior(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, BehaviorDescriptionComponent behaviorDescriptionComponent, State endState, InitialStateOfBehavior initialStateOfBehavior, int priorityNumber, SubjectBehavior subjectBehavior, State state)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsBehaviorDescribingComponent(behaviorDescriptionComponent);
            setEndState(endState);
            setInitialState(initialStateOfBehavior);
            setPriorityNumber(priorityNumber);
            setGuardsBehavior(subjectBehavior);
            setGuardsState(state);

        }

        /// <summary>
        /// Method that sets the subject behavior attribute of the instance
        /// </summary>
        /// <param name="subjectBehavior"></param>
        public void setGuardsBehavior(ISubjectBehavior subjectBehavior)
        {
            this.subjectBehavior = subjectBehavior;
        }

        /// <summary>
        /// Method that sets the guard state attribute of the instance
        /// </summary>
        /// <param name="state"></param>
        public void setGuardsState(IState state)
        {
            this.state = state;
        }

        /// <summary>
        /// Method that returns the subject behavior attribute of the instance
        /// </summary>
        /// <returns>The subject behavior attribute of the instance</returns>
        public ISubjectBehavior getGuardsBehavior()
        {
            return subjectBehavior;
        }

        /// <summary>
        /// Method that returns the guard state attribute of the instance
        /// </summary>
        /// <returns>The guard state attribute of the instance</returns>
        public IState getGuardsState()
        {
            return state;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSubjectBehavior()
        {
            return tmpSubjectBehavior;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpState()
        {
            return tmpState;
        }

        /// <summary>
        /// Factory Method that creates and returns a new empty instance of the guard behavior class
        /// </summary>
        /// <returns>A new empty instance of the guard behavior class</returns>
        new public GuardBehavior factoryMethod()
        {
            GuardBehavior guardBehavior = new GuardBehavior();

            return guardBehavior;
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
                    if (new SubjectBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.subjectBehavior = (SubjectBehavior)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new State().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.state = (State)allElements[s];
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

            if (subjectBehavior != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:belongsToSubjectBahvior");
                objec = g.CreateUriNode("standard-pass-ont:" + subjectBehavior.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (state != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:guardsState");
                objec = g.CreateUriNode("standard-pass-ont:" + state.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);

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
                if (subjectBehavior != null)
                {
                    sw.WriteLine("      <standard-pass-ont:guardsBehavior" + " rdf:resource=\"" + subjectBehavior.getModelComponentID() + "\" ></standard-pass-ont:guardsBehavior>");
                }

                if (state != null)
                {
                    sw.WriteLine("      <standard-pass-ont:guardsState" + " rdf:resource=\"" + state.getModelComponentID() + "\" ></standard-pass-ont:guardsState>");
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