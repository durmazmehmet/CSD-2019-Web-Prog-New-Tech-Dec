using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;


/*******************
 * 
 * Dikkat bunu kullanama bilmek içün:
 * Startup.cs dosyanıza aşağıdaki gibi ekleyiniz
 * 
 * using CSD.DbUtil.Provider;
 * .....
 * ....
 * services
 * .AddMvc()
 * .AddMvcOptions(options => options.ModelMetadataDetailsProviders.Add(new DisableConvertEmptyStringToNullProvider()));
 * 
 * ********************************/

namespace CSD.DbUtil.Provider
{
    public class DisableConvertEmptyStringToNullProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.Key.MetadataKind == ModelMetadataKind.Property)
                context.DisplayMetadata.ConvertEmptyStringToNull = false;
        }
    }
}
