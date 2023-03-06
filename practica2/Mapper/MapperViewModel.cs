using Modelos;
using AutoMapper;
using ViewModels;

namespace Mappers 
{
    public class MapperViewModel:Profile {
        public MapperViewModel(){
        CreateMap<Cliente,C_IndexViewModel>().ReverseMap();
        CreateMap<Cliente,C_ListarViewModel>().ReverseMap();
        CreateMap<Cliente,C_ModificarViewModel>().ReverseMap();
        
        CreateMap<Empleado,E_IndexViewModel>().ReverseMap();
        CreateMap<Empleado,E_ListarViewModel>().ReverseMap();
        CreateMap<Empleado,E_ModificarViewModel>().ReverseMap();

        CreateMap<Usuario,U_IndexViewModel>().ReverseMap();
        CreateMap<Usuario,U_ListarViewModel>().ReverseMap();
        CreateMap<Usuario,U_ModificarViewModel>().ReverseMap();

        CreateMap<Producto,P_IndexViewModel>().ReverseMap();
        CreateMap<Producto,P_ListarViewModel>().ReverseMap();
        CreateMap<Producto,P_ModificarViewModel>().ReverseMap();

        CreateMap<Proveedor,Pr_IndexViewModel>().ReverseMap();
        CreateMap<Proveedor,Pr_ListarViewModel>().ReverseMap();
        CreateMap<Proveedor,Pr_ModificarViewModel>().ReverseMap();
        }
    }
}