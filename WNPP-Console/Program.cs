using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using WNPP_WEB.Models;
using WNPP_WEB.Services;

///=== RUN =======
//string fileName = @"D:\DEV\NewContract2567v.2.04.16.xlsx"; // Data Type 4
string fileName = @"D:\DEV\NewContract2567v.2.05.05.xlsx"; // Data Type 5
///

///=== GET IMAGE ===///
Imdb67Context ctx = new Imdb67Context();
getImageFromExcel("D:\\DEV\\Branch\\", "สาขา", false);
//getImageFromExcelToDB(ctx, "สาขา", true);

getImageFromExcel("D:\\DEV\\Branch\\", "สำรอง", false);
//getImageFromExcelToDB(ctx, "สำรอง", true);

getImageFromExcel("D:\\DEV\\Branch\\", "สำรวจ", false);
//getImageFromExcelToDB(ctx, "สำรวจ", true);

///=== Load Data To Database ===///
///getDataFromNewExcelFormat();

///=== Migration Temple to database. ===//
///
//migrateTempleToDB();

void migrateTempleToDB()
{
    Wnpp67Context ctx = new Wnpp67Context();
    MMonastery mo;

    var rows = ctx.TempleDbs.ToList();
    foreach (var row in rows)
    {
        mo = new MMonastery
        {
            ActiveStatus = CommonService._Record_Active,
            LanguageId = CommonService._Lang_TH,

            CreatedBy = CommonService._Admin_ID,
            CreatedByName = CommonService._Admin_Name,
            CreatedDate = DateTime.Now,

            //Id = row.Column1,
            MonasteryName = row.Column2,
            MonasteryType = row.Column3,
            Denomination = row.Column4,
            RegisterType = row.Column5,
            DateOfFoundingTxt = row.Column6,
            WisungkhamType = row.Column7,
            DateOfWisungkhamTxt = row.Column8,
            SubDistrictMonatery = row.Column9,
            DistrictMonatery = row.Column10,
            ProvinceMonatery = row.Column11,
            PostCodeMonatery = row.Column12,

        };
        ctx.MMonasteries.Add(mo);
        Console.WriteLine(row.Column1);
    }
    ctx.SaveChanges();
}
void getDataFromNewExcelFormat()
{


    int set_1_Subject = 1;
    int set_2_Add1 = 3;
    int set_3_Add2 = 4;
    int set_4_Abbot = 6;
    ///=== สาขา สำรอง ===>
    int set_5_Ordinate = 8;
    ///=== สำรวจ =======>
    //int set_5_Ordinate = 7;
    int set_6_Certifier = 8;
    int set_Phone = 9;
    int set_Reset = 10;


    Console.WriteLine(" === Open Connection === ");
    Wnpp67Context ctx = new Wnpp67Context();

    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
        {
            WorkbookPart workbookPart = doc.WorkbookPart;
            SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
            SharedStringTable sst = sstpart.SharedStringTable;

            Console.WriteLine(" === Load data Branch type 1. === ");
            migrateType1("สาขา", sst, doc, ctx);
            Console.WriteLine(" === Load data Branch type 2. === ");
            migrateType2("สำรอง", sst, doc, ctx);
            Console.WriteLine(" === Load data Branch type 3. === ");
            migrateType3("สำรวจ", sst, doc, ctx);

            Console.WriteLine(" === Finish ");
        }
    }
}
TBranch getNewBranch()
{
    return new TBranch()
    {
        ActiveStatus = true,
        LanguageId = 1,
        RecordStatus = "c",
        CreatedDate = DateTime.Now,
        CreatedByName = "Administrator"
    };
}
String? getCellData(String cellAddress, Worksheet sheet, SharedStringTable sst)
{
    String result = null;
    Cell theCell = sheet.Descendants<Cell>().Where(c => c.CellReference == cellAddress).FirstOrDefault();
    if (theCell != null)
        if ((theCell.DataType != null) && (theCell.DataType == CellValues.SharedString))
            result = sst.ChildElements[int.Parse(theCell.CellValue.Text)].InnerText;

    return result;
}
string convBranch3Digit(string source)
{
    string result = source;
    string[] data = source.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (data.Length == 2)
    {
        result = data[0] + " " + string.Format("{0:000}", int.Parse(data[1]));
    }
    return result;
}
string getArabicnumber(string source)
{
    string result = source;
    result = result.Replace("๑", "1");
    result = result.Replace("๒", "2");
    result = result.Replace("๓", "3");
    result = result.Replace("๔", "4");
    result = result.Replace("๕", "5");
    result = result.Replace("๖", "6");
    result = result.Replace("๗", "7");
    result = result.Replace("๘", "8");
    result = result.Replace("๙", "9");
    result = result.Replace("๐", "0");

    return result;
}
int getOrdinationOfAge(String data)
{
    int result = 0;
    int ageYear = 0;
    string age = "";
    string[] convData;

    if (data.IndexOf("อุปสมบท เมื่ออายุ") >= 0)
    {
        age = data.Substring(data.IndexOf("อุปสมบท เมื่ออายุ")).Trim();
        convData = age.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (convData.Length >= 3)
        {
            bool canConvert = int.TryParse(convData[2], out ageYear);
            result = canConvert ? ageYear : 0;
        }
    }


    return result;
}
DateTime? getDateOfBirth(String data)
{
    int ageYear = 0;
    string dateType = "MM/dd/yyyy";
    string dateNull = "01/01/1777";
    string age = "";

    string[] convData;
    string newDate;
    DateTime result = new DateTime();
    DateTime odinationDate = new DateTime();

    if (data.IndexOf("วันที่") > 0)
    {
        age = data.Substring(data.IndexOf("อุปสมบท เมื่ออายุ")).Trim();
        data = data.Substring(data.IndexOf("วันที่")).Trim();

        convData = age.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        bool canConvert = int.TryParse("-" + convData[2], out ageYear);
        if (canConvert == false)
        {
            result = DateTime.ParseExact(dateNull, dateType, null);
        }
        else
        {
            convData = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            newDate = String.Format("{0:00}", int.Parse(getMonthNumber(convData[2]))) + "/" +
                        String.Format("{0:00}", int.Parse(convData[1])) + "/" +
                        (int.Parse(convData[3]) - 543);

            odinationDate = DateTime.ParseExact(newDate, dateType, null);
            result = odinationDate.AddYears(ageYear);
        }
    }
    else
    {
        result = DateTime.ParseExact(dateNull, dateType, null);
    }

    return result;
}
DateTime? getOrdination(String data)
{
    string dateType = "MM/dd/yyyy";
    string dateNull = "01/01/1777";

    string[] convData;
    string newDate;
    DateTime result = new DateTime();

    if (data.IndexOf("วันที่") > 0)
    {
        data = data.Substring(data.IndexOf("วันที่")).Trim();
        convData = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        //newDate = (int.Parse(convData[3]) - 543) + "/" + String.Format("{0:00}", int.Parse(getMonthNumber(convData[2])))  + "/" + String.Format("{0:00}", int.Parse(convData[1]));

        newDate = String.Format("{0:00}", int.Parse(getMonthNumber(convData[2]))) + "/" +
                    String.Format("{0:00}", int.Parse(convData[1])) + "/" +
                    (int.Parse(convData[3]) - 543);

        result = DateTime.ParseExact(newDate, dateType, null);
    }
    else
    {
        result = DateTime.ParseExact(dateNull, dateType, null);
    }
    return result;
}
String? getMonthNumber(String monthName)
{
    String result = null;
    switch (monthName)
    {
        case "มกราคม":
            result = "1";
            break;
        case "กุมภาพันธ์":
            result = "2";
            break;
        case "มีนาคม":
            result = "3";
            break;
        case "เมษายน":
            result = "4";
            break;
        case "พฤษภาคม":
            result = "5";
            break;
        case "มิถุนายน":
            result = "6";
            break;
        case "กรกฎาคม":
            result = "7";
            break;
        case "สิงหาคม":
            result = "8";
            break;
        case "กันยายน":
            result = "9";
            break;
        case "ตุลาคม":
            result = "10";
            break;
        case "พฤศจิกายน":
            result = "11";
            break;
        case "ธันวาคม":
            result = "12";
            break;
    }
    return result;
}
WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string sheetName)
{
    IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);

    if (sheets.Count() == 0)
    {
        // The specified worksheet does not exist.
        return null;
    }

    string relationshipId = sheets.First().Id.Value;
    WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);

    return worksheetPart;
}

