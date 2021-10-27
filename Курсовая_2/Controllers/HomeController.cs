using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовая_2._0.Controllers;
using Курсовая_2.Models;

namespace Курсовая_2.Controllers
{
    public class HomeController : Controller
    {
        StreammReader reader = new StreammReader();
        Stopwatch stopWatch = new Stopwatch();
        Statistic stat = new Statistic();
        [HttpGet]
        public ActionResult Index()
        {
            return View("IndexAJAX");
        }

        [HttpPost]
        public JsonResult Uploader(UploadFile upload)
        {
            if (upload.UsersFile != null)

            {
                OpenedFile ReadenFile = new OpenedFile();

                int count = 0;
                int rcount = 0;
                double arrstream = 0;
                string path = Server.MapPath("~/Files/");
                string fileName = Path.GetFileName(upload.UsersFile.FileName);

                upload.Time = DateTime.Now;
                upload.Name = upload.UsersFile.FileName;
                upload.Size = upload.UsersFile.ContentLength;

                string filePath = path + fileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/Files"));
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }
                upload.UsersFile.SaveAs(Server.MapPath("~/Files/" + fileName));
               
                foreach (string file in GetFile.GetFiles(filePath))
                {
                    rcount += 1;

                    stopWatch.Restart();
                    ReadenFile.FilesLines = reader.Collector(file).ToList();
                    arrstream = stopWatch.Elapsed.TotalMilliseconds;

                    foreach (string[] line in reader.Collector(file))
                    {
                        count += 1;
                    }
                    //count = count / rcount;

                }
                upload.OpenTimeStream = arrstream;
                upload.CountOfStrings = count;

                return Json(ReadenFile.FilesLines);
            }
            else
            {
                return Json("Не удалось загрузить файл");
            }
        }
        [HttpGet]
        public ActionResult Statistics()
        {
            string fileName = Directory.GetFiles(Server.MapPath("~/Files/")).First();
            ViewBag.CountOfRows = stat.CountOfRows(fileName);
            ViewBag.CountOfColumns = stat.CountOfColumns(fileName);
            ViewBag.CountOfCells = stat.CountOfCells(fileName);
            return View("StatForFile");
        }
        [HttpPost]
        public ActionResult Statistics(string symbols)
        {
            if (Directory.Exists(Server.MapPath("~/Files/")))
            {
                string fileName = Directory.GetFiles(Server.MapPath("~/Files/")).First();
                ViewBag.CountOfSymbols = stat.CountOfSymbols(fileName, symbols);
            };
            return View("StatForFile");
        }
    }
}