﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ps_epicor_vendorbank
/// </summary>
public class ps_epicor_vendorbank
{
	public ps_epicor_vendorbank()
	{ }

	#region Model
	public int ID { set; get;}
	public string VendorBank_Company { set; get; }
	public string VendorBank_VendorNum { set; get; }
	public string VendorBank_BankID { set; get; }
	public string VendorBank_BankName { set; get; }
	public string VendorBank_CountryNum { set; get; }
	public string VendorBank_BankAcctNumber { set; get; }
	public string VendorBank_NameOnAccount { set; get; }
	public string VendorBank_PayMethodType { set; get; }
	public string VendorBank_SwiftNum { set; get; }
	public DateTime Create_Date { set; get; }
	#endregion Model
	#region  BasicMethod

	public int Add(ps_epicor_vendorbank model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_vendorbank(");
		strSql.Append("VendorBank_Company,VendorBank_VendorNum,VendorBank_BankID,VendorBank_BankName,VendorBank_CountryNum,VendorBank_BankAcctNumber,VendorBank_NameOnAccount,VendorBank_PayMethodType,VendorBank_SwiftNum)");
		strSql.Append(" select ");
		strSql.Append("@VendorBank_Company,@VendorBank_VendorNum,@VendorBank_BankID,@VendorBank_BankName,@VendorBank_CountryNum,@VendorBank_BankAcctNumber,@VendorBank_NameOnAccount,@VendorBank_PayMethodType,@VendorBank_SwiftNum ");
		strSql.Append(" WHERE @VendorBank_BankID + '-' + cast(@VendorBank_VendorNum as nvarchar) not in (select VendorBank_BankID + '-' + cast(VendorBank_VendorNum as nvarchar)  from ps_epicor_vendorbank)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@VendorBank_Company", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_VendorNum", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_BankID", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_BankName", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_CountryNum", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_BankAcctNumber", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_NameOnAccount", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_PayMethodType", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_SwiftNum", SqlDbType.NVarChar,20)};
		parameters[0].Value = model.VendorBank_Company;
		parameters[1].Value = model.VendorBank_VendorNum;
		parameters[2].Value = model.VendorBank_BankID;
		parameters[3].Value = model.VendorBank_BankName;
		parameters[4].Value = model.VendorBank_CountryNum;
		parameters[5].Value = model.VendorBank_BankAcctNumber;
		parameters[6].Value = model.VendorBank_NameOnAccount;
		parameters[7].Value = model.VendorBank_PayMethodType;
		parameters[8].Value = model.VendorBank_SwiftNum;

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
	/// 更新一条数据
	/// </summary>
	public bool Update(ps_epicor_vendorbank model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_vendorbank set ");
		strSql.Append("VendorBank_Company=@VendorBank_Company,");
		strSql.Append("VendorBank_VendorNum=@VendorBank_VendorNum,");
		strSql.Append("VendorBank_BankID=@VendorBank_BankID,");
		strSql.Append("VendorBank_BankName=@VendorBank_BankName,");
		strSql.Append("VendorBank_CountryNum=@VendorBank_CountryNum,");
		strSql.Append("VendorBank_BankAcctNumber=@VendorBank_BankAcctNumber,");
		strSql.Append("VendorBank_NameOnAccount=@VendorBank_NameOnAccount,");
		strSql.Append("VendorBank_PayMethodType=@VendorBank_PayMethodType,");
		strSql.Append("VendorBank_SwiftNum=@VendorBank_SwiftNum,");
		strSql.Append("Create_Date=@Create_Date");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@VendorBank_Company", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_VendorNum", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_BankID", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_BankName", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_CountryNum", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_BankAcctNumber", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_NameOnAccount", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_PayMethodType", SqlDbType.NVarChar,20),
					new SqlParameter("@VendorBank_SwiftNum", SqlDbType.NVarChar,20),
					new SqlParameter("@Create_Date", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
		parameters[0].Value = model.VendorBank_Company;
		parameters[1].Value = model.VendorBank_VendorNum;
		parameters[2].Value = model.VendorBank_BankID;
		parameters[3].Value = model.VendorBank_BankName;
		parameters[4].Value = model.VendorBank_CountryNum;
		parameters[5].Value = model.VendorBank_BankAcctNumber;
		parameters[6].Value = model.VendorBank_NameOnAccount;
		parameters[7].Value = model.VendorBank_PayMethodType;
		parameters[8].Value = model.VendorBank_SwiftNum;
		parameters[9].Value = model.Create_Date;
		parameters[10].Value = model.ID;

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
	/// 删除一条数据
	/// </summary>
	public bool Delete(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_vendorbank ");
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
		strSql.Append("delete from ps_epicor_vendorbank ");
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
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_vendorbank GetModel(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,VendorBank_Company,VendorBank_VendorNum,VendorBank_BankID,VendorBank_BankName,VendorBank_CountryNum,VendorBank_BankAcctNumber,VendorBank_NameOnAccount,VendorBank_PayMethodType,VendorBank_SwiftNum,Create_Date from ps_epicor_vendorbank ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		ps_epicor_vendorbank model = new ps_epicor_vendorbank();
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
	public ps_epicor_vendorbank GetModelByVendorID(string Company, string VendorNum)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,VendorBank_Company,VendorBank_VendorNum,VendorBank_BankID,VendorBank_BankName,VendorBank_CountryNum,VendorBank_BankAcctNumber,VendorBank_NameOnAccount,VendorBank_PayMethodType,VendorBank_SwiftNum,Create_Date from ps_epicor_vendorbank ");
		strSql.Append(" where VendorBank_Company=@VendorBank_Company");
		strSql.Append(" and VendorBank_VendorNum=@VendorBank_VendorNum");
		SqlParameter[] parameters = {
					new SqlParameter("@VendorBank_Company", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorBank_VendorNum", SqlDbType.NVarChar,500)
			};
		parameters[0].Value = ID;

		ps_epicor_vendorbank model = new ps_epicor_vendorbank();
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
	public ps_epicor_vendorbank DataRowToModel(DataRow row)
	{
		ps_epicor_vendorbank model = new ps_epicor_vendorbank();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				model.ID = int.Parse(row["ID"].ToString());
			}
			if (row["VendorBank_Company"] != null)
			{
				model.VendorBank_Company = row["VendorBank_Company"].ToString();
			}
			if (row["VendorBank_VendorNum"] != null)
			{
				model.VendorBank_VendorNum = row["VendorBank_VendorNum"].ToString();
			}
			if (row["VendorBank_BankID"] != null)
			{
				model.VendorBank_BankID = row["VendorBank_BankID"].ToString();
			}
			if (row["VendorBank_BankName"] != null)
			{
				model.VendorBank_BankName = row["VendorBank_BankName"].ToString();
			}
			if (row["VendorBank_CountryNum"] != null)
			{
				model.VendorBank_CountryNum = row["VendorBank_CountryNum"].ToString();
			}
			if (row["VendorBank_BankAcctNumber"] != null)
			{
				model.VendorBank_BankAcctNumber = row["VendorBank_BankAcctNumber"].ToString();
			}
			if (row["VendorBank_NameOnAccount"] != null)
			{
				model.VendorBank_NameOnAccount = row["VendorBank_NameOnAccount"].ToString();
			}
			if (row["VendorBank_PayMethodType"] != null)
			{
				model.VendorBank_PayMethodType = row["VendorBank_PayMethodType"].ToString();
			}
			if (row["VendorBank_SwiftNum"] != null)
			{
				model.VendorBank_SwiftNum = row["VendorBank_SwiftNum"].ToString();
			}
			if (row["Create_Date"] != null && row["Create_Date"].ToString() != "")
			{
				model.Create_Date = DateTime.Parse(row["Create_Date"].ToString());
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
		strSql.Append("select ID,VendorBank_Company,VendorBank_VendorNum,VendorBank_BankID,VendorBank_BankName,VendorBank_CountryNum,VendorBank_BankAcctNumber,VendorBank_NameOnAccount,VendorBank_PayMethodType,VendorBank_SwiftNum,Create_Date ");
		strSql.Append(" FROM ps_epicor_vendorbank ");
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
		strSql.Append(" ID,VendorBank_Company,VendorBank_VendorNum,VendorBank_BankID,VendorBank_BankName,VendorBank_CountryNum,VendorBank_BankAcctNumber,VendorBank_NameOnAccount,VendorBank_PayMethodType,VendorBank_SwiftNum,Create_Date ");
		strSql.Append(" FROM ps_epicor_vendorbank ");
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
		strSql.Append("select count(1) FROM ps_epicor_vendorbank ");
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
		strSql.Append(")AS Row, T.*  from ps_epicor_vendorbank T ");
		if (!string.IsNullOrEmpty(strWhere.Trim()))
		{
			strSql.Append(" WHERE " + strWhere);
		}
		strSql.Append(" ) TT");
		strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
		return DbHelperSQL.Query(strSql.ToString());
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
		parameters[0].Value = "ps_epicor_vendorbank";
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
