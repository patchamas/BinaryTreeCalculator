using System;
using System.Collections.Generic;
public class csNode
{
    public List<csNode> Children{get;set;}
    public string Value { get; set; }

    // Node of Tree : Inside node contain value
    public csNode this[int index]
    {
        get { return Children[index]; }
        set { Children[index] = value; }
    }

    public csNode(string _value)
    {
        this.Value = _value;
        this.Children = new List<csNode>();
    }

    // Function of Node : Can add child
    public void AddChild(csNode node)
    {
        this.Children.Add(node);
    }

    // Function of Node : Can Remove child
    public void RemoveChild(int index)
    {
        this.Children.RemoveAt(index);
    }
}
