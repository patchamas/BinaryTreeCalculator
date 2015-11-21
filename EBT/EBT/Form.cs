using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBT
{
    public partial class Form1 : Form
    {
        csTree tree;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CreateTree();
        }

        private void loopNodes(csNode node, TreeNode treeNode)
        {
            treeNode.Text = node.Value;
            foreach (csNode mn in node.Children)
            {
                TreeNode innerNode = new TreeNode();
                innerNode.Text = mn.Value;

                treeNode.Nodes.Add(innerNode);
                loopNodes(mn, innerNode);
            }
        }

        public string[] CreateTreeRoot()
        {
            string[] arrRoot = csParseExpression.ParseExpression(txtExpression.Text);
            tree = new csTree(txtExpression.Text);
            return arrRoot;
        }

        public string[] Create_LSub1(string[] strRoot)
        {
            string[] arrL1 = new string[3];
            if (strRoot[1].Length > 1)
            {
                tree.Root.AddChild(new csNode(strRoot[1].ToString()));
                arrL1 = csParseExpression.ParseExpression(strRoot[1].ToString());
                if (arrL1[1].Length > 1 && arrL1[0].ToString() == "( )")
                {
                    arrL1 = csParseExpression.ParseExpression(arrL1[1].ToString());
                }
            }     
            return arrL1;
        }
        public string[] Create_LSub1L(string[] arrL1)
        {
            string[] arrL1L = new string[3];
            if (arrL1[1].Length >= 1 && arrL1[0].ToString() != "( )")
            {
                tree.Root.Children[0].AddChild(new csNode(arrL1[1].ToString()));
                if (arrL1[1].Length > 1 && arrL1[0].ToString() == "( )")
                {
                    arrL1L = csParseExpression.ParseExpression(arrL1[1].ToString());
                }
            }
            else 
            {
                arrL1L = csParseExpression.ParseExpression(arrL1[1].ToString());
                if (arrL1L[1].Length >= 1 && arrL1L[0].ToString() != "( )")
                {
                    tree.Root.Children[0].AddChild(new csNode(arrL1L[1].ToString()));
                }
            }
            return arrL1L;
        }
        public string[] Create_LSub1L_L(string[] arrLSub1L)
        {
            string[] arrLSub1L_L = new string[3];
            if (arrLSub1L[1].Length >= 1 && arrLSub1L[0].ToString() != "( )")
            {
                tree.Root.Children[0].Children[0].AddChild(new csNode(arrLSub1L[1].ToString()));
                if (arrLSub1L[1].Length > 1 && arrLSub1L[0].ToString() == "( )")
                {
                    arrLSub1L_L = csParseExpression.ParseExpression(arrLSub1L[1].ToString());
                }
            }
            else 
            {
                arrLSub1L_L = csParseExpression.ParseExpression(arrLSub1L[1].ToString());
                if (arrLSub1L[1].Length >= 1 && arrLSub1L[0].ToString() != "( )")
                {
                    tree.Root.Children[0].Children[0].AddChild(new csNode(arrLSub1L[1].ToString()));
                }
            }
            return arrLSub1L_L;
        }
        public string[] Create_LSub1L_R(string[] arrLSub1L)
        {
            string[] arrLSub1L_R = new string[3];
            if (arrLSub1L[2].Length >= 1 && arrLSub1L[0].ToString() != "( )")
            {
                tree.Root.Children[0].Children[0].AddChild(new csNode(arrLSub1L[2].ToString()));
                if (arrLSub1L[2].Length > 1 && arrLSub1L[0].ToString() == "( )")
                {
                    arrLSub1L_R = csParseExpression.ParseExpression(arrLSub1L[2].ToString());
                }
            }
            else 
            {
                arrLSub1L_R = csParseExpression.ParseExpression(arrLSub1L[1].ToString());
                if (arrLSub1L_R[2].Length >= 1 && arrLSub1L_R[0].ToString() != "( )")
                {
                    tree.Root.Children[0].Children[0].AddChild(new csNode(arrLSub1L_R[2].ToString()));
                }
            }
            return arrLSub1L_R;
        }
        
        
        public string[] Create_LSub1R(string[] arrL1)
        {
            string[] arrL1R = new string[3];
            if (arrL1[2].Length >= 1 && arrL1[0].ToString() != "( )") 
            {
                tree.Root.Children[0].AddChild(new csNode(arrL1[2].ToString()));
                if (arrL1[2].Length > 1)
                {
                    arrL1R = csParseExpression.ParseExpression(arrL1[2].ToString());
                }
            }
            else
            {
                arrL1R = csParseExpression.ParseExpression(arrL1[1].ToString());
                if (arrL1R[2].Length >= 1 && arrL1R[0].ToString() != "( )")
                {
                    tree.Root.Children[0].AddChild(new csNode(arrL1R[2].ToString()));
                }
            }
            return arrL1R;
        }

        public string[] Create_LSub1R_L(string[] arrLSub1R)
        {
            string[] arrLSub1R_L = new string[3];
            if (arrLSub1R[1].Length >= 1 && arrLSub1R[0].ToString() != "( )") 
            {
                tree.Root.Children[0].Children[1].AddChild(new csNode(arrLSub1R[1].ToString()));
                if (arrLSub1R[1].Length > 1 && arrLSub1R[0].ToString() == "( )")
                {
                    arrLSub1R_L = csParseExpression.ParseExpression(arrLSub1R[1].ToString());
                }
            }
            else
            {
                arrLSub1R_L = csParseExpression.ParseExpression(arrLSub1R[1].ToString());
                if (arrLSub1R_L[1].Length >= 1 && arrLSub1R_L[0].ToString() != "( )")
                {
                    tree.Root.Children[0].Children[1].AddChild(new csNode(arrLSub1R_L[1].ToString()));
                }
            }
            return arrLSub1R_L;
        }

        public string[] Create_LSub1R_R(string[] arrLSub1R)
        {
            string[] arrLSub1R_R = new string[3];
            if (arrLSub1R[1].Length >= 1 && arrLSub1R[0].ToString() != "( )") 
            {
                tree.Root.Children[0].Children[0].AddChild(new csNode(arrLSub1R[1].ToString()));
                if (arrLSub1R[2].Length > 1 && arrLSub1R[1].ToString() == "( )")
                {
                    arrLSub1R_R = csParseExpression.ParseExpression(arrLSub1R[2].ToString());
                }
            }
            else
            {
                arrLSub1R_R = csParseExpression.ParseExpression(arrLSub1R[1].ToString());
                if (arrLSub1R_R[2].Length >= 1 && arrLSub1R_R[0].ToString() != "( )")
                {
                    tree.Root.Children[0].Children[1].AddChild(new csNode(arrLSub1R_R[2].ToString()));
                }
            }
            return arrLSub1R_R;
        }     

        public string[] Create_RSub1(string[] strRoot)
        {
            string[] arrR1 = new string[3];
            if (strRoot[2].Length > 1)
            {
                tree.Root.AddChild(new csNode(strRoot[2].ToString()));
                arrR1 = csParseExpression.ParseExpression(strRoot[2].ToString());
                if (arrR1[2].Length > 1 && arrR1[0].ToString() == "( )")
                {
                    arrR1 = csParseExpression.ParseExpression(arrR1[2].ToString());
                }
            }
            return arrR1;
        }
        public string[] Create_RSub1L(string[] arrR1)
        {
            string[] arrR1L = new string[3];
            if (arrR1[1].Length >= 1 && arrR1[0].ToString() != "( )")
            {
                tree.Root.Children[1].AddChild(new csNode(arrR1[1].ToString()));
                if (arrR1[1].Length > 1 && arrR1[0].ToString() == "( )")
                {
                    arrR1L = csParseExpression.ParseExpression(arrR1[1].ToString());
                }
            }
            else
            {
                arrR1L = csParseExpression.ParseExpression(arrR1[1].ToString());
                if (arrR1L[1].Length >= 1 && arrR1L[0].ToString() != "( )")
                {
                    tree.Root.Children[1].AddChild(new csNode(arrR1L[1].ToString()));
                }
            }
            return arrR1L;
        }
        public string[] Create_RSub1L_L(string[] arrRSub1L)
        {
            string[] arrRSub1L_L = new string[3];
            if (arrRSub1L[1].Length >= 1 && arrRSub1L[0].ToString() != "( )")
            {
                tree.Root.Children[1].Children[0].AddChild(new csNode(arrRSub1L[1].ToString()));
                if (arrRSub1L[1].Length > 1 && arrRSub1L[0].ToString() == "( )")
                {
                    arrRSub1L_L = csParseExpression.ParseExpression(arrRSub1L[1].ToString());
                }
            }
            else
            {
                arrRSub1L_L = csParseExpression.ParseExpression(arrRSub1L[1].ToString());
                if (arrRSub1L_L[1].Length >= 1 && arrRSub1L_L[0].ToString() != "( )")
                {
                    tree.Root.Children[1].Children[0].AddChild(new csNode(arrRSub1L_L[1].ToString()));
                }
            }
            return arrRSub1L_L;
        }
        public string[] Create_RSub1L_R(string[] arrRSub1L)
        {
            string[] arrRSub1L_R = new string[3];
            if (arrRSub1L[1].Length >= 1 && arrRSub1L[0].ToString() != "( )")
            {
                tree.Root.Children[1].Children[0].AddChild(new csNode(arrRSub1L[2].ToString()));
                if (arrRSub1L[1].Length > 1 && arrRSub1L[0].ToString() == "( )")
                {
                    arrRSub1L_R = csParseExpression.ParseExpression(arrRSub1L[1].ToString());
                }
            }
            else
            {
                arrRSub1L_R = csParseExpression.ParseExpression(arrRSub1L[1].ToString());
                if (arrRSub1L_R[2].Length >= 1 && arrRSub1L_R[0].ToString() != "( )")
                {
                    tree.Root.Children[1].Children[0].AddChild(new csNode(arrRSub1L_R[2].ToString()));
                }
            }
            return arrRSub1L_R;
        }
        
        
        public string[] Create_RSub1R(string[] arrR1)
        {
            string[] arrR1R = new string[3];
            if (arrR1[2].Length >= 1 && arrR1[0].ToString() != "( )")
            {
                tree.Root.Children[1].AddChild(new csNode(arrR1[2].ToString()));
                if (arrR1[2].Length > 1 && arrR1[0].ToString() == "( )")
                {
                    arrR1R = csParseExpression.ParseExpression(arrR1[2].ToString());
                }
            }
            else
            {
                arrR1R = csParseExpression.ParseExpression(arrR1[1].ToString());
                if (arrR1R[2].Length >= 1 && arrR1R[0].ToString() != "( )")
                {
                    tree.Root.Children[1].AddChild(new csNode(arrR1R[2].ToString()));
                }
            }
            return arrR1R;
        }
        public string[] Create_RSub1R_L(string[] arrRSub1R)
        {
            string[] arrRSub1R_L = new string[3];
            if (arrRSub1R[2].Length >= 1 && arrRSub1R[0].ToString() != "( )")
            {
                tree.Root.Children[1].Children[1].AddChild(new csNode(arrRSub1R[1].ToString()));
                if (arrRSub1R[1].Length > 1 && arrRSub1R[0].ToString() == "( )")
                {
                    arrRSub1R_L = csParseExpression.ParseExpression(arrRSub1R[1].ToString());
                }
            }
            else
            {
                arrRSub1R_L = csParseExpression.ParseExpression(arrRSub1R[1].ToString());
                if (arrRSub1R_L[1].Length >= 1 && arrRSub1R_L[0].ToString() != "( )")
                {
                    tree.Root.Children[1].Children[1].AddChild(new csNode(arrRSub1R_L[1].ToString()));
                }
            }
            return arrRSub1R_L;
        }
        public string[] Create_RSub1R_R(string[] arrRSub1R)
        {
            string[] arrRSub1R_R = new string[3];
            if (arrRSub1R[2].Length >= 1 && arrRSub1R[0].ToString() != "( )")
            {
                tree.Root.Children[1].Children[1].AddChild(new csNode(arrRSub1R[2].ToString()));
                if (arrRSub1R[2].Length > 1 && arrRSub1R[0].ToString() == "( )")
                {
                    arrRSub1R_R = csParseExpression.ParseExpression(arrRSub1R[2].ToString());
                }
            }
            else
            {
                arrRSub1R_R = csParseExpression.ParseExpression(arrRSub1R[1].ToString());
                if (arrRSub1R_R[2].Length >= 1 && arrRSub1R_R[0].ToString() != "( )")
                {
                    tree.Root.Children[1].Children[1].AddChild(new csNode(arrRSub1R_R[2].ToString()));
                }
            }
            return arrRSub1R_R;
        }
        
        

        public void CreateTree()
        {
            string[] arrRoot = CreateTreeRoot();
            /*-*/
            string[] arrLSub1 = Create_LSub1(arrRoot);
            string[] arrRSub1 = Create_RSub1(arrRoot);
            /*-----*/
            string[] arrLSub1L = Create_LSub1L(arrLSub1);//0
            string[] arrLSub1R = Create_LSub1R(arrLSub1);//0
            string[] arrRSub1L = Create_RSub1L(arrRSub1);//1
            string[] arrRSub1R = Create_RSub1R(arrRSub1);//1
            /*---------*/
            /*
            string[] arrLSub1L_L = Create_LSub1L_L(arrLSub1L);//00
            string[] arrLSub1L_R = Create_LSub1L_R(arrLSub1L);//00
             * */
            string[] arrLSub1R_L = Create_LSub1R_L(arrLSub1R);//01
            string[] arrLSub1R_R = Create_LSub1R_R(arrLSub1R);//01
            /*
            string[] arrRSub1L_L = Create_RSub1L_L(arrRSub1L);//10
            string[] arrRSub1L_R = Create_RSub1L_R(arrRSub1L);//10
            string[] arrRSub1R_L = Create_RSub1R_L(arrRSub1R);//11
            string[] arrRSub1R_R = Create_RSub1R_R(arrRSub1R);//11
            */
            /*
            if (strMain[1].Length >1)
            {
                tree.Root.AddChild(new csNode(strMain[1].ToString()));
                string[] arrL1 = csParseExpression.ParseExpression(strMain[1].ToString());
                if (arrL1[1].Length > 1)
                {
                    tree.Root.Children[0].AddChild(new csNode(arrL1[1].ToString()));
                    string[] arrL_L2 = csParseExpression.ParseExpression(arrL1[1].ToString());
                    if (arrL_L2[1].Length > 1)
                    {
                        tree.Root.Children[0].Children[0].AddChild(new csNode(arrL_L2[1].ToString()));
                        string[] arrL_L3 = csParseExpression.ParseExpression(arrL_L2[1].ToString());
                        if (arrL_L3[1].Length > 1)
                        {
                            tree.Root.Children[0].Children[0].Children[0].AddChild(new csNode(arrL_L3[1].ToString()));
                        }
                        if (arrL_L3[2].Length > 1)
                        {
                            tree.Root.Children[0].Children[0].Children[0].AddChild(new csNode(arrL_L3[2].ToString()));
                        }
                    }
                    if (arrL_L2[2].Length > 1)
                    {
                        tree.Root.Children[0].Children[0].AddChild(new csNode(arrL_L2[2].ToString()));
                        string[] arrL_L3 = csParseExpression.ParseExpression(arrL_L2[2].ToString());
                        if (arrL_L3[1].Length > 1)
                        {
                            tree.Root.Children[0].Children[0].Children[0].AddChild(new csNode(arrL_L3[1].ToString()));
                        }
                        if (arrL_L3[2].Length > 1)
                        {
                            tree.Root.Children[0].Children[0].Children[0].AddChild(new csNode(arrL_L3[2].ToString()));
                        }
                    }
                }
                if (arrL1[2].Length > 1)
                {
                    tree.Root.Children[0].AddChild(new csNode(arrL1[2].ToString()));
                    string[] arrL_R2 = csParseExpression.ParseExpression(arrL1[2].ToString());
                    if (arrL_R2[1].Length > 1)
                    {
                        tree.Root.Children[0].Children[1].AddChild(new csNode(arrL_R2[1].ToString()));
                        string[] arrL_R3 = csParseExpression.ParseExpression(arrL_R2[1].ToString());
                        if (arrL_R3[1].Length > 1)
                        {
                            tree.Root.Children[0].Children[1].Children[1].AddChild(new csNode(arrL_R3[1].ToString()));
                        }
                        if (arrL_R3[2].Length > 1)
                        {
                            tree.Root.Children[0].Children[1].Children[1].AddChild(new csNode(arrL_R3[2].ToString()));
                        }
                    }
                    if (arrL_R2[2].Length > 1)
                    {
                        tree.Root.Children[0].Children[1].AddChild(new csNode(arrL_R2[2].ToString()));
                        string[] arrL_R3 = csParseExpression.ParseExpression(arrL_R2[2].ToString());
                        if (arrL_R3[1].Length > 1)
                        {
                            tree.Root.Children[0].Children[1].Children[1].AddChild(new csNode(arrL_R3[1].ToString()));
                        }
                        if (arrL_R3[2].Length > 1)
                        {
                            tree.Root.Children[0].Children[1].Children[1].AddChild(new csNode(arrL_R3[2].ToString()));
                        }
                    }
                }
            }
            if (strMain[2].ToString() != "")
            {
                tree.Root.AddChild(new csNode(strMain[2].ToString()));
                string[] arrR1 = csParseExpression.ParseExpression(strMain[2].ToString());
                if (arrR1[1].ToString() != "")
                {
                    tree.Root.Children[1].AddChild(new csNode(arrR1[1].ToString()));
                    string[] arrR_L2 = csParseExpression.ParseExpression(arrR1[1].ToString());
                    if (arrR_L2[1].ToString() != "")
                    {
                        tree.Root.Children[1].Children[0].AddChild(new csNode(arrR_L2[1].ToString()));
                    }
                    if (arrR_L2[2].ToString() != "")
                    {
                        tree.Root.Children[1].Children[0].AddChild(new csNode(arrR_L2[2].ToString()));
                    }
                }
                if (arrR1[2].ToString() != "")
                {
                    tree.Root.Children[1].AddChild(new csNode(arrR1[2].ToString()));
                    string[] arrR_R2 = csParseExpression.ParseExpression(arrR1[2].ToString());
                    if (arrR_R2[1].ToString() != "")
                    {
                        tree.Root.Children[1].Children[1].AddChild(new csNode(arrR_R2[1].ToString()));
                    }
                    if (arrR_R2[2].ToString() != "")
                    {
                        tree.Root.Children[1].Children[1].AddChild(new csNode(arrR_R2[2].ToString()));
                    }
                }
            }
            */
            TreeNode treeNode = new TreeNode();
            treeView_Expr.Nodes.Add(treeNode);
            loopNodes(tree.Root, treeNode);


            
            
            
        }
    }
}
