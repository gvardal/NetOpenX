using Microsoft.Extensions.Configuration;
using NetOpenX.Rest.Client;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model;
using NetOpenX.Rest.Client.Model.Custom;
using NetOpenX.Rest.Client.Model.Enums;
using NetOpenX.Rest.Client.Model.NetOpenX;

namespace Rest.Library
{
    public class RestFunctions : IRestFunctions
    {
        private oAuth2? _oAuth2;
        private readonly IConfiguration _configuration;

        public RestFunctions(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private oAuth2 GetToken()
        {
            _oAuth2 = new oAuth2(_configuration["NetOpenXSettings:RestHost"]); //yayın yapılacak sunucu adresi
            _oAuth2.Login(new JLogin()
            {
                BranchCode = 0,   //sube kodu bilgisi
                NetsisUser = _configuration["NetOpenXSettings:NetsisUser"], //netsis kullanıcı adı bilgisi
                NetsisPassword = _configuration["NetOpenXSettings:NetsisPassword"], //netsis şifre bilgisi
                DbType = JNVTTipi.vtMSSQL, //veritabanı tipi
                DbName = _configuration["NetOpenXSettings:DbName"], //şirket bilgisi
                DbPassword = _configuration["NetOpenXSettings:DbPassword"], //veritabanı şifre bilgisi
                DbUser = "TEMELSET" //veritabanı kullanıcı adı bilgisi
            });
            return _oAuth2;
        }


        public TResult<ItemSlips> NetsisFaturaBilgileriOku(JTFaturaTip faturaTip,string faturaNo,string cariKod)
        {
            oAuth2 _oAuth2 = GetToken();
            ItemSlipsManager _manager = new ItemSlipsManager(_oAuth2);
            return _manager.GetInternalById($"{JTFaturaTip.ftSFat};{faturaNo};{cariKod}");
        }

        public TResult<ItemSlips> NetsisFaturaOlustur(ItemSlips faturaBilgileri)
        {
            oAuth2 _oAuth2 = GetToken();
            ItemSlipsManager _manager = new ItemSlipsManager(_oAuth2);
            return _manager.PostInternal(faturaBilgileri);
        }
    }
}
