using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an message exchange list
    /// </summary>

    public class MessageExchangeList : InteractionDescriptionComponent, IMessageExchangeList
    {
        private Dictionary<string, IMessageExchange> messageExchange = new Dictionary<string, IMessageExchange>();
        private string tmpMessageExchange;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public string className = "MessageExchangeList";

        /// <summary>
        /// Constructor that creates a new empty instance of the message exchange list class
        /// </summary>
        public MessageExchangeList()
        {
            setModelComponentID("MessageExchangeList");
            setComment("The standart Element for MessageExchangeList");
        }
        /// <summary>
        /// Constructor that creates a new fully specified instance of the message exchange list class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="messageExchange"></param>
        public MessageExchangeList(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange messageExchange)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsMessageExchange(messageExchange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="messageExchanges"></param>
        /// <param name="additionalAttribute"></param>
        public MessageExchangeList(string label, string comment = "", Dictionary<string, IMessageExchange> messageExchanges = null, List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            if (messageExchanges != null)
            {
                this.messageExchange = messageExchanges;
            }

        }

        /// <summary>
        /// Method that sets the message exchange attribute of the class
        /// </summary>
        /// <param name="messageExchange"></param>
        public void setContainsMessageExchange(IMessageExchange messageExchange)
        {
            this.messageExchange.Add(messageExchange.getModelComponentID(), messageExchange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageExchanges"></param>
        public void setContainsMessageExchange(Dictionary<string, IMessageExchange> messageExchanges)
        {
            this.messageExchange = messageExchanges;
        }

        /// <summary>
        /// Method that returns the message exchange attribute of the class
        /// </summary>
        /// <returns>The message exchange attribute of the class</returns>
        public Dictionary<string, IMessageExchange> getMessageExchange()
        {
            return messageExchange;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpMessageExchange()
        {
            return tmpMessageExchange;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the message exchange list class
        /// </summary>
        /// <returns>A new empty instance of the message exchange list class</returns>
        new public MessageExchangeList factoryMethod()
        {
            MessageExchangeList messageExchangeList = new MessageExchangeList();

            return messageExchangeList;
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

                if (s.Contains("contains"))
                {
                    tmpMessageExchange = attribute[counter];
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
        ///Das ganze bricht hier, warum das ? 
        public override void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp)
        {
            base.completeObject(ref allElements, ref tmp);

            foreach (string s in tmp)
            {

                if (allElements.ContainsKey(s))
                {
                    if (new MessageExchange().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.messageExchange.Add(allElements[s].getModelComponentID(), (MessageExchange)allElements[s]);
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

            foreach (KeyValuePair<string, IMessageExchange> s in messageExchange)
            {
                if (s.Value != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasIncomingTransition");
                    objec = g.CreateUriNode("standard-pass-ont:" + s.Value.getModelComponentID());

                    test = new Triple(subject, predicate, objec);
                    g.Assert(test);

                    //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
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
                foreach (KeyValuePair<string, IMessageExchange> s in messageExchange)
                {
                    if (s.Value != null)
                    {
                        sw.WriteLine("      <standard-pass-ont:contains" + " rdf:resource=\"" + s.Value.getModelComponentID() + "\" ></standard-pass-ont:contains>");
                    }
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