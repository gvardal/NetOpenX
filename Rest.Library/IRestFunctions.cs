using NetOpenX.Rest.Client.Model.Enums;
using NetOpenX.Rest.Client.Model.NetOpenX;
using NetOpenX.Rest.Client.Model;

namespace Rest.Library
{
    public interface IRestFunctions
    {
        TResult<ItemSlips> NetsisFaturaBilgileriOku(JTFaturaTip faturaTip, string faturaNo, string cariKod);
        TResult<ItemSlips> NetsisFaturaOlustur(ItemSlips faturaBilgileri);
    }
}
