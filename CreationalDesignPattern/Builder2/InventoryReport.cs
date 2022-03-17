using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
   the builder patterns aims to separate the construction of a complex object from its representation so that the same construction procces can create differen 
representation.
    the builder pattern removes any and all construction or initialization code from an object class, and abstract it out to an interface.Any specific representaions
of that base class are then created as concrete classes implementing that interface, effectiveli constructing themselves form the blueprint provided. The cool part
of this proces is that the concrete classes dont deal with instantiating themselves. thats up to the director class.which controls where and what data the concrete 
classes are actually craeted.
 */
namespace Builder_Pattern
{
    public class FurnitureItem
    {
        public string Name;
        public double Price;
        public double Height;
        public double Width;
        public double Weight;

        public FurnitureItem(string productName, double price, double height, double width, double weight)
        {
            this.Name = productName;
            this.Price = price;
            this.Height = height;
            this.Width = width;
            this.Weight = weight;
        }
    }

    public class InventoryReport
    {
        public string TitleSection;
        public string DimensionsSection;
        public string LogisticsSection;

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimensionsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }
    public interface IFurnitureInventoryBuilder
    {
        IFurnitureInventoryBuilder AddTitle();
        IFurnitureInventoryBuilder AddDimensions();
        IFurnitureInventoryBuilder AddLogistics(DateTime dateTime);
        InventoryReport GetDailyReport();
    }
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport _report;
        private IEnumerable<FurnitureItem> _items;

        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {

            Reset();
            _items = items;
        }

        public void Reset()
        {
            _report = new InventoryReport();
        }

        public IFurnitureInventoryBuilder AddTitle()
        {
            _report.TitleSection = "--------Daily Inventary Report--------\n\n";
            return this;
        }
        public IFurnitureInventoryBuilder AddDimensions()
        {
            _report.DimensionsSection = String.Join(Environment.NewLine, _items.Select(x =>
            $"Product: {x.Name} \nPrice: {x.Price} \nHeigth: {x.Height}"));
            return this;
        }

        public IFurnitureInventoryBuilder AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Report generated on {dateTime}";
            return this;
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finishReport = _report;
            Reset();
            return finishReport;
        }
    }
    public class InventoryBuildDirector
    {
        private IFurnitureInventoryBuilder _builder;
        public InventoryBuildDirector(IFurnitureInventoryBuilder concreateBuilder)
        {
            _builder = concreateBuilder;
        }
        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddDimensions();
            _builder.AddLogistics(DateTime.Now);
        }
    }
}
