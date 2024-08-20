﻿
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


/// <summary>
/// 数据访问类:ps_epicor_paymethod
/// </summary>
public partial class ps_epicor_paymethod
{
	public ps_epicor_paymethod()
	{ }
	#region  BasicMethod
	#region Model

	/// 
	/// </summary>
	public int ID { set; get; }
	public string PayMethod_Company { set; get; }
	public string PayMethod_PMUID { set; get; }
	public string PayMethod_Name { set; get; }


	#endregion Model


	/// <summary>
	/// 增加一条数据
	/// </summary>
	public int Add()
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_paymethod(");
		strSql.Append("PayMethod_Company,PayMethod_PMUID,PayMethod_Name)");
		strSql.Append(" values (");
		strSql.Append("@PayMethod_Company,@PayMethod_PMUID,@PayMethod_Name)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
				new SqlParameter("@PayMethod_Company", SqlDbType.NVarChar,50),
				new SqlParameter("@PayMethod_PMUID", SqlDbType.NVarChar,50),
				new SqlParameter("@PayMethod_Name", SqlDbType.NVarChar,200)};
		parameters[0].Value = PayMethod_Company;
		parameters[1].Value = PayMethod_PMUID;
		parameters[2].Value = PayMethod_Name;


		object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
		if (obj == null)
		{
			return 0;
		}
		else
		{
			return Convert.ToInt32(obj);
		}
	}



	/// <summary>
	/// 删除一条数据
	/// </summary>
	public bool Delete(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_paymethod ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int,4)
		};
		parameters[0].Value = ID;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	/// <summary>
	/// 批量删除数据
	/// </summary>
	public bool DeleteList(string IDlist)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_paymethod ");
		strSql.Append(" where ID in (" + IDlist + ")  ");
		int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	/// <summary>
	/// 批量删除数据
	/// </summary>
	public bool DeleteAll()
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_paymethod ");
		int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_paymethod GetModel(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 * from ps_epicor_paymethod ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int,4)
		};
		parameters[0].Value = ID;

		ps_epicor_paymethod model = new ps_epicor_paymethod();
		DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
		if (ds.Tables[0].Rows.Count > 0)
		{
			return DataRowToModel(ds.Tables[0].Rows[0]);
		}
		else
		{
			return null;
		}
	}


	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_paymethod DataRowToModel(DataRow row)
	{
		ps_epicor_paymethod model = new ps_epicor_paymethod();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				ID = int.Parse(row["ID"].ToString());
			}
			if (row["PayMethod_Company"] != null)
			{
				PayMethod_Company = row["PayMethod_Company"].ToString();
			}
			if (row["PayMethod_PMUID"] != null)
			{
				PayMethod_PMUID = row["PayMethod_PMUID"].ToString();
			}
			if (row["PayMethod_Name"] != null)
			{
				PayMethod_Name = row["PayMethod_Name"].ToString();
			}
		}
		return model;
	}

	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList(string strWhere)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select * ");
		strSql.Append(" FROM ps_epicor_paymethod ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top, string strWhere, string filedOrder)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select ");
		if (Top > 0)
		{
			strSql.Append(" top " + Top.ToString());
		}
		strSql.Append(" * ");
		strSql.Append(" FROM ps_epicor_paymethod ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		strSql.Append(" order by " + filedOrder);
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获取记录总数
	/// </summary>
	public int GetRecordCount(string strWhere)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select count(1) FROM ps_epicor_paymethod ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		object obj = DbHelperSQL.GetSingle(strSql.ToString());
		if (obj == null)
		{
			return 0;
		}
		else
		{
			return Convert.ToInt32(obj);
		}
	}
	/// <summary>
	/// 分页获取数据列表
	/// </summary>
	public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("SELECT * FROM ( ");
		strSql.Append(" SELECT ROW_NUMBER() OVER (");
		if (!string.IsNullOrEmpty(orderby.Trim()))
		{
			strSql.Append("order by T." + orderby);
		}
		else
		{
			strSql.Append("order by T.ID desc");
		}
		strSql.Append(")AS Row, T.*  from ps_epicor_paymethod T ");
		if (!string.IsNullOrEmpty(strWhere.Trim()))
		{
			strSql.Append(" WHERE " + strWhere);
		}
		strSql.Append(" ) TT");
		strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获得查询分页数据
	/// </summary>
	public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select * FROM  ps_epicor_paymethod");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
		return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
	}



	/*
	/// <summary>
	/// 分页获取数据列表
	/// </summary>
	public DataSet GetList(int PageSize,int PageIndex,string strWhere)
	{
		SqlParameter[] parameters = {
				new SqlParameter("@tblName", SqlDbType.VarChar, 255),
				new SqlParameter("@fldName", SqlDbType.VarChar, 255),
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@PageIndex", SqlDbType.Int),
				new SqlParameter("@IsReCount", SqlDbType.Bit),
				new SqlParameter("@OrderType", SqlDbType.Bit),
				new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
				};
		parameters[0].Value = "ps_epicor_paymethod";
		parameters[1].Value = "ID";
		parameters[2].Value = PageSize;
		parameters[3].Value = PageIndex;
		parameters[4].Value = 0;
		parameters[5].Value = 0;
		parameters[6].Value = strWhere;	
		return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
	}*/

	#endregion  BasicMethod
	#region  ExtensionMethod

	#endregion  ExtensionMethod
}
