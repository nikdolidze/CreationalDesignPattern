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
        void AddTitle();
        void AddDimensions();
        void AddLogistics();
        InventoryReport GetDailyReport();
    }
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport _report;

        public DailyReportBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _report = new InventoryReport();
        }

        public void AddTitle()
        {
            _report.TitleSection = "--------Daily Inventary Report--------\n\n";
        }
        public void AddDimensions()
        {
            throw new System.NotImplementedException();
        }

        public void AddLogistics()
        {
            throw new System.NotImplementedException();
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finishReport = _report;
            Reset();
            return finishReport;
        }
    }
}
