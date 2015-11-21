using System;
using System.Collections.Generic;

public class csTree
{
    public csNode Root { get; set; }
    public csTree(string value)
    {
        this.Root = new csNode(value);
    }
}
