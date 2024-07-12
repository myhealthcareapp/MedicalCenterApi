using Application.Services.Authentication;
using Contracs.Authentication;
using Mapster;

namespace MedicalCenterApi.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.user);

        }
    }
}
