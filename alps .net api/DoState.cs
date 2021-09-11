using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a DoState
    /// </summary>

    public class DoState : StandartPASSState, IDoState
    {
        private IDataMappingIncomingToLocal dataMappingIncomingToLocal;
        private IDataMappingLocalToOutgoing dataMappingLocalToOutgoing;
        private IDoFunction doFunction;
        private string tmpDataMappingIncomingToLocal;
        private string tmpDataMappingLocalToOutgoing;
        private string tmpDoFunction;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "DoState";

        /// <summary>
        /// Constructor that creates a new empty instance of the do state class
        /// </summary>
        public DoState()
        {
            setModelComponentID("DoState");
            setComment("The standart Element for DoState");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the do state class
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
        /// <param name="dataMappingIncomingToLocal"></param>
        /// <param name="dataMappingLocalToOutgoing"></param>
        /// <param name="doFunction"></param>
        public DoState(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, DataMappingIncomingToLocal dataMappingIncomingToLocal, DataMappingLocalToOutgoing dataMappingLocalToOutgoing, FunctionSpecification doFunction)
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
            setDataMappingFunctionIncomingToLocal(dataMappingIncomingToLocal);
            setDataMappingFunctionLocalToOutgoing(dataMappingLocalToOutgoing);
            setFunctionSpecification(doFunction);
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
        /// <param name="dataMappingIncomingToLocal"></param>
        /// <param name="dataMappingLocalToOutgoing"></param>
        /// <param name="doFunction"></param>
        public DoState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IDataMappingIncomingToLocal dataMappingIncomingToLocal = null, IDataMappingLocalToOutgoing dataMappingLocalToOutgoing = null, IDoFunction doFunction = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition)
        {
            if (dataMappingIncomingToLocal != null)
            {
                setDataMappingFunctionIncomingToLocal(dataMappingIncomingToLocal);
            }

            if (dataMappingLocalToOutgoing != null)
            {
                setDataMappingFunctionLocalToOutgoing(dataMappingLocalToOutgoing);
            }

            if (functionSpecification != null)
            {
                setFunctionSpecification(functionSpecification);
            }
        }

        /// <summary>
        /// Method that sets the data mapping incoming to local attribute
        /// </summary>
        /// <param name="dataMappingIncomingToLocal"></param>
        public void setDataMappingFunctionIncomingToLocal(IDataMappingIncomingToLocal dataMappingIncomingToLocal)
        {
            this.dataMappingIncomingToLocal = dataMappingIncomingToLocal;
        }

        /// <summary>
        /// Method that sets the data mapping local to outgoing attribute
        /// </summary>
        /// <param name="dataMappingLocalToOutgoing"></param>
        public void setDataMappingFunctionLocalToOutgoing(IDataMappingLocalToOutgoing dataMappingLocalToOutgoing)
        {
            this.dataMappingLocalToOutgoing = dataMappingLocalToOutgoing;
        }

        /// <summary>
        /// Method that sets the do function attribute
        /// </summary>
        /// <param name="doFunction"></param>
        public void setFunctionSpecification(IDoFunction doFunction)
        {
            this.doFunction = doFunction;
        }

        /// <summary>
        /// Method that returns the data mapping incoming to local attribute
        /// </summary>
        /// <returns>The data mapping incoming to local attribute</returns>
        public IDataMappingIncomingToLocal getDataMappingIncomingToLocal()
        {
            return dataMappingIncomingToLocal;
        }

        /// <summary>
        /// Method that returns the data mapping local to outgoing attribute
        /// </summary>
        /// <returns>The data mapping local to outgoing attribute</returns>
        public IDataMappingLocalToOutgoing getDataMappingLocalToOutgoing()
        {
            return dataMappingLocalToOutgoing;
        }

        /// <summary>
        /// Method that returns the do function attribute
        /// </summary>
        /// <returns>The do function attribute</returns>
        public IDoFunction getDoFunction()
        {
            return doFunction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpDataMappingIncomingToLocal()
        {
            return tmpDataMappingIncomingToLocal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpDataMappingLocalToOutgoing()
        {
            return tmpDataMappingLocalToOutgoing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpDoFunction()
        {
            return tmpDoFunction;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the do state class
        /// </summary>
        /// <returns>A new empty instance of the do state class</returns>
        new public DoState factoryMethod()
        {
            DoState doState = new DoState();

            return doState;
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

                if (s.Contains("hasDataMappingIncomingToLocal"))
                {
                    tmpDataMappingIncomingToLocal = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasDataMappingLocalToOutgoing"))
                {
                    tmpDataMappingLocalToOutgoing = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasInputPoolConstraint"))
                {
                    tmpDoFunction = attribute[counter];
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
                    if (new DataMappingIncomingToLocal().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.dataMappingIncomingToLocal = (DataMappingIncomingToLocal)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new DataMappingLocalToOutgoing().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.dataMappingLocalToOutgoing = (DataMappingLocalToOutgoing)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new DoFunction().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.doFunction = (DoFunction)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Method that exports a do state object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (dataMappingIncomingToLocal != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasDataMappingFunction" + " rdf:resource=\"" + dataMappingIncomingToLocal.getModelComponentID() + "\" ></standard-pass-ont:hasDataMappingFunction>");
                }

                if (dataMappingLocalToOutgoing != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasDataMappingFunction" + " rdf:resource=\"" + dataMappingLocalToOutgoing.getModelComponentID() + "\" ></standard-pass-ont:hasDataMappingFunction>");
                }

                if (doFunction != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasFunctionSpecification" + " rdf:resource=\"" + doFunction.getModelComponentID() + "\" ></standard-pass-ont:hasFunctionSpecification>");
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
