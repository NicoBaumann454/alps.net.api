using System;
using System.Collections.Generic;
using VDS.RDF;

namespace alps.net_api
{
    class BaseLayer : ModelLayer, IBaseLayer
    {
        private List<ISubjectBaseBehavior> aLPSModelElements = new List<ISubjectBaseBehavior>();

        public BaseLayer()
        {
            setModelComponentID("BaseLayer");
            setComment("The standart Element for BaseLayer");
        }

        public void setALPSModelElements(SubjectBaseBehavior aLPSModelElement)
        {
            this.aLPSModelElements.Add(aLPSModelElement);
        }

        public List<ISubjectBaseBehavior> getALPSModelElements()
        {
            return this.aLPSModelElements;
        }

        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

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
                    if (new SubjectBaseBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.aLPSModelElements.Add((SubjectBaseBehavior)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
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

            foreach (ISubjectBaseBehavior s in aLPSModelElements)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:belongsToAction");
                objec = g.CreateUriNode("standard-pass-ont:" + s.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

            }
        }
    }
}
