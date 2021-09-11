using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VDS.RDF;
using VDS.RDF.Parsing;
using System.Windows;


namespace alps.net_api
{
    /// <summary>
    /// The main Class of the alps_.net_api. It is the controll class that imports and exports all the given Data. 
    /// If any model data is imported, this class returns a class which contains the given information in form of 
    /// objects. 
    /// If models should be exported, the parser creates a new empty file with the given filename and creates an 
    /// owl file at the same place where the imported data comes from.
    /// </summary>
    public class OwlGraph
    {
        private int numberOfFiles = 0;
        private string filePath;

        /// <summary>
        /// List of the graphs containing the Information required for the OwlGraph class
        /// </summary>
        public List<Graph> files = new List<Graph>();

        private List<string> ID = new List<string>();
        private List<string> URI = new List<string>();
        private List<Triple> topLayer = new List<Triple>();
        private List<Triple> namedIndiviuals = new List<Triple>();
        private List<Triple> namedIndiviualsType = new List<Triple>();
        private Graph standartPass;
        private Graph abstractPass;
        private Graph newGraph;
        private TreeNode treeRootNode;
        private TreeNode tmpTreeRootNode;
        private Tree fullGraph;
        private ArrayList standartPassObjects = new ArrayList();

        private Dictionary<String, PASSProcessModelElement> elements = new Dictionary<string, PASSProcessModelElement>();
        private Dictionary<string, string> namedIndividuals = new Dictionary<string, string>();
        private List<PassProcessModel> passProcessModells = new List<PassProcessModel>();

        Tree fullTree = new Tree();

        /// <summary>
        /// Creates an empty Instance of the OwlGraph Class
        /// </summary>
        public OwlGraph()
        {
            string path = Directory.GetCurrentDirectory();

            if (File.Exists(path + "\\logs\\" + "logfile.txt"))
            {
                File.Delete(path + "\\logs\\" + "logfile.txt");
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.WriteTo.Console()
                .WriteTo.File("logs\\logfile.txt")
                .CreateLogger();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="standartPass"></param>
        //Schreibender Zugriff wird eventl noch eingeschraenkt oder ganz entfernt
        public void setStandartPass(Graph standartPass)
        {
            this.standartPass = standartPass;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Graph getStandartPass()
        {
            return standartPass;
        }

        /// <summary>
        /// Method that sets the abstract pass ont graph
        /// </summary>
        /// <param name="abstractPass"></param>
        //Schreibender Zugriff wird eventl noch eingeschraenkt oder ganz entfernt
        public void setAbstractPass(Graph abstractPass)
        {
            this.abstractPass = abstractPass;
        }

        /// <summary>
        /// Method that returns the abstract pass on graph
        /// </summary>
        /// <returns></returns>
        public Graph getAbstractPass()
        {
            return abstractPass;
        }

        /// <summary>
        /// Method that returns the read graphs
        /// </summary>
        /// <returns>A List of Graphes</returns>

        public List<Graph> getFiles()
        {
            return files;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Triple> getTopLayer()
        {
            return topLayer;
        }

        /// <summary>
        /// Loads in all the required Files and creates the inheritans Graph within the Programm (the creation of the tree can be turned of with
        /// the "boolTree" parameter)
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="boolTree"></param>
        /// <returns>A boolean that shows if the creation of the Trees worked</returns>
        public List<PassProcessModel> load(List<string> filepath, bool boolTree = true)
        {

            Console.WriteLine("Progress: ");
            Console.WriteLine("[                              ]");

            bool readingSuccesful = false;
            foreach (string i in filepath)
            {
                try
                {
                    newGraph = new Graph();
                    if ((i.ToLower().Contains("standard") && i.ToLower().Contains("pass")) || (i.ToLower().Contains("abstract") && i.ToLower().Contains("pass")))
                    {
                        this.ID.Add("standardPass");
                    }
                    else
                    {
                        this.ID.Add(i);
                    }
                    this.filePath = i;
                    FileLoader.Load(newGraph, filePath);
                    files.Add(newGraph);
                    numberOfFiles++;
                    readingSuccesful = true;
                    Log.Information("Done reading the new File: " + i);
                    readingSuccesful = true;
                }
                catch (RdfParseException parseException)
                {
                    Log.Error("Parser Error when reading the new File " + parseException);
                }
            }

            Console.WriteLine("[##                            ]");

            if (boolTree)
            {
                readingSuccesful = creatingTree();
                createTree();

                //Here the two sepreate trees will be connected
                foreach (TreeNode t in treeRootNode.getChildNodes())
                {
                    fullGraph.getRootTreeNode().addChild(t);
                    t.setParentNode(fullGraph.getRootTreeNode());

                }
            }

            Console.WriteLine("[#################             ]");

            createAllElements();

            Console.WriteLine("[##############################]");
            Console.WriteLine("Finished loading the new in memory models");

            return passProcessModells;
        }

        /// <summary>
        ///  This Method finds all the Subclasses in the given OWL Ontologies
        ///  It takes the URI String of the Super Class and returns all the Sub Classes as a Tree Node List
        /// </summary>
        /// <returns> A Tree Node List of all the Sub Classes</returns>
        public List<TreeNode> findAllSubclasses(string className, TreeNode fatherNode, Graph graph)
        {
            List<Triple> subClasses = new List<Triple>();
            List<TreeNode> treeNodes = new List<TreeNode>();

            if (graph == null)
            {
                Log.Error("No such file found");
                return treeNodes;
            }
            else
            {
                INode superClass = graph.GetUriNode(new Uri(className));
                INode subClassOf = graph.CreateUriNode(new Uri(NamespaceMapper.RDFS + "subClassOf"));
                int counter = 0;

                foreach (Triple t in graph.GetTriplesWithPredicateObject(subClassOf, superClass))
                {
                    subClasses.Add(t);
                    counter++;
                }

                foreach (Triple t in subClasses)
                {
                    treeNodes.Add(fatherNode.factoryMethod(t.Subject.ToString()));
                }

                foreach (TreeNode i in treeNodes)
                {
                    if (!fullTree.containsTreeNode(i.getContent()))
                    {
                        fatherNode.addChild(i);
                    }

                    findAllSubclasses(i.getContent(), i, graph);
                }

            }

            return treeNodes;
        }

        /// <summary>
        /// Method that tests if a given subject has Parents and returns a boolean 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="graph"></param>
        /// <returns>A boolean that shows if a Subject has a Parent</returns>
        public bool hasParentNode(string className, Graph graph)
        {
            List<Triple> parentClasses = new List<Triple>();
            bool hasParent = false;
            int counter = 0;

            if (graph == null)
            {
                Log.Error("No such file found");
                return false;
            }
            else
            {
                try
                {
                    INode superClass = graph.GetUriNode(new Uri(className));
                    INode subClassOf = graph.CreateUriNode(new Uri(NamespaceMapper.RDFS + "subClassOf"));

                    foreach (Triple t in graph.GetTriplesWithSubjectPredicate(superClass, subClassOf))
                    {
                        parentClasses.Add(t);
                        counter++;
                    }
                }
                catch
                { }
            }

            if (counter > 0)
            {
                hasParent = true;
            }

            return hasParent;
        }

        /// <summary>
        /// This class creates the inheritans tree out of the given files
        /// </summary>
        public bool creatingTree()
        {
            bool result = false;
            bool hasParents = true;
            List<Triple> nodesWithoutParents = new List<Triple>();
            List<Tree> graphes = new List<Tree>();
            int count = 0;

            Console.WriteLine("[####                          ]");

            foreach (Graph g in files)
            {
                nodesWithoutParents = new List<Triple>();
                fullTree = new Tree();

                foreach (Triple t in g.Triples)
                {
                    hasParents = true;
                    hasParents = hasParentNode(t.Subject.ToString(), g);


                    if (hasParents == false && !t.Subject.ToString().Contains("auto") && t.Object.ToString().ToLower().Contains("#class"))
                    {
                        nodesWithoutParents.Add(t);
                    }
                }

                TreeNode firstNode = new TreeNode("http://www.w3.org/2002/07/owl#Thing");
                fullTree.setRootTreeNode(firstNode);
                TreeNode auxNode = new TreeNode();

                foreach (Triple t in nodesWithoutParents)
                {
                    TreeNode nextNode = firstNode.factoryMethod(t.Subject.ToString());
                    nextNode.setParentNode(firstNode);
                    firstNode.addChild(nextNode);
                    findAllSubclasses(nextNode.getContent(), nextNode, g);
                }

                graphes.Add(fullTree);
                count++;
            }

            Console.WriteLine("[########                      ]");

            if (count == files.Capacity)
            {
                result = true;
            }

            tmpTreeRootNode = new TreeNode("http://www.w3.org/2002/07/owl#Thing");

            foreach (Tree t in graphes)
            {
                foreach (TreeNode n in t.getRootTreeNode().getChildNodes())
                {
                    n.setParentNode(tmpTreeRootNode);
                    tmpTreeRootNode.addChild(n);
                }

            }

            Console.WriteLine("[#############                 ]");

            fullGraph = new Tree();
            fullGraph.setRootTreeNode(tmpTreeRootNode);


            Log.Information("Finished creating the inheritans tree");

            return result;
        }

        /// <summary>
        /// Finds and creates all the named individuals in the given files and creates a new list with all the individuals
        /// </summary>
        private void createAllElements()
        {
            IEnumerable<Triple> tmp = null;
            int j = 0;

            foreach (Graph i in files)
            {
                foreach (Triple t in i.Triples)
                {

                    if (!(ID[j].Contains("standardPass")))
                    {
                        if (t.Object.ToString().Contains("NamedIndividual") && t.Subject.ToString().Contains("#"))
                        {
                            this.namedIndiviuals.Add(t);
                        }
                    }
                }
                j++;
            }

            foreach (Triple t in this.namedIndiviuals)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    if (files[i].Triples.WithSubject(t.Subject).Any())
                    {
                        tmp = files[i].Triples.WithSubject(t.Subject);
                    }

                }

                foreach (Triple l in tmp)
                {
                    if (l.Subject.ToString().Equals(l.Subject.ToString()) && l.Predicate.ToString().Contains("type") && !l.Object.ToString().Contains("NamedIndividual"))
                    {
                        this.namedIndiviualsType.Add(l);
                        if (!namedIndividuals.ContainsKey(t.Subject.ToString()))
                        {
                            this.namedIndividuals.Add(l.Subject.ToString(), l.Object.ToString());
                        }
                    }
                }
            }

            Console.WriteLine("[#####################         ]");

            createInstances();
        }

        /// <summary>
        /// Method that creates the empty Instances of the Objects which later get completed by the completetObjects() Methode
        /// </summary>
        /// <returns></returns>
        private List<PassProcessModel> createInstances()
        {
            Layer layer = new Layer();
            List<string> attribute = new List<string>();
            List<string> attributeType = new List<string>();
            int counter = 0;
            int count = 0;
            int tmp = 0;
            List<string> namedModels = new List<string>();

            PassProcessModel passProcessModell = new PassProcessModel();

            foreach (KeyValuePair<string, string> i in namedIndividuals)
            {
                string name = namedIndividuals[i.Key];
                string[] splittedURI;
                splittedURI = name.Split('#');
                name = splittedURI[1];

                attribute.Clear();
                attributeType.Clear();

                switch (name)
                {

                    case "PASSProcessModel":

                        tmp++;
                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                }
                            }
                            count++;
                        }

                        passProcessModell.createInstance(attribute, attributeType);
                        name = passProcessModell.getModelComponentID();

                        namedModels.Add(i.Key);
                        splittedURI = name.Split('^');
                        name = splittedURI[0];

                        passProcessModells.Add(passProcessModell);
                        break;

                }
            }

