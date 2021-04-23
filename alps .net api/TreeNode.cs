using System;
using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the tree node class
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        void setParentNode(TreeNode parent);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        void addChild(TreeNode child);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TreeNode getParentNode();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TreeNode> getChildNodes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getContent();
    }

    /// <summary>
    /// Class that represents a tree node
    /// </summary>
    public class TreeNode : ITreeNode
    {
        private TreeNode parentNode;
        private List<TreeNode> childNodes = new List<TreeNode>();
        private string content;

        /// <summary>
        /// Constructor that creates a empty tree node
        /// </summary>
        public TreeNode()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public TreeNode(string content)
        {
            this.content = content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        public TreeNode(string content, TreeNode parent, TreeNode child)
        {
            this.content = content;
            this.parentNode = parent;
            childNodes.Add(child);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childNodes"></param>
        public TreeNode(List<TreeNode> childNodes)
        {
            this.childNodes = childNodes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public void setParentNode(TreeNode parent)
        {
            this.parentNode = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childNodes"></param>
        public void setChildNodes(List<TreeNode> childNodes)
        {
            this.childNodes = childNodes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public void addChild(TreeNode child)
        {
            childNodes.Add(child);
            child.setParentNode(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TreeNode getParentNode()
        {
            return parentNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> getChildNodes()
        {
            return childNodes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getContent()
        {
            return content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";

            if (childNodes != null)
            {

                foreach (TreeNode i in childNodes)
                {
                    result = result + i.getContent();

                    Console.WriteLine(i.getContent());
                    //Console.Write(" ");
                    i.ToString();

                }
                //Console.WriteLine();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public TreeNode factoryMethod(string uri)
        {
            TreeNode newTreeNode = new TreeNode(uri);

            return newTreeNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compare"></param>
        /// <returns></returns>
        public bool containsContent(string compare)
        {
            bool test = false;

            foreach (TreeNode t in childNodes)
            {
                if (t.getContent().ToLower().Equals(compare.ToLower()))
                {
                    test = true;
                    //TreeNode newChild = new TreeNode(compare);
                    //childNodes.Add(newChild);
                    break;
                }
                else
                {
                    t.containsContent(compare);
                }
            }

            return test;
        }


    }
}
