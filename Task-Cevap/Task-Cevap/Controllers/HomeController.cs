using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_Cevap.Models;

namespace Task_Cevap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CreatePerson()
        {
            return View();
        }
        public IActionResult Index()
        {
            var persons = GetPersons();
            return View(persons);
        }
        [HttpGet]
        [Route("export/persons")]
        public IActionResult Export()
        {
            byte[] excelFile;

            using (var workbook = new XLWorkbook())
            {
                CreateAndFillWorksheet(workbook, "Sayfa 1");

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Dosyayı bir path yerine, stream olarak kaydettim 
                    workbook.SaveAs(memoryStream);
                    excelFile = memoryStream.ToArray();
                }
            }
            return Ok(excelFile);
        }
        [HttpPost]
        public IActionResult CreatePerson(PersonViewModel personViewModel)
        {
            Program.dt.Rows.Add(GeneratePersonId(), personViewModel.Name, personViewModel.LastName, personViewModel.Address, personViewModel.Mail);
            return Redirect("/Home/Index");
        }
        public void CreateAndFillWorksheet(IXLWorkbook workbook, string sheetName)
        {
            var worksheet = workbook.Worksheets.Add(sheetName);

            worksheet.Cell(1, 1).SetValue("Id");
            worksheet.Cell(1, 2).SetValue("Name");
            worksheet.Cell(1, 3).SetValue("LastName");
            worksheet.Cell(1, 4).SetValue("Address");
            worksheet.Cell(1, 5).SetValue("Mail");

            worksheet.Row(1).CellsUsed().Style.Font.SetBold();
            worksheet.Row(1).CellsUsed().Style.Font.SetFontSize(12);
            worksheet.Row(1).CellsUsed().Style.Fill.SetBackgroundColor(XLColor.YellowGreen);

            worksheet.Cell(2, 1).InsertData(MyGlobalVariables.persons);

            worksheet.Columns().AdjustToContents();
        }

        public int GeneratePersonId()
        {
            int DataCount = Program.dt.Rows.Count;
            if (DataCount == 0)
            {
                return 1;
            }
            else
            {
                return DataCount + 1;
            }
        }
        public List<PersonViewModel> GetPersons()
        {
            if (MyGlobalVariables.persons.Count > 0) 
            {
                MyGlobalVariables.persons.Clear();
                for (int i = 0; i < Program.dt.Rows.Count; i++)
                {
                    PersonViewModel person = new PersonViewModel();
                    person.Id = Convert.ToInt32(Program.dt.Rows[i]["PersonId"]);
                    person.Mail = Program.dt.Rows[i]["Mail"].ToString();
                    person.LastName = Program.dt.Rows[i]["LastName"].ToString();
                    person.Address = Program.dt.Rows[i]["Address"].ToString();
                    person.Name = Program.dt.Rows[i]["Name"].ToString();
                    MyGlobalVariables.persons.Add(person);
                }

            }
            else
            {
                for (int i = 0; i < Program.dt.Rows.Count; i++)
                {
                    PersonViewModel person = new PersonViewModel();
                    person.Id = Convert.ToInt32(Program.dt.Rows[i]["PersonId"]);
                    person.Mail = Program.dt.Rows[i]["Mail"].ToString();
                    person.LastName = Program.dt.Rows[i]["LastName"].ToString();
                    person.Address = Program.dt.Rows[i]["Address"].ToString();
                    person.Name = Program.dt.Rows[i]["Name"].ToString();
                    MyGlobalVariables.persons.Add(person);
                }
            }
            return MyGlobalVariables.persons;
        }
    }
}