            if (tmp == 0)
            {
                passProcessModell.setModelComponentID("defaultModelID");
                passProcessModells.Add(passProcessModell);
            }

            foreach (string s in namedModels)
            {
                namedIndividuals.Remove(s);
            }


            foreach (KeyValuePair<string, string> i in namedIndividuals)
            {
                string name = namedIndividuals[i.Key];

                string[] splittedURI;
                splittedURI = name.Split('#');
                name = splittedURI[1];

                attribute.Clear();
                attributeType.Clear();

                switch (name)
                {

                    case "FullySpecifiedSubject":

                        FullySpecifiedSubject fullySpecifiedSubject = new FullySpecifiedSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    fullySpecifiedSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());

                                }
                            }
                            count++;
                        }

                        fullySpecifiedSubject.createInstance(attribute, attributeType);
                        name = fullySpecifiedSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, fullySpecifiedSubject);

                        layer.Add(fullySpecifiedSubject.getModelComponentID(), fullySpecifiedSubject);
                        layer.Add(fullySpecifiedSubject.getModelComponentID(), (Subject)fullySpecifiedSubject);

                        break;


                    case "InterfaceSubject":

                        InterfaceSubject interfaceSubject = new InterfaceSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    interfaceSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        interfaceSubject.createInstance(attribute, attributeType);
                        name = interfaceSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, interfaceSubject);

                        layer.Add(interfaceSubject.getModelComponentID(), interfaceSubject);

                        break;

                    case "MultiSubject":

                        MultiSubject multiSubject = new MultiSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    multiSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        multiSubject.createInstance(attribute, attributeType);
                        name = multiSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, multiSubject); ;

                        layer.Add(multiSubject.getModelComponentID(), multiSubject);
                        layer.Add(multiSubject.getModelComponentID(), (Subject)multiSubject);

                        break;

                    case "DoState":

                        DoState doState = new DoState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    doState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        doState.createInstance(attribute, attributeType);
                        name = doState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, doState);

                        layer.Add(doState.getModelComponentID(), doState);

                        break;

                    case "SendState":

                        SendState sendState = new SendState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    sendState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        sendState.createInstance(attribute, attributeType);
                        name = sendState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, sendState);

                        layer.Add(sendState.getModelComponentID(), sendState);

                        break;

                    case "ReceiveState":

                        ReceiveState receiveState = new ReceiveState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    receiveState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        receiveState.createInstance(attribute, attributeType);
                        name = receiveState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, receiveState);

                        //receiveState.showAllAttributes();
                        layer.Add(receiveState.getModelComponentID(), receiveState);

                        break;

                    case "MessageExchangeList":

                        MessageExchangeList messageExchangeList = new MessageExchangeList();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    messageExchangeList.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        //Methode muss in der Klasse noch implementiert werden
                        messageExchangeList.createInstance(attribute, attributeType);
                        name = messageExchangeList.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, messageExchangeList);

                        layer.Add(messageExchangeList.getModelComponentID(), messageExchangeList);

                        break;

                    case "MessageExchange":

                        MessageExchange messageExchange = new MessageExchange();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    messageExchange.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        messageExchange.createInstance(attribute, attributeType);
                        name = messageExchange.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, messageExchange);

                        layer.Add(messageExchange.getModelComponentID(), messageExchange);

                        break;

                    case "PayloadDescription":

                        PayloadDescription payloadDescription = new PayloadDescription();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    payloadDescription.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        payloadDescription.createInstance(attribute, attributeType);
                        name = payloadDescription.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, payloadDescription);

                        layer.Add(payloadDescription.getModelComponentID(), payloadDescription);

                        break;

                    case "MessageSpecification":

                        MessageSpecification messageSpecification = new MessageSpecification();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    messageSpecification.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        messageSpecification.createInstance(attribute, attributeType);
                        name = messageSpecification.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, messageSpecification);

                        layer.Add(messageSpecification.getModelComponentID(), messageSpecification);

                        break;


                    case "SubjectBehavior":

                        SubjectBehavior subjectBehavior = new SubjectBehavior();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    subjectBehavior.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        subjectBehavior.createInstance(attribute, attributeType);

                        name = subjectBehavior.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, subjectBehavior);

                        layer.Add(subjectBehavior.getModelComponentID(), subjectBehavior);

                        break;


                    case "Action":

                        Action action = new Action();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    action.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        action.createInstance(attribute, attributeType);
                        name = action.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, action);

                        layer.Add(action.getModelComponentID(), action);

                        break;

                    case "EndState":

                        EndState endState = new EndState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    endState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        endState.createInstance(attribute, attributeType);
                        name = endState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, endState);

                        layer.Add(endState.getModelComponentID(), endState);

                        break;

                    case "SendTransition":

                        SendTransition sendTransition = new SendTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    sendTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        sendTransition.createInstance(attribute, attributeType);
                        name = sendTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, sendTransition);

                        layer.Add(sendTransition.getModelComponentID(), sendTransition);

                        break;

                    case "SendTransitionCondition":

                        SendTransitionCondition sendTransitionCondition = new SendTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    sendTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }
                        //Hier müssen die string abfragen nochmal überprüft werden
                        sendTransitionCondition.createInstance(attribute, attributeType);
                        name = sendTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, sendTransitionCondition);

                        layer.Add(sendTransitionCondition.getModelComponentID(), sendTransitionCondition);

                        break;

                    case "ReceiveTransition":

                        ReceiveTransition receiveTransition = new ReceiveTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    receiveTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }
                        receiveTransition.createInstance(attribute, attributeType);
                        name = receiveTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, receiveTransition);

                        layer.Add(receiveTransition.getModelComponentID(), receiveTransition);

                        break;

                    case "ReceiveTransitionCondition":

                        ReceiveTransitionCondition receiveTransitionCondition = new ReceiveTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    receiveTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        receiveTransitionCondition.createInstance(attribute, attributeType);
                        name = receiveTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, receiveTransitionCondition);

                        layer.Add(receiveTransitionCondition.getModelComponentID(), receiveTransitionCondition);

                        break;

                    case "DoTransition":

                        DoTransition doTransition = new DoTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    doTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }
                        doTransition.createInstance(attribute, attributeType);
                        name = doTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, doTransition);

                        layer.Add(doTransition.getModelComponentID(), doTransition);

                        break;

                    case "DoTransitionCondition":

                        DoTransitionCondition doTransitionCondition = new DoTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    doTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        doTransitionCondition.createInstance(attribute, attributeType);
                        name = doTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, doTransitionCondition);

                        layer.Add(doTransitionCondition.getModelComponentID(), doTransitionCondition);

                        break;

                    case "State":

                        State state = new State();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    state.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        state.createInstance(attribute, attributeType);
                        name = state.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, state);

                        layer.Add(state.getModelComponentID(), state);

                        break;

                    case "AbstractCommunicationChannel":

                        AbstractCommunicationChannel abstractCommunicationChannel = new AbstractCommunicationChannel();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractCommunicationChannel.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractCommunicationChannel.createInstance(attribute, attributeType);
                        name = abstractCommunicationChannel.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractCommunicationChannel);

                        break;

                    case "AbstractDoState":

                        AbstractDoState abstractDoState = new AbstractDoState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractDoState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractDoState.createInstance(attribute, attributeType);
                        name = abstractDoState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractDoState);

                        break;

                    case "AbstractLayer":

                        AbstractLayer abstractLayer = new AbstractLayer();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractLayer.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractLayer.createInstance(attribute, attributeType);
                        name = abstractLayer.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractLayer);

                        break;

                    case "AbstractMessageExchange":

                        AbstractMessageExchange abstractMessageExchange = new AbstractMessageExchange();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractMessageExchange.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractMessageExchange.createInstance(attribute, attributeType);
                        name = abstractMessageExchange.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractMessageExchange);

                        break;

                    case "AbstractMultiSubject":

                        AbstractMultiSubject abstractMultiSubject = new AbstractMultiSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractMultiSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractMultiSubject.createInstance(attribute, attributeType);
                        name = abstractMultiSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractMultiSubject);

                        break;

                    case "AbstractPASSTransition":

                        AbstractPASSTransition abstractPASSTransition = new AbstractPASSTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractPASSTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractPASSTransition.createInstance(attribute, attributeType);
                        name = abstractPASSTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractPASSTransition);

                        break;

                    case "AbstractReceiveState":

                        AbstractReceiveState abstractReceiveState = new AbstractReceiveState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractReceiveState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractReceiveState.createInstance(attribute, attributeType);
                        name = abstractReceiveState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractReceiveState);

                        break;

                    case "AbstractSendState":

                        AbstractSendState abstractSendState = new AbstractSendState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractSendState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractSendState.createInstance(attribute, attributeType);
                        name = abstractSendState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractSendState);

                        break;

                    case "AbstractSingleSubject":

                        AbstractSingleSubject abstractSingleSubject = new AbstractSingleSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractSingleSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractSingleSubject.createInstance(attribute, attributeType);
                        name = abstractSingleSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractSingleSubject);

                        break;

                    case "AbstractState":

                        AbstractState abstractState = new AbstractState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractState.createInstance(attribute, attributeType);
                        name = abstractState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractState);

                        break;

                    case "AbstractSubject":

                        AbstractSubject abstractSubject = new AbstractSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    abstractSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        abstractSubject.createInstance(attribute, attributeType);
                        name = abstractSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, abstractSubject);

                        break;

                    case "ActorPlaceHolder":

                        ActorPlaceHolder actorPlaceHolder = new ActorPlaceHolder();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    actorPlaceHolder.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        actorPlaceHolder.createInstance(attribute, attributeType);
                        name = actorPlaceHolder.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, actorPlaceHolder);

                        break;

                    case "ALPSModelElement":

                        ALPSModelElement aLPSModelElement = new ALPSModelElement();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    aLPSModelElement.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        aLPSModelElement.createInstance(attribute, attributeType);
                        name = aLPSModelElement.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, aLPSModelElement);

                        break;

                    case "ALPSSBDComponent":

                        ALPSSBDComponent aLPSSBDComponent = new ALPSSBDComponent();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    aLPSSBDComponent.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        aLPSSBDComponent.createInstance(attribute, attributeType);
                        name = aLPSSBDComponent.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, aLPSSBDComponent);

                        break;

                    case "ALPSSIDComponent":

                        ALPSSIDComponent aLPSSIDComponent = new ALPSSIDComponent();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    aLPSSIDComponent.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        aLPSSIDComponent.createInstance(attribute, attributeType);
                        name = aLPSSIDComponent.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, aLPSSIDComponent);

                        break;

                    case "BaseLayer":

                        BaseLayer baseLayer = new BaseLayer();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    baseLayer.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        baseLayer.createInstance(attribute, attributeType);
                        name = baseLayer.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, baseLayer);

                        break;

                    case "BehaviorDescriptionComponent":

                        BehaviorDescriptionComponent behaviorDescriptionComponent = new BehaviorDescriptionComponent();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    behaviorDescriptionComponent.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        behaviorDescriptionComponent.createInstance(attribute, attributeType);
                        name = behaviorDescriptionComponent.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, behaviorDescriptionComponent);

                        layer.Add(behaviorDescriptionComponent.getModelComponentID(), behaviorDescriptionComponent);

                        break;

                    case "BiDirectionalCommunicationChannel":

                        BiDirectionalCommunicationChannel biDirectionalCommunicationChannel = new BiDirectionalCommunicationChannel();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    biDirectionalCommunicationChannel.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        biDirectionalCommunicationChannel.createInstance(attribute, attributeType);
                        name = biDirectionalCommunicationChannel.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, biDirectionalCommunicationChannel);

                        break;

                    case "BusinessDayTimerTransition":
                        //Schreibfehler !!!!!!!!!!!!!!!!!!!!!!!
                        BuisnessDayTimerTransition buisnessDayTimerTransition = new BuisnessDayTimerTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    buisnessDayTimerTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        buisnessDayTimerTransition.createInstance(attribute, attributeType);
                        name = buisnessDayTimerTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, buisnessDayTimerTransition);

                        layer.Add(buisnessDayTimerTransition.getModelComponentID(), buisnessDayTimerTransition);

                        break;
                    /*
                    //Hier muss die Klasse noch implementiert werden (Warum hab ich das nicht schon gemacht ?)
                    case "BusinessDayTimerTransitionCondition":
                        //Schreibfehler !!!!!!!!!!!!!!!!!!!!!!!
                        BuisnessDayTimerTransitionCondition buisnessDayTimerTransitionCondition = new BuisnessDayTimerTransitionCondition("test");

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    //buisnessDayTimerTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        //buisnessDayTimerTransitionCondition.createInstance(attribute, attributeType);
                        //name = fullySpecifiedSubject.getModelComponentID();
                        //splittedURI = name.Split('^');
                        //name = splittedURI[0];
                        //passProcessModell.addElements(name, fullySpecifiedSubject);

                        //layer.Add(buisnessDayTimerTransitionCondition.getModelComponentID(), buisnessDayTimerTransitionCondition);

                        break;
                    */
                    case "CalendarBasedReminderTransition":
                        CalenderBasedReminderTransition calenderBasedReminderTransition = new CalenderBasedReminderTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    calenderBasedReminderTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        calenderBasedReminderTransition.createInstance(attribute, attributeType);
                        name = calenderBasedReminderTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, calenderBasedReminderTransition);

                        layer.Add(calenderBasedReminderTransition.getModelComponentID(), calenderBasedReminderTransition);

                        break;

                    case "CalendarBasedReminderTransitionCondition":
                        //Schreibfehler !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        CalenderBasedReminderTransitionCondition calenderBasedReminderTransitionCondition = new CalenderBasedReminderTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    calenderBasedReminderTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        calenderBasedReminderTransitionCondition.createInstance(attribute, attributeType);
                        name = calenderBasedReminderTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, calenderBasedReminderTransitionCondition);

                        layer.Add(calenderBasedReminderTransitionCondition.getModelComponentID(), calenderBasedReminderTransitionCondition);

                        break;

                    case "ChoiceSegment":

                        ChoiceSegment choiceSegment = new ChoiceSegment();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    choiceSegment.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        choiceSegment.createInstance(attribute, attributeType);
                        name = choiceSegment.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, choiceSegment);

                        layer.Add(choiceSegment.getModelComponentID(), choiceSegment);

                        break;

                    case "ChoiceSegmentPath":

                        ChoiceSegmentPath choiceSegmentPath = new ChoiceSegmentPath();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    choiceSegmentPath.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        choiceSegmentPath.createInstance(attribute, attributeType);
                        name = choiceSegmentPath.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, choiceSegmentPath);

                        layer.Add(choiceSegmentPath.getModelComponentID(), choiceSegmentPath);

                        break;

                    case "CommunicationAct":

                        CommunicationAct communicationAct = new CommunicationAct();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    communicationAct.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        communicationAct.createInstance(attribute, attributeType);
                        name = communicationAct.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, communicationAct);

                        layer.Add(communicationAct.getModelComponentID(), communicationAct);

                        break;

                    case "CommunicationTransition":

                        CommunicationTransition communicationTransition = new CommunicationTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    communicationTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        communicationTransition.createInstance(attribute, attributeType);
                        name = communicationTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, communicationTransition);

                        layer.Add(communicationTransition.getModelComponentID(), communicationTransition);

                        break;

                    case "CustomOrExternalDataTypeDefintion":

                        CustomOrExternalDataTypeDefinition customOrExternalDataTypeDefintion = new CustomOrExternalDataTypeDefinition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    customOrExternalDataTypeDefintion.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        customOrExternalDataTypeDefintion.createInstance(attribute, attributeType);
                        name = customOrExternalDataTypeDefintion.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, customOrExternalDataTypeDefintion);

                        layer.Add(customOrExternalDataTypeDefintion.getModelComponentID(), customOrExternalDataTypeDefintion);

                        break;

                    case "DataDescriptionComponent":

                        DataDescribingComponent dataDescribingComponent = new DataDescribingComponent();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dataDescribingComponent.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dataDescribingComponent.createInstance(attribute, attributeType);
                        name = dataDescribingComponent.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, dataDescribingComponent);

                        layer.Add(dataDescribingComponent.getModelComponentID(), dataDescribingComponent);

                        break;

                    case "DataMappingFunction":

                        DataMappingFunction dataMappingFunction = new DataMappingFunction();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dataMappingFunction.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dataMappingFunction.createInstance(attribute, attributeType);
                        name = dataMappingFunction.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, dataMappingFunction);

                        layer.Add(dataMappingFunction.getModelComponentID(), dataMappingFunction);

                        break;

                    case "DataMappingIncomingToLocal":

                        DataMappingIncomingToLocal dataMappingIncomingToLocal = new DataMappingIncomingToLocal();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dataMappingIncomingToLocal.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dataMappingIncomingToLocal.createInstance(attribute, attributeType);
                        name = dataMappingIncomingToLocal.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, dataMappingIncomingToLocal);

                        layer.Add(dataMappingIncomingToLocal.getModelComponentID(), dataMappingIncomingToLocal);

                        break;

                    case "DataMappingLocalToOutgoing":

                        DataMappingLocalToOutgoing dataMappingLocalToOutgoing = new DataMappingLocalToOutgoing();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dataMappingLocalToOutgoing.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dataMappingLocalToOutgoing.createInstance(attribute, attributeType);
                        name = dataMappingLocalToOutgoing.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, dataMappingLocalToOutgoing);

                        layer.Add(dataMappingLocalToOutgoing.getModelComponentID(), dataMappingLocalToOutgoing);

                        break;

                    case "DataObjectDefinition":

                        DataObjectDefinition dataObjectDefiniton = new DataObjectDefinition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dataObjectDefiniton.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dataObjectDefiniton.createInstance(attribute, attributeType);
                        passProcessModell.addElements(dataObjectDefiniton.getModelComponentID(), dataObjectDefiniton);

                        layer.Add(dataObjectDefiniton.getModelComponentID(), dataObjectDefiniton);

                        break;

                    //Aufpassen, vielleicht kann das wegen dem Contains Probleme machen 
                    case "DataObjectListDefinition":

                        DataObjectListDefiniton dataObjectListDefiniton = new DataObjectListDefiniton();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dataObjectListDefiniton.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dataObjectListDefiniton.createInstance(attribute, attributeType);
                        name = dataObjectListDefiniton.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, dataObjectListDefiniton);

                        layer.Add(dataObjectListDefiniton.getModelComponentID(), dataObjectListDefiniton);

                        break;

                    case "DataTypeDefinition":

                        DataTypeDefinition newObject = new DataTypeDefinition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    newObject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        newObject.createInstance(attribute, attributeType);
                        name = newObject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, newObject);

                        layer.Add(newObject.getModelComponentID(), newObject);

                        break;

                    //Muss ebenfalls noch implementiert werden
                    case "DayTimeTimerTransitionCondition":

                        DayTimeTimerTransitionCondition dayTimeTimerTransitionCondition = new DayTimeTimerTransitionCondition("test");

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    //dayTimeTimerTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        //newObject.createInstance(attribute, attributeType);
                        //name = newObject.getModelComponentID();
                        //splittedURI = name.Split('^');
                        //name = splittedURI[0];
                        //passProcessModell.addElements(name, newObject);
                        //layer.Add(newObject.getModelComponentID(), newObject);

                        break;

                    case "DayTimeTimerTransition":

                        DayTimeTimerTransition dayTimeTimerTransition = new DayTimeTimerTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dayTimeTimerTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dayTimeTimerTransition.createInstance(attribute, attributeType);
                        name = dayTimeTimerTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, dayTimeTimerTransition);

                        layer.Add(dayTimeTimerTransition.getModelComponentID(), dayTimeTimerTransition);

                        break;

                    case "DayTimerTransitionCondition":

                        DayTimerTransitionCondition dayTimerTransitionCondition = new DayTimerTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    dayTimerTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        dayTimerTransitionCondition.createInstance(attribute, attributeType);
                        name = dayTimerTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, dayTimerTransitionCondition);

                        layer.Add(dayTimerTransitionCondition.getModelComponentID(), dayTimerTransitionCondition);

                        break;

                    case "DoFunction":

                        DoFunction doFunction = new DoFunction();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    doFunction.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        doFunction.createInstance(attribute, attributeType);
                        name = doFunction.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, doFunction);

                        layer.Add(doFunction.getModelComponentID(), doFunction);

                        break;

                    case "ExtensionBehavior":

                        ExtensionBehavior extensionBehavior = new ExtensionBehavior();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    extensionBehavior.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        extensionBehavior.createInstance(attribute, attributeType);
                        name = extensionBehavior.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, extensionBehavior);

                        break;

                    case "ExtensionLayer":

                        ExtensionLayer extensionLayer = new ExtensionLayer();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    extensionLayer.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        extensionLayer.createInstance(attribute, attributeType);
                        name = extensionLayer.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, extensionLayer);

                        break;

                    case "FinalizedMessageExchange":

                        FinalizedMessageExchange finalizedMessageExchange = new FinalizedMessageExchange();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    finalizedMessageExchange.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        finalizedMessageExchange.createInstance(attribute, attributeType);
                        name = finalizedMessageExchange.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, finalizedMessageExchange);

                        break;
                    /*
                    case "FinalReceiveTransition":

                        FinalReceiveTransition finalReceiveTransition = new FinalReceiveTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    finalReceiveTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        finalReceiveTransition.createInstance(attribute, attributeType);
                        name = finalReceiveTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, finalReceiveTransition);

                        break;
                    */
                    case "FinalSendTransition":

                        FinalSendTransition finalSendTransition = new FinalSendTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    finalSendTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        finalSendTransition.createInstance(attribute, attributeType);
                        name = finalSendTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, finalSendTransition);

                        break;

                    case "FinalTransition":

                        FinalTransition finalTransition = new FinalTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    finalTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        finalTransition.createInstance(attribute, attributeType);
                        name = finalTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, finalTransition);

                        break;

                    case "FinalTransitionType":

                        FinalTransitionType finalTransitionType = new FinalTransitionType();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    finalTransitionType.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        finalTransitionType.createInstance(attribute, attributeType);
                        name = finalTransitionType.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, finalTransitionType);

                        break;

                    case "FunctionSpecification":

                        FunctionSpecification functionSpecification = new FunctionSpecification();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    functionSpecification.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        functionSpecification.createInstance(attribute, attributeType);
                        name = functionSpecification.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, functionSpecification);

                        layer.Add(functionSpecification.getModelComponentID(), functionSpecification);

                        break;

                    case "GeneralAbstractState":

                        GeneralAbstractState generalAbstractState = new GeneralAbstractState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    generalAbstractState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        generalAbstractState.createInstance(attribute, attributeType);
                        name = generalAbstractState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, generalAbstractState);

                        break;

                    case "GenericReturnToOriginReference":

                        GenericReturnToOriginReference genericReturnToOriginReference = new GenericReturnToOriginReference();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    genericReturnToOriginReference.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        genericReturnToOriginReference.createInstance(attribute, attributeType);
                        name = genericReturnToOriginReference.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, genericReturnToOriginReference);

                        layer.Add(genericReturnToOriginReference.getModelComponentID(), genericReturnToOriginReference);

                        break;

                    case "GroupState":

                        GroupState groupState = new GroupState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    groupState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        groupState.createInstance(attribute, attributeType);
                        name = groupState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, groupState);

                        break;

                    case "GuardBehavior":

                        GuardBehavior guardBehavior = new GuardBehavior();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    guardBehavior.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        guardBehavior.createInstance(attribute, attributeType);
                        name = guardBehavior.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, guardBehavior);

                        layer.Add(guardBehavior.getModelComponentID(), guardBehavior);

                        break;

                    case "ModelLayer":

                        ModelLayer modelLayer = new ModelLayer();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    modelLayer.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        modelLayer.createInstance(attribute, attributeType);
                        name = modelLayer.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, modelLayer);
                        passProcessModell.addLayer(name, modelLayer);

                        break;

                    case "GuardLayer":

                        GuardLayer guardLayer = new GuardLayer();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    guardLayer.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        guardLayer.createInstance(attribute, attributeType);
                        name = guardLayer.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, guardLayer);

                        break;

                    case "GuardReceiveState":

                        GuardReceiveState guardReceiveState = new GuardReceiveState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    guardReceiveState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        guardReceiveState.createInstance(attribute, attributeType);
                        name = guardReceiveState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, guardReceiveState);

                        break;

                    case "InitialState":

                        InitialStateOfBehavior initialStateOfBehavior = new InitialStateOfBehavior();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    initialStateOfBehavior.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        initialStateOfBehavior.createInstance(attribute, attributeType);
                        name = initialStateOfBehavior.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, initialStateOfBehavior);

                        layer.Add(initialStateOfBehavior.getModelComponentID(), initialStateOfBehavior);

                        break;

                    case "InitialStateOfChoiceSegmentPath":

                        InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = new InitialStateOfChoiceSegmentPath();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    initialStateOfChoiceSegmentPath.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        initialStateOfChoiceSegmentPath.createInstance(attribute, attributeType);
                        name = initialStateOfChoiceSegmentPath.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, initialStateOfChoiceSegmentPath);

                        layer.Add(initialStateOfChoiceSegmentPath.getModelComponentID(), initialStateOfChoiceSegmentPath);

                        break;


                    case "InputPoolConstraint":

                        InputPoolConstraint inputPoolConstraint = new InputPoolConstraint();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    inputPoolConstraint.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        inputPoolConstraint.createInstance(attribute, attributeType);
                        name = inputPoolConstraint.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, inputPoolConstraint);

                        layer.Add(inputPoolConstraint.getModelComponentID(), inputPoolConstraint);

                        break;

                    case "InputPoolContstraintHandlingStrategy":
                        
                        InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = new InputPoolConstraintHandlingStrategy();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    inputPoolConstraintHandlingStrategy.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        inputPoolConstraintHandlingStrategy.createInstance(attribute, attributeType);
                        name = inputPoolConstraintHandlingStrategy.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, inputPoolConstraintHandlingStrategy);

                        layer.Add(inputPoolConstraintHandlingStrategy.getModelComponentID(), inputPoolConstraintHandlingStrategy);

                        break;

                    case "InteractionDescriptionComponent":

                        InteractionDescriptionComponent interactionDescriptionComponent = new InteractionDescriptionComponent();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    interactionDescriptionComponent.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        interactionDescriptionComponent.createInstance(attribute, attributeType);
                        name = interactionDescriptionComponent.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, interactionDescriptionComponent);

                        layer.Add(interactionDescriptionComponent.getModelComponentID(), interactionDescriptionComponent);

                        break;

                    case "JSONDataTypeDefinition":

                        JSONDataTypeDefinition jSONDataTypeDefintion = new JSONDataTypeDefinition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    jSONDataTypeDefintion.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        jSONDataTypeDefintion.createInstance(attribute, attributeType);
                        name = jSONDataTypeDefintion.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, jSONDataTypeDefintion);

                        layer.Add(jSONDataTypeDefintion.getModelComponentID(), jSONDataTypeDefintion);

                        break;

                    case "MacroBehavior":

                        MacroBehavior macroBehavior = new MacroBehavior();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    macroBehavior.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        macroBehavior.createInstance(attribute, attributeType);
                        name = macroBehavior.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, macroBehavior);

                        layer.Add(macroBehavior.getModelComponentID(), macroBehavior);

                        break;

                    case "MacroLayer":

                        MacroLayer macroLayer = new MacroLayer();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    macroLayer.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        macroLayer.createInstance(attribute, attributeType);
                        name = macroLayer.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, macroLayer);

                        break;

                    case "MacroState":

                        MacroState macroState = new MacroState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    macroState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        macroState.createInstance(attribute, attributeType);
                        name = macroState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, macroState);

                        layer.Add(macroState.getModelComponentID(), macroState);

                        break;
                    /*
                    case "MandatoryToEndChoiceSegmentPath":

                        MandatoryToEndChoiceSegment mandatoryToEndChoiceSegment = new MandatoryToEndChoiceSegment();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    mandatoryToEndChoiceSegment.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        mandatoryToEndChoiceSegment.createInstance(attribute, attributeType);
                        name = mandatoryToEndChoiceSegment.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, mandatoryToEndChoiceSegment);

                        layer.Add(mandatoryToEndChoiceSegment.getModelComponentID(), mandatoryToEndChoiceSegment);

                        break;
                    /*
                    case "MandatoryToStartChoiceSegmentPath":

                        MandatoryToStartChoiceSegment mandatoryToStartChoiceSegment = new MandatoryToStartChoiceSegment();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    mandatoryToStartChoiceSegment.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        mandatoryToStartChoiceSegment.createInstance(attribute, attributeType);
                        name = mandatoryToStartChoiceSegment.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, mandatoryToStartChoiceSegment);

                        layer.Add(mandatoryToStartChoiceSegment.getModelComponentID(), mandatoryToStartChoiceSegment);

                        break;
                    */
                    case "MessageExchangeCondition":

                        MessageExchangeCondition messageExchangeCondition = new MessageExchangeCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    messageExchangeCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        messageExchangeCondition.createInstance(attribute, attributeType);
                        name = messageExchangeCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, messageExchangeCondition);

                        layer.Add(messageExchangeCondition.getModelComponentID(), messageExchangeCondition);

                        break;

                    case "MessageSenderTypeConstraint":

                        MessageSenderTypeConstraint messageSenderTypeConstraint = new MessageSenderTypeConstraint();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    messageSenderTypeConstraint.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        messageSenderTypeConstraint.createInstance(attribute, attributeType);
                        name = messageSenderTypeConstraint.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, messageSenderTypeConstraint);

                        layer.Add(messageSenderTypeConstraint.getModelComponentID(), messageSenderTypeConstraint);

                        break;

                    case "MessageTypeConstraint":

                        MessageTypeConstraint messageTypeConstraint = new MessageTypeConstraint();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    messageTypeConstraint.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        messageTypeConstraint.createInstance(attribute, attributeType);
                        name = messageTypeConstraint.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, messageTypeConstraint);

                        layer.Add(messageTypeConstraint.getModelComponentID(), messageTypeConstraint);

                        break;

                    case "ModelBuiltInDataTypes":

                        ModelBuiltInDataTypes modelBuiltInDataTypes = new ModelBuiltInDataTypes();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    modelBuiltInDataTypes.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        modelBuiltInDataTypes.createInstance(attribute, attributeType);
                        name = modelBuiltInDataTypes.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, modelBuiltInDataTypes);

                        layer.Add(modelBuiltInDataTypes.getModelComponentID(), modelBuiltInDataTypes);

                        break;
                    /*
                    case "OptionalToEndChoiceSegmentPath":

                        OptionalToEndChoiceSegmentPath optionalToEndChoiceSegmentPath = new OptionalToEndChoiceSegmentPath();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    optionalToEndChoiceSegmentPath.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        optionalToEndChoiceSegmentPath.createInstance(attribute, attributeType);
                        name = optionalToEndChoiceSegmentPath.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, optionalToEndChoiceSegmentPath);

                        layer.Add(optionalToEndChoiceSegmentPath.getModelComponentID(), optionalToEndChoiceSegmentPath);

                        break;
                    /*
                    case "OptionalToStartChoiceSegmentPath":

                        OptionalToStartChoiceSegmentPath optionalToStartChoiceSegmentPath = new OptionalToStartChoiceSegmentPath();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    optionalToStartChoiceSegmentPath.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        optionalToStartChoiceSegmentPath.createInstance(attribute, attributeType);
                        name = optionalToStartChoiceSegmentPath.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, optionalToStartChoiceSegmentPath);

                        layer.Add(optionalToStartChoiceSegmentPath.getModelComponentID(), optionalToStartChoiceSegmentPath);

                        break;
                    */
                    case "OWLDataTypeDefinition":

                        OWLDataTypeDefintion oWLDataTypeDefintion = new OWLDataTypeDefintion();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    oWLDataTypeDefintion.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        oWLDataTypeDefintion.createInstance(attribute, attributeType);
                        name = oWLDataTypeDefintion.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, oWLDataTypeDefintion);

                        layer.Add(oWLDataTypeDefintion.getModelComponentID(), oWLDataTypeDefintion);

                        break;

                    case "PayloadDataObjectDefintion":

                        PayloadDataObjectDefinition payloadDataObjectDefinition = new PayloadDataObjectDefinition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    payloadDataObjectDefinition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        payloadDataObjectDefinition.createInstance(attribute, attributeType);
                        name = payloadDataObjectDefinition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, payloadDataObjectDefinition);

                        layer.Add(payloadDataObjectDefinition.getModelComponentID(), payloadDataObjectDefinition);

                        break;
                    /*
                    case "PrecedenceReceiveTransition":

                        PrecedenceReceiveTransition precedenceReceiveTransition = new PrecedenceReceiveTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    precedenceReceiveTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        precedenceReceiveTransition.createInstance(attribute, attributeType);
                        name = precedenceReceiveTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, precedenceReceiveTransition);

                        break;

                    case "PrecedenceSendTransition":

                        PrecedenceSendTransition precedenceSendTransition = new PrecedenceSendTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    precedenceSendTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        precedenceSendTransition.createInstance(attribute, attributeType);
                        name = precedenceSendTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, precedenceSendTransition);

                        break;
                    
                    case "PrecedenceTransition":

                        PrecedenceTransition precedenceTransition = new PrecedenceTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    precedenceTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        precedenceTransition.createInstance(attribute, attributeType);
                        name = precedenceTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, precedenceTransition);

                        break;
                    
                    case "PrecedenceTransitionType":

                        PrecedenceTransitionType precedenceTransitionType = new PrecedenceTransitionType();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    precedenceTransitionType.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        precedenceTransitionType.createInstance(attribute, attributeType);
                        name = precedenceTransitionType.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, precedenceTransitionType);

                        break;
                    */
                    case "UniDirectionalCommunicationChannel":

                        UniDirectionalCommunicationChannel uniDirectionalCommunicationChannel = new UniDirectionalCommunicationChannel();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    uniDirectionalCommunicationChannel.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        uniDirectionalCommunicationChannel.createInstance(attribute, attributeType);
                        name = uniDirectionalCommunicationChannel.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, uniDirectionalCommunicationChannel);

                        break;

                    case "ReceiveFunction":

                        ReceiveFunction receiveFunction = new ReceiveFunction();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    receiveFunction.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        receiveFunction.createInstance(attribute, attributeType);
                        name = receiveFunction.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, receiveFunction);

                        layer.Add(receiveFunction.getModelComponentID(), receiveFunction);

                        break;

                    case "ReceiveType":

                        ReceiveType receiveType = new ReceiveType();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    receiveType.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        receiveType.createInstance(attribute, attributeType);
                        name = receiveType.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, receiveType);

                        layer.Add(receiveType.getModelComponentID(), receiveType);

                        break;

                    case "ReminderEventTransitionCondition":

                        ReminderEventTransitionCondition reminderEventTransitionCondition = new ReminderEventTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    reminderEventTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        reminderEventTransitionCondition.createInstance(attribute, attributeType);
                        name = reminderEventTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, reminderEventTransitionCondition);

                        layer.Add(reminderEventTransitionCondition.getModelComponentID(), reminderEventTransitionCondition);

                        break;

                    case "ReminderTransition":

                        ReminderTransition reminderTransition = new ReminderTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    reminderTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        reminderTransition.createInstance(attribute, attributeType);
                        name = reminderTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, reminderTransition);

                        layer.Add(reminderTransition.getModelComponentID(), reminderTransition);

                        break;

                    case "SenderTypeConstraint":

                        SenderTypeConstraint senderTypeConstraint = new SenderTypeConstraint();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    senderTypeConstraint.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        senderTypeConstraint.createInstance(attribute, attributeType);
                        name = senderTypeConstraint.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, senderTypeConstraint);

                        layer.Add(senderTypeConstraint.getModelComponentID(), senderTypeConstraint);

                        break;

                    case "SendFunction":

                        SendFunction sendFunction = new SendFunction();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    sendFunction.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        sendFunction.createInstance(attribute, attributeType);
                        name = sendFunction.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, sendFunction);

                        layer.Add(sendFunction.getModelComponentID(), sendFunction);

                        break;

                    case "SendingFailedCondition":

                        SendingFailedCondition sendingFailedCondition = new SendingFailedCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    sendingFailedCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        sendingFailedCondition.createInstance(attribute, attributeType);
                        name = sendingFailedCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, sendingFailedCondition);

                        layer.Add(sendingFailedCondition.getModelComponentID(), sendingFailedCondition);

                        break;

                    case "SendingFailedTransition":

                        SendingFailedTransition sendingFailedTransition = new SendingFailedTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    sendingFailedTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        sendingFailedTransition.createInstance(attribute, attributeType);
                        name = sendingFailedTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, sendingFailedTransition);

                        layer.Add(sendingFailedTransition.getModelComponentID(), sendingFailedTransition);

                        break;

                    case "SendType":

                        SendType sendType = new SendType();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    sendType.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        sendType.createInstance(attribute, attributeType);
                        name = sendType.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, sendType);

                        layer.Add(sendType.getModelComponentID(), sendType);

                        break;

                    case "SingleSubject":

                        SingleSubject singleSubject = new SingleSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    singleSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        singleSubject.createInstance(attribute, attributeType);
                        name = singleSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, singleSubject);

                        layer.Add(singleSubject.getModelComponentID(), singleSubject);
                        layer.Add(singleSubject.getModelComponentID(), (Subject)singleSubject);

                        break;

                    case "StandartPASSState":

                        StandartPASSState standartPASSState = new StandartPASSState();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    standartPASSState.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        standartPASSState.createInstance(attribute, attributeType);
                        name = standartPASSState.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, standartPASSState);

                        layer.Add(standartPASSState.getModelComponentID(), standartPASSState);

                        break;

                    case "StartSubject":

                        StartSubject startSubject = new StartSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    startSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        startSubject.createInstance(attribute, attributeType);
                        name = startSubject.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, startSubject);

                        layer.Add(startSubject.getModelComponentID(), startSubject);
                        layer.Add(startSubject.getModelComponentID(), (Subject)startSubject);

                        break;

                    case "StatePlaceholder":

                        StatePlaceholder statePlaceholder = new StatePlaceholder();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    statePlaceholder.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        statePlaceholder.createInstance(attribute, attributeType);
                        name = statePlaceholder.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, statePlaceholder);

                        break;

                    case "StateReference":

                        StateReference stateReference = new StateReference();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    stateReference.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        stateReference.createInstance(attribute, attributeType);
                        name = stateReference.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, stateReference);

                        layer.Add(stateReference.getModelComponentID(), stateReference);

                        break;

                    case "SubjectBaseBehavior":

                        SubjectBaseBehavior subjectBaseBehavior = new SubjectBaseBehavior();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    subjectBaseBehavior.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        subjectBaseBehavior.createInstance(attribute, attributeType);
                        name = subjectBaseBehavior.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, subjectBaseBehavior);

                        layer.Add(subjectBaseBehavior.getModelComponentID(), subjectBaseBehavior);

                        break;

                    case "SubjectDataDefinition":

                        SubjectDataDefinition subjectDataDefinition = new SubjectDataDefinition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    subjectDataDefinition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        subjectDataDefinition.createInstance(attribute, attributeType);
                        name = subjectDataDefinition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, subjectDataDefinition);

                        layer.Add(subjectDataDefinition.getModelComponentID(), subjectDataDefinition);

                        break;

                    case "SubjectExtension":

                        SubjectExtension subjectExtension = new SubjectExtension();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    subjectExtension.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        subjectExtension.createInstance(attribute, attributeType);
                        name = subjectExtension.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, subjectExtension);

                        break;

                    case "TimeBasedReminderTransition":

                        TimeBasedReminderTransition timeBasedReminderTransition = new TimeBasedReminderTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    timeBasedReminderTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        timeBasedReminderTransition.createInstance(attribute, attributeType);
                        name = timeBasedReminderTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, timeBasedReminderTransition);

                        layer.Add(timeBasedReminderTransition.getModelComponentID(), timeBasedReminderTransition);

                        break;

                    case "TimeBasedReminderTransitionCondition":

                        TimeBasedReminderTransitionCondition timeBasedReminderTransitionCondition = new TimeBasedReminderTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    timeBasedReminderTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        timeBasedReminderTransitionCondition.createInstance(attribute, attributeType);
                        name = timeBasedReminderTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, timeBasedReminderTransitionCondition);

                        layer.Add(timeBasedReminderTransitionCondition.getModelComponentID(), timeBasedReminderTransitionCondition);

                        break;

                    case "TimerTransition":

                        TimerTransition timerTransition = new TimerTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    timerTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        timerTransition.createInstance(attribute, attributeType);
                        name = timerTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, timerTransition);

                        layer.Add(timerTransition.getModelComponentID(), timerTransition);

                        break;

                    case "TimerTransitionCondition":

                        TimerTransitionCondition timerTransitionCondition = new TimerTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    timerTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        timerTransitionCondition.createInstance(attribute, attributeType);
                        name = timerTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, timerTransitionCondition);

                        layer.Add(timerTransitionCondition.getModelComponentID(), timerTransitionCondition);

                        break;

                    case "TimeTransition":

                        TimeTransition timeTransition = new TimeTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    timeTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        timeTransition.createInstance(attribute, attributeType);
                        name = timeTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, timeTransition);

                        layer.Add(timeTransition.getModelComponentID(), timeTransition);

                        break;

                    case "TimeTransitionCondition":

                        TimeTransitionCondition timeTransitionCondition = new TimeTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    timeTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        timeTransitionCondition.createInstance(attribute, attributeType);
                        name = timeTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, timeTransitionCondition);

                        layer.Add(timeTransitionCondition.getModelComponentID(), timeTransitionCondition);

                        break;
                    /*
                    case "TriggerReceiveTransition":

                        TriggerReceiveTransition triggerReceiveTransition = new TriggerReceiveTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    triggerReceiveTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        triggerReceiveTransition.createInstance(attribute, attributeType);
                        name = triggerReceiveTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, triggerReceiveTransition);

                        break;
                    
                    case "TriggerSendTransition":

                        TriggerSendTransition triggerSendTransition = new TriggerSendTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    triggerSendTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        triggerSendTransition.createInstance(attribute, attributeType);
                        name = triggerSendTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, triggerSendTransition);

                        break;

                    
                    
                    case "TriggerTransitionType":

                        TriggerTransitionType triggerTransitionType = new TriggerTransitionType();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    triggerTransitionType.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        triggerTransitionType.createInstance(attribute, attributeType);
                        name = triggerTransitionType.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, triggerTransitionType);

                        break;
                    */
                    case "UserCancelTransition":

                        UserCancelTransition userCancelTransition = new UserCancelTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    userCancelTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        userCancelTransition.createInstance(attribute, attributeType);
                        name = userCancelTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, userCancelTransition);

                        layer.Add(userCancelTransition.getModelComponentID(), userCancelTransition);

                        break;

                    case "XSDDataTypeDefinition":

                        XSDDataTypeDefintion xSDDataTypeDefintion = new XSDDataTypeDefintion();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    xSDDataTypeDefintion.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        xSDDataTypeDefintion.createInstance(attribute, attributeType);
                        name = xSDDataTypeDefintion.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, xSDDataTypeDefintion);

                        layer.Add(xSDDataTypeDefintion.getModelComponentID(), xSDDataTypeDefintion);

                        break;

                    case "YearMonthTimerTransition":

                        YearMonthTimerTransition yearMonthTimerTransition = new YearMonthTimerTransition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    yearMonthTimerTransition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        yearMonthTimerTransition.createInstance(attribute, attributeType);
                        name = yearMonthTimerTransition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, yearMonthTimerTransition);

                        layer.Add(yearMonthTimerTransition.getModelComponentID(), yearMonthTimerTransition);

                        break;

                    case "YearMonthTimerTransitionCondition":

                        YearMonthTimerTransitionCondition yearMonthTimerTransitionCondition = new YearMonthTimerTransitionCondition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    yearMonthTimerTransitionCondition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }

                        yearMonthTimerTransitionCondition.createInstance(attribute, attributeType);
                        name = yearMonthTimerTransitionCondition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, yearMonthTimerTransitionCondition);

                        layer.Add(yearMonthTimerTransitionCondition.getModelComponentID(), yearMonthTimerTransitionCondition);

                        break;

                    case "StandardTransition":

                        Transition transition = new Transition();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    transition.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                    //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                }
                            }
                            count++;
                        }
                        transition.setTransitionType("Standard");
                        transition.createInstance(attribute, attributeType);
                        name = transition.getModelComponentID();
                        splittedURI = name.Split('^');
                        name = splittedURI[0];
                        passProcessModell.addElements(name, transition);

                        layer.Add(transition.getModelComponentID(), transition);

                        break;

                    default:

                        ExternalAccess externalAccess = new ExternalAccess();

                        PASSProcessModelElement externalElement = externalAccess.externalCreateInstance(name, files);

                        if (externalElement != null)
                        {
                            name = externalElement.getModelComponentID();
                            passProcessModell.addElements(name, externalElement);
                        }
                        else
                        {
                            PASSProcessModelElement pASSProcessModelElement = new PASSProcessModelElement();

                            count = 0;
                            foreach (Graph j in files)
                            {
                                foreach (Triple l in files[count].Triples)
                                {
                                    if (l.Subject.ToString().Equals(i.Key))
                                    {
                                        if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                        {
                                            attributeType.Add(l.Predicate.ToString());
                                            attribute.Add(l.Subject.ToString());
                                        }
                                        else
                                        {
                                            attributeType.Add(l.Predicate.ToString());
                                            attribute.Add(l.Object.ToString());
                                        }
                                        pASSProcessModelElement.addAttribute(l.Predicate.ToString(), l.Object.ToString());
                                        //Console.WriteLine(l.Predicate.ToString() + "    " + l.Object.ToString());
                                    }
                                }
                                count++;
                            }

                            pASSProcessModelElement.createInstance(attribute, attributeType);
                            name = pASSProcessModelElement.getModelComponentID();
                            splittedURI = name.Split('^');
                            name = splittedURI[0];
                            passProcessModell.addElements(name, pASSProcessModelElement);

                            Console.WriteLine("WARNING: Enountered unkown Object " + pASSProcessModelElement.getModelComponentID() + ", it will be parsed as an PASSProcessModelElement");

                        }
                        break;
                }

                counter++;
            }

            //layer.completeObjects();

            Console.WriteLine("[#######################       ]");
            passProcessModell.completeObjects();

            return passProcessModells;
        }

        /// <summary>
        /// Method that exports the given model to a file with the given filename at the same place where the data will be read for the load() method
        /// </summary>
        /// <param name="passProcessModel"></param>
        /// <param name="filename"></param>
        public void exportModell(PassProcessModel passProcessModel, string filename)
        {
            using (StreamWriter sw = new StreamWriter("../../../../" + filename + ".owl"))
            {

                sw.WriteLine("<?xml version=\"1.0\"?>");
                sw.WriteLine();
                sw.WriteLine("<!DOCTYPE rdf:RDF [");
                sw.WriteLine("      <!ENTITY owl \"http://www.w3.org/2002/07/owl#\" >");
                sw.WriteLine("      <!ENTITY xsd \"http://www.w3.org/2001/XMLSchema#\" >");
                sw.WriteLine("      <!ENTITY rdfs \"http://www.w3.org/2000/01/rdf-schema#\" >");
                sw.WriteLine("      <!ENTITY abstract-pass-ont \"http://www.imi.kit.edu/abstract-pass-ont#\" >");
                sw.WriteLine("      <!ENTITY standard-pass-ont \"http://www.i2pm.net/standard-pass-ont#\" >");
                sw.WriteLine("      <!ENTITY rdf \"http://www.w3.org/1999/02/22-rdf-syntax-ns#\" >");
                sw.WriteLine("]>");
                sw.WriteLine();
                sw.WriteLine("<rdf:RDF xmlns:abstract-pass-ont=\"http://www.imi.kit.edu/abstract-pass-ont#\" xmlns:standard-pass-ont=\"http://www.i2pm.net/standard-pass-ont#\" xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\" xmlns:owl=\"http://www.w3.org/2002/07/owl#\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema#\" xmlns:rdfs=\"http://www.w3.org/2000/01/rdf-schema#\" xmlns=\"http://subjective-me.jimdo.com/s-bpm/processmodels/2016-06-22/Zeichenblatt-1\">");
                //sw.WriteLine("  <owl:Ontology rdf:about=\"http://subjective-me.jimdo.com/s-bpm/processmodels/2016-06-22/Zeichenblatt-1\">");
                sw.WriteLine("  <owl:Ontology rdf:about=\"" + passProcessModel.getModelComponentID().Split('#')[0] + "\" > ");
                sw.WriteLine("      <owl:versionIRI rdf:resource=\"http://subjective-me.jimdo.com/s-bpm/processmodels/2016-06-22/Zeichenblatt-1/2019-10-11\"></owl:versionIRI>");
                sw.WriteLine("      <owl:imports rdf:resource=\"http://www.imi.kit.edu/abstract-pass-ont\"></owl:imports>");
                sw.WriteLine("      <owl:imports rdf:resource=\"http://www.i2pm.net/standard-pass-ont\"></owl:imports>");
                sw.WriteLine("  </owl:Ontology>");
                sw.WriteLine();
            }

            passProcessModel.exporting(true, filename);

            foreach (KeyValuePair<string, PASSProcessModelElement> p in passProcessModel.getAllElements())
            {
                p.Value.exporting(true, filename);
            }

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {
                sw.WriteLine("</rdf:RDF>");
            }
        }

        /// <summary>
        /// Creates the inheraitans Graph out of hardcodet classes
        /// WIP: Hier müssen noch die korrekten Namen der Elemente (URIs) eingetragen werden, das hab ich immernoch nicht gemacht, aber irgendwie ändert das gerade auch nichts mehr
        /// </summary>
        public void createTree()
        {
            OwlThing owlThing = new OwlThing();
            TreeNode treeNodeOwlThing = new TreeNode("owlThing");
            treeRootNode = treeNodeOwlThing;
            standartPassObjects.Add(owlThing);

            PASSProcessModelElement pASSProcessModelElement = new PASSProcessModelElement();
            TreeNode treeNodePASSProcessModelElement = new TreeNode(pASSProcessModelElement.getModelComponentID());
            treeRootNode.addChild(treeNodePASSProcessModelElement);
            //pASSProcessModelElements.Add(pASSProcessModelElement);
            //standartPassObjects.Add(pASSProcessModelElement);

            BehaviorDescriptionComponent behaviorDescriptionComponent = new BehaviorDescriptionComponent();
            TreeNode treeNodeBehaviorDescriptionComponent = new TreeNode(behaviorDescriptionComponent.getModelComponentID());
            treeNodePASSProcessModelElement.addChild(treeNodeBehaviorDescriptionComponent);
            standartPassObjects.Add(behaviorDescriptionComponent);

            Action action = new Action();
            TreeNode treeNodeAction = new TreeNode(action.getModelComponentID());
            treeNodeBehaviorDescriptionComponent.addChild(treeNodeAction);
            standartPassObjects.Add(action);

            FunctionSpecification functionSpecification = new FunctionSpecification();
            TreeNode treeNodeFunctionSpecification = new TreeNode(functionSpecification.getModelComponentID());
            treeNodeBehaviorDescriptionComponent.addChild(treeNodeFunctionSpecification);
            standartPassObjects.Add(functionSpecification);

            CommunicationAct communicationAct = new CommunicationAct();
            TreeNode treeNodeCommunicationAct = new TreeNode(communicationAct.getModelComponentID());
            treeNodeFunctionSpecification.addChild(treeNodeCommunicationAct);
            standartPassObjects.Add(communicationAct);

            ReceiveFunction receiveFunction = new ReceiveFunction();
            TreeNode treeNodeReceiveFunction = new TreeNode(receiveFunction.getModelComponentID());
            treeNodeCommunicationAct.addChild(treeNodeReceiveFunction);
            standartPassObjects.Add(receiveFunction);

            SendFunction sendFunction = new SendFunction();
            TreeNode treeNodeSendFunction = new TreeNode(sendFunction.getModelComponentID());
            treeNodeCommunicationAct.addChild(treeNodeSendFunction);
            standartPassObjects.Add(sendFunction);

            DoFunction doFunction = new DoFunction();
            TreeNode treeNodeDoFunction = new TreeNode(doFunction.getModelComponentID());
            treeNodeFunctionSpecification.addChild(treeNodeDoFunction);
            standartPassObjects.Add(doFunction);

            ReceiveType receiveType = new ReceiveType();
            TreeNode treeNodeReceiveType = new TreeNode(receiveType.getModelComponentID());
            treeNodeBehaviorDescriptionComponent.addChild(treeNodeReceiveType);
            standartPassObjects.Add(receiveFunction);

            SendType sendType = new SendType();
            TreeNode treeNodeSendType = new TreeNode(sendType.getModelComponentID());
            treeNodeBehaviorDescriptionComponent.addChild(treeNodeSendType);
            standartPassObjects.Add(sendType);

            State state = new State();
            TreeNode treeNodeState = new TreeNode(state.getModelComponentID());
            treeNodeBehaviorDescriptionComponent.addChild(treeNodeState);
            standartPassObjects.Add(state);

            ChoiceSegment choiceSegment = new ChoiceSegment();
            TreeNode treeNodeChoiceSegment = new TreeNode(choiceSegment.getModelComponentID());
            treeNodeState.addChild(treeNodeChoiceSegment);
            standartPassObjects.Add(choiceSegment);

            ChoiceSegmentPath choiceSegmentPath = new ChoiceSegmentPath();
            TreeNode treeNodeChoiceSegmentPath = new TreeNode(choiceSegmentPath.getModelComponentID());
            treeNodeState.addChild(treeNodeChoiceSegmentPath);
            standartPassObjects.Add(choiceSegmentPath);

            EndState endState = new EndState();
            TreeNode treeNodeEndState = new TreeNode(endState.getModelComponentID());
            treeNodeState.addChild(treeNodeEndState);
            standartPassObjects.Add(endState);

            GenericReturnToOriginReference genericReturnToOriginReference = new GenericReturnToOriginReference();
            TreeNode treeNodeGenericReturnToOriginReference = new TreeNode(genericReturnToOriginReference.getModelComponentID());
            treeNodeState.addChild(treeNodeGenericReturnToOriginReference);
            standartPassObjects.Add(genericReturnToOriginReference);

            InitialStateOfBehavior initialStateOfBehavior = new InitialStateOfBehavior();
            TreeNode treeNodeInitialStateOfBehavior = new TreeNode(initialStateOfBehavior.getModelComponentID());
            treeNodeState.addChild(treeNodeInitialStateOfBehavior);
            standartPassObjects.Add(initialStateOfBehavior);

            InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = new InitialStateOfChoiceSegmentPath();
            TreeNode treeNodeInitialStateOfChoiceSegmentPath = new TreeNode(initialStateOfChoiceSegmentPath.getModelComponentID());
            treeNodeState.addChild(treeNodeInitialStateOfChoiceSegmentPath);
            standartPassObjects.Add(initialStateOfChoiceSegmentPath);

            MacroState macroState = new MacroState();
            TreeNode treeNodeMacroState = new TreeNode(macroState.getModelComponentID());
            treeNodeState.addChild(treeNodeMacroState);
            standartPassObjects.Add(macroState);

            StandartPASSState standartPASSState = new StandartPASSState();
            TreeNode treeNodeStandartPASSState = new TreeNode(standartPASSState.getModelComponentID());
            treeNodeState.addChild(treeNodeStandartPASSState);
            standartPassObjects.Add(standartPASSState);

            DoState doState = new DoState();
            TreeNode treeNodeDoState = new TreeNode(doState.getModelComponentID());
            treeNodeStandartPASSState.addChild(treeNodeDoState);
            standartPassObjects.Add(doState);

            ReceiveState receiveState = new ReceiveState();
            TreeNode treeNodeReceiveState = new TreeNode(receiveState.getModelComponentID());
            treeNodeStandartPASSState.addChild(treeNodeReceiveState);
            standartPassObjects.Add(receiveState);

            SendState sendState = new SendState();
            TreeNode treeNodeSendState = new TreeNode(sendState.getModelComponentID());
            treeNodeStandartPASSState.addChild(treeNodeSendState);
            standartPassObjects.Add(sendState);

            StateReference stateReference = new StateReference();
            TreeNode treeNodeStateReference = new TreeNode(stateReference.getModelComponentID());
            treeNodeState.addChild(treeNodeStateReference);
            standartPassObjects.Add(stateReference);

            Transition transition = new Transition();
            TreeNode treeNodeTransition = new TreeNode(transition.getModelComponentID());
            treeNodeBehaviorDescriptionComponent.addChild(treeNodeTransition);
            standartPassObjects.Add(transition);

            CommunicationTransition communicationTransition = new CommunicationTransition();
            TreeNode treeNodeCommunicationTransition = new TreeNode(communicationTransition.getModelComponentID());
            treeNodeTransition.addChild(treeNodeCommunicationTransition);
            standartPassObjects.Add(communicationTransition);

            ReceiveTransition receiveTransition = new ReceiveTransition();
            TreeNode treeNodeReceiveTransition = new TreeNode(receiveTransition.getModelComponentID());
            treeNodeCommunicationTransition.addChild(treeNodeReceiveTransition);
            standartPassObjects.Add(receiveTransition);

            SendTransition sendTransition = new SendTransition();
            TreeNode treeNodeSendTransition = new TreeNode(sendTransition.getModelComponentID());
            treeNodeCommunicationTransition.addChild(treeNodeSendTransition);
            standartPassObjects.Add(sendTransition);

            DoTransition doTransition = new DoTransition();
            TreeNode treeNodeDoTransition = new TreeNode(doTransition.getModelComponentID());
            treeNodeTransition.addChild(treeNodeDoTransition);
            standartPassObjects.Add(doTransition);

            SendingFailedTransition sendingFailedTransition = new SendingFailedTransition();
            TreeNode treeNodeSendingFailedTransition = new TreeNode(sendingFailedTransition.getModelComponentID());
            treeNodeTransition.addChild(treeNodeSendingFailedTransition);
            standartPassObjects.Add(sendingFailedTransition);

            TimeTransition timeTransition = new TimeTransition();
            TreeNode treeNodeTimeTransition = new TreeNode(timeTransition.getModelComponentID());
            treeNodeTransition.addChild(treeNodeTimeTransition);
            standartPassObjects.Add(timeTransition);

            ReminderTransition reminderTransition = new ReminderTransition();
            TreeNode treeNodeReminderTransition = new TreeNode(reminderTransition.getModelComponentID());
            treeNodeTimeTransition.addChild(treeNodeReminderTransition);
            standartPassObjects.Add(reminderTransition);

            CalenderBasedReminderTransition calenderBasedReminderTransition = new CalenderBasedReminderTransition();
            TreeNode treeNodeCalenderBasedReminderTransition = new TreeNode(calenderBasedReminderTransition.getModelComponentID());
            treeNodeReminderTransition.addChild(treeNodeCalenderBasedReminderTransition);
            standartPassObjects.Add(calenderBasedReminderTransition);

            TimeBasedReminderTransition timeBasedReminderTransition = new TimeBasedReminderTransition();
            TreeNode treeNodeTimeBasedReminderTransition = new TreeNode(timeBasedReminderTransition.getModelComponentID());
            treeNodeReminderTransition.addChild(treeNodeTimeBasedReminderTransition);
            standartPassObjects.Add(timeBasedReminderTransition);

            TimerTransition timerTransition = new TimerTransition();
            TreeNode treeNodeTimerTransition = new TreeNode(timerTransition.getModelComponentID());
            treeNodeTimeTransition.addChild(treeNodeTimerTransition);
            standartPassObjects.Add(timerTransition);

            BuisnessDayTimerTransition buisnessDayTimerTransition = new BuisnessDayTimerTransition();
            TreeNode treeNodeBuisnessDayTimerTransition = new TreeNode(buisnessDayTimerTransition.getModelComponentID());
            treeNodeTimerTransition.addChild(treeNodeBuisnessDayTimerTransition);
            standartPassObjects.Add(buisnessDayTimerTransition);

            DayTimeTimerTransition dayTimeTimerTransition = new DayTimeTimerTransition();
            TreeNode treeNodeDayTimeTimerTransition = new TreeNode(dayTimeTimerTransition.getModelComponentID());
            treeNodeTimerTransition.addChild(treeNodeDayTimeTimerTransition);
            standartPassObjects.Add(dayTimeTimerTransition);

            YearMonthTimerTransition yearMonthTimerTransition = new YearMonthTimerTransition();
            TreeNode treeNodeYearMonthTimerTransition = new TreeNode(yearMonthTimerTransition.getModelComponentID());
            treeNodeTimerTransition.addChild(treeNodeYearMonthTimerTransition);
            standartPassObjects.Add(yearMonthTimerTransition);

            UserCancelTransition userCancelTransition = new UserCancelTransition();
            TreeNode treeNodeUserCancelTransition = new TreeNode(userCancelTransition.getModelComponentID());
            treeNodeTransition.addChild(treeNodeUserCancelTransition);
            standartPassObjects.Add(userCancelTransition);

            TransitionCondition transitionCondition = new TransitionCondition();
            TreeNode treeNodeTransitionCondition = new TreeNode(transitionCondition.getModelComponentID());
            treeNodeBehaviorDescriptionComponent.addChild(treeNodeTransitionCondition);
            standartPassObjects.Add(transitionCondition);

            DoTransitionCondition doTransitionCondition = new DoTransitionCondition();
            TreeNode treeNodeDoTransitionCondition = new TreeNode(doTransitionCondition.getModelComponentID());
            treeNodeTransitionCondition.addChild(treeNodeDoTransitionCondition);
            standartPassObjects.Add(doTransitionCondition);

            MessageExchangeCondition messageExchangeCondition = new MessageExchangeCondition();
            TreeNode treeNodeMessageExchangeCondition = new TreeNode(messageExchangeCondition.getModelComponentID());
            treeNodeTransitionCondition.addChild(treeNodeMessageExchangeCondition);
            standartPassObjects.Add(messageExchangeCondition);

            ReceiveTransitionCondition receiveTransitionCondition = new ReceiveTransitionCondition();
            TreeNode treeNodeReceiveTransitionCondition = new TreeNode(receiveTransitionCondition.getModelComponentID());
            treeNodeMessageExchangeCondition.addChild(treeNodeReceiveTransitionCondition);
            standartPassObjects.Add(receiveTransitionCondition);

            SendTransitionCondition sendTransitionCondition = new SendTransitionCondition();
            TreeNode treeNodeSendTransitionCondition = new TreeNode(sendTransitionCondition.getModelComponentID());
            treeNodeMessageExchangeCondition.addChild(treeNodeSendTransitionCondition);
            standartPassObjects.Add(sendTransitionCondition);

            SendingFailedCondition sendingFailedCondition = new SendingFailedCondition();
            TreeNode treeNodeSendingFailedCondition = new TreeNode(sendingFailedCondition.getModelComponentID());
            treeNodeTransitionCondition.addChild(treeNodeSendingFailedCondition);
            standartPassObjects.Add(sendingFailedCondition);

            TimeTransitionCondition timeTransitionCondition = new TimeTransitionCondition();
            TreeNode treeNodeTimeTransitionCondition = new TreeNode(timeTransitionCondition.getModelComponentID());
            treeNodeTransitionCondition.addChild(treeNodeTimeTransitionCondition);
            standartPassObjects.Add(timeTransitionCondition);

            ReminderEventTransitionCondition reminderEventTransitionCondition = new ReminderEventTransitionCondition();
            TreeNode treeNodeReminderEventTransitionCondition = new TreeNode(reminderEventTransitionCondition.getModelComponentID());
            treeNodeTimeTransitionCondition.addChild(treeNodeReminderEventTransitionCondition);
            standartPassObjects.Add(reminderEventTransitionCondition);

            CalenderBasedReminderTransitionCondition calenderBasedReminderTransitionCondition = new CalenderBasedReminderTransitionCondition();
            TreeNode treeNodeCalenderBasedReminderTransitionCondition = new TreeNode(calenderBasedReminderTransitionCondition.getModelComponentID());
            treeNodeReminderEventTransitionCondition.addChild(treeNodeCalenderBasedReminderTransitionCondition);
            standartPassObjects.Add(calenderBasedReminderTransitionCondition);

            TimeBasedReminderTransitionCondition timeBasedReminderTransitionCondition = new TimeBasedReminderTransitionCondition();
            TreeNode treeNodeTimeBasedReminderTransitionCondition = new TreeNode(timeBasedReminderTransitionCondition.getModelComponentID());
            treeNodeReminderEventTransitionCondition.addChild(treeNodeTimeBasedReminderTransitionCondition);
            standartPassObjects.Add(timeBasedReminderTransitionCondition);

            TimerTransitionCondition timerTransitionCondition = new TimerTransitionCondition();
            TreeNode treeNodeTimerTransitionCondition = new TreeNode(timerTransitionCondition.getModelComponentID());
            treeNodeTimeTransitionCondition.addChild(treeNodeTimerTransitionCondition);
            standartPassObjects.Add(timerTransitionCondition);

            //BuisnessDayTimerTransitionCondition
            //TreeNode treeNodeBuisnessDayTimerTransitionCondition;
            //treeNodeTimerTransitionCondition.addChild(treeNodeBuisnessDayTimerTransitionCondition);
            //standartPassObjects.Add(buisnessDayTimerTransitionCondition);

            //DayTimeTimerTransitionCondition
            //TreeNode treeNodeDayTimeTimerTransitionCondition;
            //treeNodeTimerTransitionCondition.addChild(treeNodeDayTimeTimerTransitionCondition);
            //standartPassObjects.Add(dayTimeTimerTransitionCondition);

            //YearMonthTimerTransitionConditions
            //TreeNode treeNodeYearMonthTimerTransitionConditions;
            //treeNodeTimerTransitionCondition.addChild(treeNodeYearMonthTimerTransitionConditions);
            //standartPassObjects.Add(yearMonthTimerTransitionConditions);

            DataDescribingComponent dataDescribingComponent = new DataDescribingComponent();
            TreeNode treeNodeDataDescribingComponent = new TreeNode(dataDescribingComponent.getModelComponentID());
            treeNodePASSProcessModelElement.addChild(treeNodeDataDescribingComponent);
            standartPassObjects.Add(dataDescribingComponent);

            DataMappingFunction dataMappingFunction = new DataMappingFunction();
            TreeNode treeNodeDataMappingFunction = new TreeNode(dataMappingFunction.getModelComponentID());
            treeNodeDataDescribingComponent.addChild(treeNodeDataMappingFunction);
            standartPassObjects.Add(dataMappingFunction);

            DataMappingIncomingToLocal dataMappingIncomingToLocal = new DataMappingIncomingToLocal();
            TreeNode treeNodeDataMappingIncomingToLocal = new TreeNode(dataMappingIncomingToLocal.getModelComponentID());
            treeNodeDataMappingFunction.addChild(treeNodeDataMappingIncomingToLocal);
            standartPassObjects.Add(dataMappingIncomingToLocal);

            DataMappingLocalToOutgoing dataMappingLocalToOutgoing = new DataMappingLocalToOutgoing();
            TreeNode treeNodeDataMappingLocalToOutgoing = new TreeNode(dataMappingLocalToOutgoing.getModelComponentID());
            treeNodeDataMappingFunction.addChild(treeNodeDataMappingLocalToOutgoing);
            standartPassObjects.Add(dataMappingLocalToOutgoing);

            DataObjectDefinition dataObjectDefiniton = new DataObjectDefinition();
            TreeNode treeNodeDataObjectDefiniton = new TreeNode(dataObjectDefiniton.getModelComponentID());
            treeNodeDataDescribingComponent.addChild(treeNodeDataObjectDefiniton);
            standartPassObjects.Add(dataObjectDefiniton);

            DataObjectListDefiniton dataObjectListDefiniton = new DataObjectListDefiniton();
            TreeNode treeNodeDataObjectListDefiniton = new TreeNode(dataObjectListDefiniton.getModelComponentID());
            treeNodeDataObjectDefiniton.addChild(treeNodeDataObjectListDefiniton);
            standartPassObjects.Add(dataObjectListDefiniton);

            PayloadDataObjectDefinition payloadDataObjectDefinition = new PayloadDataObjectDefinition();
            TreeNode treeNodePayloadDataObjectDefinition = new TreeNode(payloadDataObjectDefinition.getModelComponentID());
            treeNodeDataObjectDefiniton.addChild(treeNodePayloadDataObjectDefinition);
            standartPassObjects.Add(payloadDataObjectDefinition);

            SubjectDataDefinition subjectDataDefinition = new SubjectDataDefinition();
            TreeNode treeNodeSubjectDataDefinition = new TreeNode(subjectDataDefinition.getModelComponentID());
            treeNodeDataObjectDefiniton.addChild(treeNodeSubjectDataDefinition);
            standartPassObjects.Add(subjectDataDefinition);

            DataTypeDefinition dataTypeDefintion = new DataTypeDefinition();
            TreeNode treeNodeDataTypeDefintion = new TreeNode(dataTypeDefintion.getModelComponentID());
            treeNodeDataDescribingComponent.addChild(treeNodeDataTypeDefintion);
            standartPassObjects.Add(dataTypeDefintion);

            CustomOrExternalDataTypeDefinition customOrExternalDataTypeDefintion = new CustomOrExternalDataTypeDefinition();
            TreeNode treeNodeCustomOrExternalDataTypeDefintion = new TreeNode(customOrExternalDataTypeDefintion.getModelComponentID());
            treeNodeDataTypeDefintion.addChild(treeNodeCustomOrExternalDataTypeDefintion);
            standartPassObjects.Add(customOrExternalDataTypeDefintion);

            JSONDataTypeDefinition jSONDataTypeDefintion = new JSONDataTypeDefinition();
            TreeNode treeNodeJSONDataTypeDefintion = new TreeNode(jSONDataTypeDefintion.getModelComponentID());
            treeNodeCustomOrExternalDataTypeDefintion.addChild(treeNodeJSONDataTypeDefintion);
            standartPassObjects.Add(jSONDataTypeDefintion);

            OWLDataTypeDefintion oWLDataTypeDefintion = new OWLDataTypeDefintion();
            TreeNode treeNodeOWLDataTypeDefintion = new TreeNode(oWLDataTypeDefintion.getModelComponentID());
            treeNodeCustomOrExternalDataTypeDefintion.addChild(treeNodeOWLDataTypeDefintion);
            standartPassObjects.Add(oWLDataTypeDefintion);

            XSDDataTypeDefintion xSDDataTypeDefintion = new XSDDataTypeDefintion();
            TreeNode treeNodeXSDDataTypeDefintion = new TreeNode(xSDDataTypeDefintion.getModelComponentID());
            treeNodeCustomOrExternalDataTypeDefintion.addChild(treeNodeXSDDataTypeDefintion);
            standartPassObjects.Add(xSDDataTypeDefintion);

            ModelBuiltInDataTypes modelBuiltInDataTypes = new ModelBuiltInDataTypes();
            TreeNode treeNodeModelBuiltInDataTypes = new TreeNode(modelBuiltInDataTypes.getModelComponentID());
            treeNodeDataTypeDefintion.addChild(treeNodeModelBuiltInDataTypes);
            standartPassObjects.Add(modelBuiltInDataTypes);

            PayloadDescription payloadDescription = new PayloadDescription();
            TreeNode treeNodePayloadDescription = new TreeNode(payloadDescription.getModelComponentID());
            treeNodeDataDescribingComponent.addChild(treeNodePayloadDescription);
            standartPassObjects.Add(payloadDescription);

            PayloadDataObjectDefinition payloadDataObjectDefinition1 = new PayloadDataObjectDefinition();
            TreeNode treeNodePayloadDataObjectDefinition1 = new TreeNode(payloadDataObjectDefinition1.getModelComponentID());
            treeNodePayloadDescription.addChild(treeNodePayloadDataObjectDefinition1);
            standartPassObjects.Add(payloadDataObjectDefinition1);

            //PayloadPhysikalObjectDefinition
            //TreeNode treeNodePayloadPhysikalObjectDefinition;
            //treeNodePayloadDescription.addChild(treeNodePayloadPhysikalObjectDefinition);
            //standartPassObjects.Add(payloadPhysikalObjectDefinition);

            InteractionDescriptionComponent interactionDescriptionComponent = new InteractionDescriptionComponent();
            TreeNode treeNodeInteractionDescriptionComponent = new TreeNode(interactionDescriptionComponent.getModelComponentID());
            treeNodePASSProcessModelElement.addChild(treeNodeInteractionDescriptionComponent);
            standartPassObjects.Add(interactionDescriptionComponent);

            InputPoolConstraint inputPoolConstraint = new InputPoolConstraint();
            TreeNode treeNodeInputPoolConstraint = new TreeNode(inputPoolConstraint.getModelComponentID());
            treeNodeInteractionDescriptionComponent.addChild(treeNodeInputPoolConstraint);
            standartPassObjects.Add(inputPoolConstraint);

            MessageSenderTypeConstraint messageSenderTypeConstraint = new MessageSenderTypeConstraint();
            TreeNode treeNodeMessageSenderTypeConstraint = new TreeNode(messageSenderTypeConstraint.getModelComponentID());
            treeNodeInputPoolConstraint.addChild(treeNodeMessageSenderTypeConstraint);
            standartPassObjects.Add(messageSenderTypeConstraint);

            MessageTypeConstraint messageTypeConstraint = new MessageTypeConstraint();
            TreeNode treeNodeMessageTypeConstraint = new TreeNode(messageTypeConstraint.getModelComponentID());
            treeNodeInputPoolConstraint.addChild(treeNodeMessageTypeConstraint);
            standartPassObjects.Add(messageTypeConstraint);

            SenderTypeConstraint senderTypeConstraint = new SenderTypeConstraint();
            TreeNode treeNodeSenderTypeConstraint = new TreeNode(senderTypeConstraint.getModelComponentID());
            treeNodeInputPoolConstraint.addChild(treeNodeSenderTypeConstraint);
            standartPassObjects.Add(senderTypeConstraint);

            InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = new InputPoolConstraintHandlingStrategy();
            TreeNode treeNodeInputPoolConstraintHandlingStrategy = new TreeNode(inputPoolConstraintHandlingStrategy.getModelComponentID());
            //Hier muss ich nochmal drueber, der Name stimmt nicht
            treeNodeInteractionDescriptionComponent.addChild(treeNodeInputPoolConstraintHandlingStrategy);
            standartPassObjects.Add(inputPoolConstraintHandlingStrategy);

            MessageExchange messageExchange = new MessageExchange();
            TreeNode treeNodeMessageExchange = new TreeNode(messageExchange.getModelComponentID());
            treeNodeInteractionDescriptionComponent.addChild(treeNodeMessageExchange);
            standartPassObjects.Add(messageExchange);

            MessageExchangeList messageExchangeList = new MessageExchangeList();
            TreeNode treeNodeMessageExchangeList = new TreeNode(messageExchangeList.getModelComponentID());
            treeNodeInteractionDescriptionComponent.addChild(treeNodeMessageExchangeList);
            standartPassObjects.Add(messageExchangeList);

            MessageSpecification messageSpecification = new MessageSpecification();
            TreeNode treeNodeMessageSpecification = new TreeNode(messageSpecification.getModelComponentID());
            treeNodeInteractionDescriptionComponent.addChild(treeNodeMessageSpecification);
            standartPassObjects.Add(messageSpecification);

            Subject subject = new Subject();
            TreeNode treeNodeSubject = new TreeNode(subject.getModelComponentID());
            treeNodeInteractionDescriptionComponent.addChild(treeNodeSubject);
            standartPassObjects.Add(subject);

            FullySpecifiedSubject fullySpecifiedSubject = new FullySpecifiedSubject();
            TreeNode treeNodeFullySpecifiedSubject = new TreeNode(fullySpecifiedSubject.getModelComponentID());
            treeNodeSubject.addChild(treeNodeFullySpecifiedSubject);
            standartPassObjects.Add(fullySpecifiedSubject);

            InterfaceSubject interfaceSubject = new InterfaceSubject();
            TreeNode treeNodeInterfaceSubject = new TreeNode(interfaceSubject.getModelComponentID());
            treeNodeSubject.addChild(treeNodeInterfaceSubject);
            standartPassObjects.Add(interfaceSubject);

            MultiSubject multiSubject = new MultiSubject();
            TreeNode treeNodeMultiSubject = new TreeNode(multiSubject.getModelComponentID());
            treeNodeSubject.addChild(treeNodeMultiSubject);
            standartPassObjects.Add(multiSubject);

            SingleSubject singleSubject = new SingleSubject();
            TreeNode treeNodeSingleSubject = new TreeNode(singleSubject.getModelComponentID());
            treeNodeSubject.addChild(treeNodeSingleSubject);
            standartPassObjects.Add(singleSubject);

            StartSubject startSubject = new StartSubject();
            TreeNode treeNodeStartSubject = new TreeNode(startSubject.getModelComponentID());
            treeNodeSubject.addChild(treeNodeStartSubject);
            standartPassObjects.Add(startSubject);

            PassProcessModel passProcessModell = new PassProcessModel();
            TreeNode treeNodePassProcessModell = new TreeNode(passProcessModell.getModelComponentID());
            treeNodePASSProcessModelElement.addChild(treeNodePassProcessModell);
            standartPassObjects.Add(passProcessModell);

            SubjectBehavior subjectBehavior = new SubjectBehavior();
            TreeNode treeNodeSubjectBehavior = new TreeNode(subjectBehavior.getModelComponentID());
            treeNodePASSProcessModelElement.addChild(treeNodeSubjectBehavior);
            standartPassObjects.Add(subjectBehavior);

            GuardBehavior guardBehavior = new GuardBehavior();
            TreeNode treeNodeGuardBehavior = new TreeNode(guardBehavior.getModelComponentID());
            treeNodeSubjectBehavior.addChild(treeNodeGuardBehavior);
            standartPassObjects.Add(guardBehavior);

            MacroBehavior macroBehavior = new MacroBehavior();
            TreeNode treeNodeMacroBehavior = new TreeNode(macroBehavior.getModelComponentID());
            treeNodeSubjectBehavior.addChild(treeNodeMacroBehavior);
            standartPassObjects.Add(macroBehavior);

            SubjectBaseBehavior subjectBaseBehavior = new SubjectBaseBehavior();
            TreeNode treeNodeSubjectBaseBehavior = new TreeNode(subjectBaseBehavior.getModelComponentID());
            treeNodeSubjectBehavior.addChild(treeNodeSubjectBaseBehavior);
            standartPassObjects.Add(subjectBaseBehavior);

            Log.Information("Finished Creating the Standart Pass Tree");
        }

    }

    /// <summary>
    /// Dies ist die Beschreibung der einfachen Element wobei diese an sich nicht unbedingt
    /// notwending ist, mal schauen ob diese in der Bibliothek verbleiben, vermutlich schon 
    /// </summary>

    public interface SimplePASSElement : IOwlThing
    {

    }

    /// <summary>
    /// hier sollte die Beschreibung der AbstractPass kommen, mal schauen was ich davon
    /// brauche, vermutlich alles
    /// </summary>

    public interface abstracPass
    {

    }
}
