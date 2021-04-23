namespace alps.net_api
{

    class Tree
    {
        private TreeNode rootTreeNode;

        public Tree()
        {

        }

        public Tree(TreeNode rootTreeNode)
        {
            this.rootTreeNode = rootTreeNode;
        }

        public TreeNode getRootTreeNode()
        {
            return rootTreeNode;
        }

        public void setRootTreeNode(TreeNode rootTreeNode)
        {
            this.rootTreeNode = rootTreeNode;
        }

        public bool containsTreeNode(string name)
        {
            bool containsTreeNode = false;

            foreach (TreeNode i in rootTreeNode.getChildNodes())
            {
                if (name.ToLower().Equals(i.getContent().ToLower()))
                {
                    containsTreeNode = true;
                }
            }

            return containsTreeNode;
        }
    }
}
