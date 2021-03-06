﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Triangles.Code.DataAccess;
using Triangles.Code.Services;

namespace Triangles.Web.Controllers
{
	public class ReceiptRecordsController : Controller
	{
		readonly ReceiptRepository _receiptRepository = new ReceiptRepository();
		readonly ReceiptRecordRepository _receiptRecordRepository = new ReceiptRecordRepository();

		public ActionResult AjaxSelect(int receiptId)
		{
			throw new NotImplementedException();
//			return View(GetReceiptRecordsGridModel(receiptId));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult AjaxInsert(int receiptId)
		{
			throw new NotImplementedException();
			var receiptRecord = new Models.ReceiptRecord();

			if (TryUpdateModel(receiptRecord))
			{
				var newReceiptRecord = Mapper.Map<Code.DataAccess.ReceiptRecord>(receiptRecord);
				newReceiptRecord.ReceiptId = receiptId;
				_receiptRecordRepository.Insert(newReceiptRecord);
			}

//			return View(GetReceiptRecordsGridModel(receiptId));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult AjaxSave(int receiptId, int id)
		{
			throw new NotImplementedException();

			var receiptRecord = new Models.ReceiptRecord { Id = id };

			if (TryUpdateModel(receiptRecord))
			{
				_receiptRecordRepository.Update(Mapper.Map<Code.DataAccess.ReceiptRecord>(receiptRecord));
			}

//			return View(GetReceiptRecordsGridModel(receiptId));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult AjaxDelete(int receiptId, int id)
		{
			throw new NotImplementedException();

			_receiptRecordRepository.Delete(id);

//			return View(GetReceiptRecordsGridModel(receiptId));
		}

//		private GridModel GetReceiptRecordsGridModel(int receiptId)
//		{
//			return new GridModel(_receiptRepository.ById(receiptId).ReceiptRecords.Select(x => Mapper.Map<Models.ReceiptRecord>(x)).ToArray());
//		}
	}
}
