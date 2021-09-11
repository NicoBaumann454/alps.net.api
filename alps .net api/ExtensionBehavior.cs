using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    class ExtensionBehavior : ALPSModelElement, IExtensionBehavior
    {
        private List<IBehaviorDescriptionComponent> behaviorDescriptionComponent = new List<IBehaviorDescriptionComponent>();
        private IState endState;
        private IInitialStateOfBehavior initialStateOfBehavior;
        private int priorityNumber;
        private string tmpBehaviorDescriptionComponent;
        private string tmpEndState;
        private string tmpInitialStateOfBehavior;
        private string tmpPriorityNumber;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "ExtensionBehavior";

        /// <summary>
        /// Constructor that creates a new empty instance of the extension behavior class
        /// </summary>
        public ExtensionBehavior()
        {
            setModelComponentID("ExtensionBehavior");
            setComment("The standart Element for ExtensionBehavior");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the extension behavior class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="behaviorDescriptionComponent"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfBehavior"></param>
        /// <param name="priorityNumber"></param>
        public ExtensionBehavior(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, BehaviorDescriptionComponent behaviorDescriptionComponent, State endState, InitialStateOfBehavior initialStateOfBehavior, int priorityNumber)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsBehaviorDescribingComponent(behaviorDescriptionComponent);
            setEndState(endState);
            setInitialState(initialStateOfBehavior);
            setPriorityNumber(priorityNumber);

        }

        /// <summary>
        /// Method that sets the behavior description component attribute of the instance
        /// </summary>
        /// <param name="behaviorDescriptionComponent"></param>
        public void setContainsBehaviorDescribingComponent(IBehaviorDescriptionComponent behaviorDescriptionComponent)
        {
            this.behaviorDescriptionComponent.Add(behaviorDescriptionComponent);
        }

        /// <summary>
        /// Method that sets the end state attribute of the instance
        /// </summary>
        /// <param name="endState"></param>
        public void setEndState(IState endState)
        {
            this.endState = endState;
        }

        /// <summary>
        /// Method that sets the initial state of behaviors attribute of the instance
        /// </summary>
        /// <param name="initialStateOfBehavior"></param>
        public void setInitialState(IInitialStateOfBehavior initialStateOfBehavior)
        {
            this.initialStateOfBehavior = initialStateOfBehavior;
        }

        /// <summary>
        /// Method that sets the priotity number attribute of the instance
        /// </summary>
        /// <param name="nonNegativNumber"></param>
        public void setPriorityNumber(int nonNegativNumber)
        {
            this.priorityNumber = nonNegativNumber;
        }

        /// <summary>
        /// Method that returns the behavior description component attribute of the instance
        /// </summary>
        /// <returns>The behavior description component attribute of the instance</returns>
        public List<IBehaviorDescriptionComponent> getBehaviorDescriptionComponent()
        {
            return behaviorDescriptionComponent;
        }

        /// <summary>
        /// Method that returns the end state attribute of the instance
        /// </summary>
        /// <returns>The end state attribute of the instance</returns>
        public IState getEndState()
        {
            return endState;
        }

        /// <summary>
        /// Method that returns the initial state of behaviors attribute of the instance
        /// </summary>
        /// <returns>The initial state of behaviors attribute of the instance</returns>
        public IInitialStateOfBehavior getInitialStateOfBehavior()
        {
            return initialStateOfBehavior;
        }

        /// <summary>
        /// Method that returns the priotity number attribute of the instance
        /// </summary>
        /// <returns>The priotity number attribute of the instance</returns>
        public int getPriorityNumber()
        {
            return priorityNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpBehaviorDescriptionComponent()
        {
            return tmpBehaviorDescriptionComponent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpEndState()
        {
            return tmpEndState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpInitialStateOfBehavior()
        {
            return tmpInitialStateOfBehavior;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpPriorityNumber()
        {
            return tmpPriorityNumber;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the subject behavior class
        /// </summary>
        /// <returns>A new empty instance of the subject behavior class</returns>
        new public ExtensionBehavior factoryMethod()
        {
            ExtensionBehavior subjectBehavior = new ExtensionBehavior();

            return subjectBehavior;
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
                if (s.ToLower().Contains("hasBehaviorDescriptionComponent"))
                {
                    tmpBehaviorDescriptionComponent = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasEndState"))
                {
                    tmpEndState = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasInitialStateOfBehavior"))
                {
                    tmpInitialStateOfBehavior = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasPriorityNumber"))
                {
                    //Hier muss ich noch herausfinden wie ich aus dem String den int mache, das sollte an sich gehen, sonst wird aus dem int ein String gemacht 
                    //(verschiebt aber nur das Problem von jetzt zu später)

                    //priorityNumber = attribute[counter];
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
                    if (new BehaviorDescriptionComponent().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.behaviorDescriptionComponent.Add((BehaviorDescriptionComponent)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new EndState().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.endState = (EndState)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new InitialStateOfBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.initialStateOfBehavior = (InitialStateOfBehavior)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
            }
        }

        
        /// <summary>
        /// Method that exports a extension behavior object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (endState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasEndState" + " rdf:resource=\"" + endState.getModelComponentID() + "\" ></standard-pass-ont:hasEndState>");
                }

                if (initialStateOfBehavior != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasInitialStateOfBehavior" + " rdf:resource=\"" + initialStateOfBehavior.getModelComponentID() + "\" ></standard-pass-ont:hasInitialStateOfBehavior>");
                }

                foreach (IBehaviorDescriptionComponent s in behaviorDescriptionComponent)
                {
                    if (behaviorDescriptionComponent != null)
                    {
                        sw.WriteLine("      <standard-pass-ont:contains" + " rdf:resource=\"" + s.getModelComponentID() + "\" ></standard-pass-ont:contains>");
                    }
                }

                if (priorityNumber != null)
                {
                    //sw.WriteLine("      <standard-pass-ont:hasIncomingTransition" + " rdf:resource=\"" + incomingTransition.getModelComponentID() + "\" ></standard-pass-ont:hasIncomingTransition>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&abstract-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
