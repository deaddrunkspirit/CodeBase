using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pathToData = args[0];
            string inputPath = args[1];
            string outputPath = args[2];
            string[] inputData = File.ReadAllLines(inputPath);
            int conditionCount = int.Parse(inputData[1]);
            RoaringBitmap[] bitmaps = new RoaringBitmap[conditionCount];
            Phase1(inputData, conditionCount, bitmaps, pathToData);
            RoaringBitmap ans = Phase2(conditionCount, bitmaps);
            string[] outputPropertyNames = inputData[0].Split(',');
            List<string> res = Phase3(outputPropertyNames, ans, pathToData);
            File.WriteAllLines(outputPath, res);
        }

        private static int GetDimTableIndex(string tableName, int i, string pathToData)
        {
            StreamReader reader = new StreamReader(pathToData + tableName + ".csv");
            int res = 1;
            while (!reader.EndOfStream)
            {
                int value = int.Parse(reader.ReadLine().Split('|')[0]);
                if (value == i)
                {
                    reader.Close();
                    return res;
                }
                res++;
            }
            reader.Close();
            return -1;
        }

        private static List<string> Phase3(string[] tableNames, RoaringBitmap bitmap, string pathToData)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < bitmap.BitsCount; i++)
            {
                if (bitmap.Get(i))
                {
                    string line = "";
                    for (int j = 0; j < tableNames.Length; j++)
                    {
                        if (tableNames[j].Contains("Dim"))
                        {
                            string[] cond = tableNames[j].Split('.');
                            int index;
                            if (cond[0].Contains("DimDate"))
                            {
                                index = int.Parse(GetFactTableValue(cond[0].Replace("Dim", "FactResellerSales.Order") + "Key", i, pathToData));
                                line += GetDimTableValue(cond[0], cond[1], GetDimTableIndex(cond[0], index, pathToData), pathToData);

                            }
                            else
                            {
                                index = int.Parse(GetFactTableValue(cond[0].Replace("Dim", "FactResellerSales.") + "Key", i, pathToData));
                                line += GetDimTableValue(cond[0], cond[1], index, pathToData);
                            }
                        }
                        else if (tableNames[j].Contains("Fact"))
                        {
                            line += GetFactTableValue(tableNames[j], i, pathToData);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid table given");
                        }

                        line += "|";
                    }
                    res.Add(line.Trim('|'));
                }
            }
            return res;
        }

        private static RoaringBitmap Phase2(int conditionCount, RoaringBitmap[] bitmaps)
        {
            for (int i = 0; i < conditionCount - 1; i++)
            {
                bitmaps[i + 1].And(bitmaps[i]);
            }

            RoaringBitmap ans = bitmaps[conditionCount - 1];
            return ans;
        }

        private static void Phase1(string[] inputData, int conditionsCount, RoaringBitmap[] bitmaps, string pathToData)
        {
            for (int i = 0; i < conditionsCount; i++)
            {
                string[] cond = inputData[i + 2].Split(' '),
                    tableInfo = cond[0].Split('.');
                string secondOperand = cond[2];
                if (cond.Length > 3)
                {
                    for (int j = 3; j < cond.Length; j++)
                    {
                        secondOperand += " " + cond[j];
                    }
                }

                string tableName = tableInfo[0],
                    tableProp = tableInfo[1];
                List<int> keys = new List<int>();
                if (tableName.Contains("Fact"))
                {
                    FillKeysFactTable(cond, secondOperand, tableName, tableProp, keys, pathToData);
                    bitmaps[i] = FactRoaring(pathToData + tableName + "." + tableProp + ".csv", keys);
                }
                else
                {
                    FillKeysDimTable(cond, secondOperand, tableName, tableProp, keys, pathToData);
                    bitmaps[i] = FactRoaring(pathToData + tableName + ".csv", keys);
                }
            }
        }

        private static void FillKeysDimTable(string[] cond, string secondOperand, string tableName, string tableProp, List<int> keys, string pathToData)
        {
            StreamReader reader = new StreamReader(pathToData + tableName + ".csv");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                bool val;
                switch (cond[1])
                {
                    case "<>":
                        val = CondNotEquals(tableName, tableProp, line, secondOperand);
                        if (val)
                        {
                            keys.Add(GetPropertyValue(tableName, tableName.Replace("Dim", "") + "Key", line));
                        }

                        break;
                    case "=":
                        val = CondEquals(tableName, tableProp, line, secondOperand);
                        if (val)
                        {
                            keys.Add(GetPropertyValue(tableName, tableName.Replace("Dim", "") + "Key", line));
                        }

                        break;
                    case ">=":
                        val = CondGreaterOrEq(tableName, tableProp, line, secondOperand);
                        if (val)
                        {
                            keys.Add(GetPropertyValue(tableName, tableName.Replace("Dim", "") + "Key", line));
                        }

                        break;
                    case "<=":
                        val = CondLowerOrEq(tableName, tableProp, line, secondOperand);
                        if (val)
                        {
                            keys.Add(GetPropertyValue(tableName, tableName.Replace("Dim", "") + "Key", line));
                        }

                        break;
                    case ">":
                        val = CondGreater(tableName, tableProp, line, secondOperand);
                        if (val)
                        {
                            keys.Add(GetPropertyValue(tableName, tableName.Replace("Dim", "") + "Key", line));
                        }

                        break;
                    case "<":
                        val = CondLower(tableName, tableProp, line, secondOperand);
                        if (val)
                        {
                            keys.Add(GetPropertyValue(tableName, tableName.Replace("Dim", "") + "Key", line));
                        }

                        break;
                }
            }
            reader.Close();
        }

        private static void FillKeysFactTable(string[] cond, string secondOperand, string tableName, string tableProp, List<int> keys, string pathToData)
        {
            StreamReader reader = new StreamReader(pathToData + tableName + "." + tableProp + ".csv");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                int key = int.Parse(line);
                switch (cond[1])
                {
                    case "<>":
                        if (key != int.Parse(secondOperand))
                        {
                            keys.Add(key);
                        }

                        break;
                    case "=":
                        if (key == int.Parse(secondOperand))
                        {
                            keys.Add(key);
                        }

                        break;
                    case ">=":
                        if (key >= int.Parse(secondOperand))
                        {
                            keys.Add(key);
                        }

                        break;
                    case "<=":
                        if (key <= int.Parse(secondOperand))
                        {
                            keys.Add(key);
                        }

                        break;
                    case ">":
                        if (key > int.Parse(secondOperand))
                        {
                            keys.Add(key);
                        }

                        break;
                    case "<":
                        if (key < int.Parse(secondOperand))
                        {
                            keys.Add(key);
                        }

                        break;
                }
            }
            reader.Close();
        }

        private static RoaringBitmap FactRoaring(string tableName, List<int> keys)
        {
            string factTable;
            if (tableName.Contains("DimDate"))
            {
                factTable = tableName.Replace("Dim", "FactResellerSales.Order").Replace(".csv", "Key.csv");
            }
            else if (tableName.Contains("Dim"))
            {
                factTable = tableName.Replace("Dim", "FactResellerSales.").Replace(".csv", "Key.csv");
            }
            else
            {
                factTable = tableName;
            }

            StreamReader reader = new StreamReader(factTable);
            List<bool> vals = new List<bool>();
            while (!reader.EndOfStream)
            {
                int value = int.Parse(reader.ReadLine());
                vals.Add(keys.Contains(value));
            }
            reader.Close();
            return new RoaringBitmap(BoolListToBitsArray(vals));
        }

        private static string GetDimTableValue(string tableName, string propertyName, int i, string pathToData)
        {
            string line = File.ReadLines(pathToData + tableName + ".csv").Skip(i - 1).FirstOrDefault();
            return GetPropertyValue(tableName, propertyName, line).ToString();
        }

        private static string GetFactTableValue(string tableName, int i, string pathToData)
            => File.ReadLines(pathToData + tableName + ".csv").Skip(i).FirstOrDefault();

        private static dynamic GetInstance(string className, string line)
        {
            switch (className)
            {
                case "DimProduct":
                    return new DimProduct(line);
                case "DimPromotion":
                    return new DimPromotion(line);
                case "DimDate":
                    return new DimDate(line);
                case "DimCurrency":
                    return new DimCurrency(line);
                case "DimEmployee":
                    return new DimEmployee(line);
                case "DimReseller":
                    return new DimReseller(line);
                case "DimSalesTerritory":
                    return new DimSalesTerritory(line);
                default:
                    throw new Exception("Invalid class name");
            }
        }

        private static uint[] BoolListToBitsArray(List<bool> values)
        {
            int elemsCount = values.Count / 32 + (values.Count % 32 == 0 ? 0 : 1);
            uint[] res = new uint[elemsCount];
            for (int i = 0; i < res.Length; i++)
            {
                uint num = 0;
                for (int j = 0; j < 32; j++)
                {
                    if (i * 32 + j < values.Count)
                    {
                        num += values[i * 32 + j] ? (uint)Math.Pow(2, j) : 0;
                    }
                }

                res[i] = num;
            }
            return res;
        }

        private static dynamic GetPropertyValue(string tableName, string tableProp, string line)
        {
            object table = GetInstance(tableName, line);
            return table.GetType().GetProperty(tableProp).GetValue(table);
        }

        private static bool CondEquals(string tableName, string tableProp, string line, string secondOperand)
            => GetPropertyValue(tableName, tableProp, line).ToString().Equals(secondOperand.Trim('\''));

        private static bool CondNotEquals(string tableName, string tableProp, string line, string secondOperand)
            => !(GetPropertyValue(tableName, tableProp, line).ToString()).Equals(secondOperand.Trim('\''));

        private static bool CondGreater(string tableName, string tableProp, string line, string secondOperand)
            => GetPropertyValue(tableName, tableProp, line) > int.Parse(secondOperand);

        private static bool CondLower(string tableName, string tableProp, string line, string secondOperand)
            => GetPropertyValue(tableName, tableProp, line) < int.Parse(secondOperand);

        private static bool CondGreaterOrEq(string tableName, string tableProp, string line, string secondOperand)
            => GetPropertyValue(tableName, tableProp, line) >= int.Parse(secondOperand);

        private static bool CondLowerOrEq(string tableName, string tableProp, string line, string secondOperand)
            => GetPropertyValue(tableName, tableProp, line) <= int.Parse(secondOperand);
    }

    internal abstract class Container
    {
        public const int bitsCount = ushort.MaxValue + 1;
        public int cardinality;
        public int length;
        public abstract void And(Container other);
        public abstract void Set(int i, bool value);
        public abstract bool Get(int i);
    }

    internal class BitmapContainer : Container
    {
        public uint[] values; // 2^16 бит

        public BitmapContainer()
        {
            cardinality = 0;
            values = new uint[2048];
            length = 2048;
        }

        public override void And(Container other)
        {
            if (other is BitmapContainer)
            {
                cardinality = 0;
                for (int i = 0; i < length; i++)
                {
                    values[i] &= (other as BitmapContainer).values[i];
                    uint num = values[i];
                    for (int j = 0; j < 32; j++)
                    {
                        cardinality += (int)num % 2;
                        num /= 2;
                    }
                }
            }
            else if (other is ArrayContainer)
            {
                var otherContainer = other as ArrayContainer;
                otherContainer.cardinality = 0;
                for (int i = 0; i < bitsCount; i++)
                {
                    if (Get(i) && otherContainer.Get(i))
                    {
                        otherContainer.cardinality++;
                    }

                    otherContainer.Set(i, Get(i) && otherContainer.Get(i));
                }
            }
            else
            {
                throw new ArgumentException("Invalid container type");
            }
        }

        public bool this[int i]
        {
            get => Get(i);
            set => Set(i, value);
        }

        public override bool Get(int i)
        {
            if (i < 0 || i >= length * 32)
            {
                throw new ArgumentException("Invalid index in Bitmap Container");
            }

            return (values[i / 32] & (1 << (i % 32))) != 0;
        }

        public override void Set(int i, bool value)
        {
            if (value && !Get(i))
            {
                cardinality++;
                values[i / 32] += (uint)Math.Pow(2, i % 32);
            }
            else if (!value && Get(i))
            {
                cardinality--;
                values[i / 32] += (uint)Math.Pow(2, i % 32);
            }
        }
    }

    internal class ArrayContainer : Container
    {
        public ushort[] values;

        public ArrayContainer(BitmapContainer cont)
        {
            length = cont.cardinality;
            cardinality = cont.cardinality;
            values = new ushort[cardinality];
            int index = 0;
            for (int i = 0; i < cardinality; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (cont[i * 32 + j])
                    {
                        values[index] = (ushort)(i * 32 + j);
                        index++;
                    }
                }
            }
        }

        public ArrayContainer()
        {
            values = new ushort[0];
            cardinality = values.Length;
        }

        public bool this[int i]
        {
            get => Get(i);
            set => Set(i, value);
        }

        public override void And(Container other)
        {
            if (other is BitmapContainer)
            {
                var otherContainer = other as BitmapContainer;
                for (int i = 0; i < bitsCount; i++)
                {
                    Set(i, Get(i) && otherContainer.Get(i));
                }

                cardinality = values.Length;
            }
            else if (other is ArrayContainer)
            {
                ArrayContainer thisContainer = this;
                var otherContainer = other as ArrayContainer;
                int capacity = Math.Min(thisContainer.length, otherContainer.length);
                ushort[] newValues = new ushort[capacity];
                int j = 0;
                for (int i = 0; i < length; i++)
                {
                    int index = Array.BinarySearch((other as ArrayContainer).values, values[i]);
                    if (index > 0)
                    {
                        newValues[j] = values[i];
                        j++;
                    }
                }
                cardinality = j;
                Array.Resize(ref newValues, j);
                values = newValues;
                length = newValues.Length;
            }
            else
            {
                throw new ArgumentException("Invalid container type");
            }
        }

        public override bool Get(int i)
        {
            foreach (var index in values)
            {
                if (index == i)
                {
                    return true;
                }
            }

            return false;
        }

        public override void Set(int i, bool value)
        {
            if (value)
            {
                if (Array.BinarySearch(values, (ushort)i) < 0)
                {
                    Array.Resize(ref values, values.Length + 1);
                    length += 1;
                    values[values.Length - 1] = (ushort)i;
                }
            }
            else
            {
                List<ushort> valuesList = values.ToList();
                valuesList.Remove((ushort)i);
                values = valuesList.ToArray();
            }
        }
    }

    public class RoaringBitmap : Bitmap
    {
        private int containersCount;
        public int BitsCount => containers.Length * (int)Math.Pow(2, 16);

        private Container[] containers;

        public RoaringBitmap(uint[] bits)
        {
            int containersCount = bits.Length / 2048 + bits.Length % 2048 == 0 ? 0 : 1;
            this.containersCount = containersCount;
            containers = new Container[containersCount];
            for (int i = 0; i < containersCount; i++)
            {
                int cardinality = 0;
                BitmapContainer container = new BitmapContainer();
                for (int j = 0; j < 2048; j++)
                {
                    uint num;
                    if (i * 2048 + j < bits.Length)
                    {
                        num = bits[i * 2048 + j];
                    }
                    else
                    {
                        num = 0;
                    }

                    for (int l = 0; l < 32; l++)
                    {
                        cardinality += (int)num % 2;
                        container.Set(j * 32 + l, (int)(num % 2) == 1);
                        num /= 2;
                    }
                }
                if (cardinality < 4096)
                {
                    containers[i] = new ArrayContainer(container);
                }
                else
                {
                    containers[i] = container;
                }
            }
        }

        public bool this[int i]
        {
            get => Get(i);
            set => Set(i, value);
        }

        public override void And(Bitmap other)
        {
            var roaringOther = other as RoaringBitmap;
            for (int i = 0; i < containersCount; i++)
            {
                if (containers[i] is BitmapContainer && roaringOther.containers[i] is ArrayContainer)
                {
                    containers[i].And(roaringOther.containers[i]);
                    containers[i] = roaringOther.containers[i];
                }
                else
                {
                    containers[i].And(roaringOther.containers[i]);
                }
            }
        }

        public override bool Get(int i)
        {
            int index = (int)(i / Math.Pow(2, 16));
            return containers[index].Get((int)(i % Math.Pow(2, 16)));
        }

        public override void Set(int i, bool value)
        {
            int index = (int)(i / Math.Pow(2, 16));
            containers[index].Set((int)(i % Math.Pow(2, 16)), value);
        }
    }

    public abstract class Bitmap
    {
        public abstract void And(Bitmap other);
        public abstract void Set(int i, bool value);
        public abstract bool Get(int i);
    }

    public class DimProduct
    {
        public DimProduct(string line)
        {
            string[] values = line.Split('|');
            ProductKey = int.Parse(values[0]);
            ProductAlternateKey = values[1];
            EnglishProductName = values[2];
            Color = values[3];
            SaftyStockLevel = short.Parse(values[4]);
            ReorderPoint = short.Parse(values[5]);
            SizeRange = values[6];
            DaysToManufacture = int.Parse(values[7]);
            StartDate = values[8];

        }

        public int ProductKey { get; set; }
        public string ProductAlternateKey { get; set; }
        public string EnglishProductName { get; set; }
        public string Color { get; set; }
        public short SaftyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public string SizeRange { get; set; }
        public int DaysToManufacture { get; set; }
        public string StartDate { get; set; }
    }

    public class DimReseller
    {
        public DimReseller(string line)
        {
            string[] values = line.Split('|');
            ResellerKey = int.Parse(values[0]);
            ResellerAlternateKey = values[1];
            Phone = values[2];
            BusinessType = values[3];
            ResellerName = values[4];
            NumberEmployees = int.Parse(values[5]);
            OrderFrequency = values[6];
            ProductLine = values[7];
            AddressLine1 = values[8];
            BankName = values[9];
            YearOpened = int.Parse(values[10]);

        }

        public int ResellerKey { get; set; }
        public string ResellerAlternateKey { get; set; }
        public string Phone { get; set; }
        public string BusinessType { get; set; }
        public string ResellerName { get; set; }
        public int NumberEmployees { get; set; }
        public string OrderFrequency { get; set; }
        public string ProductLine { get; set; }
        public string AddressLine1 { get; set; }
        public string BankName { get; set; }
        public int YearOpened { get; set; }
    }

    public class DimCurrency
    {
        public DimCurrency(string line)
        {
            string[] values = line.Split('|');
            CurrencyKey = int.Parse(values[0]);
            CurrencyAlternateKey = values[1];
            CurrencyName = values[2];
        }

        public int CurrencyKey { get; set; }
        public string CurrencyAlternateKey { get; set; }
        public string CurrencyName { get; set; }
    }

    public class DimPromotion
    {
        public DimPromotion(string line)
        {
            string[] values = line.Split('|');
            PromotionKey = int.Parse(values[0]);
            PromotionAlternateKey = int.Parse(values[1]);
            EnglishPromotionName = values[2];
            EnglishPromotionType = values[3];
            EnglishPromotionCategory = values[4];
            StartDate = values[5];
            EndDatePget = values[6];
            MinQty = int.Parse(values[7]);

        }

        public int PromotionKey { get; set; }
        public int PromotionAlternateKey { get; set; }
        public string EnglishPromotionName { get; set; }
        public string EnglishPromotionType { get; set; }
        public string EnglishPromotionCategory { get; set; }
        public string StartDate { get; set; }
        public string EndDatePget { get; set; }
        public int MinQty { get; set; }
    }

    public class DimSalesTerritory
    {
        public DimSalesTerritory(string line)
        {
            string[] values = line.Split('|');
            SalesTerritoryKey = int.Parse(values[0]);
            SalesTerritoryAlternateKey = int.Parse(values[1]);
            SalesTerritoryRegion = values[2];
            SalesTerritoryCountry = values[3];
            SalesTerritoryGroup = values[4];

        }
        public int SalesTerritoryKey { get; set; }
        public int SalesTerritoryAlternateKey { get; set; }
        public string SalesTerritoryRegion { get; set; }
        public string SalesTerritoryCountry { get; set; }
        public string SalesTerritoryGroup { get; set; }
    }

    public class DimEmployee
    {
        public DimEmployee(string line)
        {
            string[] values = line.Split('|');
            EmployeeKey = int.Parse(values[0]);
            FirstName = values[1];
            LastName = values[2];
            Title = values[3];
            BirthDate = values[4];
            LoginID = values[5];
            EmailAddress = values[6];
            Phone = values[7];
            MaritalStatus = values[8];
            Gender = values[9];
            PayFrequency = byte.Parse(values[10]);
            VacationHours = short.Parse(values[11]);
            SickLeaveHours = short.Parse(values[12]);
            DepartmentName = values[13];
            StartDate = values[14];
        }

        public int EmployeeKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string BirthDate { get; set; }
        public string LoginID { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public byte PayFrequency { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public string DepartmentName { get; set; }
        public string StartDate { get; set; }
    }

    public class DimDate
    {
        public DimDate(string line)
        {
            string[] values = line.Split('|');
            DateKey = int.Parse(values[0]);
            FullDateAlternateKey = values[1];
            DayNumberOfWeek = byte.Parse(values[2]);
            EnglishDayNameOfWeek = values[3];
            DayNumberOfMonth = byte.Parse(values[4]);
            DayNumberOfYear = short.Parse(values[5]);
            WeekNumberOfYear = byte.Parse(values[6]);
            EnglishMonthName = values[7];
            MonthNumberOfYear = byte.Parse(values[8]);
            CalendarQuarter = byte.Parse(values[9]);
            CalendarYear = short.Parse(values[10]);
            CalendarSemester = byte.Parse(values[11]);
            FiscalQuarter = byte.Parse(values[12]);
            FiscalYear = short.Parse(values[13]);
            FiscalSemester = byte.Parse(values[14]);
        }

        public int DateKey { get; set; }
        public string FullDateAlternateKey { get; set; }
        public byte DayNumberOfWeek { get; set; }
        public string EnglishDayNameOfWeek { get; set; }
        public byte DayNumberOfMonth { get; set; }
        public short DayNumberOfYear { get; set; }
        public byte WeekNumberOfYear { get; set; }
        public string EnglishMonthName { get; set; }
        public byte MonthNumberOfYear { get; set; }
        public byte CalendarQuarter { get; set; }
        public short CalendarYear { get; set; }
        public byte CalendarSemester { get; set; }
        public byte FiscalQuarter { get; set; }
        public short FiscalYear { get; set; }
        public byte FiscalSemester { get; set; }
    }
}
