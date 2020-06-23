using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBSystem.BLL;
using DBSystem.ENTITIES;

namespace WebApp_assignment6.Pages

{
    public partial class SingleRecordQuery : System.Web.UI.Page

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ID.Text = "";
            Name.Text = "";
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IDArg.Text))
            {
                MessageLabel.Text = "Enter a ID value.";
                ID.Text = "";
                Name.Text = "";
            }

            else
            {
                int id = 0;
                if (int.TryParse(IDArg.Text, out id))
                {
                    if (id > 0)
                    {
                        Controller01 sysmgr = new Controller01();
                        Entity01 info = null;
                        info = sysmgr.FindByID(id); //BLL controller method          

                        if (info == null)
                        {
                            MessageLabel.Text = "ID not found.";
                            ID.Text = "";
                            Name.Text = "";
                        }
                        else
                        {
                            ID.Text = info.TeamID.ToString();
                            Name.Text = info.TeamName;
                        }
                    }
                    else
                    {
                        MessageLabel.Text = "ID must be greater than 0";
                        ID.Text = "";
                        Name.Text = "";
                    }
                }
                else
                {
                    MessageLabel.Text = "ID must be a number.";
                    ID.Text = "";
                    Name.Text = "";
                }
            }
        }
    }
}