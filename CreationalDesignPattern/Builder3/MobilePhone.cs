using System;
/*
    builder design pattern builds a complex object by using  a tep-by-step approach wather builder interface defins the step to build the final object the builder
is independent of an object creation process a class that is known as director contrls the object creator procces 
participants : 1 product 2 builder 3 concreateBuilder 4 director
 */
namespace Builder3
{
    //product
    public class MobilePhone
    {
        public string Screen { get; set; }
        public int Battery { get; set; }
        public string OperationSystem { get; set; }
        public string Collor { get; set; }
        public string Model { get; set; }

        public MobilePhone()
        {

        }
        public override string ToString()
        {
            return ($"Screen {Screen} Battary : {Battery} Operationsysmte {OperationSystem} model {Model}");
        }
    }
    //builder
    public interface IBilderMobilePhone
    {

        void GetScreen();
        void GetBattery();
        void GetOperationSystem();
        void GetCollor();
        void GetModel();
        MobilePhone GetMobilePhone();
    }
    //concreateBuilder
    public class AndroidMobilePhone : IBilderMobilePhone
    {
        MobilePhone objMobilePhone;
        public AndroidMobilePhone()
        {
            objMobilePhone = new MobilePhone();
        }
        public void GetBattery()
        {
            objMobilePhone.Battery = 3500;
        }

        public void GetCollor()
        {
            objMobilePhone.Collor = "Android Collor";
        }

        public MobilePhone GetMobilePhone()
        {

            return objMobilePhone;
        }

        public void GetModel()
        {
            objMobilePhone.Model = "Android Model";
        }

        public void GetOperationSystem()
        {
            objMobilePhone.OperationSystem = "Android operatio system";
        }

        public void GetScreen()
        {
            objMobilePhone.Screen = "Android Screen";

        }
    }
    //concreateBuilder
    public class WindowsMobilePhone : IBilderMobilePhone
    {
        MobilePhone objMobilePhone;
        public WindowsMobilePhone()
        {
            objMobilePhone = new MobilePhone();
        }
        public void GetBattery()
        {
            objMobilePhone.Battery = 3500;
        }

        public void GetCollor()
        {
            objMobilePhone.Collor = "Windows Collor";
        }

        public MobilePhone GetMobilePhone()
        {

            return objMobilePhone;
        }

        public void GetModel()
        {
            objMobilePhone.Model = "Windows Model";
        }

        public void GetOperationSystem()
        {
            objMobilePhone.OperationSystem = "Windows operatio system";
        }

        public void GetScreen()
        {
            objMobilePhone.Screen = "Windows Screen";

        }
    }

    // Director
    public class DirectorMobilePhone
    {
         readonly IBilderMobilePhone bilderMobilePhone;

        public DirectorMobilePhone(IBilderMobilePhone bilderMobilePhone)
        {
            this.bilderMobilePhone = bilderMobilePhone;

        }

        public void Constructor()
        {
            bilderMobilePhone.GetBattery();
            bilderMobilePhone.GetCollor();
            bilderMobilePhone.GetScreen();
            bilderMobilePhone.GetModel();
            bilderMobilePhone.GetOperationSystem();
        }

    }

    
}
//1 product
//2 builder
//3 concreateBuilder
//4 director