using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;

namespace UnboundRowStateImage {
	public partial class _Default : System.Web.UI.Page {
		protected void ASPxGridView1_DataBinding(object sender, EventArgs e) {
			ASPxGridView1.DataSource = GetDataTable();

		}
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack)
				ASPxGridView1.DataBind();
		}
		private DataTable GetDataTable() {
			DataTable table = new DataTable("Tasks");
			table.Columns.Add("ID", typeof(int));
			table.Columns.Add("Subject", typeof(string));
			table.Columns.Add("DueOn", typeof(DateTime));
			table.Rows.Add(1, "Feed the dog", DateTime.Today.AddHours(9));
			table.Rows.Add(2, "Shop for food", DateTime.Today.AddHours(12));
			table.Rows.Add(3, "Watch the race", DateTime.Today.AddHours(23));
			return table;
		}

		string GetSate(int id) {
			string sessionKey = String.Format("Actions_{0}", id);
			string state = (string)Session[sessionKey];
			if (state == null)
				state = "undone";
			return state;
		}

		void SetState(int id, string state) {
			string sessionKey = String.Format("Actions_{0}", id);
			Session[sessionKey] = state;
		}

		string GetNextState(string currentSate) {
			switch (currentSate) {
				case "deleted":
					return "undone";
				case "undone":
					return "deleted";
				default:
					return currentSate;
			}
		}

		string GetImagePath(string state) {
			switch (state) {
				case "deleted":
					return "~/Images/undo.gif";
				case "undone":
					return "~/Images/delete.gif";
				default:
					return string.Empty;
			}
		}

		protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e) {
			if (e.RowType == GridViewRowType.Data) {
				int id = (int)e.KeyValue;
				ASPxGridView grid = (ASPxGridView)sender;
				GridViewDataColumn colAction = (GridViewDataColumn)grid.Columns["colAction"];
				ASPxButton btnAction = (ASPxButton)grid.FindRowCellTemplateControl(e.VisibleIndex, colAction, "btnAction");
				string state = GetSate(id);
				btnAction.ImageUrl = GetImagePath(state);
				btnAction.ClientSideEvents.Click = GetActionScript(id, state);
			}
		}

		private string GetActionScript(int id, string state) {
			string changeState = "ChangeState;" + id.ToString();
			string nextState = GetNextState(state);
			switch (nextState) {
				case "deleted":
					return "function(s,e){ if(confirm('Delete?')) grid.PerformCallback('" + changeState + "'); }";
				case "undone":
					return "function(s,e){ if(confirm('Undo?')) grid.PerformCallback('" + changeState + "'); }";
				default:
					return string.Empty;
			}
		}

		protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
			string[] parameters = e.Parameters.Split(';');
			if (parameters.Length == 2 && parameters[0] == "ChangeState") {
				int id = Convert.ToInt32(parameters[1]);
				string currentState = GetSate(id);
				string newState = GetNextState(currentState);
				SetState(id, newState);
			}
		}

	}
}
