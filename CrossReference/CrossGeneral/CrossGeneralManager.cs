using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossReference.CrossGeneral
{
    public class CrossGeneralManager
    {
          
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Data source=192.11.200.5;User Id='mental';password='kamerun';Initial Catalog='GENERAL';Integrated Security=False");
        }
        public  void AddData(List<CrossGeneralModel> crossGeneralModels)
        {
            crossGeneralModels.ForEach(x =>
            {
                using (var db=GetConnection())
                {
                    var dbData = db.Query<CrossGeneralModel>("select AracTipi,Marka,Oem,UrunKodu from CrossGeneral where replace(AracTipi,' ','')='" + x.AracTipi + "'" +
                        " and replace(Marka,' ','')='" + x.Marka + "'" +
                        " and replace(Oem,' ','')='" + x.Oem + "' " +
                        " and replace(UrunKodu,' ','')='" + x.UrunKodu + "' ");
                    if (dbData.Count() <= 0)
                    {
                        var result = db.Execute("insert into CrossGeneral (AracTipi,Marka,Oem,UrunKodu) values " +
                            "('" + x.AracTipi + "','" + x.Marka + "','" + x.Oem + "','" + x.UrunKodu + "')");
                    }
                }
            });
        }

        public  List<CROSSB2BModel> SearchCrossB2B(string searchkey)
        {

            using (var db = GetConnection())
            {
                var dbData = db.Query<CROSSB2BModel>("select * from CROSSB2B where lower(replace(OeNormal,' ','')) like '" + searchkey.Replace(" ", "").ToLower() + "%' ");

                return dbData.ToList();
            }
        
        }



}
}