void migrateType1(string sheetName, SharedStringTable sst, SpreadsheetDocument doc, Wnpp67Context ctx)
{
    WorksheetPart worksheetPart = GetWorksheetPartByName(doc, sheetName);
    Worksheet sheet = worksheetPart.Worksheet;

    string? data = null;
    string[] add = null;

    string cellColumn = "";
    int branchType = 1; /// 1, 2, 3

    List<TBranch> lstTBranch = new List<TBranch>();
    TBranch branch;
    int rowCount = 1, rowRecCount = 1;
    int maxRowCount = 3330;
    for (int i = 1; i <= maxRowCount; i++)
    {

        rowRecCount = 1;
        branch = getNewBranch();

        ///=== 1 Subject ===
        ///=================
        cellColumn = "B" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.BranchName = convBranch3Digit(data);
        branch.BranchType = branchType;
        branch.BranchTypeName = sheetName;

        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        branch.MonasteryName = data;
        if (branch.MonasteryName.StartsWith("วัด"))
        {
            branch.MonasteryType = 1;
            branch.MonasteryTypeName = "วัด";
            branch.AbbotType = 1;
        }
        else
        {
            branch.MonasteryType = 2;
            branch.MonasteryTypeName = "ที่พักสงฆ์";
            branch.AbbotType = 2;
        }

        rowRecCount++; i++;
        rowRecCount++; i++;

        ///3 === Add1 ===
        ///==============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.AddressTextMonatery = data;

        rowRecCount++; i++;

        ///4 === Add2 ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        add = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (add.Length == 5)
        {
            branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
            branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
            branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
        }
        else if (add.Length == 4)
        {
            if (add[3].Length > 5)
            {
                branch.CountryMonatery = add[3].Trim();
                branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
                branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
                branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
            }
            else
            {
                branch.CountryMonatery = "ไทย";
                branch.PostCodeMonatery = getArabicnumber(add[3].Trim());
                branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
                branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
                branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
            }

        }
        else if (add.Length == 3)
        {
            branch.CountryMonatery = "ไทย";
            branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
            branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
            branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
        }

        rowRecCount++; i++;
        rowRecCount++; i++;

        ///6 === Abbot ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        branch.AbbotName = data;

        rowRecCount++; i++;
        rowRecCount++; i++;

        ///8 === Ordinate ====
        ///===================
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.Notation = data;
        branch.OrdainedAtAge = getOrdinationOfAge(data);
        branch.DateOfBirth = getDateOfBirth(data);
        branch.DateOfOrdination = getOrdination(data);

        rowRecCount++; i++;

        ///9 === Phone ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        data = data.Replace("-", "");
        data = data.Replace(" ", "");
        branch.MonasteryPhoneNo = data;

        rowRecCount++; i++;

        lstTBranch.Add(branch);
    }
    ctx.TBranches.AddRange(lstTBranch);
    ctx.SaveChanges();
}
/// ===> สำรอง
void migrateType2(string sheetName, SharedStringTable sst, SpreadsheetDocument doc, Wnpp67Context ctx)
{
    WorksheetPart worksheetPart = GetWorksheetPartByName(doc, sheetName);
    Worksheet sheet = worksheetPart.Worksheet;

    string tmp = "";
    string? data = null;
    string[] add = null;

    string cellColumn = "";
    int branchType = 2; /// 1, 2, 3

    List<TBranch> lstTBranch = new List<TBranch>();
    TBranch branch;
    int rowCount = 1, rowRecCount = 1;
    int maxRowCount = 40;
    for (int i = 1; i <= maxRowCount; i++)
    {

        rowRecCount = 1;
        branch = getNewBranch();

        ///=== 1 Subject ===
        ///=================
        cellColumn = "B" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.BranchName = convBranch3Digit(data);
        branch.BranchType = branchType;
        branch.BranchTypeName = sheetName;

        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        branch.MonasteryName = data;
        if (branch.MonasteryName.StartsWith("วัด"))
        {
            branch.MonasteryType = 1;
            branch.MonasteryTypeName = "วัด";
            branch.AbbotType = 1;
        }
        else
        {
            branch.MonasteryType = 2;
            branch.MonasteryTypeName = "ที่พักสงฆ์";
            branch.AbbotType = 2;
        }

        rowRecCount++; i++;
        rowRecCount++; i++;

        ///3 === Add1 ===
        ///==============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.AddressTextMonatery = data;

        rowRecCount++; i++;

        ///4 === Add2 ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        add = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (add.Length == 5)
        {
            branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
            branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
            branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
        }
        else if (add.Length == 4)
        {
            if (add[3].Length > 5)
            {
                branch.CountryMonatery = add[3].Trim();
                branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
                branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
                branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
            }
            else
            {
                branch.CountryMonatery = "ไทย";
                branch.PostCodeMonatery = getArabicnumber(add[3].Trim());
                branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
                branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
                branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
            }
        }
        else if (add.Length == 3)
        {
            branch.CountryMonatery = "ไทย";
            branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
            branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
            branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
        }

        rowRecCount++; i++;
        rowRecCount++; i++;

        ///6 === Abbot ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        branch.AbbotName = data;

        rowRecCount++; i++;

        ///8 === Ordinate ====
        ///===================
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.Notation = data;
        branch.OrdainedAtAge = getOrdinationOfAge(data);
        branch.DateOfBirth = getDateOfBirth(data);
        branch.DateOfOrdination = getOrdination(data);

        rowRecCount++; i++;

        ///8 === Certifier ===
        ///===================
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        data = data.Replace("รับรอง", "");
        add = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        tmp = "";
        if (add.Length >= 1)
        {
            for (int j = 0; j < add.Length - 1; j++)
            {
                tmp = tmp + add[j] + " ";
            }
            tmp = tmp.Trim();
            branch.CertifierName = tmp;
            branch.CertifierTemple = add[add.Length - 1];
        }


        rowRecCount++; i++;

        ///9 === Phone ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        data = data.Replace("-", "");
        data = data.Replace(" ", "");
        branch.MonasteryPhoneNo = data;

        rowRecCount++; i++;

        lstTBranch.Add(branch);
    }
    ctx.TBranches.AddRange(lstTBranch);
    ctx.SaveChanges();
}
/// ===> สำรวจ
void migrateType3(string sheetName, SharedStringTable sst, SpreadsheetDocument doc, Wnpp67Context ctx)
{
    WorksheetPart worksheetPart = GetWorksheetPartByName(doc, sheetName);
    Worksheet sheet = worksheetPart.Worksheet;

    string tmp = "";
    string? data = null;
    string[] add = null;

    string cellColumn = "";
    int branchType = 3; /// 1, 2, 3

    List<TBranch> lstTBranch = new List<TBranch>();
    TBranch branch;
    int rowCount = 1, rowRecCount = 1;
    int maxRowCount = 730;
    for (int i = 1; i <= maxRowCount; i++)
    {

        rowRecCount = 1;
        branch = getNewBranch();

        ///=== 1 Subject ===
        ///=================
        cellColumn = "B" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.BranchName = convBranch3Digit(data);
        branch.BranchType = branchType;
        branch.BranchTypeName = sheetName;

        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        branch.MonasteryName = data;
        if (branch.MonasteryName.StartsWith("วัด"))
        {
            branch.MonasteryType = 1;
            branch.MonasteryTypeName = "วัด";
            branch.AbbotType = 1;
        }
        else
        {
            branch.MonasteryType = 2;
            branch.MonasteryTypeName = "ที่พักสงฆ์";
            branch.AbbotType = 2;
        }

        rowRecCount++; i++;
        rowRecCount++; i++;

        ///3 === Add1 ===
        ///==============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.AddressTextMonatery = data;

        rowRecCount++; i++;

        ///4 === Add2 ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        add = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (add.Length == 5)
        {
            branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
            branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
            branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
        }
        else if (add.Length == 4)
        {
            if (add[3].Length > 5)
            {
                branch.CountryMonatery = add[3].Trim();
                branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
                branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
                branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
            }
            else
            {
                branch.CountryMonatery = "ไทย";
                branch.PostCodeMonatery = getArabicnumber(add[3].Trim());
                branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
                branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
                branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
            }
        }
        else if (add.Length == 3)
        {
            branch.CountryMonatery = "ไทย";
            branch.ProvinceMonatery = add[2].Trim().Replace("จ.", "");
            branch.DistrictMonatery = add[1].Trim().Replace("อ.", "");
            branch.SubDistrictMonatery = add[0].Trim().Replace("ต.", "");
        }

        rowRecCount++; i++;
        rowRecCount++; i++;

        ///6 === Abbot ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        branch.AbbotName = data;

        rowRecCount++; i++;

        ///7 === Ordinate ====
        ///===================
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        branch.Notation = data;
        branch.OrdainedAtAge = getOrdinationOfAge(data);
        branch.DateOfBirth = getDateOfBirth(data);
        branch.DateOfOrdination = getOrdination(data);

        rowRecCount++; i++;

        ///8 === Certifier ===
        ///===================
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? data.Trim() : "";
        data = data.Replace("รับรอง", "");
        add = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        tmp = "";
        for (int j = 0; j < add.Length - 1; j++)
        {
            tmp = tmp + add[j] + " ";
        }
        tmp = tmp.Trim();
        branch.CertifierName = tmp;
        branch.CertifierTemple = add[add.Length - 1];

        rowRecCount++; i++;

        ///9 === Phone ===
        ///===============
        cellColumn = "C" + i;
        data = getCellData(cellColumn, sheet, sst);
        data = data != null ? getArabicnumber(data.Trim()) : "";
        data = data.Replace("-", "");
        data = data.Replace(" ", "");
        branch.MonasteryPhoneNo = data;

        rowRecCount++; i++;

        lstTBranch.Add(branch);
    }
    ctx.TBranches.AddRange(lstTBranch);
    ctx.SaveChanges();
}
void getImageFromExcelToDB(Imdb67Context ctx, string sheetName, bool needReSize)
{
    Stream stream;
    long length;
    byte[] byteStream;
    Image img;
    TAbbotImg result;

    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
        {
            WorkbookPart workbookPart = doc.WorkbookPart;
            WorksheetPart workSheet = GetWorksheetPartByName(doc, sheetName);


            foreach (ImagePart i in workSheet.DrawingsPart.ImageParts)
            {
                var rId = workSheet.DrawingsPart.GetIdOfPart(i);

                stream = i.GetStream();
                length = stream.Length;
                byteStream = new byte[length];
                stream.Read(byteStream, 0, (int)length);

                Console.WriteLine("The rId of this Image is '{0}' data {1}", rId, i);

                if (needReSize)
                    img = ResizeImage(Image.FromStream(i.GetStream()), 100, 150);

                else
                    img = Image.FromStream(i.GetStream());

                result = new TAbbotImg()
                {
                    ActiveStatus = CommonService._Record_Active,
                    LanguageId = CommonService._Lang_TH,

                    CreatedBy = CommonService._Admin_ID,
                    CreatedByName = CommonService._Admin_Name,
                    CreatedDate = DateTime.Now,

                    //AbbotName = rId +".jpg",
                    ImgNotation = rId + ".jpg",
                };

                using (var stm = new MemoryStream())
                {
                    img.Save(stm, ImageFormat.Jpeg);
                    result.ImgType = "image/jpeg";
                    result.ImgSize = stm.Length;
                    result.ImgBinary = stm.ToArray();
                }

                ctx.TAbbotImgs.Add(result);
                ctx.SaveChanges();
            }
            
        }
    }
}
void getImageFromExcel(string filePath, string sheetName, bool needReSize)


{
    string filesOut = filePath + sheetName + "\\";

    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
        {
            WorkbookPart workbookPart = doc.WorkbookPart;
            WorksheetPart workSheet = GetWorksheetPartByName(doc, sheetName);

            foreach (ImagePart i in workSheet.DrawingsPart.ImageParts)
            {
                var rId = workSheet.DrawingsPart.GetIdOfPart(i);

                Stream stream = i.GetStream();
                long length = stream.Length;
                byte[] byteStream = new byte[length];
                stream.Read(byteStream, 0, (int)length);

                Console.WriteLine("The rId of this Image is '{0}' data {1}", rId, i);
                Image img;
                if (needReSize)
                    img = ResizeImage(Image.FromStream(i.GetStream()), 100, 150);

                else
                    img = Image.FromStream(i.GetStream());

                img.Save(filesOut + rId + ".jpg", ImageFormat.Jpeg);
            }

        }
    }
}

Bitmap ResizeImage(Image image, int width, int height)
{
    var destRect = new Rectangle(0, 0, width, height);
    var destImage = new Bitmap(width, height);

    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

    using (var graphics = Graphics.FromImage(destImage))
    {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using (var wrapMode = new ImageAttributes())
        {
            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        }
    }

    return destImage;
}