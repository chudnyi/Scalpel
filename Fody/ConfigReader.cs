﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

public partial class ModuleWeaver
{
    public XElement Config { get; set; }
    public List<string> RemoveReferences = new List<string>();

    public void ReadConfig()
    {
        if (Config == null)
        {
            return;
        }

        ReadIncludes();

    }

    void ReadIncludes()
    {
        var includeAssembliesAttribute = Config.Attribute("RemoveReferences");
        if (includeAssembliesAttribute != null)
        {
            foreach (var item in includeAssembliesAttribute.Value.Split('|').NonEmpty())
            {
                RemoveReferences.Add(item);
            }
        }

        var includeAssembliesElement = Config.Element("RemoveReferences");
        if (includeAssembliesElement != null)
        {
            foreach (var item in includeAssembliesElement.Value
                                                         .Split(new[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries)
                                                         .NonEmpty())
            {
                RemoveReferences.Add(item);
            }
        }
    }

}