using System;

namespace Ucuncu
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    #region PascalCasing 
    public class FootballTeam
    {
        public void TrabzonSpor()
        {
            //...
        }
        public void BesiktasKulubu()
        {
            //...
        }
    }
    #endregion PascalCasing 

    #region camelCasing 
    public class PersonelLog
    {
        public void Add(LogEvent logEvent)
        {
            int itemCount = logEvent.Items.Count;
            // ...
        }
    }
    #endregion camelCasing 

    #region SingleRes

    //kötü olan kod burda karman çorban olmuş durumda kullanıcı ve adres bilgilerini ayırıpuser sınıfını daha güzel ve sadeleştirmiş olucaz
    public class User
    {
        private int id { get; set; }
        private String name { get; set; }
        private String street { get; set; }
        private String city { get; set; }
        private String username { get; set; }



        public void changeAddress(String street, String city)
        {
            //logic
        }

        public void login(String username)
        {
            //logic
        }

        public void logout(String username)
        {
            //logic
        }
    }

    //güzel kod
    public class User
    {

        private int id { get; set; }
        private Address name { get; set; }


    }
    public class Address
    {

        private String street { get; set; }
        private String city { get; set; }
        private String country { get; set; }

    }
    //Adressservice adında bir class oluşturduk biz sadece bundan sorumluyuz user beni ilgilendirmiyor!
    public class AddressService
    {
        public void changeAddress(Address address)
        {

        }
    }

    #endregion SingleRes

    #region BooleanDeg

   /* public int dersNotu { get; set; }
    //Kötü kod
    bool gecti; 
        if(dersNotu > 55)
        {        
            gecti = true; 
        }
        else
        {
            gecti = false;
        }
   */
//Güzel Kod
bool gecti = dersNotu > 55;



    #endregion BooleanDeg 

    #region Ternary
    /*
     * Kötü Kod
     if (number % 2 == 0)
     {
	    isEven = true;
     }
     else
    {
	    isEven = false;
    }
     Güzel Kod
    isEven = (number % 2 == 0) ? true : false ;
     
     */


    #endregion Ternary
    #region Strongly type
    /*
     
     Kötü Kod
    if(player == "Zeki Ünyıldız"

    İyi kod
    
    if(player == Player.Name)
    
     */


    #endregion Strongly type
    #region Başı boş
    /*
     * 
     Kötü Kod
    if(value > 250000)

    İyi kod
    
    int maxValue = 250000; 
    if(value > maxValue)
    
     */


    #endregion Başı boş
    #region Karmaşık koşul
    /*
     * 
     Kötü Kod
    if((Maas - gider.Kira+gider.CocukMasrafi) <1500 && MutfakMasrafı > 500)
    {
        
    }


    İyi kod
    
    bool tatileGidermiyim = (Maas - gider.Kira+gider.CocukMasrafi) <1500 && MutfakMasrafı > 500)
    if(tatileGidermiyim)
{
}
    
     */


    #endregion Karmaşık koşul

}
