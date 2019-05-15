using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace dataApplicationGenerator
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		
		private void btnFindPath_Click(object sender, EventArgs e)
		{
			folderDialog.ShowDialog();
			txtFindPath.Text = folderDialog.SelectedPath;
		}


		//Code for Data Object
		private String generatebusinessObjects()
		{
			


			StringBuilder BusinessObjects = new StringBuilder();

			BusinessObjects.Append("using System;" + Environment.NewLine);
			BusinessObjects.Append("using System.Collections.Generic;" + Environment.NewLine);
			BusinessObjects.Append("using System.Linq;" + Environment.NewLine);
			BusinessObjects.Append("using System.Text;" + Environment.NewLine);
			BusinessObjects.Append("using System.Threading.Tasks;" + Environment.NewLine);
			BusinessObjects.Append("using System.Data;" + Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);

			BusinessObjects.Append("namespace " + txtProjectName.Text + ".Classes" + Environment.NewLine);
			BusinessObjects.Append("{" + Environment.NewLine);
			BusinessObjects.Append("\tclass BusinessObjects" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t//Private members" + Environment.NewLine);
			BusinessObjects.Append("\tprivate DataLayer _dataObject;" + Environment.NewLine);
			BusinessObjects.Append("\tprivate String _extendedErrorInformation;" + Environment.NewLine);
			BusinessObjects.Append("\tprivate String _tableName;" + Environment.NewLine);
			BusinessObjects.Append("\tprivate DataRow _row;" + Environment.NewLine);
			BusinessObjects.Append("\t//End Private members" + Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);
			BusinessObjects.Append("\t//Constructors" + Environment.NewLine);

			BusinessObjects.Append("\tpublic BusinessObjects()" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\t_dataObject = new DataLayer();" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);
			BusinessObjects.Append("\tpublic BusinessObjects(String connString)" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t_dataObject = new DataLayer(connString);" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);
			BusinessObjects.Append("\t//endConstructors" + Environment.NewLine);

			BusinessObjects.Append("\t//properties" + Environment.NewLine);

			BusinessObjects.Append("\tpublic String ExtendedErrorInformation" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\tget" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\treturn _extendedErrorInformation;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);

			BusinessObjects.Append("\tpublic String ConnectionString" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\tget" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\treturn _dataObject.ConnectionString;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);

			BusinessObjects.Append("\tpublic String TableName" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\tget" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\treturn _tableName;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t\tset" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\t_tableName = value;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);

			BusinessObjects.Append("\tpublic DataRow Row" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\tget" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\t\treturn _row;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);

			BusinessObjects.Append("\t//public methods" + Environment.NewLine);

			BusinessObjects.Append("\tpublic DataTable GetDataTable(String SQL)" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\tDataTable dt = _dataObject.GetDataTable(SQL, TableName);" + Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);
			BusinessObjects.Append("\t\tif(dt == null)" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\t_extendedErrorInformation = _dataObject.ExtendedErrorInformation;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t\treturn dt;" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);

			BusinessObjects.Append("\tpublic DataSet GetDataSet(String SQL)" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\tDataSet ds = _dataObject.GetData(SQL, TableName);" + Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);
			BusinessObjects.Append("\t\tif(ds == null)" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\t\t_extendedErrorInformation = _dataObject.ExtendedErrorInformation;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t\treturn ds;" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);

			BusinessObjects.Append("\tpublic bool ExecuteSQLStatement(String SQL)" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\treturn _dataObject.ExecuteSQLStatement(SQL);" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);

			BusinessObjects.Append(Environment.NewLine);
			BusinessObjects.Append(Environment.NewLine);

			BusinessObjects.Append("\tpublic bool FindByPrimaryID(long id,String colName)" + Environment.NewLine);
			BusinessObjects.Append("\t{" + Environment.NewLine);
			BusinessObjects.Append("\t_row = _dataObject.Find_By_SQL(\"SELECT*FROM \" + _tableName + \" WHERE \" + colName + \" = \" + id, TableName);" + Environment.NewLine);//review this
			BusinessObjects.Append(Environment.NewLine);
			BusinessObjects.Append("\t\tif(_row == null)" + Environment.NewLine);
			BusinessObjects.Append("\t\t{" + Environment.NewLine);
			BusinessObjects.Append("\t\t\t_extendedErrorInformation = _dataObject.ExtendedErrorInformation;" + Environment.NewLine);
			BusinessObjects.Append("\t\t\treturn false;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t\telse" + Environment.NewLine);
			BusinessObjects.Append("\t\t\treturn true;" + Environment.NewLine);
			BusinessObjects.Append("\t\t}" + Environment.NewLine);
			BusinessObjects.Append("\t}" + Environment.NewLine);
			BusinessObjects.Append("}" + Environment.NewLine);


			return BusinessObjects.ToString();

		}

		//Code for Data Class
		private String generateDataClass()
		{
			StringBuilder dataClassCode = new StringBuilder();


			try
			{
				dataClassCode.Append("using System;" + Environment.NewLine);
				dataClassCode.Append("using System.Collections.Generic;" + Environment.NewLine);
				dataClassCode.Append("using System.Linq;" + Environment.NewLine);
				dataClassCode.Append("using System.Text;" + Environment.NewLine);
				dataClassCode.Append("using System.Threading.Tasks;" + Environment.NewLine);
				dataClassCode.Append("using System.Data.OleDb;" + Environment.NewLine);
				dataClassCode.Append("using System.Data;" + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("namespace " +txtProjectName.Text+ ".Classes" + Environment.NewLine);
				dataClassCode.Append("{" + Environment.NewLine);
				dataClassCode.Append("\tclass DataLayer" + Environment.NewLine);
				dataClassCode.Append("\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t#region Private Members" + Environment.NewLine);
				dataClassCode.Append("\t\tprivate OleDbConnection _conn;" + Environment.NewLine);
				dataClassCode.Append("\t\tprivate String _connString;" + Environment.NewLine);
				dataClassCode.Append("\t\tprivate String _extendedErrorInformation;" + Environment.NewLine);
				dataClassCode.Append("\t\t#endregion" + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("\t\t#region Constructors " + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("\t\tpublic DataLayer()" + Environment.NewLine);

				dataClassCode.Append("\t\t{" + Environment.NewLine);

				dataClassCode.Append("\t\t\t_connString = \"\";" + Environment.NewLine);
				dataClassCode.Append("\t\t\t_conn = new OleDbConnection(_connString);" + Environment.NewLine);

				dataClassCode.Append("\t\t}" + Environment.NewLine);

				dataClassCode.Append("\t\tpublic DataLayer(String connString)" + Environment.NewLine);
				dataClassCode.Append("\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t_connString = connString;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t_conn = new OleDbConnection(_connString);" + Environment.NewLine);
				dataClassCode.Append("\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t#endregion" + Environment.NewLine);
				dataClassCode.Append(Environment.NewLine);
				dataClassCode.Append("\t\t#region Properties" + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("\t\tpublic String ConnectionString" + Environment.NewLine);
				dataClassCode.Append("\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\tget" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn _connString;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tset" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_connString = value;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t" + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("\t\tpublic String ExtendedErrorInformation" + Environment.NewLine);
				dataClassCode.Append("\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\tget" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn _extendedErrorInformation;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tset" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_extendedErrorInformation = value;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t#endregion" + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("\t\t#region Public Methods" + Environment.NewLine);
				dataClassCode.Append("\t\tpublic bool ExecuteSQLStatement(String SQL)" + Environment.NewLine);
				dataClassCode.Append("\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\tOleDbCommand command = new OleDbCommand();" + Environment.NewLine);
				dataClassCode.Append("\t\t\ttry" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tcommand.Connection = _conn;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tcommand.CommandType = CommandType.Text;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tcommand.CommandText = SQL;" + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("\t\t\t\tcommand.Connection.Open();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tcommand.ExecuteNonQuery();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn true;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tcatch (Exception ex)" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tExtendedErrorInformation = ex.Message;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn false;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tfinally" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tcommand.Connection.Close();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t}" + Environment.NewLine);

				dataClassCode.Append(Environment.NewLine);

				dataClassCode.Append("\t\tpublic DataTable GetDataTable(String SQL, String TableName)" + Environment.NewLine);
				dataClassCode.Append("\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\tDataSet ds = new DataSet();" + Environment.NewLine);
				dataClassCode.Append("\t\t\tOleDbDataAdapter adapter = new OleDbDataAdapter(SQL, _conn);" + Environment.NewLine);
				dataClassCode.Append("\t\t\ttry" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_conn.Open();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tadapter.Fill(ds, TableName);" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tDataTable dt = ds.Tables[TableName];" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn dt;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tcatch (Exception ex)" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t _extendedErrorInformation = ex.Message;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn null;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tfinally" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_conn.Close();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t}" + Environment.NewLine);
				dataClassCode.Append(Environment.NewLine);
				dataClassCode.Append("\t\tpublic DataSet GetData(String SQL, String TableName)" + Environment.NewLine);
				dataClassCode.Append("\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\tDataSet ds = new DataSet();" + Environment.NewLine);
				dataClassCode.Append("\t\t\tOleDbDataAdapter adapter = new OleDbDataAdapter(SQL, _conn);" + Environment.NewLine);
				dataClassCode.Append("\t\t\ttry" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_conn.Open();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t\tadapter.Fill(ds, TableName);" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn ds;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tcatch (Exception ex)" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_extendedErrorInformation = ex.Message;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn null;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tfinally" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_conn.Close();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\tpublic DataRow Find_By_SQL(String SQL, String tableName)" + Environment.NewLine);
				dataClassCode.Append("\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\tDataRow row;" + Environment.NewLine);
				dataClassCode.Append("\t\t\ttry" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_conn.Open();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tOleDbDataAdapter adapter = new OleDbDataAdapter(SQL, _conn);" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tDataSet ds = new DataSet();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\tadapter.Fill(ds, tableName);" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\trow = ds.Tables[tableName].Rows[0];" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn row;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tcatch (Exception ex)" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_extendedErrorInformation = ex.Message;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\treturn null;" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t\tfinally" + Environment.NewLine);
				dataClassCode.Append("\t\t\t{" + Environment.NewLine);
				dataClassCode.Append("\t\t\t\t_conn.Close();" + Environment.NewLine);
				dataClassCode.Append("\t\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t}" + Environment.NewLine);
				dataClassCode.Append("\t\t#endregion" + Environment.NewLine);
				dataClassCode.Append("\t}" + Environment.NewLine);
				dataClassCode.Append("}" + Environment.NewLine);


				return dataClassCode.ToString();

			}

			catch (Exception ex)
			{
				return "";
			}



		}


		private String MainFormDesigner()
		{
			StringBuilder designerCode = new StringBuilder();
			return designerCode.ToString();

		}



        //Code for Customer Class
        private String generateCustomerClass()
        {
            StringBuilder Class = new StringBuilder();
            try
            {
                Class.AppendLine("using System;");
                Class.AppendLine("using System.Collections.Generic;");
                Class.AppendLine("using System.Data;");
                Class.AppendLine("using System.Linq;");
                Class.AppendLine("using System.Text;");
                Class.AppendLine("using System.Threading.Tasks;");
                Class.AppendLine("");
                Class.AppendLine("namespace " + txtProjectName.Text + ".Classes");
                Class.AppendLine("{");
                Class.AppendLine("\tclass Customer");
                Class.AppendLine("\t\t: BusinessObjects ");
                Class.AppendLine("\t{");
                foreach (ListViewItem litem in lvwElements.Items)
                {
                    if (litem.SubItems[1].Text == "String")
                        Class.AppendLine("\t\tprivate String _" + litem.Text + ";");
                    else
                        Class.AppendLine("\t\tprivate long _" + litem.Text + ";");

                }
                Class.AppendLine("\t\tprivate String _extendedErrorInformation;");
                Class.AppendLine("");
                Class.AppendLine("\t\tpublic Customer()");
                Class.AppendLine("\t\t\t: base()");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\tclear_fields();");
                Class.AppendLine("\t\t\tTableName = \"customers\";");
                Class.AppendLine("\t\t}");
                Class.AppendLine("");
                Class.AppendLine("\t\tpublic Customer(String connString)");
                Class.AppendLine("\t\t\t: base(connString)");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\tclear_fields();");
                Class.AppendLine("\t\t\tTableName = \"customers\";");
                Class.AppendLine("\t\t}");
                Class.AppendLine("\t\tpublic void clear_fields()");
                Class.AppendLine("\t\t{");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    if (litem.SubItems[1].Text == "String")
                        Class.AppendLine("\t\t_" + litem.Text + " = \"\";");
                    else
                        Class.AppendLine("\t\t_" + litem.Text + " = 0;");

                }

                Class.AppendLine("\t\t}");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    if (litem.SubItems[1].Text == "String")
                    {
                        Class.AppendLine("\t\tpublic String " + litem.Text);
                        Class.AppendLine("\t\t{");
                        Class.AppendLine("\t\t\tget");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\treturn _" + litem.Text + ";");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("\t\t\tset");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\t_" + litem.Text + " = value;");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("\t\t}");
                        Class.AppendLine("");

                    }
                    else
                    {
                        Class.AppendLine("\t\tpublic long " + litem.Text);
                        Class.AppendLine("\t\t{");
                        Class.AppendLine("\t\t\tget");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\treturn _" + litem.Text + ";");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("\t\t\tset");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\t_" + litem.Text + " = value;");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("\t\t}");
                        Class.AppendLine("");
                    }

                }


                Class.AppendLine("");
                Class.AppendLine("\t\tprivate void Load_Members(DataRow row)");
                Class.AppendLine("\t\t{");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    if (litem.SubItems[1].Text == "String")
                    {
                        Class.AppendLine("\t\t\ttry");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\t_" + litem.Text + " = row[\"" + litem.Text + "\"].ToString();");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("\t\t\tcatch (Exception ex)");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\t_" + litem.Text + " = \"\";");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("");
                    }
                    else
                    {
                        Class.AppendLine("\t\t\ttry");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\t_" + litem.Text + " = long.Parse(row[\"" + litem.Text + "\"].ToString());");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("\t\t\tcatch (Exception ex)");
                        Class.AppendLine("\t\t\t{");
                        Class.AppendLine("\t\t\t\t_" + litem.Text + " = 0;");
                        Class.AppendLine("\t\t\t}");
                        Class.AppendLine("");
                    }


                }


                Class.AppendLine("\t\t}");
                Class.AppendLine("\t\tpublic DataSet GetAll()");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\ttry");
                Class.AppendLine("\t\t\t{");
                Class.AppendLine("\t\t\t\tDataSet ds = GetDataSet(\"SELECT * FROM customers\");");
                Class.AppendLine("\t\t\treturn ds;");
                Class.AppendLine("\t\t\t}");
                Class.AppendLine("\t\t\tcatch (Exception ex)");
                Class.AppendLine("\t\t\t{");
                Class.AppendLine("\t\t\t\t_extendedErrorInformation = ExtendedErrorInformation;");
                Class.AppendLine("\t\t\t\treturn null;");
                Class.AppendLine("\t\t\t}");
                Class.AppendLine("\t\t}");

                Class.AppendLine("");

                Class.AppendLine("\t\tpublic DataSet FindByName(String name)");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\ttry");
                Class.AppendLine("\t\t\t{");
                Class.AppendLine("\t\t\t\tDataSet ds = GetDataSet(\"SELECT * FROM customers WHERE customer_name LIKE '\" + name + \"'\");");
                Class.AppendLine("\t\t\t\treturn ds;");
                Class.AppendLine("\t\t\t}");
                Class.AppendLine("\t\t\tcatch (Exception ex)");
                Class.AppendLine("\t\t\t{");
                Class.AppendLine("\t\t\t\t_extendedErrorInformation = ExtendedErrorInformation;");
                Class.AppendLine("\t\t\t\treturn null;");
                Class.AppendLine("\t\t\t}");
                Class.AppendLine("\t\t}");

                Class.AppendLine("");

                Class.AppendLine("\t\tpublic bool FindByID(long lNumber)");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\tString SQL = \"SELECT * FROM customers WHERE customers_id = \" + lNumber;");
                Class.AppendLine("\t\t\tDataTable _currentDataTable = GetDataTable(SQL);");
                Class.AppendLine("\t\t\tDataRow _row;");
                Class.AppendLine("\t\t\tif (_currentDataTable != null)");
                Class.AppendLine("\t\t\t{");
                Class.AppendLine("\t\t\t\t_row = _currentDataTable.Rows[0];");
                Class.AppendLine("\t\t\t\tLoad_Members(_row);");
                Class.AppendLine("\t\t\t\treturn true;");
                Class.AppendLine("\t\t\t}");
                Class.AppendLine("\t\t\telse");
                Class.AppendLine("\t\t\t{");
                Class.AppendLine("\t\t\t\treturn false;");
                Class.AppendLine("\t\t\t}");
                Class.AppendLine("\t\t}");

                Class.AppendLine("");

                Class.AppendLine("\t\tpublic bool Add()");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\tString SQL;");
                Class.AppendLine("\t\t\tSQL = \"INSERT INTO customers(\" +");
                Class.Append("\t\t\t\"");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    Class.Append(litem.Text + ", ");
                }

                Class.Length--;
                Class.Length--;

                Class.Append(") VALUES (\" +");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    Class.AppendLine("\t\t\t\t\"'\" + _" + litem.Text + " + \"', \" +");
                }


                Class.AppendLine("\t\t\t\t\"')\";");
                Class.AppendLine("\t\t\treturn ExecuteSQLStatement(SQL);");
                Class.AppendLine("\t\t}");

                Class.AppendLine("");

                Class.AppendLine("\t\tpublic bool Edit()");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\tString SQL;");
                Class.AppendLine("\t\t\tSQL = \"UPDATE customers SET \" +");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    Class.AppendLine("\t\t\t\t\"" + litem.Text + " = '\" + _" + litem.Text + " + \"', \" +");
                }

                Class.Length--; Class.Length--; Class.Length--; Class.Length--; Class.Length--; Class.Length--; Class.Length--;

                Class.AppendLine("WHERE customers_id = \" + _customerID;");

                Class.AppendLine("\t\t\treturn ExecuteSQLStatement(SQL); ");
                Class.AppendLine("\t\t}");
                Class.AppendLine("");
                Class.AppendLine("\t\tpublic bool Delete()");
                Class.AppendLine("\t\t{");
                Class.AppendLine("\t\t\tString SQL;");
                Class.AppendLine("\t\t\tSQL = \"DELETE FROM customers WHERE customers_id = \" + _customerID;");
                Class.AppendLine("\t\t\treturn ExecuteSQLStatement(SQL);");
                Class.AppendLine("\t\t}");
                Class.AppendLine("\t}");
                Class.AppendLine("}");


                return Class.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }
		//end code to create classes


		//Code to create forms
		private String generate_MainForm()
		{
			StringBuilder MainFormCode = new StringBuilder();

			try
			{
				MainFormCode.AppendLine("using System;");
				MainFormCode.AppendLine("using System.Collections.Generic;");
				MainFormCode.AppendLine("using System.ComponentModel;");
				MainFormCode.AppendLine("using System.Data;");
				MainFormCode.AppendLine("using System.Drawing;");
				MainFormCode.AppendLine("using System.Linq;");
				MainFormCode.AppendLine("using System.Text;");
				MainFormCode.AppendLine("using System.Threading.Tasks;");
				MainFormCode.AppendLine("using System.Windows.Forms;");
				MainFormCode.AppendLine("using System.Collections;");
				MainFormCode.AppendLine("using " + txtProjectName.Text + ".Classes;");
				MainFormCode.AppendLine("");
				MainFormCode.AppendLine("");
				MainFormCode.AppendLine("namespace " + txtProjectName.Text);
				MainFormCode.AppendLine("{");
				MainFormCode.AppendLine("\tpublic partial class frmMain : Form");
				MainFormCode.AppendLine("\t{");
				MainFormCode.AppendLine("\tprivate String _connString = \"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \" + Application.StartupPath + \"\\" + "\\" + "datCustomers.accdb; Persist Security Info = False\";");
				MainFormCode.AppendLine("\tprivate Customer _customer;");
				MainFormCode.AppendLine("\t\t");
				MainFormCode.AppendLine("\t\tpublic frmMain()");
				MainFormCode.AppendLine("\t\t{");
				MainFormCode.AppendLine("\t\t\tInitializeComponent();");
				MainFormCode.AppendLine("\t\t\t__customer = new Customer(_connString);");
				MainFormCode.AppendLine("\t\t\t");
				MainFormCode.AppendLine("\t\t\tsetupCustomer(ref grdCustomers);");
				MainFormCode.AppendLine("\t\t\tload_customer_data();");
				MainFormCode.AppendLine("\t\t}");
				MainFormCode.AppendLine("\t\t");
				MainFormCode.AppendLine("\t\tprivate void load_customer_data()");
				MainFormCode.AppendLine("\t\t{");
				MainFormCode.AppendLine("\t\t\tgrdCustomers.DataSource = _customer.GetAll();");
				MainFormCode.AppendLine("\t\t\tgrdCustomers.DataMember = _customer.TableName;");
				MainFormCode.AppendLine("\t\t}");
				MainFormCode.AppendLine("\t\t");
				MainFormCode.AppendLine("\t\tprivate void btnExit_Click(object sender, EventArgs e)");
				MainFormCode.AppendLine("\t\t{");
				MainFormCode.AppendLine("\t\t\tApplication.Exit();");
				MainFormCode.AppendLine("\t\t}");
				MainFormCode.AppendLine("\t\t");
				MainFormCode.AppendLine("\t\tprivate void setupGridCustomers(ref DataGridView grid)");
				MainFormCode.AppendLine("\t\t{");
				MainFormCode.AppendLine("\t\t\tArrayList columns = new ArrayList();");
				MainFormCode.AppendLine("\t\t\ttry");
				MainFormCode.AppendLine("\t\t\t{");
				MainFormCode.AppendLine("\t\t\t\tDataGridViewTextBoxColumn columnName = new DataGridViewTextBoxColumn();");
				foreach (ListViewItem litem in lvwElements.Items)
				{
					if (litem.SubItems[1].Text == "String")
					{
						MainFormCode.AppendLine("\t\t\t\t columnName.DataPropertyName = \"" + litem.SubItems[1].Text + "\";");
						MainFormCode.AppendLine("\t\t\t\tcolumnName.HeaderText = \"" + litem.SubItems[1].Text + "\";");
						MainFormCode.AppendLine("\t\t\t\t//forenameColumn.ValueType = typeof(string);");
						MainFormCode.AppendLine("\t\t\t\t//forenameColumn.Frozen = true;");
						MainFormCode.AppendLine("\t\t\t\tcolumnName.Width = 100;");
						MainFormCode.AppendLine("\t\t\t\tcolumns.Add(columnName);");
					}
					else
					{
						MainFormCode.AppendLine("\t\t\t\t columnName.DataPropertyName = \"" + litem.SubItems[1].Text + "\";");
						MainFormCode.AppendLine("\t\t\t\tcolumnName.HeaderText = \"" + litem.SubItems[1].Text + "\";");
						MainFormCode.AppendLine("\t\t\t\t//forenameColumn.ValueType = typeof(int);");
						MainFormCode.AppendLine("\t\t\t\t//forenameColumn.Frozen = true;");
						MainFormCode.AppendLine("\t\t\t\tcolumnName.Width = 100;");
						MainFormCode.AppendLine("\t\t\t\tcolumns.Add(columnName);");
					}
				}

				MainFormCode.AppendLine("\t\t\t\t");
				MainFormCode.AppendLine("\t\t\t\t//Add Columns to datagridview");
				MainFormCode.AppendLine("\t\t\t\tfor (int index = 0; index < columns.Count; index++)");
				MainFormCode.AppendLine("\t\t\t\t\tgrid.Columns.Add((DataGridViewTextBoxColumn)columns[index]);");
				MainFormCode.AppendLine("\t\t\t\t//Format coloring scheme");
				MainFormCode.AppendLine("\t\t\t\tgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;");
				MainFormCode.AppendLine("\t\t\t\tgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;");
				MainFormCode.AppendLine("\t\t\t\tgrid.RowHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;");
				MainFormCode.AppendLine("\t\t\t\tgrid.RowHeadersDefaultCellStyle.ForeColor = Color.Black;");
				MainFormCode.AppendLine("\t\t\t\tgrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;");
				MainFormCode.AppendLine("\t\t\t\t");
				MainFormCode.AppendLine("\t\t\t\t //Make sure these are set to false so that the formatting will work.");
				MainFormCode.AppendLine("\t\t\t\tgrid.AutoGenerateColumns = false;");
				MainFormCode.AppendLine("\t\t\t\tgrid.EnableHeadersVisualStyles = false;");
				MainFormCode.AppendLine("\t\t\t\tgrid.AllowUserToAddRows = false;");
				MainFormCode.AppendLine("\t\t\t\tgrid.AllowUserToDeleteRows = false;");
				MainFormCode.AppendLine("\t\t\t\tgrid.AllowUserToResizeRows = false;");
				MainFormCode.AppendLine("\t\t\t\tgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;");
				MainFormCode.AppendLine("\t\t\t}");
				MainFormCode.AppendLine("\t\t\tcatch (Exception ex)");
				MainFormCode.AppendLine("\t\t\t{");
				MainFormCode.AppendLine("\t\t\t\tConsole.WriteLine(ex.Message);");
				MainFormCode.AppendLine("\t\t\t}");
				MainFormCode.AppendLine("\t\t}");

				MainFormCode.AppendLine("\t\tprivate void btnAddCustomer_Click(object sender, EventArgs e)");
				MainFormCode.AppendLine("\t\t{");
				MainFormCode.AppendLine("\t\t\tfrmAddEdit addCust = new frmAddEdit(true, 0, _connString);");
				MainFormCode.AppendLine("\t\t\taddCust.ShowDialog();");
				MainFormCode.AppendLine("\t\t\t");
				MainFormCode.AppendLine("\t\t\tif(addCust.WasCancelled == false)");
				MainFormCode.AppendLine("\t\t\t load_customer_data();");
				MainFormCode.AppendLine("\t\t}");
				MainFormCode.AppendLine("\t\t\t");
				MainFormCode.AppendLine("\t\tprivate void btnEditCustomer_Click(object sender, EventArgs e)");
				MainFormCode.AppendLine("\t\t{");
				MainFormCode.AppendLine("\t\t\ttry");
				MainFormCode.AppendLine("\t\t\t{");
				MainFormCode.AppendLine("\t\t\t\tDataGridViewRow row = grdCustomers.SelectedRows[0];");
				MainFormCode.AppendLine("\t\t\t\tlong tempID = long.Parse(row.Cells[0].Value.ToString());");
				MainFormCode.AppendLine("\t\t\t\t");
				MainFormCode.AppendLine("\t\t\t\tfrmAddEdit editCust = new frmAddEdit(false, tempID, _connString);");
				MainFormCode.AppendLine("\t\t\t\teditCust.ShowDialog();");
				MainFormCode.AppendLine("\t\t\t\t");
				MainFormCode.AppendLine("\t\t\t\tif(editCust.WasCancelled == false)");
				MainFormCode.AppendLine("\t\t\t\tload_customer_data();");
				MainFormCode.AppendLine("\t\t\t}");
				MainFormCode.AppendLine("\t\t\tcatch (Exception ex)");
				MainFormCode.AppendLine("\t\t\t{");
				MainFormCode.AppendLine("\t\t\t\tMessageBox.Show(ex.Message);");
				MainFormCode.AppendLine("\t\t\t}");
				MainFormCode.AppendLine("\t\t}");
				MainFormCode.AppendLine("\t\t");
				MainFormCode.AppendLine("\t\t");
				MainFormCode.AppendLine("\t\tprivate void btnDeleteCustomer_Click(object sender, EventArgs e)");
				MainFormCode.AppendLine("\t\t{");
				MainFormCode.AppendLine("\t\t\ttry");
				MainFormCode.AppendLine("\t\t\t{");
				MainFormCode.AppendLine("\t\t\t\tDialogResult result;");
				MainFormCode.AppendLine("\t\t\t\tDataGridViewRow row = grdCustomers.SelectedRows[0];");
				MainFormCode.AppendLine("\t\t\t\tlong tempID = long.Parse(row.Cells[0].Value.ToString());");
				MainFormCode.AppendLine("\t\t\t\tresult = MessageBox.Show(\"Are you sure you want to delete the selected item ? \", \"Confirm\", MessageBoxButtons.YesNo);");
				MainFormCode.AppendLine("\t\t\t\t");
				MainFormCode.AppendLine("\t\t\t\tif(result == DialogResult.Yes)");
				MainFormCode.AppendLine("\t\t\t\t{");
				MainFormCode.AppendLine("\t\t\t\t\t__customer.FindByID(tempID);");
				MainFormCode.AppendLine("\t\t\t\t\t__customer.Delete();");
				MainFormCode.AppendLine("\t\t\t\t\tload_customer_data();");
				MainFormCode.AppendLine("\t\t\t\t}");
				MainFormCode.AppendLine("\t\t\t}");
				MainFormCode.AppendLine("\t\t\tcatch (Exception ex)");
				MainFormCode.AppendLine("\t\t\t{");
				MainFormCode.AppendLine("\t\t\t\tMessageBox.Show(ex.Message);");
				MainFormCode.AppendLine("\t\t\t}");
				MainFormCode.AppendLine("\t\t}");
				MainFormCode.AppendLine("\t}");
				MainFormCode.AppendLine("}");


				return MainFormCode.ToString();

			}
			catch (Exception ex)
			{
				return "";
			}
		}




		private String create_AddEditDesigner()
        {
            StringBuilder AddEditDesigner = new StringBuilder();
            try
            {
                AddEditDesigner.AppendLine("namespace " + txtProjectName.Text);
                AddEditDesigner.AppendLine("{");
                AddEditDesigner.AppendLine("\tpartial class frmAddEdit");
                AddEditDesigner.AppendLine("\t{");
                AddEditDesigner.AppendLine("\t\tprivate System.ComponentModel.IContainer components = null;");
                AddEditDesigner.AppendLine("\t\tprotected override void Dispose(bool disposing)");
                AddEditDesigner.AppendLine("\t\t{");
                AddEditDesigner.AppendLine("\t\t\tif (disposing && (components != null))");
                AddEditDesigner.AppendLine("\t\t\t{");
                AddEditDesigner.AppendLine("\t\t\t\tcomponents.Dispose();");
                AddEditDesigner.AppendLine("\t\t\t}");
                AddEditDesigner.AppendLine("\t\t\tbase.Dispose(disposing);");
                AddEditDesigner.AppendLine("\t}");
                AddEditDesigner.AppendLine("");
                AddEditDesigner.AppendLine("\t#region Windows Form Designer generated code");
                AddEditDesigner.AppendLine("");
                AddEditDesigner.AppendLine("\tprivate void InitializeComponent()");
                AddEditDesigner.AppendLine("\t{");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    AddEditDesigner.AppendLine("\t\tthis.lbl" + litem.Text + " = new System.Windows.Forms.Label();");
                    AddEditDesigner.AppendLine("\t\tthis.txt" + litem.Text + " = new System.Windows.Forms.TextBox();");
                }

                AddEditDesigner.AppendLine("\t\tthis.btnCancel = new System.Windows.Forms.Button();");
                AddEditDesigner.AppendLine("\t\tthis.btnSave = new System.Windows.Forms.Button();");
                AddEditDesigner.AppendLine("\t\tthis.SuspendLayout();");
				int count = 1;
				foreach (ListViewItem litem in lvwElements.Items)
                {
						int lbllocation = count * 17;
						int txtlocation = count * 26;
						AddEditDesigner.AppendLine("\t\t//lbl" + litem.Text);
						AddEditDesigner.AppendLine("\t\tthis.lbl" + litem.Text + ".AutoSize = true;");
						AddEditDesigner.AppendLine("\t\tthis.lbl" + litem.Text + ".Location = new System.Drawing.Point(14, " + lbllocation + ");");
						AddEditDesigner.AppendLine("\t\tthis.lbl" + litem.Text + ".Name = \"lbl" + litem.Text + "\";");
						AddEditDesigner.AppendLine("\t\tthis.lbl" + litem.Text + ".Size = new System.Drawing.Size(85, 13);");
						AddEditDesigner.AppendLine("\t\tthis.lbl" + litem.Text + ".Text = \"" + litem.Text + ":\";");

						AddEditDesigner.AppendLine("\t\t//txt" + litem.Text);
						AddEditDesigner.AppendLine("\t\tthis.txt" + litem.Text + ".Location = new System.Drawing.Point(117, " + txtlocation + ");");
						AddEditDesigner.AppendLine("\t\tthis.txt" + litem.Text + ".Name = \"txt" + litem.Text + "\";");
						AddEditDesigner.AppendLine("\t\tthis.txt" + litem.Text + ".Size = new System.Drawing.Size(255, 29);");
						AddEditDesigner.AppendLine("\t\tthis.txt" + litem.Text + ".Text = \"" + litem.Text + ":\";");
					count += count;
                }

                AddEditDesigner.AppendLine("\t\t//btnCancel");
                AddEditDesigner.AppendLine("\t\tthis.btnCancel.Location = new System.Drawing.Point(200, 182);");
                AddEditDesigner.AppendLine("\t\tthis.btnCancel.Name = \"btnCancel\";");
                AddEditDesigner.AppendLine("\t\tthis.btnCancel.Size = new System.Drawing.Size(73, 33);");
                AddEditDesigner.AppendLine("\t\tthis.btnCancel.Text = \"Cancel\";");
                AddEditDesigner.AppendLine("\t\tthis.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);");
                AddEditDesigner.AppendLine("\t\t//btnSave");
                AddEditDesigner.AppendLine("\t\tthis.btnSave.Location = new System.Drawing.Point(121, 182);");
                AddEditDesigner.AppendLine("\t\tthis.btnSave.Name = \"btnSave\";");
                AddEditDesigner.AppendLine("\t\tthis.btnSave.Size = new System.Drawing.Size(73, 33);");
                AddEditDesigner.AppendLine("\t\tthis.btnSave.Text = \"Save\";");
                AddEditDesigner.AppendLine("\t\tthis.btnSave.Click += new System.EventHandler(this.btnSave_Click);");
                AddEditDesigner.AppendLine("\t\t//frmAddEdit");
                AddEditDesigner.AppendLine("\t\tthis.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);");
                AddEditDesigner.AppendLine("\t\tthis.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
                AddEditDesigner.AppendLine("\t\tthis.ClientSize = new System.Drawing.Size(393, 226);");
                AddEditDesigner.AppendLine("\t\tthis.Controls.Add(this.btnCancel);");
                AddEditDesigner.AppendLine("\t\tthis.Controls.Add(this.btnSave);");
                foreach (ListViewItem litem in lvwElements.Items)
                {
                    AddEditDesigner.AppendLine("\t\tthis.Controls.Add(this.txt" + litem.Text + ");");
                    AddEditDesigner.AppendLine("\t\tthis.Controls.Add(this.lbl" + litem.Text + ");");
                }
                AddEditDesigner.AppendLine("\t\tthis.Margin = new System.Windows.Forms.Padding(2);");
                AddEditDesigner.AppendLine("\t\tthis.Name = \"frmAddEdit\";");
                AddEditDesigner.AppendLine("\t\tthis.Text = \"Add / Edit Customers\";");
                AddEditDesigner.AppendLine("\t\tthis.ResumeLayout(false);");
                AddEditDesigner.AppendLine("\t\tthis.PerformLayout();");
                AddEditDesigner.AppendLine("\t\t}");
                AddEditDesigner.AppendLine("\t\t#endregion");
                AddEditDesigner.AppendLine("");
                AddEditDesigner.AppendLine("\t\tprivate System.Windows.Forms.Button btnCancel;");
                AddEditDesigner.AppendLine("\t\tprivate System.Windows.Forms.Button btnSave;");
                foreach (ListViewItem litem in lvwElements.Items)
                {
                    AddEditDesigner.AppendLine("\t\tprivate System.Windows.Forms.Label lbl" + litem.Text + ";");
                    AddEditDesigner.AppendLine("\t\tprivate System.Windows.Forms.Label txt" + litem.Text + ";");

                }
                AddEditDesigner.AppendLine("\t}");
                AddEditDesigner.AppendLine("}");


                return AddEditDesigner.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        private String create_AddEdit()
        {
            StringBuilder AddEdit = new StringBuilder();
            try
            {
                AddEdit.AppendLine("using System;");
                AddEdit.AppendLine("using System.Collections.Generic;");
                AddEdit.AppendLine("using System.ComponentModel;");
                AddEdit.AppendLine("using System.Data;");
                AddEdit.AppendLine("using System.Drawing;");
                AddEdit.AppendLine("using System.Linq;");
                AddEdit.AppendLine("using System.Text;");
                AddEdit.AppendLine("using System.Threading.Tasks;");
                AddEdit.AppendLine("using System.Windows.Forms;");
                AddEdit.AppendLine("using " + txtProjectName.Text + ".Classes;");

                AddEdit.AppendLine("");

                AddEdit.AppendLine("namespace " + txtProjectName.Text);
                AddEdit.AppendLine("{");
                AddEdit.AppendLine("\t");
                AddEdit.AppendLine("\tpublic partial class frmAddEdit : Form");
                AddEdit.AppendLine("\t{");
                AddEdit.AppendLine("\t\tprivate bool _isNew;");
                AddEdit.AppendLine("\t\tprivate bool _wasCancelled;");
                AddEdit.AppendLine("");
                AddEdit.AppendLine("\t\tCustomer _customers;");

                AddEdit.AppendLine("");

                AddEdit.AppendLine("\t\tpublic frmAddEdit(bool isNew, long custID, String connString)");
                AddEdit.AppendLine("\t\t{");
                AddEdit.AppendLine("\t\t\tInitializeComponent();");
                AddEdit.AppendLine("\t\t\t_customers = new Customer(connString);");
                AddEdit.AppendLine("\t\t\t_isNew = isNew;");
                AddEdit.AppendLine("\t\t\t_wasCancelled = false;");
                AddEdit.AppendLine("");
                AddEdit.AppendLine("\t\t\tif (_isNew)");
                AddEdit.AppendLine("\t\t\t\tclear_fields();");
                AddEdit.AppendLine("\t\t\telse");
                AddEdit.AppendLine("\t\t\t{");
                AddEdit.AppendLine("\t\t\t\t_customers.FindByID(custID);");
                AddEdit.AppendLine("\t\t\t\tload_fields();");
                AddEdit.AppendLine("\t\t\t}");
                AddEdit.AppendLine("\t\t}");
                AddEdit.AppendLine("\t\tpublic bool WasCancelled");
                AddEdit.AppendLine("\t\t{");
                AddEdit.AppendLine("\t\t\tget");
                AddEdit.AppendLine("\t\t\t{");
                AddEdit.AppendLine("\t\t\t\treturn _wasCancelled;");
                AddEdit.AppendLine("\t\t\t}");
                AddEdit.AppendLine("\t\t}");
                AddEdit.AppendLine("\t\tprivate void load_fields()");
                AddEdit.AppendLine("\t\t{");
                AddEdit.AppendLine("\t\t\ttry");
                AddEdit.AppendLine("\t\t\t{");

                foreach (ListViewItem litem in lvwElements.Items)
                {
					if(litem.Text == "String")
                   AddEdit.AppendLine("\t\t\t\t\ttxt" + litem.Text + ".Text = _customers." + litem.Text + ";");
					else
					AddEdit.AppendLine("\t\t\t\t\ttxt" + litem.Text + ".Text = _customers." + litem.Text + ".ToString();");
				}

                AddEdit.AppendLine("\t\t\t}");
                AddEdit.AppendLine("\t\t\tcatch(Exception ex)");
                AddEdit.AppendLine("\t\t\t{");
                AddEdit.AppendLine("\t\t\t\tbtnSave.Enabled = false;");
                AddEdit.AppendLine("\t\t\t\tMessageBox.Show(ex.Message);");
                AddEdit.AppendLine("\t\t\t}");
                AddEdit.AppendLine("\t\t}");
                AddEdit.AppendLine("\t\tprivate void save_fields()");
                AddEdit.AppendLine("\t\t{");

                foreach (ListViewItem litem in lvwElements.Items)
                {
					if(litem.Text == "String")
                    AddEdit.AppendLine("\t\t\t_customers." + litem.Text + " = " + "txt" + litem.Text + ".Text;");
					else
					 AddEdit.AppendLine("\t\t\t_customers." + litem.Text + " = " + "Convert.ToInt32(txt" + litem.Text + ".Text;)");
				}

                AddEdit.AppendLine("\t\t}");
                AddEdit.AppendLine("");
                AddEdit.AppendLine("\t\tprivate void clear_fields()");
                AddEdit.AppendLine("\t\t{");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    AddEdit.AppendLine("\t\t\t\ttxt" + litem.Text + ".Text = \"\";");
                }

                AddEdit.AppendLine("\t\t}");
                AddEdit.AppendLine("");
                AddEdit.AppendLine("\t\tprivate void btnCancel_Click(object sender, EventArgs e)");
                AddEdit.AppendLine("\t\t{");
                AddEdit.AppendLine("\t\t\t_wasCancelled = true;");
                AddEdit.AppendLine("\t\t\tthis.Close();");
                AddEdit.AppendLine("\t\t}");
                AddEdit.AppendLine("\t\t\tprivate void btnSave_Click(object sender, EventArgs e)");
                AddEdit.AppendLine("\t\t\t{");
                AddEdit.AppendLine("\t\t\tsave_fields();");
                AddEdit.AppendLine("\t\t\tif (_isNew)");
                AddEdit.AppendLine("\t\t\t\t_customers.Add();");
                AddEdit.AppendLine("\t\t\telse");
                AddEdit.AppendLine("\t\t\t\t_customers.Edit();");
                AddEdit.AppendLine("\t\t\tthis.Close();");
                AddEdit.AppendLine("\t\t}");

                foreach (ListViewItem litem in lvwElements.Items)
                {
                    AddEdit.AppendLine("\t\tprivate void txt" + litem.Text + "_KeyPress(object sender, KeyPressEventArgs e)");
                    AddEdit.AppendLine("\t\t{");
                    AddEdit.AppendLine("\t\t\tif ((Keys)e.KeyChar == Keys.Enter)");
                    AddEdit.AppendLine("\t\t\t{");
                    AddEdit.AppendLine("\t\t\t\te.Handled = true;");
                    AddEdit.AppendLine("\t\t\ttxt" + litem.Text + ".Focus();");
                    AddEdit.AppendLine("\t\t\t}");
                    AddEdit.AppendLine("\t\t}");
                    AddEdit.AppendLine("");
                }



                AddEdit.AppendLine("\t\t}");
                AddEdit.AppendLine("\t}");






                return AddEdit.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }



        private String generateMainFormDesigner()
        {
            StringBuilder DesignerCode = new StringBuilder();
            try
            {
                DesignerCode.AppendLine("namespace" + txtProjectName.Text);
                DesignerCode.AppendLine("{");
                DesignerCode.AppendLine("\tpartial class frmMain");
                DesignerCode.AppendLine("\t{");
                DesignerCode.AppendLine("\t\t// Required designer variable.");
                DesignerCode.AppendLine("\t\tprivate System.ComponentModel.IContainer components = null;");
                DesignerCode.AppendLine("\t\t// Clean up any resources being used.");
                DesignerCode.AppendLine("\t\t// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>");
                DesignerCode.AppendLine("\t\tprotected override void Dispose(bool disposing)");
                DesignerCode.AppendLine("\t\t{");
                DesignerCode.AppendLine("\t\t\tif (disposing && (components != null))");
                DesignerCode.AppendLine("\t\t\t{");
                DesignerCode.AppendLine("\t\t\t\tcomponents.Dispose();");
                DesignerCode.AppendLine("\t\t\t}");
                DesignerCode.AppendLine("\t\t\tbase.Dispose(disposing);");
                DesignerCode.AppendLine("\t\t}");
                DesignerCode.AppendLine("\t\t#region Windows Form Designer generated code");
                DesignerCode.AppendLine("\t\t// Required method for Designer support - do not modify");
                DesignerCode.AppendLine("\t\t// the contents of this method with the code editor.");
                DesignerCode.AppendLine("\t\t");
                DesignerCode.AppendLine("\t\tprivate void InitializeComponent()");
                DesignerCode.AppendLine("\t\t{");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers = new System.Windows.Forms.DataGridView();");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer = new System.Windows.Forms.Button();");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer = new System.Windows.Forms.Button();");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer = new System.Windows.Forms.Button();");
                DesignerCode.AppendLine("\t\t\tthis.btnExit = new System.Windows.Forms.Button();");
                DesignerCode.AppendLine("\t\t\t((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();");
                DesignerCode.AppendLine("\t\t\tthis.SuspendLayout();");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\t// grdCustomers");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)");
                DesignerCode.AppendLine("\t\t\t| System.Windows.Forms.AnchorStyles.Left)");
                DesignerCode.AppendLine("\t\t\t| System.Windows.Forms.AnchorStyles.Right)));");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers.Location = new System.Drawing.Point(13, 13);");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers.Margin = new System.Windows.Forms.Padding(4);");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers.Name = \"grdCustomers\";");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers.Size = new System.Drawing.Size(817, 341);");
                DesignerCode.AppendLine("\t\t\tthis.grdCustomers.TabIndex = 58;");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\t// btnDeleteCustomer");
                DesignerCode.AppendLine("\t\t\t// ");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.Location = new System.Drawing.Point(689, 362);");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.Margin = new System.Windows.Forms.Padding(4);");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.Name = \"btnDeleteCustomer\";");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.Size = new System.Drawing.Size(141, 47);");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.TabIndex = 61;");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.Text = \"Delete\";");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.UseVisualStyleBackColor = true;");
                DesignerCode.AppendLine("\t\t\tthis.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\t// btnAddCustomer");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.Location = new System.Drawing.Point(391, 362);");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4);");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.Name = \"btnAddCustomer\";");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.Size = new System.Drawing.Size(141, 47);");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.TabIndex = 59;");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.Text = \"Add\";");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.UseVisualStyleBackColor = true;");
                DesignerCode.AppendLine("\t\t\tthis.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\t// btnEditCustomer");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.Location = new System.Drawing.Point(540, 362);");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.Margin = new System.Windows.Forms.Padding(4);");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.Name = \"btnEditCustomer\";");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.Size = new System.Drawing.Size(141, 47);");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.TabIndex = 60;");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.Text = \"Edit\";");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.UseVisualStyleBackColor = true;");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.UseVisualStyleBackColor = true;");
                DesignerCode.AppendLine("\t\t\tthis.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);");
                DesignerCode.AppendLine("\t\t\t// ");
                DesignerCode.AppendLine("\t\t\t// btnExit");
                DesignerCode.AppendLine("\t\t\t// ");
                DesignerCode.AppendLine("\t\t\t this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.Location = new System.Drawing.Point(329, 430);");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.Margin = new System.Windows.Forms.Padding(4);");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.Name = \"btnExit\";");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.Size = new System.Drawing.Size(184, 55);");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.TabIndex = 62;");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.Text = \"Exit\";");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.UseVisualStyleBackColor = true;");
                DesignerCode.AppendLine("\t\t\tthis.btnExit.Click += new System.EventHandler(this.btnExit_Click);");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\t// frmMain");
                DesignerCode.AppendLine("\t\t\t//");
                DesignerCode.AppendLine("\t\t\tthis.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);");
                DesignerCode.AppendLine("\t\t\tthis.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
                DesignerCode.AppendLine("\t\t\tthis.ClientSize = new System.Drawing.Size(843, 498);");
                DesignerCode.AppendLine("\t\t\tthis.Controls.Add(this.btnExit);");
                DesignerCode.AppendLine("\t\t\tthis.Controls.Add(this.btnDeleteCustomer);");
                DesignerCode.AppendLine("\t\t\tthis.Controls.Add(this.btnAddCustomer);");
                DesignerCode.AppendLine("\t\t\tthis.Controls.Add(this.btnEditCustomer);");
                DesignerCode.AppendLine("\t\t\tthis.Controls.Add(this.grdCustomers);");
                DesignerCode.AppendLine("\t\t\tthis.Name = \"frmMain\";");
                DesignerCode.AppendLine("\t\t\tthis.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;");
                DesignerCode.AppendLine("\t\t\tthis.Text = \"Customer Management\";");
                DesignerCode.AppendLine("\t\t\t((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();");
                DesignerCode.AppendLine("\t\t\tthis.ResumeLayout(false);");
                DesignerCode.AppendLine("\t\t");
                DesignerCode.AppendLine("\t\t}");
                DesignerCode.AppendLine("\t\t#endregion");
                DesignerCode.AppendLine("\t\t");
                DesignerCode.AppendLine("\t\tprivate System.Windows.Forms.DataGridView grdCustomers;");
                DesignerCode.AppendLine("\t\tprivate System.Windows.Forms.Button btnDeleteCustomer;");
                DesignerCode.AppendLine("\t\tprivate System.Windows.Forms.Button btnAddCustomer;");
                DesignerCode.AppendLine("\t\tprivate System.Windows.Forms.Button btnEditCustomer;");
                DesignerCode.AppendLine("\t\tprivate System.Windows.Forms.Button btnExit;");
                DesignerCode.AppendLine("\t}");
                DesignerCode.AppendLine("}");
              

                return DesignerCode.ToString();
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        private String generateMainResX()
        {
            StringBuilder ResXCode = new StringBuilder();
            try
            {

                ResXCode.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\"?>");
                ResXCode.AppendLine("<root>");

                ResXCode.AppendLine("\t<xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">");
                ResXCode.AppendLine("\t<xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />");
                ResXCode.AppendLine("\t<xsd:element name=\"root\" msdata:IsDataSet=\"true\">");
                ResXCode.AppendLine("\t<xsd:complexType>");
                ResXCode.AppendLine("\t<xsd:choice maxOccurs=\"unbounded\">");
                ResXCode.AppendLine("\t<xsd:element name=\"metadata\">");
                ResXCode.AppendLine("\t<xsd:complexType>");
                ResXCode.AppendLine("\t<xsd:sequence>");
                ResXCode.AppendLine("\t<xsd:element name=\"value\" type=\"xsd: string\" minOccurs=\"0\" />");
                ResXCode.AppendLine("\t</xsd:sequence>");
                ResXCode.AppendLine("\t<xsd:attribute name=\"name\" use=\"required\" type=\"xsd: string\" />");
                ResXCode.AppendLine("\t<xsd:attribute name=\"type\" type=\"xsd: string\" />");
                ResXCode.AppendLine("\t<xsd:attribute name=\"mimetype\" type=\"xsd: string\" />");
                ResXCode.AppendLine("\t<xsd:attribute ref=\"xml: space\" />");
                ResXCode.AppendLine("\t</xsd:complexType>");
                ResXCode.AppendLine("\t</xsd:element>");
                ResXCode.AppendLine("\t<xsd:element name=\"assembly\">");
                ResXCode.AppendLine("\t<xsd:complexType>");
                ResXCode.AppendLine("\t<xsd:attribute name=\"alias\" type=\"xsd: string\" />");
                ResXCode.AppendLine("\t<xsd:attribute name=\"name\" type=\"xsd: string\" />");
                ResXCode.AppendLine("\t</xsd:complexType>");
                ResXCode.AppendLine("\t</xsd:element>");
                ResXCode.AppendLine("\t<xsd:element name=\"data\">");
                ResXCode.AppendLine("\t<xsd:complexType>");
                ResXCode.AppendLine("\t<xsd:sequence>");
                ResXCode.AppendLine("\t<xsd:element name=\"value\" type=\"xsd: string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
                ResXCode.AppendLine("\t<xsd:element name=\"comment\" type=\"xsd: string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />");
                ResXCode.AppendLine("\t</xsd:sequence>");
                ResXCode.AppendLine("\t<xsd:attribute name=\"name\" type=\"xsd: string\" use=\"required\" msdata:Ordinal=\"1\" />");
                ResXCode.AppendLine("\t<xsd:attribute name=\"type\" type=\"xsd: string\" msdata:Ordinal=\"3\" />");
                ResXCode.AppendLine("\t<xsd:attribute name=\"mimetype\" type=\"xsd: string\" msdata:Ordinal=\"4\" />");
                ResXCode.AppendLine("\t<xsd:attribute ref=\"xml: space\" />");
                ResXCode.AppendLine("\t</xsd:complexType>");
                ResXCode.AppendLine("\t</xsd:element>");
                ResXCode.AppendLine("\t<xsd:element name=\"resheader\">");
                ResXCode.AppendLine("\t<xsd:complexType>");
                ResXCode.AppendLine("\t<xsd:sequence>");
                ResXCode.AppendLine("\t<xsd:element name=\value\" type=\"xsd: string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
                ResXCode.AppendLine("\t</xsd:sequence>");
                ResXCode.AppendLine("\t<xsd:attribute name=\"name\" type=\"xsd: string\" use=\"required\" />");
                ResXCode.AppendLine("\t</xsd:complexType>");
                ResXCode.AppendLine("\t</xsd:element>");
                ResXCode.AppendLine("\t</xsd:choice>");
                ResXCode.AppendLine("\t</xsd:complexType>");
                ResXCode.AppendLine("\t</xsd:element>");
                ResXCode.AppendLine("\t</xsd:schema>");
                ResXCode.AppendLine("\t<resheader name=\"resmimetype\">");
                ResXCode.AppendLine("\t<value>text/microsoft-resx</value>");
                ResXCode.AppendLine("\t</resheader>");
                ResXCode.AppendLine("\t<resheader name=\"version\">");
                ResXCode.AppendLine("\t<value>2.0</value>");
                ResXCode.AppendLine("\t</resheader>");
                ResXCode.AppendLine("\t<resheader name=\"reader\">");
                ResXCode.AppendLine("\t<value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
                ResXCode.AppendLine("\t</resheader>");
                ResXCode.AppendLine("\t<resheader name=\"writer\">");
                ResXCode.AppendLine("\t<value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
                ResXCode.AppendLine("\t</resheader>");
                ResXCode.AppendLine("\t</root>");
                
                return ResXCode.ToString();
            }
            catch(Exception ex)
            {
                return "";
            }
        }
		private String generateAddEditResX()
		{
			StringBuilder ResXCode = new StringBuilder();
			try
			{

				ResXCode.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\"?>");
				ResXCode.AppendLine("<root>");

				ResXCode.AppendLine("\t<xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">");
				ResXCode.AppendLine("\t<xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />");
				ResXCode.AppendLine("\t<xsd:element name=\"root\" msdata:IsDataSet=\"true\">");
				ResXCode.AppendLine("\t<xsd:complexType>");
				ResXCode.AppendLine("\t<xsd:choice maxOccurs=\"unbounded\">");
				ResXCode.AppendLine("\t<xsd:element name=\"metadata\">");
				ResXCode.AppendLine("\t<xsd:complexType>");
				ResXCode.AppendLine("\t<xsd:sequence>");
				ResXCode.AppendLine("\t<xsd:element name=\"value\" type=\"xsd: string\" minOccurs=\"0\" />");
				ResXCode.AppendLine("\t</xsd:sequence>");
				ResXCode.AppendLine("\t<xsd:attribute name=\"name\" use=\"required\" type=\"xsd: string\" />");
				ResXCode.AppendLine("\t<xsd:attribute name=\"type\" type=\"xsd: string\" />");
				ResXCode.AppendLine("\t<xsd:attribute name=\"mimetype\" type=\"xsd: string\" />");
				ResXCode.AppendLine("\t<xsd:attribute ref=\"xml: space\" />");
				ResXCode.AppendLine("\t</xsd:complexType>");
				ResXCode.AppendLine("\t</xsd:element>");
				ResXCode.AppendLine("\t<xsd:element name=\"assembly\">");
				ResXCode.AppendLine("\t<xsd:complexType>");
				ResXCode.AppendLine("\t<xsd:attribute name=\"alias\" type=\"xsd: string\" />");
				ResXCode.AppendLine("\t<xsd:attribute name=\"name\" type=\"xsd: string\" />");
				ResXCode.AppendLine("\t</xsd:complexType>");
				ResXCode.AppendLine("\t</xsd:element>");
				ResXCode.AppendLine("\t<xsd:element name=\"data\">");
				ResXCode.AppendLine("\t<xsd:complexType>");
				ResXCode.AppendLine("\t<xsd:sequence>");
				ResXCode.AppendLine("\t<xsd:element name=\"value\" type=\"xsd: string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
				ResXCode.AppendLine("\t<xsd:element name=\"comment\" type=\"xsd: string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />");
				ResXCode.AppendLine("\t</xsd:sequence>");
				ResXCode.AppendLine("\t<xsd:attribute name=\"name\" type=\"xsd: string\" use=\"required\" msdata:Ordinal=\"1\" />");
				ResXCode.AppendLine("\t<xsd:attribute name=\"type\" type=\"xsd: string\" msdata:Ordinal=\"3\" />");
				ResXCode.AppendLine("\t<xsd:attribute name=\"mimetype\" type=\"xsd: string\" msdata:Ordinal=\"4\" />");
				ResXCode.AppendLine("\t<xsd:attribute ref=\"xml: space\" />");
				ResXCode.AppendLine("\t</xsd:complexType>");
				ResXCode.AppendLine("\t</xsd:element>");
				ResXCode.AppendLine("\t<xsd:element name=\"resheader\">");
				ResXCode.AppendLine("\t<xsd:complexType>");
				ResXCode.AppendLine("\t<xsd:sequence>");
				ResXCode.AppendLine("\t<xsd:element name=\value\" type=\"xsd: string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
				ResXCode.AppendLine("\t</xsd:sequence>");
				ResXCode.AppendLine("\t<xsd:attribute name=\"name\" type=\"xsd: string\" use=\"required\" />");
				ResXCode.AppendLine("\t</xsd:complexType>");
				ResXCode.AppendLine("\t</xsd:element>");
				ResXCode.AppendLine("\t</xsd:choice>");
				ResXCode.AppendLine("\t</xsd:complexType>");
				ResXCode.AppendLine("\t</xsd:element>");
				ResXCode.AppendLine("\t</xsd:schema>");
				ResXCode.AppendLine("\t<resheader name=\"resmimetype\">");
				ResXCode.AppendLine("\t<value>text/microsoft-resx</value>");
				ResXCode.AppendLine("\t</resheader>");
				ResXCode.AppendLine("\t<resheader name=\"version\">");
				ResXCode.AppendLine("\t<value>2.0</value>");
				ResXCode.AppendLine("\t</resheader>");
				ResXCode.AppendLine("\t<resheader name=\"reader\">");
				ResXCode.AppendLine("\t<value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
				ResXCode.AppendLine("\t</resheader>");
				ResXCode.AppendLine("\t<resheader name=\"writer\">");
				ResXCode.AppendLine("\t<value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
				ResXCode.AppendLine("\t</resheader>");
				ResXCode.AppendLine("\t</root>");

				return ResXCode.ToString();
			}
			catch (Exception ex)
			{
				return "";
			}
		}

		//end code to create forms

		//creating Program.cs
		private String generateProgram()
        {
            StringBuilder programCode = new StringBuilder();
            try
            {
                programCode.AppendLine("using System;");
                programCode.AppendLine("using System.Collections.Generic;");
                programCode.AppendLine("using System.Linq;");
                programCode.AppendLine("using System.Threading.Tasks;");
                programCode.AppendLine("using System.Windows.Forms;");
                programCode.AppendLine("");
                programCode.AppendLine("");
                programCode.AppendLine("namespace " + txtProjectName.Text);
                programCode.AppendLine("{");
                programCode.AppendLine("\tstatic class Program");
                programCode.AppendLine("\t{");
                programCode.AppendLine("\t\t/// <summary>");
                programCode.AppendLine("\t\t/// The main entry point for the application.");
                programCode.AppendLine("\t\t/// </summary>");
                programCode.AppendLine("\t\t[STAThread]");
                programCode.AppendLine("\t\tstatic void Main()");
                programCode.AppendLine("\t\t{");
                programCode.AppendLine("\t\t\tApplication.EnableVisualStyles();");
                programCode.AppendLine("\t\t\tApplication.SetCompatibleTextRenderingDefault(false);");
                programCode.AppendLine("\t\t\tApplication.Run(new frmMain());");
                programCode.AppendLine("\t\t}");
                programCode.AppendLine("\t}");
                programCode.AppendLine("}");

                 return programCode.ToString();
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        //creating app.config
        private String generateAppConfig()
        {
            StringBuilder ConfigCode = new StringBuilder();
            try
            {
                ConfigCode.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>");
                ConfigCode.AppendLine("<configuration>");
                ConfigCode.AppendLine("\t<startup>");
                
                ConfigCode.AppendLine("\t\t<supportedRuntime version=\"v4.0\" sku=\".NETFramework, Version = v4.6.1\" />");
                ConfigCode.AppendLine("\t</startup>");
                ConfigCode.AppendLine("</configuration>");

                return ConfigCode.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }

		
	


		//Methods to create files
		private void createBusinessObjects()
		{
            create_folders();
             StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\"+ txtProjectName.Text +"\\Classes\\businessObjects.cs", false);
			stream.Write(generatebusinessObjects());
			stream.Close();
		}
		private void createDataClass()
		{
			StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\Classes\\data_class.cs", false);
			stream.Write(generateDataClass());
			stream.Close();
		}
		private void createCustomerClass()
		{
			StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\Classes\\customer_class.cs", false);
			stream.Write(generateCustomerClass());
			stream.Close();
		}

        private void createAppConfiguration()
        {
            StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\App.config", false);
            stream.Write(generateAppConfig());
            stream.Close();
        }
        private void createProgramFile()
        {
            StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\Program.cs", false);
            stream.Write(generateProgram());
            stream.Close();
        }
        private void createResxFile()
        {
            StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\frmMain.resx", false);
            stream.Write(generateMainResX());
            stream.Close();
        }
		private void createResxAddEdit()
		{
			StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\frmAddEdit.resx", false);
			stream.Write(generateAddEditResX());
			stream.Close();
		}
		private void createMainformDesigner()
        {
            StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\frmMain.Designer.cs", false);
            stream.Write(generateMainFormDesigner());
            stream.Close();
        }
        private void createMainForm()
        {
            StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\frmMain.cs", false);
            stream.Write(generate_MainForm());
            stream.Close();
        }
		private void createAddEditDesigner()
		{
			StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\frmAddEdit.Designer.cs", false);
			stream.Write(create_AddEditDesigner());
			stream.Close();
		}
		private void createAddEdit()
		{
			StreamWriter stream = new StreamWriter(txtFindPath.Text + "\\" + txtProjectName.Text + "\\frmAddEdit.cs", false);
			stream.Write(create_AddEdit());
			stream.Close();
		}
		//End methods to create files




		private void btnGenerate_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtFindPath.Text == "")
					throw new Exception("Please select a file path");

				if (txtProjectName.Text == "")
					throw new Exception("Please enter a project name");

				if (cbCreateClasses.Checked == true)
				{
					if (lvwElements.Items.Count == 0)
						throw new Exception("List must have at least one element.");
					else
					{
						createBusinessObjects();
						createDataClass();
						createCustomerClass();
					}
				}

				if (cbAddEdit.Checked == true)
				{
					createAddEdit();
					createAddEditDesigner();
					createResxAddEdit();
				}

				if (cbMain.Checked == true)
				{
					createMainForm();
					createMainformDesigner();
					createResxFile();
					createAppConfiguration();
					createProgramFile();
				}

				MessageBox.Show(txtProjectName.Text + " Created sucessfully!");

			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			


        }

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (droplistDataTypes.Text == "")
			{
				MessageBox.Show("Please enter information before proceeding!");
				return;
			}

				ListViewItem litem = new ListViewItem(txtInsertFields.Text);
				litem.SubItems.Add(droplistDataTypes.Text);
				lvwElements.Items.Add(litem);

		}

        private void create_folders()
        {
            string folderName = txtFindPath.Text + "\\" + txtProjectName.Text;
            string pathString = System.IO.Path.Combine(folderName, "Classes");
            string pathString2 = System.IO.Path.Combine(folderName, "bin");
            string pathString3 = System.IO.Path.Combine(folderName, "obj");
            string pathString4 = System.IO.Path.Combine(folderName, "Properties");
            System.IO.Directory.CreateDirectory(pathString);
            System.IO.Directory.CreateDirectory(pathString2);
            System.IO.Directory.CreateDirectory(pathString3);
            System.IO.Directory.CreateDirectory(pathString4);
            string newfolderName = txtFindPath.Text + "\\" + txtProjectName.Text + "\\bin";
            string pathString5 = System.IO.Path.Combine(newfolderName, "Debug");
            string pathString6 = System.IO.Path.Combine(newfolderName, "Release");
            System.IO.Directory.CreateDirectory(pathString5);
            System.IO.Directory.CreateDirectory(pathString6);
        }

		private void txtProjectName_KeyDown(object sender, KeyEventArgs e)
		{
			Keys key = e.KeyCode;
			if (key == Keys.Space)
			{
				MessageBox.Show("Spaces are not allowed");
				txtProjectName.Text = "";
			}

			
		}

		
	}
}



