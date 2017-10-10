using CodeHelper;
using System;
using System.Collections.Generic;

namespace IBuilder
{
	public interface IBuilderModel
	{
		string ModelName
		{
			get;
			set;
		}

		string NameSpace
		{
			get;
			set;
		}

		string Modelpath
		{
			get;
			set;
		}
        string TableDescription { get; set; }
        string BaseClass { get; set; }

        List<ColumnInfo> Fieldlist
		{
			get;
			set;
		}

		string CreatModel();

		string CreatModelMethod();
	}
}
