using CodeHelper;
using IDBO;
using System;
using System.Collections.Generic;

namespace IBuilder
{
	public interface IBuilderDALMTran
	{
		IDbObject DbObject
		{
			get;
			set;
		}

		string DbName
		{
			get;
			set;
		}

		List<ModelTran> ModelTranList
		{
			get;
			set;
		}

		string NameSpace
		{
			get;
			set;
		}

		string Folder
		{
			get;
			set;
		}

		string Modelpath
		{
			get;
			set;
		}

		string DALpath
		{
			get;
			set;
		}

		string IDALpath
		{
			get;
			set;
		}

		string IClass
		{
			get;
			set;
		}

		string DbHelperName
		{
			get;
			set;
		}

		string GetDALCode();
	}
}
