﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangles.Code;
using Triangles.Code.DataAccess;
using Expenditure = Triangles.Code.Expenditure;

namespace Triangles.Web
{
	public partial class CalculationWithCommonFundResult : System.Web.UI.Page
	{
		readonly ExpenditureRepository _repository = new ExpenditureRepository();
		readonly CommonFundCalculator _calculator = new CommonFundCalculator();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var records = _repository.All();

				lvRecords.DataSource = records;
				lvRecords.DataBind();

				var transfers = _calculator.Calculate(
													records.Select(x => new Expenditure { Who = x.Who, Amount = x.Amount }).ToArray(),
													records.Select(x => x.Who).ToArray());

				lvTransfers.DataSource = transfers;
				lvTransfers.DataBind();
			}
		}
	}
}